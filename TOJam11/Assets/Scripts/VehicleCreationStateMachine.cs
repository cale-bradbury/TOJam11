using UnityEngine;
using System.Collections;

public class VehicleCreationStateMachine : StateMachine<VehicleCreationState>
{
    public override void Awake()
    {
        SwitchState<Chassis>();
    }
}
