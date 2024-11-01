using System.Collections;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    public float speedMultiplier = 2.0f; //플레이어 속도 몇배로 증가
    public float jumpMultiplier = 1.5f; // 플레이어 점프 힘 몇배로 증가
    public float magnetRange = 5.0f; // 아이템이 플레이어에게 올 수 있는 최대거리
    public float magnetPullSpeed = 5.0f; //아이템이 플레이어에게 끌려오는 속도
    public float effectDuration = 5.0f; // 모든 아이템 효과가 지속되는 시간

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
            // 한 번 점프 적용 후 원상복구
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
            if (item.CompareTag("Collectible")) // 아이템 태그 확인
            {
                Vector3 directionToPlayer = (playerTransform.position - item.transform.position).normalized;
                item.transform.position = Vector3.MoveTowards(item.transform.position, playerTransform.position, magnetPullSpeed * Time.deltaTime);
            }
        }
    }
}



