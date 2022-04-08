using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCheckPointZone : MonoBehaviour
{
    public GameEvent OnNPCCheckPointZoneEntered;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NPCMovement>() != null)
        {
            OnNPCCheckPointZoneEntered.sentPassable = other.gameObject.GetComponent<DataPassWithEvent>();
            OnNPCCheckPointZoneEntered.Raise();
        }
    }

}
