using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerAnimationController : AnimationController
{
    private static readonly int IsMove = Animator.StringToHash("IsMove");
    private static readonly int IsJump = Animator.StringToHash("IsJump");
    private static readonly int IsHit = Animator.StringToHash("IsHit");


    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        // ��ֹ��� �ε����ų� ������ �� �ִϸ��̼��� ���� �����ϵ��� ����
        // playerController���� �������ش�.
        controller.OnMoveEvent += Move;
        controller.OnHitEvent += Hit;
    }

    private void Update()
    {
        // y��ǥ(����)�� ���� �ִϸ��̼� �����ϵ��� ��
        animator.SetFloat(IsJump, animator.gameObject.transform.position.y);
    }

    private void Move()
    {
        animator.SetTrigger(IsMove);
    }

    private void Hit()
    {
        animator.SetTrigger(IsHit);
    }
}
