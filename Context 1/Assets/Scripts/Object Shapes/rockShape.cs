using System;
using UnityEngine;

public class rockShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-0.1838882f, 0.4480977f),
            new Vector2(-0.1868111f, -0.4453743f),
            new Vector2(0.3097871f, -0.4517894f),
            new Vector2(0.307664f, 0.4376268f)
        };

        base.Awake();
    }
}
