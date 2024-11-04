using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour
{
    [SerializeField] GameObject Wings;
    public float rotationSpeed; // ȸ�� �ӵ� ����


    private void Start()
    {
        rotationSpeed = Random.Range(50, 100);
    }

    void Update()
    {
        // Wings�� Z���� �������� ��� ȸ��
        Wings.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
