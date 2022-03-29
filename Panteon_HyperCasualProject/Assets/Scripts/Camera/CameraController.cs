using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _movingOffset;
        [SerializeField] private Vector3 _fallingOffset;
        [SerializeField] private float _smoothTime;
        private bool _isFollowing = true;
        private bool _isFalling = false;
        private Vector3 _offset;

        private void LateUpdate()
        {
            if (_isFollowing)
            {
                FollowPlayer(_isFalling ? _fallingOffset: _movingOffset);
            }
        }

        private void FollowPlayer(Vector3 offset)
        {
            transform.position = Vector3.Lerp(transform.position, SetCameraPositionToTarget(offset), _smoothTime * Time.deltaTime);
        }
        private Vector3 SetCameraPositionToTarget(Vector3 offset)
        {
            Vector3 targetPosition = _target.position + offset;
            targetPosition.x = 0;
            return targetPosition;
        }

        public void SetIsFollowingToFalse(DataPassWithEvent rawData)
        {
            if(rawData.gameObject.GetComponent<PlayerMovement>()!= null)
            {
                _isFollowing = false;
            }
        }
        public void SetIsFollowingToTrue(DataPassWithEvent rawData)
        {
            if(CheckIsPlayer(rawData))
            {
                _isFollowing = true;
            }
        }
        public void SetIsFollowingToTrue()
        {
                _isFollowing = true;
        }

        public void SetIsFallingTrue(DataPassWithEvent rawData)
        {
            if(CheckIsPlayer(rawData))
            {
                _isFalling = true;
            }
        }

        public void SetIsFallingFalse(DataPassWithEvent rawData)
        {
            if(CheckIsPlayer(rawData))
            {
                _isFalling = false;
            }
        }

        public void MoveCameraToDrawWall(DataPassWithEvent rawData)
        {
            if(rawData.gameObject.GetComponent<PlayerMovement>()!= null)
            {
                transform.DOMove(new Vector3(0.02f,0.436f,4.904f), 1f).SetEase(Ease.Linear);
                transform.DOLocalRotate(new Vector3(0f, 0f, 0f),1f);
            }
        }

        public void SetCameraPositionToStart(DataPassWithEvent rawData)
        {
            if(CheckIsPlayer(rawData))
            {
                transform.position = SetCameraPositionToTarget(_movingOffset);
            }
        }
        public void SetCameraPositionToStart()
        {
                transform.position = SetCameraPositionToTarget(_movingOffset);
        }
        public void ShakeCamera(DataPassWithEvent rawData)
        {
            if(CheckIsPlayer(rawData))
            {
                UnityEngine.Camera.main.DOShakePosition(0.2f, 0.01f, fadeOut: true);
            }
        }

        public void InitializeCameraRotation(DataPassWithEvent rawData)
        {
            if(CheckIsPlayer(rawData))
            {
                transform.rotation = Quaternion.Euler(34.58f, 0, 0);
            }
        }
        public void InitializeCameraRotation()
        {
                transform.rotation = Quaternion.Euler(34.58f, 0, 0);
        }

        public bool CheckIsPlayer(DataPassWithEvent rawData)
        {
            if (rawData.gameObject == gameObject)
            {
                if (gameObject.GetComponent<PlayerMovement>()!= null)
                {
                    return true;
                }
            }
            
            return false;
        }

        
}