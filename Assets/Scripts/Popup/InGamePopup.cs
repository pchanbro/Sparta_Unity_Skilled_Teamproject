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

    private void Update()
    {
        score.text = InGameManagers.Game.score.ToString("N2");
    }
    /// <summary>
    /// ���� ��ư
    /// </summary>
    public void Pause()
    {
        pause.SetActive(true);
    }
}
