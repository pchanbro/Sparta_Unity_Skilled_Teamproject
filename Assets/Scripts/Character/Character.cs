using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterInfo info;

    public int SerialNumber
    { get { return info.serialNumber; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            InGameManagers.Character.PlayerController.OnTrigger();
            InGameManagers.Game.isGameStart = false;
            InGameManagers.Game.totalSpeed = 0;
            InGameManagers.Game.GameOverPopup.SetActive(true);
        }
    }
}
