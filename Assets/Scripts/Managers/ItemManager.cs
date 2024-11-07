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
    public float itemSpeed = 10f;

    private PlayerController playerController;
    private bool isSuperJumpActive = false; // 슈퍼 점프 활성화 여부 확인 변수

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
        if (playerController != null && !isSuperJumpActive) // 중복 적용 방지
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
        isSuperJumpActive = true; // 슈퍼 점프 활성화 상태로 변경
        float originalJumpSpeed = playerController.jumpForce;
        playerController.jumpForce *= jumpMultiplier;

        yield return new WaitForSeconds(effectDuration);

        playerController.jumpForce = originalJumpSpeed;
        isSuperJumpActive = false; // 효과가 끝난 후 비활성화 상태로 변경
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
            if (item.CompareTag("Collectible"))
            {
                Vector3 directionToPlayer = (playerController.transform.position - item.transform.position).normalized;
                item.transform.position = Vector3.MoveTowards(item.transform.position, playerController.transform.position, magnetPullSpeed * Time.deltaTime);
            }
        }
    }

    private void Update()
    {
        if(InGameManagers.Game.isGameStart)
        {
            MoveItems();
        }
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






