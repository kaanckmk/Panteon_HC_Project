using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public GameEvent OnDied;
    
    private void Die()
    {
        OnDied.Raise();
    }
}
