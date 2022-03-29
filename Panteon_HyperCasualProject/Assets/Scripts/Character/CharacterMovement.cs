using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected float _forwardSpeed;
    
    private Rigidbody _rigidbody;
    private bool _isMoving = false;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    //general movement function
    public void Move(Vector3 offset)
    {
        if (_isMoving)
        {
            offset = offset + MoveForward();
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }

    
    //forward movement of character
    private Vector3 MoveForward()
    {
        return Vector3.forward * Time.deltaTime * _forwardSpeed;
    }
    
    public void SetMovingFalse(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            _isMoving=false;
        }
        else
        {
            return;
        }
    }
    /*public void SetMovingFalse(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
        _isMoving=false;
        }
        else
        {
            return;
        }
    }*/
    public void SetMovingTrue(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            _isMoving=true;
        }
        else
        {
            return;
        }
    }
    public void SetMovingTrue()
    {
        _isMoving=true;
    }
    
    
}
