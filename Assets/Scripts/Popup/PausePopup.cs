using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePopup : BasePopup
{
    public Text nowScoreText;       //���� ���ھ� text
    protected override void Init()
    {
        base.Init();
        Time.timeScale = 0f;
        //nowScoreText.text
    }
    /// <summary>
    /// �̾��ϱ� ��ư
    /// </summary>
    public override void Close()
    {
        Time.timeScale = 1f;
        base.Close();
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
