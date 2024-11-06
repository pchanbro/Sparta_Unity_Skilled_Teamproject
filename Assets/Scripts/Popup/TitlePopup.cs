using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePopup : MonoBehaviour
{
    public GameObject titlePopup;
    /// <summary>
    /// Start 버튼
    /// </summary>
    public void LoadInGame()
    {
        SceneManager.LoadScene("InGame");
    }
    public GameObject selectPopup;
    /// <summary>
    /// 캐릭터 선택창
    /// </summary>
    public void SelectCharacter()
    {
        titlePopup.SetActive(false);
        selectPopup.SetActive(true);
    }
}
