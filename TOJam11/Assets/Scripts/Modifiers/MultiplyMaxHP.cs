using UnityEngine;
using System.Collections;

public class MultiplyMaxHP : CarModifier
{

    public float multiplier = 2;
    LensToken token;

    public override void Start()
    {
        base.Start();
        token = car.maxHealth.AddLens(new Lens<float>(100, (x) => x * multiplier));
    }
}
