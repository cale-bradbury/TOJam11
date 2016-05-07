using UnityEngine;
using System.Collections;

public class MultiplyMaxAP : CarModifier
{

    public float multiplier = 1;
    LensToken token;

    void Start()
    {
        token = car.maxAP.AddLens(new Lens<float>(100, (x) => x * multiplier));
    }

}
