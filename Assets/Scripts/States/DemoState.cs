using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoState : BaseState
{
    public override void EnterState(StateMachine myStateMachine)
    {
        base.EnterState(myStateMachine);
        Debug.Log("DemoState activated");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("DemoState Updated");
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exited from DemoState");
        
    }
}
