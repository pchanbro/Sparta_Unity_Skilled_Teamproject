using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPopup : MonoBehaviour
{
    //캐릭터 정보 가져오기


    /// <summary>
    /// 캐릭터1
    /// </summary>
    public void StartCharacter1()
    {
        //Character1 Dispatch
        LoadInGame();
    }

    /// <summary>
    /// 캐릭터2
    /// </summary>
    public void StartCharacter2()
    {
        //Character2 Dispatch
        LoadInGame();
    }

    /// <summary>
    /// 캐릭터3
    /// </summary>
    public void StartCharacter3()
    {
        //Character3 Dispatch
        LoadInGame();
    }

    /// <summary>
    /// Start 버튼
    /// </summary>
    public void LoadInGame()
    {
        SceneManager.LoadScene("InGame");
    }
}
