using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePopup : BasePopup
{
    /// <summary>
    /// Start ¹öÆ°
    /// </summary>
    public void LoadInGame()
    {
        PopupManager.Instance.Clear();
        SceneManager.LoadScene("InGame");
    }
}
