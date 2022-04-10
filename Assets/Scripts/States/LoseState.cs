using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : BaseState
{
    public override void EnterState(StateMachine myStateMachine)
    {
        base.EnterState(myStateMachine);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(Input.GetKeyDown(KeyCode.R))
        {
            myStateMachine.EnterState(new GameState());
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
