using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 인게임 기본 팝업
/// </summary>
public class InGamePopup : BasePopup
{
    public Text score;          //스코어
    public Text TimeTxt;       //타임 텍스트
    public float startTime;     //타임 저장 변수
    public GameObject ItemTimer; //아이템 지속시간

    private void Update()
    {
        startTime += Time.deltaTime;
        TimeTxt.text = startTime.ToString("0");
        //score.text = GameManager.Instance.score.ToString();
        //아이템 획득시
    }

    /// <summary>
    /// 퍼즈 버튼
    /// </summary>
    public void Pause()
    {
        PopupManager.Instance.CreatePopup(PopupType.PausePopup);
    }
}
