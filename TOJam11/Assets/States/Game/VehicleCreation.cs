using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class VehicleCreation : GameState
{
    GameStateMachine gsm;
    GameObject canvas;
    GameObject vehicleCreationMenu;

    VehicleCreationStateMachine vcsm;

    public override void Awake()
    {
        gsm = GetComponent<GameStateMachine>();
        canvas = GameObject.Find( "Canvas" );
        vehicleCreationMenu = Instantiate<GameObject>( Resources.Load<GameObject>( "Menus/Vehicle Creation" ) );
        vehicleCreationMenu.GetComponent<RectTransform>().SetParent( canvas.GetComponent<RectTransform>(), false );

        foreach( var button in vehicleCreationMenu.GetComponentsInChildren<Button>() )
        {
            if( button.GetComponent<BackButton>() == null ) continue;

            button.onClick.AddListener( () =>
            {
                gsm.SwitchState<TitleScreen>();
            } );
        }


        vcsm = gameObject.AddComponent<VehicleCreationStateMachine>();
        vcsm.SwitchState<Chassis>();
    }

    public override void Update()
    {
        
    }

    public override void OnDestroy()
    {
        Destroy( vehicleCreationMenu );
        Destroy( vcsm );
    }
}
