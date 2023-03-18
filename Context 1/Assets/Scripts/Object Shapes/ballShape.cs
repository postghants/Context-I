using System;
using UnityEngine;

public class ballShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(0.0287447f, 0.2874613f),
            new Vector2(-0.3554473f, -0.1322727f),
            new Vector2(0.0270524f, -0.4487658f),
            new Vector2(0.382472f, -0.1390424f)
        };

        base.Awake();
    }
}
