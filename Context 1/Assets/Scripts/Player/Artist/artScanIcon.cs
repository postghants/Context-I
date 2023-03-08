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
        spriteRenderer.sprite = ShapeController.GetIcon(shape);
    }
}
