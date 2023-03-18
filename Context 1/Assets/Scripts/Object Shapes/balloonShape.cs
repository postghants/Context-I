using System;
using UnityEngine;

public class balloonShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(0.008508205f, 0.4798732f),
            new Vector2(-0.2493515f, 0.2731209f),
            new Vector2(-0.03330708f, -0.1148305f),
            new Vector2(0.2501068f, 0.2289824f)
        };

        base.Awake();
    }
}
