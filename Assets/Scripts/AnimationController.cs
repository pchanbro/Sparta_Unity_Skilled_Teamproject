using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected PlayerController controller;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
    }
}