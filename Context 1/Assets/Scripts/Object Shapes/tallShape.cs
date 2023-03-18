using System;
using UnityEngine;

public class tallShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-0.15f, 0.5f),
            new Vector2(-0.3f, -1f),
            new Vector2(0.3f, -1f),
            new Vector2(0.18f, 0.5f)
        };

        base.Awake();
    }
}
