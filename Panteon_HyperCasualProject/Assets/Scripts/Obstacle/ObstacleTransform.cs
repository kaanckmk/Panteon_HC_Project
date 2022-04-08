using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

//This Class is for the obstacles to give dotween animations 
[RequireComponent(typeof(Renderer))]
public class ObstacleTransform : MonoBehaviour
{
    //until where object can move 
    private float _obstaclePlayBoundryMax;
    private float _obstaclePlayBoundryMin;

    //Movement paramaters of Obstacles
    public bool isMovable;
    public float movePositionPercentage;
    public float movementduration;
    
    //Rotation paramaters of Obstacles
    public bool isRotatable;
    public int rotationX, rotationY, rotationZ;
    public float rotationDuration;

    //Punch paramaters of Obstacles
    public bool isPunchable;
    private void Awake()
    {
        float objectWidth = CalculateWidth();
        _obstaclePlayBoundryMax = PlatformData.MAXPLATFORMXBOUNDRY - (objectWidth/ 2);
        _obstaclePlayBoundryMin = PlatformData.MINPLATFORMXBOUNDRY + (objectWidth/ 2);
    }

    void Start()
    {
        if (isMovable) 
        {
            MoveObstacleToX();
        }

        if (isRotatable)
        {
            RotateObstacle();
        }

        if (isPunchable)
        {
            PunchWithObstacleX();
        }
        
    }

    
    public void MoveObstacleToX()
    {
        if (movementduration != 0)
        {
            float moveTO = CalculateWheretoMove();
            transform.DOMoveX(moveTO, movementduration).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }

    public void PunchWithObstacleX()
    {
        float firstPosX = transform.position.x;
        Sequence PunchSequence = DOTween.Sequence();
        PunchSequence.Append(transform.DOMoveX(CalculateWheretoMove(), 0.6f).SetDelay(4f).SetEase(Ease.Unset).SetUpdate(UpdateType.Fixed)
                .SetRelative())
            .Append(transform.DOMoveX(firstPosX, 1f).SetDelay(1f).SetEase(Ease.Linear).SetDelay(2f).SetUpdate(UpdateType.Fixed));
        PunchSequence.SetLoops(-1, LoopType.Restart);
            
            
        /*mySequence = DOTween.Sequence();
        mySequence.Append(this.transform.DOMoveY(MoveDistance, DownDoneTime).SetRelative().SetDelay(StartWaitTime).SetEase(Ease.Linear))
            .Append(
                this.transform.DOMoveY(startPosY, UpDoneTime).SetDelay(UpWaitTime).SetEase(Ease.Linear))
            .SetDelay(TestValue); ;
        mySequence.SetLoops(-1, LoopType.Restart);
        create Sequence You can set the delay separately*/
    }

    public void RotateObstacle()
    {
        if (rotationX !=0 || rotationY !=0 || rotationZ!=0)
        {
            if(rotationDuration!=0)
                transform.DOLocalRotate(new Vector3(rotationX * 180f, rotationY*180f, rotationZ* 180f), rotationDuration).SetEase(Ease.Linear).SetLoops(-1,LoopType.Incremental);
        }
    }

    private float CalculateWidth() 
    {
        return GetComponent<Renderer>().bounds.size.x;
    }

    private float CalculateWheretoMove()
    {
        return ((Mathf.Abs(_obstaclePlayBoundryMax) + Mathf.Abs(_obstaclePlayBoundryMin)) * movePositionPercentage) /
               2f;
    }
    
}



