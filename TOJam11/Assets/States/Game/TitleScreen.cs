using UnityEngine;
using System.Collections;
using System;

public class TitleScreen : GameState
{
    GameStateMachine gsm;
    GameObject canvas;
    GameObject titleScreenMenu;

    public override void Awake()
    {
        gsm = GetComponent<GameStateMachine>();
        canvas = GameObject.Find( "Canvas" );
        titleScreenMenu = Instantiate<GameObject>( Resources.Load<GameObject>( "Menus/Title Screen" ) );
        titleScreenMenu.GetComponent<RectTransform>().SetParent( canvas.GetComponent<RectTransform>(), false);     
    }

    public override void Update()
    {
        if( Input.anyKey )
        {
            // gsm.SwitchState<VehicleCreation>();
            gsm.SwitchState<Overworld>();
        }
    }

    public override void OnDestroy()
    {
        Destroy( titleScreenMenu );
        canvas = null;
    }
}
