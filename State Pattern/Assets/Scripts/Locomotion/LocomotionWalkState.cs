using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionWalkState : LocomotionBaseState
{
    public LocomotionWalkState(LocomotionStateMachine Context, LocomotionStateFactory States) : base(Context, States)
    {
    }

    public override void EnterState()
    {
        Context.SwitchLocomotionAnimation(LocomotionState.Walk);
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
        if(!Input.anyKey)
            SwitchState(States.Idle());
        else if(Input.GetKeyDown(KeyCode.LeftShift))
            SwitchState(States.Run());
    }
}
