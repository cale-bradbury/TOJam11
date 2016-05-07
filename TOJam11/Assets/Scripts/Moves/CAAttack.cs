using UnityEngine;
using System.Collections.Generic;

public class CAAttack : CarAction
{
    public int distance;
    public float damage;
    List<GridTile> g;

    public override void Start()
    {
        base.Start();
    }

    override public void Perform(ActionCallback callback)
    {
        base.Perform(callback);
        g = car.tile.grid.GetSuroundingDiamond(car.tile, distance);
        car.tile.grid.ShowSelection(g, SelectCallback, Color.red);
    }

    public override void PerformAI(CarAction.ActionCallback callback)
    {
        base.PerformAI(callback);
        g = car.tile.grid.GetSuroundingDiamond(car.tile, distance);
        car.tile.grid.RemoveCarTiles(g);
        car.tile.grid.ColorSelection(g, Color.red);
        Invoke("AISelect", .5f);
    }

    public void AISelect()
    {
        SelectCallback(g[Mathf.FloorToInt(Random.value * g.Count)]);
    }

    void SelectCallback(GridTile selection)
    {
        if (selection.car == null || selection.car.isPlayer==car.isPlayer)
        {
            Perform(finishedAction);
            return;
        }
        selection.car.Damage(damage);
        Invoke("EndTurn", .3f);
    }
}
