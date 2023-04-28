using System;
using UnityEngine;

public class carShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-0.2779145f, 0.316268f),
            new Vector2(-0.4267138f, -0.4032421f),
            new Vector2(0.4528968f, -0.4051256f),
            new Vector2(0.241941f, 0.3087339f)
        };

        base.Awake();
    }
}
