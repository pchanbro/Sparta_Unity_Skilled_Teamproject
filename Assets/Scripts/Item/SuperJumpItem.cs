using UnityEngine;

public class SuperJumpItem : PoolAble
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            InGameManagers.Item.SetPlayerController(playerController);
            InGameManagers.Item.ActivateSuperJump();
            ReleaseObject();  // 풀로 반환
        }
    }
}





