using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

/// <summary>
/// 게임오버 팝업
/// </summary>
public class GameOverPopup : MonoBehaviour
{
    public GameObject gameoverPopup;
    public Text ScoreText;
    
    void OnEnable()
    {
        Time.timeScale = 0f;
        ScoreText.text = InGameManagers.Game.score.ToString("N2");
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
    }

    /// <summary>
    /// 다시하기 버튼
    /// </summary>
    public void GameoverRetry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("KDH_bScene");
    }

    /// <summary>
    /// 종료 버튼
    /// </summary>
    public void ExitGame()
    {
        // 에디터에서 실행 중일 경우
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // 빌드된 애플리케이션에서 실행 중일 경우
#else
            Application.Quit();
#endif
    }

}
