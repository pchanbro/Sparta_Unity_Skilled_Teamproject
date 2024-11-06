using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : PoolAble
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
            // 건물의 오른쪽 라인인 경우
            if (transform.position.x == 15)
            {
                transform.position = new Vector3(15, 0, 160); // 위치 초기화
            }
            // 건물의 왼쪽 라인인 경우
            else
            {
                transform.position = new Vector3(-15, 0, 160); // 위치 초기화
            }
        }
    }
}
