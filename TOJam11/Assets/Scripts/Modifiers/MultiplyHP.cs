using UnityEngine;
using System.Collections;

public class MultiplyHP : CarModifier
{

    public float multiplier = 2;
    LensToken token;

    void Start()
    {
        token = car.health.AddLens(new Lens<float>(100, (x) => x * multiplier));
    }
}
