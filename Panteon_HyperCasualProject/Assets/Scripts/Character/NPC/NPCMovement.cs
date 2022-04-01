using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : CharacterMovement
{
    
    [SerializeField] private Transform finishZone;
    
    private NavMeshAgent _npcAgent;

    private void Awake()
    {
        _npcAgent = GetComponent<NavMeshAgent>();
        _npcAgent.speed = _platformForwardSpeed;
        _npcAgent.angularSpeed = _sidewaySpeed;
        SetNPCDestination();
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
    

    // set destination as finish zone with random x axis
    public void SetNPCDestination()
    {
        Vector3 destination = new Vector3(UnityEngine.Random.Range(PlatformData.MINPLATFORMXBOUNDRY,PlatformData.MAXPLATFORMXBOUNDRY),finishZone.position.y,finishZone.position.z);
        _npcAgent.destination = destination;
    }
    
}