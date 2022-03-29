using UnityEngine;

public class EventRaiser : MonoBehaviour
{

    public GameEvent eventToRaise;

    public virtual void RaiseEvent()
    {
        if (eventToRaise == null)
        {
            Debug.Log("Event was not set for Event Raiser on GameObject named:" + gameObject.name);
            return;
        }
        
        eventToRaise.Raise();
    }
}
