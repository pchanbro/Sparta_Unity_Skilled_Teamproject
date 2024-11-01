using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class PopupManager : MonoBehaviour, ICreate
{
    private readonly Dictionary<PopupType, GameObject> popupContainerDic = new Dictionary<PopupType, GameObject>();     //�˾� Ÿ�� ���� ������ �����ϴ� dic
    private readonly Stack<GameObject> depth = new Stack<GameObject>();                                                 //�˾� ����

    private Transform mainCanvas;   //Scene���� �ִ� mainCanvas���� ����

    public void Init()
    {
        foreach (PopupType type in Enum.GetValues(typeof(PopupType)))
        {
            GameObject go = Resources.Load<GameObject>(string.Format($"Prefabs/Popup/{type.ToString()}"));
            popupContainerDic.Add(type, go);
        }

        //Managers.Scene.OnLoadCompleted(FindMainCanvas);
        //Managers.Scene.OnLoadCompleted(ResetPopup);
    }

    /// <summary>
    /// MainCanvas ã���ִ� �Լ�
    /// </summary>
    public void FindMainCanvas(Scene scene, LoadSceneMode mode)
    {
        GameObject mainCanvasObj = GameObject.Find("MainCanvas");
        if (mainCanvasObj == null)
        {
            Debug.LogError("Is Not MainCanvas.");
            return;
        }

        mainCanvas = mainCanvasObj.transform;
    }

    /// <summary>
    /// �˾� ���� ����� �Լ�
    /// </summary>
    public void ResetPopup(Scene scene, LoadSceneMode mode)
    {
        while (depth.Count != 0)
        {
            Close();
        }
    }
    public void Clear()
    {
        depth.Clear();
    }

    /// <summary>
    /// �˾� ���� �Լ�
    /// </summary>
    public BasePopup CreatePopup(PopupType type, bool useMainCanvas = true, bool curPopupActive = true)
    {
        if (!popupContainerDic.TryGetValue(type, out GameObject popupGo))
        {
            Debug.LogError("Is Not BasePopup : popupContainerDic");
            return null;
        }

        GameObject clone = Instantiate(popupGo, useMainCanvas ? mainCanvas : null);

        if (depth.TryPeek(out GameObject go) && curPopupActive)
        {
            go.SetActive(false);
        }

        depth.Push(clone);

        BasePopup popup = clone.GetComponent<BasePopup>();

        return popup;
    }

    /// <summary>
    /// �˾� �ݴ� �Լ�
    /// </summary>
    public void Close()
    {
        if (depth.Count == 0)
        {
            return;
        }

        Destroy(depth.Pop());

        if (depth.TryPeek(out GameObject go))
        {
            go.SetActive(true);
        }
    }

    /// <summary>
    /// ���� depth�� �ִ� ������Ʈ�� ���� ������Ʈ�� ������ �����ִ� �Լ�
    /// </summary>
    public bool ComparerLastDepth(GameObject go)
    {
        depth.TryPeek(out GameObject temp);

        if (temp == null || temp != go)
        {
            return false;
        }
        return true;
    }
}