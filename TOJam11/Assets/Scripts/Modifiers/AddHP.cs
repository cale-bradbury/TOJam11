using UnityEngine;
using System.Collections;

public class AddHP : CarModifier
{
    public float hp = 1;

    void Start()
    {
        token = car.health.AddLens(new Lens<float>(0, (x) => x + hp));
    }
}
