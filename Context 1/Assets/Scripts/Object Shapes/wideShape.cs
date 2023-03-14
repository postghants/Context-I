using System;
using UnityEngine;

public class wideShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-1.2f, 0.3f),
            new Vector2(-1.2f, -0.3f),
            new Vector2(1.2f, -0.3f),
            new Vector2(1.2f, 0.3f)
        };

        base.Awake();
    }
}
