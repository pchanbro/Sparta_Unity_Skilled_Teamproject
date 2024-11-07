using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePopup : InGamePopup
{
    void OnEnable()
    {
        Time.timeScale = 0f; // 게임 일시정지
        score.text = InGameManagers.Game.score.ToString("N2");
    }

    void OnDisable()
    {
        Time.timeScale = 1f; // 게임 재개
    }

    /// <summary>
    /// 이어하기 버튼
    /// </summary>
    public  void Resume()
    {
        Time.timeScale = 1f; 
        pause.SetActive(false);
    }

    /// <summary>
    /// 다시하기 버튼
    /// </summary>
    public void PauseRetry()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
        SceneManager.LoadScene("Title");
    }
}
