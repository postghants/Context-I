using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class artUIController : MonoBehaviour
{
    public Type heldShape;
    public Image image;

    public void SetIconShape(Type shape)
    {
        heldShape = shape;
        image.color = Color.white;
        image.sprite = MechanicController.GetIcon(shape);
        if(shape == null)
        {
            image.color = Color.clear;
        }
    }
}