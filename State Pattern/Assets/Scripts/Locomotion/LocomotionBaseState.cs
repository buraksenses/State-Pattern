using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LocomotionBaseState
{
    protected LocomotionStateMachine Context;
    protected LocomotionStateFactory States;
    
    protected LocomotionBaseState(LocomotionStateMachine Context,LocomotionStateFactory States)
    {
        this.Context = Context;
        this.States = States;
    }
    
    public abstract void EnterState();

    public abstract void UpdateState();

    protected abstract void ExitState();

    protected abstract void CheckSwitches();

    protected void SwitchState(LocomotionBaseState newState)
    {
        ExitState();

        Context.CurrentState = newState;
        
        newState.EnterState();
    }
}
