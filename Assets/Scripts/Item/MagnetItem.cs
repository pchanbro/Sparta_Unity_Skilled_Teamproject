using UnityEngine;

public class MagnetItem : PoolAble
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            ItemManager.Instance.SetPlayerController(playerController);
            ItemManager.Instance.ActivateMagnet();
            ReleaseObject();  // 풀로 반환
        }
    }
}




