using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : CharacterMovement
{
    [SerializeField] private MouseInput _mouseInput;

    private Vector3 _offset;
    private Rigidbody  _rigidbody;
    
    
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
    
    
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, PlatformData.MINPLATFORMXBOUNDRY - 0.2f, PlatformData.MAXPLATFORMXBOUNDRY + 0.2f), // let player fall on edges
            transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        _offset = new Vector3(_mouseInput.MoveFactorX * _sidewaySpeed * Time.deltaTime,0f,0f);
        Move();
    }
    
    public override void Move()
    {
        base.Move();
        if (_isMoving)
        {
            _offset += MoveForward();
            _rigidbody.MovePosition(_rigidbody.position + _offset);
        }
    }
    
    //forward movement of character
    private Vector3 MoveForward()
    {
        return Vector3.forward * Time.deltaTime * _speed;
    }
}
