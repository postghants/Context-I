using System;
using UnityEngine;

public class ballMechanic : MechanicController
{
    private const float boundarySize = 0.05f;
    private const float bounceStrength = 10f;

    private Rigidbody2D body;
    private Collider2D colliderShape;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        colliderShape = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        Vector2 topLeft = new Vector2(colliderShape.bounds.min.x + boundarySize, colliderShape.bounds.min.y - boundarySize);
        Vector2 bottomRight = topLeft + new Vector2(colliderShape.bounds.size.x - 2 * boundarySize, -1 * boundarySize);
        bool onGround = Physics2D.OverlapArea(topLeft, bottomRight); // Checks area underneath
        if(onGround)
        {
            body.velocity = new Vector2(body.velocity.x, bounceStrength);
        }
    }
}
