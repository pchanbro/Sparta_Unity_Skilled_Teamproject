using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// ���ӿ��� �˾�
/// </summary>
public class GameOverPopup : MonoBehaviour
{
    public GameObject gameoverPopup;
    public Text ScoreText;      //���ھ�text
    void Awake()
    {
        Time.timeScale = 0f;
        //ScoreText.text = GameManager.Instance.score.ToString();
    }

    /// <summary>
    /// �ٽ��ϱ� ��ư
    /// </summary>
    public void GameoverRetry()
    {
        Time.timeScale = 1f;
        gameoverPopup.SetActive(false);
        SceneManager.LoadScene("Title");
    }
}
