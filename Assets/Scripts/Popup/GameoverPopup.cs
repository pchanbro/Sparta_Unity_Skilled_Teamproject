using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

/// <summary>
/// ���ӿ��� �˾�
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
    /// �ٽ��ϱ� ��ư
    /// </summary>
    public void GameoverRetry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("KDH_bScene");
    }

    /// <summary>
    /// ���� ��ư
    /// </summary>
    public void ExitGame()
    {
        // �����Ϳ��� ���� ���� ���
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // ����� ���ø����̼ǿ��� ���� ���� ���
#else
            Application.Quit();
#endif
    }

}
