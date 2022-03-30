using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator _characterAnimator;

    private void Awake()
    {
        _characterAnimator = transform.GetComponent<Animator>();
    }
    
    public void AnimateIdle(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {   
            _characterAnimator.SetBool("IsMoving",false);
        }
        else
        {
            return;
        }
    }
    public void AnimateMoveForward(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {   
            _characterAnimator.SetBool("IsMoving", true);
        }
        else
        {
            return;
        }
    }
    public void AnimateMoveForward()
    { 
            _characterAnimator.SetBool("IsMoving", true);
    }

    public void AnimateObstacleHit(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {   
            _characterAnimator.SetBool("HitObstacle", true);
        }
        else
        {
            return;
        }
    }
    public void StopHitObstacleAnimation(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {   
            _characterAnimator.SetBool("HitObstacle", false);
        }
        else
        {
            return;
        }
    }

    public void AnimateFall(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {   
            _characterAnimator.SetBool("IsFalling", true);
        }
        else
        {
            return;
        }
    }

    public void StopFallAnimation(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {   
            _characterAnimator.SetBool("IsFalling", false);
        }
        else
        {
            return;
        }
    }

    public void AnimateEdgeMovement(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {   
            _characterAnimator.SetBool("OnEdge", true);
        }
        else
        {
            return;
        }
        
    }
    public void StopEdgeMovementAnimation(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {   
            _characterAnimator.SetBool("OnEdge", false);
        }
        else
        {
            return;
        }
        
    }
    
    
    
}