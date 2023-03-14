using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionRunState : LocomotionBaseState
{
    public LocomotionRunState(LocomotionStateMachine Context, LocomotionStateFactory States) : base(Context, States)
    {
    }

    public override void EnterState()
    {
        Context.SwitchLocomotionAnimation(LocomotionState.Run);
    }

    public override void UpdateState()
    {
        CheckSwitches();
    }

    protected override void ExitState()
    {
    }

    protected override void CheckSwitches()
    {
        if(Input.GetKeyUp(KeyCode.LeftShift))
            SwitchState(States.Walk());
        else if(Input.GetKeyUp(KeyCode.W))
            SwitchState(States.Idle());
    }
}
