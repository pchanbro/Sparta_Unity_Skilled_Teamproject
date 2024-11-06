using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePopup : MonoBehaviour
{
    public GameObject pausePopup;
    public Text nowScoreTxt;       //현재 스코어 text
    void Awake()
    {
        Time.timeScale = 0f;
        //nowScoreTxt.text = GameManager.Instance.score.ToString();
    }
    /// <summary>
    /// 이어하기 버튼
    /// </summary>
    public  void Resume()
    {
        Time.timeScale = 1f; 
        pausePopup.SetActive(false);
    }
    /// <summary>
    /// 다시하기 버튼
    /// </summary>
    public void PauseRetry()
    {
        Time.timeScale = 1f;
        pausePopup.SetActive(false);
        SceneManager.LoadScene("Title");
    }
}
