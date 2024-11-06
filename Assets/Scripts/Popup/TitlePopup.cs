using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePopup : MonoBehaviour
{
    public GameObject titlePopup;
    /// <summary>
    /// Start ��ư
    /// </summary>
    public void LoadInGame()
    {
        SceneManager.LoadScene("InGame");
    }
    public GameObject selectPopup;
    /// <summary>
    /// ĳ���� ����â
    /// </summary>
    public void SelectCharacter()
    {
        titlePopup.SetActive(false);
        selectPopup.SetActive(true);
    }
}
