using System;
using UnityEngine;

public class wideShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-0.3935376f, 0.01331377f),
            new Vector2(-0.3815019f, -0.4202704f),
            new Vector2(0.4497483f, -0.4189224f),
            new Vector2(0.4272387f, 0.001976967f)
        };

        base.Awake();
    }
}
