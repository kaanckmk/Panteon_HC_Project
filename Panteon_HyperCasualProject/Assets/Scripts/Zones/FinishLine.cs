using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameEvent OnFinishLineEntered;
       
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            OnFinishLineEntered.Raise();
        }
    }
}
