using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : PoolAble
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 가져오기
    }

    private void FixedUpdate()
    {
        if (InGameManagers.Game.isGameStart)
        {
            MoveRoad();
        }
    }

    public void MoveRoad()
    {
        Vector3 targetPosition = rb.position + Vector3.back * InGameManagers.Game.totalSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition); // Rigidbody를 사용하여 부드럽게 이동
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ResetWall"))
        {
            if(transform.position.x >= 30) transform.position = new Vector3(30, 0, 160); // 위치 초기화
            else transform.position = new Vector3(0, 0, 160); // 위치 초기화
        }
    }
}
