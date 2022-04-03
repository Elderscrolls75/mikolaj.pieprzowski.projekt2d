using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected StateMachine myStateMachine;

    public virtual void EnterState(StateMachine myStateMachine)
    {
        this.myStateMachine = myStateMachine;
    }

    public virtual void UpdateState()
    {

    }

    public virtual void ExitState()
    {

    }
}
