using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int totalSpeed = 1;

    public float score = 0;
    public float itemSpawnInterval = 5f;
    public bool isGameStart;
    public string[] buildingNames;
    public string[] itemNames;
    public string[] obstacleNames;
    private float[] xPos_Two = { -2.5f, 2.5f};
    private float[] xPos_Three = { -5, 0 ,5f};

    public GameObject inGamePopup;
    public Material[] busColor;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        isGameStart = false;
        inGamePopup.SetActive(true);
    }

    void Start()
    {
        SettingMap();
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnItemsInCenter());
    }

    private void Update()
    {
        score += Time.deltaTime;
    }

    public void SettingMap()
    {
        float zPosition = 0;
        for(int i = 0; i < 5; i++)
        {
            GameObject roads_1 = InGameManagers.ObjectPool.GetGo("Roads");
            roads_1.transform.position = roads_1.transform.position + new Vector3(0, 0, zPosition);
            zPosition += 40;
        }

        zPosition = 0;
        for (int i = 0; i < 10; i++)
        {
            int RN_1, RN_2;
            RN_1 = UnityEngine.Random.Range(0, buildingNames.Length);
            while(true)
            {
                RN_2 = UnityEngine.Random.Range(0, buildingNames.Length);
                if (RN_2 != RN_1) break;
            }

            GameObject building_1 = InGameManagers.ObjectPool.GetGo(buildingNames[RN_1]);
            GameObject building_2 = InGameManagers.ObjectPool.GetGo(buildingNames[RN_2]);

            building_1.transform.position = building_1.transform.position + new Vector3(15, 0, -10 + zPosition);
            building_1.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

            building_2.transform.position = building_2.transform.position + new Vector3(-15, 0, -10 + zPosition);
            building_2.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

            zPosition += 20;
        }

        isGameStart = true;
    }
    private IEnumerator SpawnItemsInCenter()
    {
        while (true)
        {
            int randomIndex = UnityEngine.Random.Range(0, itemNames.Length);
            string randomItemName = itemNames[randomIndex];

            GameObject item = InGameManagers.ObjectPool.GetGo(randomItemName);
            float randomX = Random.Range(-5, 5);
            item.transform.position = new Vector3(randomX, 1,  Random.Range(10, 50));

            yield return new WaitForSeconds(itemSpawnInterval);
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);

            int randomIndex = UnityEngine.Random.Range(0, obstacleNames.Length);
            GameObject obstacle = InGameManagers.ObjectPool.GetGo(obstacleNames[randomIndex]);

            int RnIdx;

            if (obstacle.name == "Bus")
            {
                RnIdx = Random.Range(0, 1);
                obstacle.transform.position = new Vector3(xPos_Two[RnIdx], 0, 160);

                RnIdx = Random.Range(0, 2);
                obstacle.GetComponent<MeshRenderer>().material = busColor[RnIdx];
                obstacle.GetComponent<Obstacle>().addtionalSpeed += 5 * (RnIdx + 1);
            }
            else if(obstacle.name == "Bomb")
            {
                RnIdx = Random.Range(0, 2);
                obstacle.transform.position = new Vector3(xPos_Three[RnIdx], 2, 160);
                obstacle.GetComponent<Obstacle>().isRotate = true;
            }
            else if(obstacle.name == "Rock")
            {
                RnIdx = Random.Range(0, 2);
                obstacle.transform.position = new Vector3(xPos_Three[RnIdx], 0, 160);
            }
            obstacle.SetActive(true);
        }
    }

    public void SpawnBuilding(int Direction)
    {
        int RN_1 = UnityEngine.Random.Range(0, buildingNames.Length);
        GameObject building_1 = InGameManagers.ObjectPool.GetGo(buildingNames[RN_1]);

        if(Direction > 0)
        {
            building_1.transform.position = new Vector3(15, 0, 160);
            building_1.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        else
        {
            building_1.transform.position = new Vector3(-15, 0, 160);
            building_1.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

    }  


}
