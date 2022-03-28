using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterGamePlayController : MonoBehaviour
{
    [SerializeField] private Transform checkPointObject;
    
    public void SendCharacterToCheckPoint()
    {
        transform.parent.position = checkPointObject.position;
    }

}
