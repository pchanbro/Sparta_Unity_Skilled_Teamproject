using UnityEngine;

public class SpeedUpItem : PoolAble
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        if (other.transform.parent.TryGetComponent<PlayerController>(out var playerController))
        {
            InGameManagers.Item.SetPlayerController(playerController);
            InGameManagers.Item.ActivateSpeedUp();
            ReleaseObject();  // 풀로 반환
        }
    }
}



