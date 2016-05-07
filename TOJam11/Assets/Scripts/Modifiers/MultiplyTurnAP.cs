using UnityEngine;
using System.Collections;

public class MultiplyTurnAP : CarModifier
{
    public float multiplier = 1;
    LensToken token;

    void Start()
    {
        token = car.turnAP.AddLens(new Lens<float>(100, (x) => x * multiplier));
    }
}
