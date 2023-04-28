using System;
using UnityEngine;

public class TNTShape : ShapeController
{
    protected override void Awake()
    {
        colliderPath = new[] {
            new Vector2(-0.2236027f, 0.2115664f),
            new Vector2(-0.2476265f, -0.4418807f),
            new Vector2(0.1944112f, -0.4538927f),
            new Vector2(0.1872041f, 0.1995544f)
        };

        base.Awake();
    }
}
