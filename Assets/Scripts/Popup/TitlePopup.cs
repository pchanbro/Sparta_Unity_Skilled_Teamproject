using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePopup : MonoBehaviour
{
    public GameObject selectPopup;
    public GameObject titlePopup;
    /// <summary>
    /// ĳ���� ����â
    /// </summary>
    public void SelectCharacter()
    {
        titlePopup.SetActive(false);
        selectPopup.SetActive(true);
    }
}
