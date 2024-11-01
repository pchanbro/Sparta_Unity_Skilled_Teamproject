using UnityEngine;

public class SuperJumpItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ItemManager.Instance.SetPlayerTransform(other.transform);
            ItemManager.Instance.ActivateSuperJump();
            Destroy(gameObject);
        }
    }
}


