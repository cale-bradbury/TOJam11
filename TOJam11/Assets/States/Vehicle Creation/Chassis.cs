using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Chassis : VehicleCreationState
{
    public override void Awake()
    {
        resourcePath = "Menus/Vehicle Creation/Chassis";
        moduleType = Modules.Types.Chassis;
        base.Awake();         
    }

    public override void Update(){ }    
}
