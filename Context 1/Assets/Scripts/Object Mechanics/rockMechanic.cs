using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockMechanic : MechanicController
{
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.constraints ^= RigidbodyConstraints2D.FreezePositionX; //Allow pushing
    }

    private void OnDestroy()
    {
        body.constraints ^= RigidbodyConstraints2D.FreezePositionX; //Disallow pushing
    }
}
