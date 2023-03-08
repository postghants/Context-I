using System;
using UnityEngine;

public class wideShape : ShapeController
{
    protected override void Awake()
    {
        xScale = 2.4f;
        yScale = 0.6f;

        base.Awake();
    }
}
