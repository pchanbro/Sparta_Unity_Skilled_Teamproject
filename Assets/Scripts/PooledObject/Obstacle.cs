using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Obstacle : PoolAble
{
    public int addtionalSpeed = 0;
    public float rotationSpeed = 50f; // ȸ�� �ӵ�
    public bool isRotate = false;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ ��������
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
            rb.MovePosition(targetPosition); // Rigidbody�� ����Ͽ� �ε巴�� �̵�
        }
        else
        {
            Vector3 targetPosition = rb.position + Vector3.back * InGameManagers.Game.totalSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition); // Rigidbody�� ����Ͽ� �ε巴�� �̵�
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
