using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;

    private void Update()
    {
        RunStateMachine();
    }
    private void RunStateMachine()
    {
        if(currentState !=null)
        {
            State nextState = currentState.RunCurrentState();
            if (nextState != null)
            {
                SwitchToNextState(nextState);
            }
        }
    }

    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
}
