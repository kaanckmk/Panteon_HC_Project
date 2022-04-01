using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformPhysic : MonoBehaviour
{
    [SerializeField] private float rotateForce = 0.01f;
    
    private Vector3 _offset;
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<Character>() !=null)
        {
            int direction = GetComponent<ObstacleTransform>().rotationZ;
            _offset = new Vector3(-direction * rotateForce * Time.deltaTime ,0f,0f);
            other.rigidbody.MovePosition(other.transform.position + _offset);
        }
    }
}
