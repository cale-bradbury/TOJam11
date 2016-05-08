using UnityEngine;
using System.Collections;
using System;

public class Overworld : GameState
{
    // store a ref active node

    GameStateMachine gsm;
    MapController activeLevel;

    public override void Awake()
    {
        gsm = GetComponent<GameStateMachine>();
        // When there is more than one level, we will need to request specific levels.
        GameObject g = Instantiate<GameObject>(Resources.Load<GameObject>("Levels/LevelOneMapController"));
        activeLevel = g.GetComponent<MapController>();
        activeLevel.overworld = this;
    }

    public override void Update()
    {
        
    }

    public override void OnDestroy()
    {
        if(activeLevel != null)
        {
            Destroy(activeLevel.gameObject);
        }
    }

    public void StartEncounter(LocationNode node, bool isRandomEncounter) {
        // TODO:
        // Once battles are developed, we will need to do some configuring based on data in the node
        // to ensure the correct battle state is entered.
        //TODO:
        // cache a reference to this node's name or ID so that if the player comes back to this state they are at the correct node.
        gsm.SwitchState<Battle>();
    }
}
