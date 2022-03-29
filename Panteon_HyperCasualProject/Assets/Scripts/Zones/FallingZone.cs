using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingZone : MonoBehaviour
{
    public GameEvent OnFall;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            OnFall.sentPassable = other.gameObject.GetComponent<DataPassWithEvent>();
            OnFall.Raise();
        }
    }
}
