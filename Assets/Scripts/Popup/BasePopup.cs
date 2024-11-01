using System;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    private PopupManager popupManager;
    public Action ClossEvent;       // �˾� ������ ȣ��Ǵ� �Լ�

    private void OnEnable()
    {
        Init();
    }

    /// <summary>
    /// ���� �Լ�
    /// </summary>
    protected virtual void Init()
    {

    }

    /// <summary>
    /// �ݱ� �Լ�
    /// </summary>
    
    public virtual void Close()
    {
        if (!popupManager.ComparerLastDepth(gameObject))
            return;


        ClossEvent?.Invoke();
        popupManager.Close();
    }
    
}
