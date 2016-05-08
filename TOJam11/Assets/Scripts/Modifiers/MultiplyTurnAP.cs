using UnityEngine;
using System.Collections;

public class MultiplyTurnAP : CarModifier
{
    public float multiplier = 1;

    public override void Start()
    {
        base.Start();
        token = car.turnAP.AddLens(new Lens<float>(100, (x) => x * multiplier));
    }
}
