using System;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
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
        if (!PopupManager.Instance.ComparerLastDepth(gameObject))
            return;


        ClossEvent?.Invoke();
        PopupManager.Instance.Close();
    }
    
}
