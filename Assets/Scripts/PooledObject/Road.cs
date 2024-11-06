using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : PoolAble
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ ��������
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
        rb.MovePosition(targetPosition); // Rigidbody�� ����Ͽ� �ε巴�� �̵�
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ResetWall"))
        {
            if(transform.position.x >= 30) transform.position = new Vector3(30, 0, 160); // ��ġ �ʱ�ȭ
            else transform.position = new Vector3(0, 0, 160); // ��ġ �ʱ�ȭ
        }
    }
}
