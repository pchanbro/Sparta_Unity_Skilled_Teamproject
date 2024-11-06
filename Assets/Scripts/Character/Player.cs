using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Character character;

    private void Awake()
    {
        InGameManagers.Character.Player = this;
    }

    public void SetCharacter(Character newCharacter)
    {
        if (character != null )
        character.gameObject.SetActive(false);

        character = newCharacter;
        character.gameObject.SetActive(true);
    }
}
