using System;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    private PopupManager popupManager;
    public Action ClossEvent;       // ÆË¾÷ ´ÝÈú¶§ È£ÃâµÇ´Â ÇÔ¼ö

    private void OnEnable()
    {
        Init();
    }

    /// <summary>
    /// »ý¼º ÇÔ¼ö
    /// </summary>
    protected virtual void Init()
    {

    }

    /// <summary>
    /// ´Ý±â ÇÔ¼ö
    /// </summary>
    
    public virtual void Close()
    {
        if (!popupManager.ComparerLastDepth(gameObject))
            return;


        ClossEvent?.Invoke();
        popupManager.Close();
    }
    
}
