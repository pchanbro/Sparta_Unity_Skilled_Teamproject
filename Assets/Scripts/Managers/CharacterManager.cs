using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private Dictionary<int, Character> characterDictionary = new Dictionary<int, Character>();

    private static CharacterManager instance;
    public static CharacterManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameObject("CharacterManager").AddComponent<CharacterManager>();
            }
            return instance;
        }
    }

    private Player player;
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance == this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        LoadCharacter();
    }

    public void SetPlayerCharacter(int characterNum)
    {
        Character character = characterDictionary[characterNum];
        player.SetCharacter(character);
    }

    private void LoadCharacter()
    {
        foreach (Transform child in player.transform)
        {
            Character character = child.GetComponent<Character>();
            if(character != null)
            {
                characterDictionary[character.SerialNumber] = character;
                character.gameObject.SetActive(false);
            }
        }
    }
}
