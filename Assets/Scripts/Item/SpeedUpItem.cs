using UnityEngine;

public class SpeedUpItem : PoolAble
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            ItemManager.Instance.SetPlayerController(playerController);
            ItemManager.Instance.ActivateSpeedUp();
            ReleaseObject();  // 풀로 반환
        }
    }
}



