using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private Dictionary<int, Character> characterDictionary = new Dictionary<int, Character>();

    private Player player;
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }

    private PlayerController playerController;
    public PlayerController PlayerController
    {
        get { return playerController; }
        set { playerController = value; }
    }

    private PlayerAnimationController playerAnimationController;
    public PlayerAnimationController PlayerAnimationController
    {
        get { return playerAnimationController; }
        set { playerAnimationController = value; }
    }

    private void Start()
    {
        LoadCharacter();
    }

    public void SetPlayerCharacter(int characterNum)
    {
        Character character = characterDictionary[characterNum];
        player.SetCharacter(character);
        playerController.SetCharacter();
        playerAnimationController.SetCharacter();
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
