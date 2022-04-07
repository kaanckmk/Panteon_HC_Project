using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCheckPointZone : MonoBehaviour
{
    public GameEvent OnNPCCheckPointZoneEntered;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("some1 entered");
        if (other.gameObject.GetComponent<NPCMovement>() != null)
        {
            Debug.Log("Entered");
            OnNPCCheckPointZoneEntered.sentPassable = other.gameObject.GetComponent<DataPassWithEvent>();
            OnNPCCheckPointZoneEntered.Raise();
        }
    }

}
