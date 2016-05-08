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

        invetory = GameObject.Find( "Inventory" ).GetComponent<Inventory>();

        foreach( var item in invetory.list )
        {
            var module = item.prefab.GetComponent<Module>();
            if( module.type == moduleType && item.prefab != null )
            {
                for( int i = 0; i < item.count; i++ )
                {
                    var prefab = Instantiate<GameObject>( item.prefab );
                    prefab.transform.SetParent( invetory.transform );
                    moduleList.Add( prefab );
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
                // Add Module to Vehicle
                var prefab = builderButton.GetComponent<PrefabDisplay>().prefab;
                var newModule = Instantiate( prefab );
                newModule.name = prefab.name;
                newModule.transform.SetParent( vehicle.transform );

                gameObject.GetComponent<VehicleCreationStateMachine>().SwitchState<Engine>();
            } );
        }
    }

    public override void OnDestroy()
    {
        Destroy( menu );
        canvas = null;
    }
}
