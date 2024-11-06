using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 게임오버 팝업
/// </summary>
public class GameOverPopup : MonoBehaviour
{
    public GameObject gameoverPopup;
    public Text ScoreText;      //스코어text
    void Awake()
    {
        Time.timeScale = 0f;
        //ScoreText.text = GameManager.Instance.score.ToString();
    }

    /// <summary>
    /// 다시하기 버튼
    /// </summary>
    public void GameoverRetry()
    {
        Time.timeScale = 1f;
        gameoverPopup.SetActive(false);
        SceneManager.LoadScene("Title");
    }
}
