using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �ΰ��� �⺻ �˾�
/// </summary>
public class InGamePopup : MonoBehaviour
{
    public GameObject pause;
    public Text score;          //���ھ�
    public Text TimeTxt;       //Ÿ�� �ؽ�Ʈ
    public float startTime;     //Ÿ�� ���� ����
    public GameObject ItemTimer; //������ ���� ���� �ð����� �����Ÿ��� ������

    private void Update()
    {
        startTime += Time.deltaTime;
        TimeTxt.text = startTime.ToString("0");
        //score.text = GameManager.Instance.score.ToString();
        ItemAnimation();//������ ȹ��� ���ӽð����� �����̴� �ִϸ��̼�
    }
    /// <summary>
    /// ������ ȹ��� ���ӽð����� �����̴� �ִϸ��̼�
    /// </summary>
    public void ItemAnimation()
    {
        ItemTimer.SetActive(true);
        //���ӽð����� ������
        ItemTimer.SetActive(false);
    }

    /// <summary>
    /// ���� ��ư
    /// </summary>
    public void Pause()
    {
        pause.SetActive(true);
    }
}
