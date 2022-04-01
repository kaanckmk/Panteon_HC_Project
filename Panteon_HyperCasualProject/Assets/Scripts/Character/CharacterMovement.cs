using UnityEngine;
public abstract class CharacterMovement : Character
{
    [SerializeField] protected float _platformForwardSpeed;
    [SerializeField] protected float _onEdgeForwardSpeed;
    [SerializeField] protected float _sidewaySpeed;

    private protected float _speed;
    private protected bool _isMoving;
    private protected bool _OnEdge;
    
    private void Awake()
    {
        _isMoving = false;
        _OnEdge = false;
    }
    
    //general movement function
    public virtual void Move()
    {
        SetSpeed();
    }
    public void SetMovingFalse(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            _isMoving=false;
        }
        else
        {
            return;
        }
    }

    public void SetSpeed()
    {
        _speed = _OnEdge ? _onEdgeForwardSpeed : _platformForwardSpeed;
    }
    public void SetMovingTrue(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            _isMoving=true;
        }
        else
        {
            return;
        }
    }
    public void SetMovingTrue()
    {
        _isMoving=true;
    }

    public void SetOnEdgeTrue(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            
            _OnEdge = true;
        }
        else
        {
            return;
        }
    }
    public void SetOnEdgeFalse(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == gameObject)
        {
            _OnEdge = false;
        }
        else
        {
            return;
        }
    }

    
}
