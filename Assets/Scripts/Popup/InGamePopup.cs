using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 인게임 기본 팝업
/// </summary>
public class InGamePopup : MonoBehaviour
{
    public GameObject pause;
    public Text score;          //스코어

    private void Update()
    {
        score.text = InGameManagers.Game.score.ToString("N2");
    }
    /// <summary>
    /// 퍼즈 버튼
    /// </summary>
    public void Pause()
    {
        pause.SetActive(true);
    }
}
