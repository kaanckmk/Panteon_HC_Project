using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterGamePlayController : EventRaiser
{
    [SerializeField] private Transform checkPointObject;
    
    public void SendCharacterToCheckPoint(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            transform.position = checkPointObject.position;
        }
        else
        {
            return;
        }
    }
    public void SendCharacterToCheckPoint()
    {
            transform.position = checkPointObject.position;
    }

}
