using UnityEngine;
using System.Collections;
using System;

public class Engine : VehicleCreationState
{
    public override void Awake()
    {
        resourcePath = "Menus/Vehicle Creation/Engine";
        moduleType = Modules.Types.Engine;
        base.Awake();
    }

    public override void Update() { }
}
