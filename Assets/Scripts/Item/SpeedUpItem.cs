using UnityEngine;

public class SpeedUpItem : PoolAble
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            InGameManagers.Item.SetPlayerController(playerController);
            InGameManagers.Item.ActivateSpeedUp();
            ReleaseObject();  // 풀로 반환
        }
    }
}



