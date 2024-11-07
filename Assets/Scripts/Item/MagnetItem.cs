using UnityEngine;

public class MagnetItem : PoolAble
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        if (other.transform.parent.TryGetComponent<PlayerController>(out var playerController))
        {
            InGameManagers.Item.SetPlayerController(playerController);
            InGameManagers.Item.ActivateMagnet();
            ReleaseObject();  // 풀로 반환
        }
    }
}




