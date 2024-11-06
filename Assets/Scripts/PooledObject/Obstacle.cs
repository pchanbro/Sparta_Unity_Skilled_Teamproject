using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Obstacle : PoolAble
{
    public int addtionalSpeed = 0;
    public float rotationSpeed = 50f; // 회전 속도
    public bool isRotate = false;
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
        if(InGameManagers.Game.totalSpeed != 0)
        {
            Vector3 targetPosition = rb.position + Vector3.back * (InGameManagers.Game.totalSpeed + addtionalSpeed) * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition); // Rigidbody를 사용하여 부드럽게 이동
        }
        else
        {
            Vector3 targetPosition = rb.position + Vector3.back * InGameManagers.Game.totalSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition); // Rigidbody를 사용하여 부드럽게 이동
        }

        if(isRotate)
        {
            Quaternion deltaRotation = Quaternion.Euler(0, rotationSpeed * Time.fixedDeltaTime, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ResetWall"))
        {
            ReleaseObject();
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            ReleaseObject();
        }
    }
}
