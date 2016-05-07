using UnityEngine;
using System.Collections;

public class AddMaxAP : CarModifier
{

    public float ap = 1;
    LensToken token;

    void Start()
    {
        token = car.maxAP.AddLens(new Lens<float>(0, (x) => x + ap));
    }
}
