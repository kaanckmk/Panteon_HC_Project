using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDead : MonoBehaviour
{
    public GameEvent OnDie;

    public void KillCharacter()
    {
        OnDie.sentPassable = gameObject.GetComponent<DataPassWithEvent>();
        OnDie.Raise();
    }
}
