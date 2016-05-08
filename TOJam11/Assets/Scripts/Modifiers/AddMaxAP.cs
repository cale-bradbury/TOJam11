using UnityEngine;
using System.Collections;

public class AddMaxAP : CarModifier
{

    public float ap = 1;
    LensToken token;

    public override void Start()
    {
        base.Start();
        token = car.maxAP.AddLens(new Lens<float>(0, (x) => x + ap));
    }
}
