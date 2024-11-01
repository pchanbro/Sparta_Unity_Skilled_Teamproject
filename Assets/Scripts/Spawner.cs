using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    //private readonly Dictionary<EnemyType, List<Vector3>> startEnemyDic = new Dictionary<EnemyType, List<Vector3>>();

    private void Awake()
    {           
        
    }

/*    /// <summary>
    /// 적 생성 SO 풀어서 Dictionary에 저장해주는 함수
    /// </summary>
    private void SetStartEnemyDic()
    {
        foreach (var patternSO in startEnemyList)
        {
            List<EnemySpawnData> tempList = patternSO.pattern.spawnPointList;
            List<Vector3> posList = new List<Vector3>();

            for (int i = 0; i < tempList.Count; i++)
            {
                posList.Add(tempList[i].Pos);
            }

            startEnemyDic.Add(tempList[0].EnemyType, posList);
        }
    }*/

    /// <summary>
    /// 
    /// </summary>
    public void SpawnStageEnemy()
    {

    }
}