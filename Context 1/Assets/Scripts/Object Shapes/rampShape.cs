using System;
using UnityEngine;

public class rampShape : ShapeController
{
    protected override void Awake()
    {
        xScale = 1f;
        yScale = 1f;

        colliderPath = new[] {
            new Vector2(0f, 0f),
            new Vector2(-0.5f, -0.5f),
            new Vector2(0.5f, -0.5f),
            new Vector2(0.5f, 0.5f)
        };

        base.Awake();
    }
}
