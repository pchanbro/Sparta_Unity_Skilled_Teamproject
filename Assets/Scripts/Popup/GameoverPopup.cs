using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// ���ӿ��� �˾�
/// </summary>
public class GameOverPopup : BasePopup
{
    public Text ScoreText;      //���ھ�text
    protected override void Init()
    {
        base.Init();
        Time.timeScale = 0f;
        //ScoreText.text
    }

    /// <summary>
    /// �ٽ��ϱ� ��ư
    /// </summary>
    public void LoadTitle()
    {
        Time.timeScale = 1f;
        PopupManager.Instance.Clear();
        SceneManager.LoadScene("Title");
    }
}
