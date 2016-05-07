using UnityEngine;
using System.Collections.Generic;

public class CAMove : CarAction {

    public int distance;

    public override void Start()
    {
        base.Start();
    }

    override public void Perform(ActionCallback callback)
    {
       base.Perform(callback);
       List<GridTile> g = car.tile.grid.GetSuroundingDiamond(car.tile, distance);
       car.tile.grid.RemoveCarTiles(g);
       car.tile.grid.ShowSelection(g, SelectCallback);
   }

   void SelectCallback(GridTile selection)
   {
       if (selection.car != null)
       {
           Perform(finishedAction);
           return;
       }
       car.tile = selection;
       finishedAction();
   }


}
