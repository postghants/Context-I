using System;
using UnityEngine;

public class tallShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-0.3f, 1.2f),
            new Vector2(-0.3f, -1.2f),
            new Vector2(0.3f, -1.2f),
            new Vector2(0.3f, 1.2f)
        };

        base.Awake();
    }
}
