using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;

    private void Start()
    {
        EnterState(new DemoState());
    }

    private void Update() 
    {
        currentState.UpdateState();    
    }

    private void OnDestroy() 
    {
        currentState.ExitState();    
    }

    void EnterState(BaseState stateToEnter)
    {
        if(currentState!=null)
        {
            currentState.ExitState();
        }

        currentState = stateToEnter;

        currentState.EnterState(this);
    }
}
