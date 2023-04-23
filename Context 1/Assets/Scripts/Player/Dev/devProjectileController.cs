using System;
using UnityEngine;

public class devProjectileController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Type heldMechanic;
    public float speed;
    public Vector2 direction;
    public float lifespan;

    public void SetIconMechanic(Type mechanic)
    {
        spriteRenderer.sprite = MechanicController.GetIcon(mechanic);
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
        MechanicController mc = other.GetComponent<MechanicController>();
        characterJump characterJump = other.GetComponent<characterJump>();
        if(mc != null)
        {
            mc.SwapMechanic(heldMechanic);
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
