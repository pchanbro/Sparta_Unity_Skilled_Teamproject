using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePopup : BasePopup
{
    public Text nowScoreText;       //현재 스코어 text
    protected override void Init()
    {
        base.Init();
        Time.timeScale = 0f;
        //nowScoreText.text
    }
    /// <summary>
    /// 이어하기 버튼
    /// </summary>
    public override void Close()
    {
        Time.timeScale = 1f;
        base.Close();
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
