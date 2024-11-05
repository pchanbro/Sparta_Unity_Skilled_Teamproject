using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �ΰ��� �⺻ �˾�
/// </summary>
public class InGamePopup : BasePopup
{
    public Text score;          //���ھ�
    public Text TimeTxt;       //Ÿ�� �ؽ�Ʈ
    public float startTime;     //Ÿ�� ���� ����
    public GameObject ItemTimer; //������ ���ӽð�

    private void Update()
    {
        startTime += Time.deltaTime;
        TimeTxt.text = startTime.ToString("0");
        //score.text = GameManager.Instance.score.ToString();
        //������ ȹ���
    }

    /// <summary>
    /// ���� ��ư
    /// </summary>
    public void Pause()
    {
        PopupManager.Instance.CreatePopup(PopupType.PausePopup);
    }
}
