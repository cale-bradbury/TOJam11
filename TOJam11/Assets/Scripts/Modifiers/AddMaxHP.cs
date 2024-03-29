﻿using UnityEngine;
using System.Collections;

public class AddMaxHP : CarModifier
{
    public float hp = 1;

    public override void Start()
    {
        base.Start();
        token = car.maxHealth.AddLens(new Lens<float>(0, (x) => x + hp));
    }
}
