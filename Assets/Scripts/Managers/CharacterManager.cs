using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private Player player;
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }
}
