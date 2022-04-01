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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Character>() != null)
        {
            Vector3 normal = other.GetContact(0).normal;
            other.gameObject.GetComponent<Rigidbody>().AddForce(-normal * pushingForce);
        }
    }
}
