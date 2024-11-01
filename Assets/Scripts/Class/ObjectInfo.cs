using UnityEngine;

[System.Serializable]
public class ObjectInfo
{
    // 오브젝트 이름
    public string objectName;
    // 오브젝트 풀에서 관리할 오브젝트
    public GameObject perfab;
    // 몇개를 미리 생성 해놓을건지
    public int count;
}