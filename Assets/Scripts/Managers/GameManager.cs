using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isGameStart = false;
    [SerializeField] private float mapSpeed = 0;

    void Start()
    {
        SettingMap();
    }

    public void SettingMap()
    {
        int zPosition = 0;
        for(int i = 0; i < 5; i++)
        {
            GameObject Roads = ObjectPoolManager.instance.GetGo("Roads");
            Roads.transform.position = Roads.transform.position + new Vector3(0, 0, zPosition);
            zPosition += 40;
        }
    }
}
