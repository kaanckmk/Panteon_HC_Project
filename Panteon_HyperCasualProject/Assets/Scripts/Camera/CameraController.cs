using System;
using DG.Tweening;
using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothTime;
        private bool _isFollowing = true; 

        private void LateUpdate()
        {
            if (_isFollowing)
            {
                FollowPlayer();
            }
        }

        public void SetIsFollowingToFalse()
        {
            _isFollowing = false;
        }
        public void SetIsFollowingToTrue()
        {
            _isFollowing = true;
        }

        public void MoveCameraToDrawWall()
        {
            transform.DOMove(new Vector3(0.02f,0.436f,4.904f), 1f).SetEase(Ease.Linear);
            transform.DOLocalRotate(new Vector3(0f, 0f, 0f),1f);
        }


        public void SetCameraPositionToStart()
        {
            transform.position = SetCameraPositionToTarget();
        }


        private Vector3 SetCameraPositionToTarget()
        {
            Vector3 targetPosition = _target.position + _offset;
            targetPosition.x = 0;
            return targetPosition;
        }
        
        public void ShakeCamera(bool isPlayer)
        {
            if (isPlayer)
            {
                UnityEngine.Camera.main.DOShakePosition(0.2f, 0.01f, fadeOut: true);
            }
        }

        public void InitializeCameraRotation()
        {
            transform.parent.rotation = Quaternion.Euler(28.96f, 0, 0);
        }

        private void FollowPlayer()
        {
            transform.position = Vector3.Lerp(transform.position, SetCameraPositionToTarget(), _smoothTime * Time.deltaTime);
        }
        
    }
}