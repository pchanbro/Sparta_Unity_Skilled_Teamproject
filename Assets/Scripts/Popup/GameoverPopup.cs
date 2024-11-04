using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 게임오버 팝업
/// </summary>
public class GameOverPopup : BasePopup
{
    public Text ScoreText;      //스코어text
    protected override void Init()
    {
        base.Init();
        Time.timeScale = 0f;
        //ScoreText.text
    }

    /// <summary>
    /// 다시하기 버튼
    /// </summary>
    public void LoadTitle()
    {
        Time.timeScale = 1f;
        PopupManager.Instance.Clear();
        SceneManager.LoadScene("Title");
    }
}
