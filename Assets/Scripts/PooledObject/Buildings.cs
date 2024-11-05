using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : PoolAble
{
    public float speed = 10;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ ��������
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.isGameStart)
        {
            MoveRoad();
        }
    }

    public void MoveRoad()
    {
        Vector3 targetPosition = rb.position + Vector3.back * speed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition); // Rigidbody�� ����Ͽ� �ε巴�� �̵�
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ResetWall"))
        {
            // �ǹ��� ������ ������ ���
            if (transform.position.x == 15)
            {
                transform.position = new Vector3(15, 0, 160); // ��ġ �ʱ�ȭ
            }
            // �ǹ��� ���� ������ ���
            else
            {
                transform.position = new Vector3(-15, 0, 160); // ��ġ �ʱ�ȭ
            }
        }
    }
}
