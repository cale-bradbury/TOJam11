using UnityEngine;
using System.Collections.Generic;

public class CAAddObject : CarAction
{
    public GameObject prefab;
    public bool canAddToTeam;
    public bool canAddToEnemy;
    public int range = 3;
    public Color selectColor = Color.blue;
    List<GridTile> g;

    override public void Perform(ActionCallback callback)
    {
        canCancel = true;
        base.Perform(callback);
        g = grid.GetSuroundingDiamond(car.tile, range);
        if (!canAddToEnemy)
            grid.RemoveSquadTiles(g, !car.isPlayer);
        if (!canAddToTeam)
            grid.RemoveSquadTiles(g, car.isPlayer);

        grid.ShowSelection(g, SelectCallback, selectColor);
    }

    public override bool PerformAI(CarAction.ActionCallback callback)
    {
        base.PerformAI(callback);

        g = grid.GetSuroundingDiamond(car.tile, range);
        grid.RemoveEmptyTiles(g);
        if (!canAddToEnemy)
            grid.RemoveSquadTiles(g, !car.isPlayer);
        if (!canAddToTeam)
            grid.RemoveSquadTiles(g, car.isPlayer);

        if (g.Count == 0)
        {
            return false;
        }
        grid.ColorSelection(g, selectColor);
        Invoke("AISelect", Settings.aiSpeed);
        return true;
    }

    public void AISelect()
    {
        SelectCallback(g[Mathf.FloorToInt(Random.value * g.Count)]);
    }

    void SelectCallback(GridTile selection)
    {
        if (selection.car == null)
        {
            Perform(finishedAction);
            return;
        }
        canCancel = false;
        GameObject o = Instantiate<GameObject>(prefab);
        o.transform.parent = selection.car.transform;
        o.transform.localPosition = Vector3.zero;
        o.transform.localEulerAngles = Vector3.zero;
        o.transform.localScale = Vector3.one;
        Invoke("EndTurn", Settings.turnDelay);
    }
}
