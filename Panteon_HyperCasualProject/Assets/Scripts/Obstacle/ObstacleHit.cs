using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class ObstacleHit : MonoBehaviour
{
    public GameEvent onHit;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            //OnHit?.Invoke(other.gameObject);
            onHit.sentBool = other.gameObject.GetComponent<PlayerMovement>() != null ? 
                true : false;

            onHit.Raise();
        }
    }
    
}
