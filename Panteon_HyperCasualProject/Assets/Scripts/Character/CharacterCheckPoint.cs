using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterCheckPoint : MonoBehaviour
{
    [SerializeField] private Transform checkPointObject;
    private Vector3 _firstPosition;

    private void Awake()
    {
        _firstPosition = transform.position;
    }

    public void SendCharacterFirstPosition(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            transform.position = _firstPosition;
        }
    }
    public void SendCharacterFirstPosition()
    {
        transform.position = _firstPosition;
    }

    public void SendCharactherToCheckPoint(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            transform.position = new Vector3(UnityEngine.Random.Range(PlatformData.MINPLATFORMXBOUNDRY,PlatformData.MAXPLATFORMXBOUNDRY),_firstPosition.y,checkPointObject.position.z);
        }
        
    }
    public void SendCharactherToCheckPoint()
    {
            transform.position = new Vector3(UnityEngine.Random.Range(PlatformData.MINPLATFORMXBOUNDRY,PlatformData.MAXPLATFORMXBOUNDRY),_firstPosition.y,checkPointObject.position.z);
        
    }

}
