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
    public Text TimeTxt;       //타임 텍스트
    public float startTime;     //타임 저장 변수
    public GameObject ItemTimer; //아이템 지속 남은 시간동안 깜빡거리고 꺼지기

    private void Update()
    {
        startTime += Time.deltaTime;
        TimeTxt.text = startTime.ToString("0");
        //score.text = GameManager.Instance.score.ToString();
        ItemAnimation();//아이템 획득시 지속시간동안 깜빡이는 애니메이션
    }
    /// <summary>
    /// 아이템 획득시 지속시간동안 깜빡이는 애니메이션
    /// </summary>
    public void ItemAnimation()
    {
        ItemTimer.SetActive(true);
        //지속시간동안 깜빡임
        ItemTimer.SetActive(false);
    }

    /// <summary>
    /// 퍼즈 버튼
    /// </summary>
    public void Pause()
    {
        pause.SetActive(true);
    }
}
