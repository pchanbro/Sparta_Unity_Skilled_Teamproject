using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Obstacle : PoolAble
{
    public float speed = 10;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 가져오기
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.isGameStart)
        {
            Move();
        }
    }

    public void Move()
    {
        Vector3 targetPosition = rb.position + Vector3.back * speed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition); // Rigidbody를 사용하여 부드럽게 이동
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
