using System;
using UnityEngine;

public class enemyMechanic : MechanicController
{
    private const float wallWidth = 0.6f;
    private const float speed = 5f;

    private Rigidbody2D body;
    private int direction = 1;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.constraints ^= RigidbodyConstraints2D.FreezePositionX; //Toggle X-constraint
    }

    private void Update()
    {
        bool hitWall = Physics2D.RaycastAll(transform.position, new Vector2(direction, 0), wallWidth * transform.localScale.x).Length > 1; //Detects object other than self
        if (hitWall)
        {
            direction *= -1;
        }

        body.velocity = new Vector2(speed * direction, body.velocity.y);
    }

    private void OnDestroy()
    {
        body.constraints ^= RigidbodyConstraints2D.FreezePositionX; //Toggle X-constraint
    }
}
