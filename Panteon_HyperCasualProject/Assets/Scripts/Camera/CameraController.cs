using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _movingOffset;
        [SerializeField] private Vector3 _fallingOffset;
        [SerializeField] private Vector3 _playerFocusedOffset;
        [SerializeField] private float _smoothTime;
        
        private bool _isFollowing = true;
        private bool _isFollowingX = false;
        private Vector3 _offset;

        private void Awake()
        {
            _offset = _movingOffset;
        }

        private void Start()
        {
            _offset = _movingOffset;
        }

        private void LateUpdate()
        {
            if (_isFollowing)
            {
                FollowPlayer(_offset);
            }
        }

        private void FollowPlayer(Vector3 offset)
        {
            transform.position = Vector3.Lerp(transform.position, SetCameraPositionToTarget(offset,_isFollowingX), _smoothTime * Time.deltaTime);
        }
        
        private Vector3 SetCameraPositionToTarget(Vector3 offset, bool followTargetX)
        {
            Vector3 targetPosition = _target.position + offset;

            targetPosition.x = followTargetX ? targetPosition.x : 0;
            
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

        public void SetCameraToFalling(DataPassWithEvent rawData)
        {
            if(CheckIsPlayer(rawData))
            {
                _isFollowingX = true;
                _offset = _fallingOffset;
                transform.DOLocalRotate(new Vector3(60f, 0f, 0f),1f);
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

        public void SetCameraToDangerZone(DataPassWithEvent rawData)
        {
            if(CheckIsPlayer(rawData))
            {
                _isFollowingX = true;
                _offset = _playerFocusedOffset;
                transform.DOLocalRotate(new Vector3(26.41f, 0f, 0f),1f);
            }
        }

        public void ShakeCamera(DataPassWithEvent rawData)
        {
            if(CheckIsPlayer(rawData))
            {
                UnityEngine.Camera.main.DOShakePosition(0.2f, 0.01f, fadeOut: true);
            }
        }

        public void InitializeCamera(DataPassWithEvent rawData)
        {
            if(CheckIsPlayer(rawData))
            {
                SetIsFollowingToTrue();
                _offset = _movingOffset;
                _isFollowingX = false;
                transform.rotation = Quaternion.Euler(34.58f, 0, 0);
            }
        }
        public void InitializeCamera()
        {
            SetIsFollowingToTrue();
            _offset = _movingOffset;
            _isFollowingX = false;
            transform.rotation = Quaternion.Euler(34.58f, 0, 0);
        }

        public bool CheckIsPlayer(DataPassWithEvent rawData)
        {
            if (rawData.gameObject == _target.gameObject)
            {
                    return true;
            }
            
            return false;
        }

        
}