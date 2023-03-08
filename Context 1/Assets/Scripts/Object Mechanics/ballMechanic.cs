using System;
using UnityEngine;

public class ballMechanic : MechanicController
{
    private const float groundLength = 0.6f;
    private const float bounceStrength = 10f;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool onGround = Physics2D.RaycastAll(transform.position, Vector2.down, groundLength * transform.localScale.y).Length > 1; //Detects object other than self
        if(onGround)
        {
            body.velocity = new Vector2(body.velocity.x, bounceStrength);
        }
    }
}
