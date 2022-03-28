using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
    private Animator _characterAnimator;

    private void Awake()
    {
        _characterAnimator = GetComponent<Animator>();
    }
    
    public void AnimateIdle()
    {
        _characterAnimator.SetBool("IsMoving",false);
    }
    public void AnimateMoveForward()
    {
        _characterAnimator.SetBool("IsMoving", true);
    }

    public void AnimateObstacleHit()
    {
        _characterAnimator.SetBool("HitObstacle", true);
    }

    public void StopHitObstacleAnimation()
    {
        _characterAnimator.SetBool("HitObstacle", false);
    }
}