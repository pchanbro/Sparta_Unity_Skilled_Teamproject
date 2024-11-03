using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    // ������ ������Ʈ�� ������ �̸� ��� �迭
    [SerializeField]
    private ObjectInfo[] objectInfos;

    // ������ ������Ʈ�� key�������� ���� ����
    private string objectName;

    // ������Ʈ Ǯ �ʱ�ȭ�� ����� �ε����� ��Ÿ�� ����
    private int curIdx = 0;

    // ������ƮǮ���� ������ ��ųʸ�
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
                Debug.LogFormat($"{0} : �̹� ��ϵ� ������Ʈ�Դϴ�. ������ƮǮ �ʱ�ȭ�� �ߴ��մϴ�.", objectInfos[idx].objectName);

                return;
            }

            objectPoolDic.Add(objectInfos[idx].objectName, pool);

            // �̸� ������Ʈ ���� �س���
            for (int i = 0; i < objectInfos[idx].count; i++)
            {
                curIdx = idx;
                objectName = objectInfos[idx].objectName;

                PoolAble poolAbleGo = CreatePooledObject().GetComponent<PoolAble>();
                poolAbleGo.Pool.Release(poolAbleGo.gameObject);
            }
        }
    }

    // ����
    private GameObject CreatePooledObject()
    {
        GameObject poolGo = Instantiate(objectInfos[curIdx].originPrefab);
        
        // �̸� �� 'Clone' ǥ�ø� ���ֱ� ���� ����Ѵ�.
        poolGo.gameObject.name = objectName;

        poolGo.GetComponent<PoolAble>().Pool = objectPoolDic[objectName];
        return poolGo;
    }

    // �뿩
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    // ��ȯ
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    // ����
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }

    public GameObject GetGo(string goName)
    {
        objectName = goName;

        if (objectPoolDic.ContainsKey(goName) == false)
        {
            Debug.LogFormat("{0} ������ƮǮ�� ��ϵ��� ���� ������Ʈ�Դϴ�.", goName);
            return null;
        }

        return objectPoolDic[goName].Get();
    }
}