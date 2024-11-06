using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum HorizontalPosition
{ 
    Left = -1,
    middle,
    Right
}

public enum HorizontalMoveDir
{
    Left = -1,
    Right = 1
};


public class PlayerController : MonoBehaviour
{
    public float horizontalMoveDistance = 5f;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    int curHorizontalPosition = 0;
    private Vector3 targetPosition;
    private Vector3 newPosition;
    private bool isMoving = false;

    public LayerMask groundLayerMask;

    private Rigidbody rigidbody;

    public event Action OnMoveEvent;
    public event Action OnHitEvent;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InGameManagers.Item.SetPlayerController(this);
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            // 움직임이 자연스럽게 보이도록 deltaTime 마다 잘게 쪼갠 위치로 이동시키기 위해 위치를 설정한다. 
            SetMidPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            OnHitEvent?.Invoke();
        }
    }

    private void Move()
    {
        // 근데 SetMovePoint만 하면 영원히 1에 정확히 도달하지는 못한다. 그렇기에 목표지점에 거의 도달하면 도착하게 만들어준다.
        if (Vector3.Distance(newPosition, targetPosition) < 0.01f)
        {
            newPosition = targetPosition;
            isMoving = false;
        }

        rigidbody.MovePosition(newPosition);
    }

    private void SetMidPoint()
    {
        newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    public void OnHorizontalMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            int inputDir = (int)context.ReadValue<float>();

            // 방향에 따라 위치 업데이트
            if (inputDir == (int)HorizontalMoveDir.Left && curHorizontalPosition > (int)HorizontalPosition.Left)
            {
                curHorizontalPosition -= 1;
            }
            else if (inputDir == (int)HorizontalMoveDir.Right && curHorizontalPosition < (int)HorizontalPosition.Right)
            {
                curHorizontalPosition += 1;
            }
            else
            {
                return;
            }

            // 목표 지점을 잡는다.
            targetPosition = new Vector3(curHorizontalPosition * horizontalMoveDistance, transform.position.y, transform.position.z);
            isMoving = true;

            // 움직임 중에 재입력으로 움직이지 못하도록 띄워둔다.
            rigidbody.AddForce(Vector3.up * 2, ForceMode.Impulse);

            OnMoveEvent?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.1f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }
}
