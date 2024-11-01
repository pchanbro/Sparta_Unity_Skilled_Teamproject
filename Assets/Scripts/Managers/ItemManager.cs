using System.Collections;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    public float speedMultiplier = 2.0f; //�÷��̾� �ӵ� ���� ����
    public float jumpMultiplier = 1.5f; // �÷��̾� ���� �� ���� ����
    public float magnetRange = 5.0f; // �������� �÷��̾�� �� �� �ִ� �ִ�Ÿ�
    public float magnetPullSpeed = 5.0f; //�������� �÷��̾�� �������� �ӵ�
    public float effectDuration = 5.0f; // ��� ������ ȿ���� ���ӵǴ� �ð�

    private Transform playerTransform;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerTransform(Transform player)
    {
        playerTransform = player;
    }

    public void ActivateSpeedUp()
    {
        if (playerTransform != null)
        {
            StartCoroutine(SpeedUpCoroutine());
        }
    }

    public void ActivateSuperJump()
    {
        if (playerTransform != null)
        {
            StartCoroutine(SuperJumpCoroutine());
        }
    }

    public void ActivateMagnet()
    {
        if (playerTransform != null)
        {
            StartCoroutine(MagnetCoroutine());
        }
    }

    private IEnumerator SpeedUpCoroutine()
    {
        Rigidbody rb = playerTransform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float originalSpeed = rb.velocity.magnitude;
            rb.velocity *= speedMultiplier;
            yield return new WaitForSeconds(effectDuration);
            rb.velocity = rb.velocity.normalized * originalSpeed;
        }
    }

    private IEnumerator SuperJumpCoroutine()
    {
        Rigidbody rb = playerTransform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpMultiplier, ForceMode.Impulse);
            yield return new WaitForSeconds(effectDuration);
            // �� �� ���� ���� �� ���󺹱�
        }
    }

    private IEnumerator MagnetCoroutine()
    {
        float elapsedTime = 0;

        while (elapsedTime < effectDuration)
        {
            PullItemsWithinRange();
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void PullItemsWithinRange()
    {
        Collider[] itemsInRange = Physics.OverlapSphere(playerTransform.position, magnetRange);

        foreach (Collider item in itemsInRange)
        {
            if (item.CompareTag("Collectible")) // ������ �±� Ȯ��
            {
                Vector3 directionToPlayer = (playerTransform.position - item.transform.position).normalized;
                item.transform.position = Vector3.MoveTowards(item.transform.position, playerTransform.position, magnetPullSpeed * Time.deltaTime);
            }
        }
    }
}



