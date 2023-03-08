using System;
using UnityEngine;

public class enemyMechanic : MechanicController
{
    private const float boundarySize = 0.05f;
    private const float speed = 2f;

    private Rigidbody2D body;
    private Collider2D colliderShape;
    private SpriteRenderer sprite;
    private int direction = 1;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        colliderShape = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        body.constraints ^= RigidbodyConstraints2D.FreezePositionX; //Toggle X-constraint
    }

    private void FixedUpdate()
    {
        Vector2 topCorner = new Vector2(colliderShape.bounds.center.x + direction * (colliderShape.bounds.extents.x + boundarySize), colliderShape.bounds.max.y - boundarySize);
        Vector2 bottomCorner = topCorner + new Vector2(direction * boundarySize, 2 * boundarySize - colliderShape.bounds.size.y);
        bool hitWall = Physics2D.OverlapArea(topCorner, bottomCorner); // Checks area in front
        if(hitWall)
        {
            direction *= -1;
        }

        body.velocity = new Vector2(speed * direction, body.velocity.y);
        sprite.flipX = (direction == -1);
    }

    private void OnDestroy()
    {
        body.constraints ^= RigidbodyConstraints2D.FreezePositionX; //Toggle X-constraint
    }
}
