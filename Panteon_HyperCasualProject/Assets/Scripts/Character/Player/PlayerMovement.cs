using UnityEngine;
public class PlayerMovement : CharacterMovement
{
    
    [SerializeField] protected float _sidewaySpeed;
    [SerializeField] private MouseInput _mouseInput;

    private Vector3 _offset;

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, PlatformData.MINPLATFORMXBOUNDRY - 0.2f, PlatformData.MAXPLATFORMXBOUNDRY + 0.2f), // let player fall on edges
            transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        _offset = new Vector3(_mouseInput.MoveFactorX * _sidewaySpeed * Time.deltaTime,0f,0f);
        Move(_offset);
    }
}
