using System;
using UnityEngine;

public class artProjectileController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Type heldShape;
    public float speed;
    public Vector2 direction;
    public float lifespan;

    public void SetIconShape(Type shape)
    {
        spriteRenderer.sprite = ShapeController.GetIcon(shape);
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        lifespan -= Time.deltaTime;
        if(lifespan <= 0)
        {
            DestroySelf();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ShapeController sc = other.GetComponent<ShapeController>();
        characterJump characterJump = other.GetComponent<characterJump>();
        if(sc != null)
        {
            sc.SwapShape(heldShape);
            DestroySelf();
        }
        else if(characterJump != null)
        {
            return;
        }
        else
        {
            DestroySelf();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
