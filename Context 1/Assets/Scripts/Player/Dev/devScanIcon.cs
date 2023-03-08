using System;
using UnityEngine;

public class devScanIcon : MonoBehaviour
{
    public Type heldMechanic;
    public SpriteRenderer spriteRenderer;

    public void Awake()
    {
        transform.parent = null;
    }

    public void SetIconMechanic(Type mechanic)
    {
        spriteRenderer.sprite = Resources.Load<Sprite>("Icons/" + mechanic.Name + "Icon");
    }
}
