using UnityEngine;
using System.Collections;

public class CAMoveWarp : CarAction {
    
    override public void Perform()
    {
        base.Perform();
        GetTile();
    }

    void GetTile()
    {
        GridTile g = car.tile.grid.GetRandom();
        if (g.car != null)
        {
            GetTile();
            return;
        }
        car.tile = g;
        BattleManager.Next();
    }

}
