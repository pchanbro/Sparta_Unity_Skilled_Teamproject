using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPopup : TitlePopup
{
    /// <summary>
    /// Monkey
    /// </summary>
    public void StartCharacter1()
    {
        InGameManagers.Character.SetPlayerCharacter(0);
        LoadInGame();
    }

    /// <summary>
    /// Mouse
    /// </summary>
    public void StartCharacter2()
    {
        InGameManagers.Character.SetPlayerCharacter(1);
        LoadInGame();
    }

    /// <summary>
    /// Sparrow
    /// </summary>
    public void StartCharacter3()
    {
        InGameManagers.Character.SetPlayerCharacter(2);
        LoadInGame();
    }

    /// <summary>
    /// Start ¹öÆ°
    /// </summary>
    public void LoadInGame()
    {
        selectPopup.SetActive(false);
        SceneManager.LoadScene("InGame");
    }
}
