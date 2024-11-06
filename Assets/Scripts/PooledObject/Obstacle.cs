using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Obstacle : PoolAble
{
    public float speed = 10;
    public float rotationSpeed = 50f; // ȸ�� �ӵ�
    public bool isRotate = false;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ ��������
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
        rb.MovePosition(targetPosition); // Rigidbody�� ����Ͽ� �ε巴�� �̵�

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
