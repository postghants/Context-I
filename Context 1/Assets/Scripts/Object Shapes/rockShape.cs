using System;
using UnityEngine;

public class rockShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-0.2499785f, 0.2086034f),
            new Vector2(-0.3916478f, -0.3407087f),
            new Vector2(0.3968053f, -0.3405318f),
            new Vector2(0.29849f, 0.2058749f)
        };

        base.Awake();
    }
}
