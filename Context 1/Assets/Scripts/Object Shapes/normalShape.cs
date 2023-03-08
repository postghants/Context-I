using System;
using UnityEngine;

public class normalShape : ShapeController
{
    protected override void Awake()
    {
        xScale = 1f;
        yScale = 1f;

        base.Awake();
    }
}
