using System;
using UnityEngine;

public class tallShape : ShapeController
{
    protected override void Awake()
    {
        xScale = 0.6f;
        yScale = 2.4f;

        base.Awake();
    }
}
