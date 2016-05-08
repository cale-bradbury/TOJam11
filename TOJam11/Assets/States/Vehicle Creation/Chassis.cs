using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Chassis : VehicleCreationState
{
    VehicleCreationStateMachine vcsm;

    GameObject canvas;
    GameObject chassisMenu;

    Modules.Types moduleType = Modules.Types.Chassis;

    Inventory invetory;
    GameObject vehicle;

    List<GameObject> chassisList = new List<GameObject>();

    public override void Awake()
    {
        canvas = GameObject.Find( "Canvas" );
        chassisMenu = Instantiate( Resources.Load<GameObject>( "Menus/Vehicle Creation/Chassis" ) );
        chassisMenu.GetComponent<RectTransform>().SetParent( canvas.GetComponent<RectTransform>(), false );

        if( vehicle != null )
        {
            Destroy( vehicle );
        }
        vehicle = new GameObject( "Vehicle" );

        invetory = GameObject.Find( "Inventory" ).GetComponent<Inventory>();

        foreach( var item in invetory.list )
        {
            var module = item.prefab.GetComponent<Module>();
            if( module.type == moduleType && item.prefab != null )
            {
                for( int i = 0; i < item.count; i++ )
                {
                    var chassis = Instantiate<GameObject>( item.prefab );
                    chassis.transform.SetParent( invetory.transform );
                    chassisList.Add( chassis );
                }
            }
        }

        var chassisContent = FindObjectOfType<ChassisContent>();
        foreach( var chassis in chassisList )
        {
            var builderButton = Instantiate( Resources.Load<GameObject>( "Menus/Vehicle Creation/BuilderButton" ) );
            builderButton.transform.SetParent( chassisContent.transform );
            builderButton.GetComponent<PrefabDisplay>().prefab = chassis;

            builderButton.GetComponent<Button>().onClick.AddListener( () =>
            {
                vcsm.SwitchState<Engine>();
            } );
        }
         
    }

    public override void Update(){ }

    public override void OnDestroy()
    {
        Destroy( vehicle );
        Destroy( chassisMenu );
        canvas = null;
    }
}
