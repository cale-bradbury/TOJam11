using UnityEngine;
using System.Collections;
using System;

public class Battle : GameState
{
    GameStateMachine gsm;
    BattleManager bm;

    public override void Awake()
    {
        gsm = GetComponent<GameStateMachine>();

        // Need to add a battle manager. Also need to know which specific battle to add...
    }

    public override void OnDestroy()
    {

    }

    public override void Update()
    {

    }
}
