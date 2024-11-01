using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ItemManager.Instance.SetPlayerTransform(other.transform);
            ItemManager.Instance.ActivateSpeedUp();
            Destroy(gameObject);
        }
    }
}


