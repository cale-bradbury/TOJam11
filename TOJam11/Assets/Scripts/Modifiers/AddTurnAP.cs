using UnityEngine;
using System.Collections;

public class AddTurnAP : CarModifier
{

    public float ap = 1;
    LensToken token;

    public override void Start()
    {
        base.Start();
        token = car.turnAP.AddLens(new Lens<float>(0, (x) => x + ap));
    }
}
