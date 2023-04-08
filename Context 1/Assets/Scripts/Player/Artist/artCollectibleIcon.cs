using System;
using UnityEngine;

public class artCollectibleIcon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float initialSpeed, acceleration, maxSpeed, collectRange;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Transform target;

    public void SetIconShape(Type shape)
    {
        spriteRenderer.sprite = ShapeController.GetIcon(shape);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Start()
    {
        body.velocity = new Vector2(0, initialSpeed);
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (body.velocity.magnitude > 0.5f * acceleration) body.velocity -= body.velocity.normalized * 0.5f * acceleration;
            body.velocity += (Vector2)(target.position - transform.position).normalized * acceleration;
        }

        if (body.velocity.magnitude > maxSpeed) body.velocity = body.velocity.normalized * maxSpeed;

        if ((target.position - transform.position).magnitude <= collectRange)
        {
            Destroy(this.gameObject);
        }
    }
}
