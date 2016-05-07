using UnityEngine;
using System.Collections.Generic;

public class CAMove : CarAction {

    public int distance;    

   override public void Perform(){
       base.Perform();
       List<GridTile> g = car.tile.grid.GetSuroundingDiamond(car.tile, distance);
       car.tile.grid.RemoveCarTiles(g);
       car.tile.grid.ShowSelection(g, SelectCallback);
   }

   void SelectCallback(GridTile selection)
   {
       if (selection.car != null)
       {
           Perform();
           return;
       }
       car.tile = selection;
       BattleManager.Next();
   }


}
