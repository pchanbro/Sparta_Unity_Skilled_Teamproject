using UnityEngine;

public class MagnetItem : PoolAble
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("�÷��̾���.");

            InGameManagers.Item.SetPlayerController(other.GetComponent<PlayerController>());
            InGameManagers.Item.ActivateMagnet();

            Debug.Log("ó����. ��ȯ.");
            ReleaseObject();  // Ǯ�� ��ȯ

        }
/*
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            InGameManagers.Item.SetPlayerController(playerController);
            InGameManagers.Item.ActivateMagnet();
            ReleaseObject();  // Ǯ�� ��ȯ
        }*/
    }
}




