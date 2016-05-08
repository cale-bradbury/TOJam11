using UnityEngine;
using System.Collections;
using System;

public class GameStateMachine : StateMachine<GameState>
{
    public override void Awake()
    {
        SwitchState<VehicleCreation>();
    }
}
