using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerSpeed = 1;
    public bool isGameStart = false;
    public string[] buildingNames;
    public string[] itemNames;
    public string[] obstacleNames;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    void Start()
    {
        SettingMap();
        StartCoroutine(SpawnObstacle());
    }

    public void SettingMap()
    {
        float zPosition = 0;
        for(int i = 0; i < 5; i++)
        {
            GameObject roads_1 = ObjectPoolManager.instance.GetGo("Roads");
            GameObject roads_2 = ObjectPoolManager.instance.GetGo("Roads");
            roads_1.transform.position = roads_1.transform.position + new Vector3(0, 0, zPosition);
            roads_2.transform.position = roads_2.transform.position + new Vector3(30, 0, zPosition);
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

            GameObject building_1 = ObjectPoolManager.instance.GetGo(buildingNames[RN_1]);
            GameObject building_2 = ObjectPoolManager.instance.GetGo(buildingNames[RN_2]);

            building_1.transform.position = building_1.transform.position + new Vector3(15, 0, -10 + zPosition);
            building_1.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

            building_2.transform.position = building_2.transform.position + new Vector3(-15, 0, -10 + zPosition);
            building_2.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

            zPosition += 20;
        }
        for (int t = 0; t < itemNames.Length; t++)
        {
            GameObject item = ObjectPoolManager.instance.GetGo(itemNames[t]);
            // 아이템 위치 설정 (건물과 상관없이)
            item.transform.position = new Vector3(Random.Range(-5, 5), 1, Random.Range(10, 50));
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);

            int randomIndex = UnityEngine.Random.Range(0, obstacleNames.Length);
            GameObject obstacle = ObjectPoolManager.instance.GetGo(obstacleNames[randomIndex]);

            float xPosition = Random.Range(-4f, 4f);
            obstacle.transform.position = new Vector3(xPosition, 2, 160);
            obstacle.SetActive(true);
        }
    }

    public void SpawnBuilding(int Direction)
    {
        int RN_1 = UnityEngine.Random.Range(0, buildingNames.Length);
        GameObject building_1 = ObjectPoolManager.instance.GetGo(buildingNames[RN_1]);

        // 오른쪽 건물 건설
        if(Direction > 0)
        {
            building_1.transform.position = new Vector3(15, 0, 160);
            building_1.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        // 왼쪽 건물 건설
        else
        {
            building_1.transform.position = new Vector3(-15, 0, 160);
            building_1.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

    }  


}
