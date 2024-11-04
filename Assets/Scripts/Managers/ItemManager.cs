using System;
using System.Collections;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    [Header("Item Effect Settings")]
   public float speedMultiplier = 2.0f;
    public float jumpMultiplier = 1.5f;
    public float magnetRange = 5.0f;
    public float magnetPullSpeed = 5.0f;
    public float effectDuration = 5.0f;
    public float itemSpeed = 10f; // 아이템 이 일정한 속도 유지

    private PlayerController playerController;
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

    public void SetPlayerController(PlayerController player)
    {
        playerController = player;
    }

    public void ActivateSpeedUp()
    {
        if (playerController != null)
        {
            StartCoroutine(SpeedUpCoroutine());
        }
    }

    public void ActivateSuperJump()
    {
        if (playerController != null)
        {
            StartCoroutine(SuperJumpCoroutine());
        }
    }

    public void ActivateMagnet()
    {
        if (playerController != null)
        {
            StartCoroutine(MagnetCoroutine());
        }
    }

    private IEnumerator SpeedUpCoroutine()
    {
        float originalSpeed = playerController.moveSpeed;
        playerController.moveSpeed *= speedMultiplier;

        yield return new WaitForSeconds(effectDuration);

        playerController.moveSpeed = originalSpeed;
    }

    private IEnumerator SuperJumpCoroutine()
    {
        float originalJumpSpeed = playerController.jumpSpeed;
        playerController.jumpSpeed *= jumpMultiplier;

        yield return new WaitForSeconds(effectDuration);

        playerController.jumpSpeed = originalJumpSpeed;
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
        Collider[] itemsInRange = Physics.OverlapSphere(playerController.transform.position, magnetRange);

        foreach (Collider item in itemsInRange)
        {
            if (item.CompareTag("Collectible")) // 아이템 태그 확인
            {
                Vector3 directionToPlayer = (playerController.transform.position - item.transform.position).normalized;
                item.transform.position = Vector3.MoveTowards(item.transform.position, playerController.transform.position, magnetPullSpeed * Time.deltaTime);
            }
        }
    }
    private void Update()
    {
        MoveItems();
    }

    private void MoveItems()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Collectible");
        foreach (GameObject item in items)
        {
            item.transform.position += Vector3.back * itemSpeed * Time.deltaTime;
        }
    }
    public void SpawnItem(GameObject item, Vector3 spawnPosition)
    {
        item.transform.position = spawnPosition;
        item.SetActive(true);
    }
}





