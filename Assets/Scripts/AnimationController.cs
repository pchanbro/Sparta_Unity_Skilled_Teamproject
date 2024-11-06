using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    protected PlayerController controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<PlayerController>();
    }
}
