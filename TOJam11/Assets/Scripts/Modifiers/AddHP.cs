using UnityEngine;
using System.Collections;

public class AddHP : CarModifier
{
    public float hp = 1;

    public override void Start()
    {
        base.Start();
        token = car.health.AddLens(new Lens<float>(0, (x) => x + hp));
    }
}
