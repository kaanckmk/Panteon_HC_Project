using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody))]
public abstract class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected float _platformForwardSpeed;
    [SerializeField] protected float _onEdgeForwardSpeed;
    
    
    private Rigidbody _rigidbody;
    private bool _isMoving = false;
    private bool _OnEdge = false;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    //general movement function
    public void Move(Vector3 offset)
    {
        if (_isMoving)
        {
            offset += MoveForward(_OnEdge ? _onEdgeForwardSpeed : _platformForwardSpeed);
            
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
    
    //forward movement of character
    private Vector3 MoveForward(float forwardSpeed)
    {
        return Vector3.forward * Time.deltaTime * forwardSpeed;
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

    public void SetOnEdgeTrue(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            
            _OnEdge = true;
        }
        else
        {
            return;
        }
    }
    public void SetOnEdgeFalse(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            _OnEdge = false;
        }
        else
        {
            return;
        }
    }
    
    
}
