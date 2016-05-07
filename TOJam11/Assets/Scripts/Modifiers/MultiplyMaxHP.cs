using UnityEngine;
using System.Collections;

public class MultiplyMaxHP : CarModifier
{

    public float multiplier = 2;
    LensToken token;

    void Start()
    {
        token = car.maxHealth.AddLens(new Lens<float>(100, (x) => x * multiplier));
    }
}
