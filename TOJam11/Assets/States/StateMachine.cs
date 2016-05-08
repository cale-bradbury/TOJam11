using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class StateMachine<TState> : MonoBehaviour
    where TState : State
{
    protected State _currentState;

    public abstract void Awake();
    
    public void SwitchState<TNewState>()
        where TNewState : TState
    {
        if( _currentState != null && _currentState is TNewState ) return;

        Destroy( _currentState );
        _currentState = gameObject.AddComponent<TNewState>();
    }

    protected void OnDestroy()
    {
        Destroy( _currentState );
    }
}