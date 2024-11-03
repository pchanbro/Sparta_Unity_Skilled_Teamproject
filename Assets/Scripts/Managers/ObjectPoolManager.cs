using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    // 생성할 오브젝트의 정보를 미리 담는 배열
    [SerializeField]
    private ObjectInfo[] objectInfos;

    // 생성할 오브젝트의 key값지정을 위한 변수
    private string objectName;

    // 오브젝트 풀 초기화시 사용할 인덱스를 나타낼 변수
    private int curIdx = 0;

    // 오브젝트풀들을 관리할 딕셔너리
    private Dictionary<string, IObjectPool<GameObject>> objectPoolDic = new Dictionary<string, IObjectPool<GameObject>>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);

        InitalizePool();
    }


    private void InitalizePool()
    {
        for (int idx = 0; idx < objectInfos.Length; idx++)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreatePooledObject, OnTakeFromPool, OnReturnedToPool,
            OnDestroyPoolObject, true, objectInfos[idx].count, objectInfos[idx].count);

            if (objectPoolDic.ContainsKey(objectInfos[idx].objectName))
            {
                Debug.LogFormat($"{0} : 이미 등록된 오브젝트입니다. 오브젝트풀 초기화를 중단합니다.", objectInfos[idx].objectName);

                return;
            }

            objectPoolDic.Add(objectInfos[idx].objectName, pool);

            // 미리 오브젝트 생성 해놓기
            for (int i = 0; i < objectInfos[idx].count; i++)
            {
                curIdx = idx;
                objectName = objectInfos[idx].objectName;

                PoolAble poolAbleGo = CreatePooledObject().GetComponent<PoolAble>();
                poolAbleGo.Pool.Release(poolAbleGo.gameObject);
            }
        }
    }

    // 생성
    private GameObject CreatePooledObject()
    {
        GameObject poolGo = Instantiate(objectInfos[curIdx].originPrefab);
        
        // 이름 뒤 'Clone' 표시를 없애기 위해 사용한다.
        poolGo.gameObject.name = objectName;

        poolGo.GetComponent<PoolAble>().Pool = objectPoolDic[objectName];
        return poolGo;
    }

    // 대여
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    // 반환
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    // 삭제
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }

    public GameObject GetGo(string goName)
    {
        objectName = goName;

        if (objectPoolDic.ContainsKey(goName) == false)
        {
            Debug.LogFormat("{0} 오브젝트풀에 등록되지 않은 오브젝트입니다.", goName);
            return null;
        }

        return objectPoolDic[goName].Get();
    }
}