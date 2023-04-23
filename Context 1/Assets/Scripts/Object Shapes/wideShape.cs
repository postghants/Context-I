using System;
using UnityEngine;

public class wideShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-0.4447929f, 0.1903913f),
            new Vector2(-0.4486662f, -0.1317008f),
            new Vector2(0.4427658f, -0.1304383f),
            new Vector2(0.4196959f, 0.1912456f)
        };

        base.Awake();
    }
}
