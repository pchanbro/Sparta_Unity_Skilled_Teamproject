using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePopup : InGamePopup
{
    void Awake()
    {
        Time.timeScale = 0f;
        score.text = GameManager.Instance.score.ToString("N2");
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
