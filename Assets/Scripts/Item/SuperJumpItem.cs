using UnityEngine;

public class SuperJumpItem : PoolAble
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            ItemManager.Instance.SetPlayerController(playerController);
            ItemManager.Instance.ActivateSuperJump();
            ReleaseObject();  // 풀로 반환
        }
    }
}





