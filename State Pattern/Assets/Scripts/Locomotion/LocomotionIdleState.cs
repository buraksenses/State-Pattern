using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionIdleState : LocomotionBaseState
{
    public LocomotionIdleState(LocomotionStateMachine Context, LocomotionStateFactory States) : base(Context, States)
    {
    }

    public override void EnterState()
    {
        Context.SwitchLocomotionAnimation(LocomotionState.Idle);
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
        if(Input.GetKeyDown(KeyCode.W))
            SwitchState(States.Walk());
        else if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))
            SwitchState(States.Run());
    }
}
