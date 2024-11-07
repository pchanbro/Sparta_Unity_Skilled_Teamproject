using UnityEngine;

public class MagnetItem : PoolAble
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("플레이어임.");

            InGameManagers.Item.SetPlayerController(other.GetComponent<PlayerController>());
            InGameManagers.Item.ActivateMagnet();

            Debug.Log("처리함. 반환.");
            ReleaseObject();  // 풀로 반환

        }
/*
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            InGameManagers.Item.SetPlayerController(playerController);
            InGameManagers.Item.ActivateMagnet();
            ReleaseObject();  // 풀로 반환
        }*/
    }
}




