using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHitEachOtherPhysic : MonoBehaviour
{
    public GameEvent onHitEachOther;
    
    [SerializeField] private float pushingForce = 1f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Character>() != null)
        {
            Vector3 normal = other.GetContact(0).normal;
            other.gameObject.GetComponent<Rigidbody>().AddForce(-normal * pushingForce);
            gameObject.GetComponent<Rigidbody>().AddForce(-normal * pushingForce);
            
            onHitEachOther.sentPassable = other.gameObject.GetComponent<DataPassWithEvent>();
            onHitEachOther.Raise();
        }
    }
}
