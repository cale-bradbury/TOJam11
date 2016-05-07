using UnityEngine;
using System.Collections;

public class CAMove : CarAction {

    public int distance;    

   override public void Perform(){
       base.Perform();
       Debug.Log(car.tile);
       car.tile.grid.ShowSelection(car.tile.grid.GetSuroundingDiamond(car.tile, distance), SelectCallback);
   }

   void SelectCallback(GridTile selection)
   {
       car.tile = selection;
       BattleManager.Next();
   }


}
