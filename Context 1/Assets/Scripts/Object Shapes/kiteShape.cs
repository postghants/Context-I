using System;
using UnityEngine;

public class kiteShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-0.01343989f, 0.07317615f),
            new Vector2(-0.3150406f, -0.2196119f),
            new Vector2(0.2950745f, -0.2242103f),
            new Vector2(0.2649717f, 0.3330765f)
        };

        base.Awake();
    }
}
