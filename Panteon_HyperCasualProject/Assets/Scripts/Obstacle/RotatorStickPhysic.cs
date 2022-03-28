using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotatorStickPhysic : MonoBehaviour
{
    [SerializeField] private float pushingForce = 50f;
    
    private Rigidbody _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {    
            Vector3 normal = other.GetContact(0).normal;
            Debug.Log(normal);
            Vector3 x = Quaternion.LookRotation(normal).eulerAngles;
            
            Rigidbody characterRb = other.gameObject.GetComponent<Rigidbody>();
            
            characterRb.AddForce( - normal );
        }
    }
}
