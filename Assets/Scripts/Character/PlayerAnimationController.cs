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
        // 장애물에 부딪히거나 움직일 때 애니메이션이 같이 반응하도록 구독
        // playerController에서 실행해준다.
        controller.OnMoveEvent += Move;
        controller.OnHitEvent += Hit;
    }

    private void Update()
    {
        // y좌표(높이)에 따라 애니메이션 실행하도록 함
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
