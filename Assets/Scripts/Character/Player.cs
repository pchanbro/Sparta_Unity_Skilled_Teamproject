using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    private Character character;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        CharacterManager.Instance.Player = this;
    }

    public void SetCharacter(Character newCharacter)
    {
        if (character != null )
        character.gameObject.SetActive(false);

        character = newCharacter;
        character.gameObject.SetActive(true);
        controller.SetCharacter();
    }
}
