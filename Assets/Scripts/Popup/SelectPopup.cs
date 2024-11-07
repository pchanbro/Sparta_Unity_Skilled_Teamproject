using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPopup : TitlePopup
{
    public GameObject InGamePopup;
    /// <summary>
    /// SelectCharacter
    /// </summary>
    public void SelectCharacter(int num)
    {
        InGameManagers.Character.SetPlayerCharacter(num);
        InGameStart();
    }

    /// <summary>
    /// 게임 시작 버튼
    /// </summary>
    public void InGameStart()
    {
        InGamePopup.SetActive(true);
        gameObject.SetActive(false);
        InGameManagers.Game.isGameStart = true;
        InGameManagers.Game.totalSpeed = 15;
    }
}
