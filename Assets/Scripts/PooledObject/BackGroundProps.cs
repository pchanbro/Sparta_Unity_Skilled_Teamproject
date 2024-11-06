using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundProps : MonoBehaviour
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
            Move();
        }
    }

    public void Move()
    {
        Vector3 targetPosition = rb.position + Vector3.back * InGameManagers.Game.totalSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition); // Rigidbody를 사용하여 부드럽게 이동
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ResetWall"))
        {
            int Rn_x = Random.Range(-25, -30);
            transform.position = new Vector3(Rn_x, 0, 160); // 위치 초기화
        }
    }
}
