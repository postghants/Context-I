using System;
using UnityEngine;

public class artScanIcon : MonoBehaviour
{
    public Type heldShape;
    public SpriteRenderer spriteRenderer;

    public void Awake()
    {
        transform.parent = null;
    }

    public void SetIconShape(Type shape)
    {
        spriteRenderer.sprite = Resources.Load<Sprite>("Icons/" + shape.Name + "Icon");
    }
}
