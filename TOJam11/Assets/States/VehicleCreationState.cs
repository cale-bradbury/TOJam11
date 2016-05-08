using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public abstract class VehicleCreationState : State
{
    protected VehicleCreationStateMachine vcsm;

    protected string resourcePath;
    protected GameObject canvas;
    protected GameObject menu;

    protected Modules.Types moduleType;

    protected Inventory invetory;
    protected GameObject vehicle;

    List<GameObject> moduleList = new List<GameObject>();

    public override void Awake()
    {
        canvas = GameObject.Find( "Canvas" );
        menu = Instantiate( Resources.Load<GameObject>( resourcePath ) );
        menu.GetComponent<RectTransform>().SetParent( canvas.GetComponent<RectTransform>(), false );

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
                    moduleList.Add( chassis );
                }
            }
        }

        var content = FindObjectOfType<VerticalLayoutGroup>();
        foreach( var module in moduleList )
        {
            var builderButton = Instantiate( Resources.Load<GameObject>( "Menus/Vehicle Creation/BuilderButton" ) );
            builderButton.transform.SetParent( content.transform );
            builderButton.transform.localScale = Vector3.one;

            builderButton.GetComponent<PrefabDisplay>().prefab = module;

            builderButton.GetComponent<Button>().onClick.AddListener( () =>
            {
                vcsm.SwitchState<Engine>();
            } );
        }
    }

    public override void OnDestroy()
    {
        Destroy( vehicle );
        Destroy( menu );
        canvas = null;
    }
}
