using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionStateFactory
{
    private LocomotionStateMachine _context;
    
    private LocomotionIdleState _idle;
    private LocomotionWalkState _walk;
    private LocomotionRunState _run;

    public LocomotionStateFactory(LocomotionStateMachine context)
    {
        this._context = context;
        
        _idle = new LocomotionIdleState(_context, this);
        _walk = new LocomotionWalkState(_context, this);
        _run = new LocomotionRunState(_context, this);
    }

    public LocomotionBaseState Idle() => _idle;
    public LocomotionBaseState Walk() => _walk;
    public LocomotionBaseState Run() => _run;
}
