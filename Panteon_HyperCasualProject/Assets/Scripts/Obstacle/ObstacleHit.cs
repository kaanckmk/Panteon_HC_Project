using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    public GameEvent onHit;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            onHit.sentPassable = other.gameObject.GetComponent<DataPassWithEvent>();
            onHit.Raise();
        }
    }
    
}
