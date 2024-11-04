using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour
{
    [SerializeField] GameObject Wings;
    public float rotationSpeed; // 회전 속도 조정


    private void Start()
    {
        rotationSpeed = Random.Range(50, 100);
    }

    void Update()
    {
        // Wings를 Z축을 기준으로 계속 회전
        Wings.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
