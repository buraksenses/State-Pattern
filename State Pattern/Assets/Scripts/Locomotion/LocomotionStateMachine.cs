using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class LocomotionStateMachine : MonoBehaviour
{
    public LocomotionBaseState CurrentState;
    private LocomotionStateFactory _states;

    //Animator Variables
    private Animator _animator;
    private const float TransitionTime = .75f;

    private static readonly int IDLE = Animator.StringToHash("Idle");
    private static readonly int WALK = Animator.StringToHash("Walk");
    private static readonly int RUN = Animator.StringToHash("Run");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        //Initializing first state
        _states = new LocomotionStateFactory(this);
        CurrentState = _states.Idle();
        CurrentState.EnterState();
        
        //Executing current state's UpdateState function
        this.UpdateAsObservable().Subscribe(_ => CurrentState.UpdateState());
    }

    public void SwitchLocomotionAnimation(LocomotionState state)
    {
        switch (state)
        {
            case LocomotionState.Idle:
                _animator.CrossFadeInFixedTime(IDLE,TransitionTime);
                break;
            case LocomotionState.Walk:
                _animator.CrossFadeInFixedTime(WALK,TransitionTime);
                break;
            case LocomotionState.Run:
                _animator.CrossFadeInFixedTime(RUN,TransitionTime);
                break;
        }
    }
}

public enum LocomotionState
{
    Idle,
    Walk,
    Run
}
