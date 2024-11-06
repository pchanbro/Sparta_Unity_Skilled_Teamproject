using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float horizontalMoveDistance = 5f;
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
        rigidbody = GetComponentInChildren<Rigidbody>();
        CharacterManager.Instance.PlayerController = this;
    }

    private void Start()
    {
        ItemManager.Instance.SetPlayerController(this);
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
            // �������� �ڿ������� ���̵��� deltaTime ���� �߰� �ɰ� ��ġ�� �̵���Ű�� ���� ��ġ�� �����Ѵ�. 
            SetMidPoint();
        }
    }

    private void Move()
    {
        // �ٵ� SetMovePoint�� �ϸ� ������ 1�� ��Ȯ�� ���������� ���Ѵ�. �׷��⿡ ��ǥ������ ���� �����ϸ� �����ϰ� ������ش�.
        if (Vector3.Distance(newPosition, targetPosition) < 0.01f)
        {
            newPosition = targetPosition;
            isMoving = false;
        }

        rigidbody.MovePosition(newPosition);
    }

    private void SetMidPoint()
    {
        newPosition = Vector3.Lerp(rigidbody.transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    public void OnHorizontalMove(InputAction.CallbackContext context)
    {
        Debug.Log(IsGrounded());
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            int inputDir = (int)context.ReadValue<float>();

            // ���⿡ ���� ��ġ ������Ʈ
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

            // ��ǥ ������ ��´�.
            targetPosition = new Vector3(curHorizontalPosition * horizontalMoveDistance, rigidbody.transform.position.y, rigidbody.transform.position.z);
            isMoving = true;

            // ������ �߿� ���Է����� �������� ���ϵ��� ����д�.
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
            new Ray(rigidbody.transform.position + (rigidbody.transform.forward * 0.2f) + (rigidbody.transform.up * 0.3f), Vector3.down),
            new Ray(rigidbody.transform.position + (-rigidbody.transform.forward * 0.2f) + (rigidbody.transform.up * 0.3f), Vector3.down),
            new Ray(rigidbody.transform.position + (rigidbody.transform.right * 0.2f) + (rigidbody.transform.up * 0.3f), Vector3.down),
            new Ray(rigidbody.transform.position + (-rigidbody.transform.right * 0.2f) + (rigidbody.transform.up * 0.3f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.4f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public void OnTrigger()
    {
        OnHitEvent?.Invoke();
    }

    public void SetCharacter()
    {
        rigidbody = GetComponentInChildren<Rigidbody>();
    }

    // �� ���� �ӽ÷� ĳ���͸� ��ȯ�ϱ� ���� �޼����
    public Image image;

    public void OnCharacterChoice(InputAction.CallbackContext context)
    {
        image.gameObject.SetActive(true);
    }

    public void SpawnZero()
    {
        CharacterManager.Instance.SetPlayerCharacter(0);
        image.gameObject.SetActive(false);
    }

    public void SpawnOne()
    {
        CharacterManager.Instance.SetPlayerCharacter(1);
        image.gameObject.SetActive(false);
    }

    public void SpawnTwo()
    {
        CharacterManager.Instance.SetPlayerCharacter(2);
        image.gameObject.SetActive(false);
    }
}
