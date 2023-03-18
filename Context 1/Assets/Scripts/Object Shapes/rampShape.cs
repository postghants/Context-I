using System;
using UnityEngine;

public class rampShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-0.07208943f, -0.2021332f),
            new Vector2(-0.4856353f, -0.4058919f),
            new Vector2(0.493371f, -0.413126f),
            new Vector2(0.294435f, -0.0514245f)
        };

        base.Awake();
    }
}
