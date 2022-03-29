using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameEvent OnFinishLineEntered;
       
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            OnFinishLineEntered.sentPassable = other.gameObject.GetComponent<DataPassWithEvent>();
            OnFinishLineEntered.Raise();
        }
    }
}
