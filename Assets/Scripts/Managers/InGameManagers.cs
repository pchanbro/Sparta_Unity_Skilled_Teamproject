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
    [SerializeField] CharacterManager CharacterManager;

    #region Managers
    public static GameManager Game { get { return instance.gameManager; } }
    public static ItemManager Item { get { return instance.itemManager; } }
    public static ObjectPoolManager ObjectPool { get { return instance.objectPoolManager; } }
    public static CharacterManager Character { get { return instance.characterManager; } }

    private GameManager gameManager;
    private ItemManager itemManager;
    private ObjectPoolManager objectPoolManager;
    private CharacterManager characterManager;
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
        characterManager = CharacterManager;
    }
}