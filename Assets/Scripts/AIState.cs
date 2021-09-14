using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI State")]
public abstract class AIState : ScriptableObject
{
    public virtual bool EnterState()
    {
        return true;
    }

    

    public virtual bool ExitState()
    {
        return true;
    }
}
