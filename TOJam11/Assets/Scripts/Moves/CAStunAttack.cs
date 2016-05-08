using UnityEngine;
using System.Collections.Generic;

public class CAStunAttack : CarAction
{

    public int distance;
    public float duration;
    List<GridTile> g;

    public override void Start()
    {
        base.Start();
    }

    override public void Perform(ActionCallback callback)
    {
        canCancel = true;
        base.Perform(callback);
        g = car.tile.grid.GetSuroundingDiamond(car.tile, distance);
        car.tile.grid.ShowSelection(g, SelectCallback, Color.yellow);
    }

    public override bool PerformAI(CarAction.ActionCallback callback)
    {
        base.PerformAI(callback);
        g = car.tile.grid.GetSuroundingDiamond(car.tile, distance);
        car.tile.grid.RemoveEmptyTiles(g);
        car.tile.grid.RemoveSquadTiles(g, car.isPlayer);
        if (g.Count == 0)
        {
            return false;
        }
        car.tile.grid.ColorSelection(g, Color.yellow);
        Invoke("AISelect", Settings.aiSpeed);
        return true;
    }

    public void AISelect()
    {
        SelectCallback(g[Mathf.FloorToInt(Random.value * g.Count)]);
    }

    void SelectCallback(GridTile selection)
    {
        if (selection.car == null || selection.car.isPlayer == car.isPlayer)
        {
            Perform(finishedAction);
            return;
        }
        canCancel = false;
        // selection.car.Damage(damage);
        // todo: debuff car for duration, reducing it's AP to 0
        // add a stun prefab to target car
            // this prefab should have a public duration float 
        Invoke("EndTurn", Settings.turnDelay);
    }
}
