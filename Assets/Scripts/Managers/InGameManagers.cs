using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManagers : MonoBehaviour
{
    private static InGameManagers instance;

    [SerializeField] GameManager GameManager;
    [SerializeField] ItemManager ItemManager;
    [SerializeField] ObjectPoolManager ObjectPoolManager;

    #region Managers
    public static GameManager Game { get { return instance.gameManager; } }
    public static ItemManager Item { get { return instance.itemManager; } }
    public static ObjectPoolManager ObjectPool { get { return instance.objectPoolManager; } }

    private GameManager gameManager;
    private ItemManager itemManager;
    private ObjectPoolManager objectPoolManager;
    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        gameManager = GameManager;
        itemManager = ItemManager;
        objectPoolManager = ObjectPoolManager;
    }
}