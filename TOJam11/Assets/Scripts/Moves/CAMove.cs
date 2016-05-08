using UnityEngine;
using System.Collections.Generic;

public class CAMove : CarAction {

    public int distance;
    List<GridTile> g;

    public override void Start()
    {
        base.Start();
    }

    override public void Perform(ActionCallback callback)
    {
       base.Perform(callback);
       canCancel = true;
       g = car.tile.grid.GetSuroundingDiamond(car.tile, distance);
       car.tile.grid.RemoveCarTiles(g);
       car.tile.grid.ShowSelection(g, SelectCallback, Color.green);
   }

    public override void PerformAI(CarAction.ActionCallback callback)
    {
        base.PerformAI(callback);
        g = car.tile.grid.GetSuroundingDiamond(car.tile, distance);
        car.tile.grid.RemoveCarTiles(g);
        car.tile.grid.ColorSelection(g, Color.green);
        Invoke("AISelect",.3f);
    }

    public void AISelect()
    {
        SelectCallback(g[Mathf.FloorToInt(Random.value * g.Count)]);
    }

   void SelectCallback(GridTile selection)
   {
       canCancel = false;
       car.tile = selection;
       Invoke("EndTurn", .3f);
   }


}
