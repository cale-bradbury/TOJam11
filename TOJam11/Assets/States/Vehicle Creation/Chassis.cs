using UnityEngine;
using System.Collections;
using System;

public class Chassis : VehicleCreationState
{
    VehicleCreationStateMachine vcsm;

    GameObject canvas;
    GameObject chassisMenu;

    public override void Awake()
    {
        canvas = GameObject.Find( "Canvas" );
        chassisMenu = Instantiate<GameObject>( Resources.Load<GameObject>( "Menus/Vehicle Creation/Chassis" ) );
        chassisMenu.GetComponent<RectTransform>().SetParent( canvas.GetComponent<RectTransform>(), false );
    }

    public override void Update()
    {

    }

    public override void OnDestroy()
    {
        Destroy( chassisMenu );
        canvas = null;
    }
}
