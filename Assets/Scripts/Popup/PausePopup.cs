using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePopup : InGamePopup
{
    void OnEnable()
    {
        Time.timeScale = 0f;
        score.text = InGameManagers.Game.score.ToString("N2");
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
    }

    /// <summary>
    /// �̾��ϱ� ��ư
    /// </summary>
    public  void Resume()
    {
        Time.timeScale = 1f; 
        pause.SetActive(false);
    }

    /// <summary>
    /// �ٽ��ϱ� ��ư
    /// </summary>
    public void PauseRetry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("KDH_bScene");
    }
}
