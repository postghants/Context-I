using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonMechanic : MechanicController
{
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale *= -1;
    }

    private void OnDestroy()
    {
        body.gravityScale *= -1;
    }
}
