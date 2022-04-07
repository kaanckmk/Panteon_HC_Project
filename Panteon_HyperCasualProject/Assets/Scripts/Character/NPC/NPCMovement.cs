using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class NPCMovement : CharacterMovement
{
    [SerializeField] private List<Transform> zones;
    private int _nextZone = 0;
    
    private NavMeshAgent _npcAgent;

    private void Awake()
    {
        if (GetComponentInParent<NavMeshAgent>()!=null)
        {
            _npcAgent = GetComponentInParent<NavMeshAgent>();
        }
        
        _npcAgent.speed = _platformForwardSpeed;
        SetNPCDestination(zones[_nextZone]);
        _npcAgent.isStopped = true;

    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        base.Move();
        _npcAgent.isStopped = !_isMoving;
    }

    public void SetTargetZone(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            _nextZone++;
            SetNPCDestination(zones[_nextZone]);
        }
    }

    // set destination as finish zone with random x axis
    public void SetNPCDestination(Transform zone)
    {
        //Vector3 destination = new Vector3(UnityEngine.Random.Range(PlatformData.MINPLATFORMXBOUNDRY,PlatformData.MAXPLATFORMXBOUNDRY),finishZone.position.y,finishZone.position.z);
        _npcAgent.destination = zone.position;
        
    }
    
}