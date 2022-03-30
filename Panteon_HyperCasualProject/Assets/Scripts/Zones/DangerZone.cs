using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public GameEvent OnEdgeEntered;
    public GameEvent OnEdgeExited;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            Debug.Log("dangerZoneEntered!");
            OnEdgeEntered.sentPassable = other.gameObject.GetComponent<DataPassWithEvent>();
            OnEdgeEntered.Raise();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            Debug.Log("dangerZoneExited!");
            OnEdgeExited.sentPassable = other.gameObject.GetComponent<DataPassWithEvent>();
            OnEdgeExited.Raise();
        }
    }
}
