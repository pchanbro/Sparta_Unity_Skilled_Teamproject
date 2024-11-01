using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ItemManager.Instance.SetPlayerTransform(other.transform);
            ItemManager.Instance.ActivateMagnet();
            Destroy(gameObject);
        }
    }
}


