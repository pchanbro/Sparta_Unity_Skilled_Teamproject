using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPopup : MonoBehaviour
{
    //ĳ���� ���� ��������


    /// <summary>
    /// ĳ����1
    /// </summary>
    public void StartCharacter1()
    {
        //Character1 Dispatch
        LoadInGame();
    }

    /// <summary>
    /// ĳ����2
    /// </summary>
    public void StartCharacter2()
    {
        //Character2 Dispatch
        LoadInGame();
    }

    /// <summary>
    /// ĳ����3
    /// </summary>
    public void StartCharacter3()
    {
        //Character3 Dispatch
        LoadInGame();
    }

    /// <summary>
    /// Start ��ư
    /// </summary>
    public void LoadInGame()
    {
        SceneManager.LoadScene("InGame");
    }
}
