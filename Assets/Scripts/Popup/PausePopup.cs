using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePopup : MonoBehaviour
{
    public GameObject pausePopup;
    public Text nowScoreTxt;       //���� ���ھ� text
    void Awake()
    {
        Time.timeScale = 0f;
        //nowScoreTxt.text = GameManager.Instance.score.ToString();
    }
    /// <summary>
    /// �̾��ϱ� ��ư
    /// </summary>
    public  void Resume()
    {
        Time.timeScale = 1f; 
        pausePopup.SetActive(false);
    }
    /// <summary>
    /// �ٽ��ϱ� ��ư
    /// </summary>
    public void PauseRetry()
    {
        Time.timeScale = 1f;
        pausePopup.SetActive(false);
        SceneManager.LoadScene("Title");
    }
}
