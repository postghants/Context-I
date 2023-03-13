using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class devUIController : MonoBehaviour
{
    public Type heldMechanic;
    public Image image;

    public void Awake()
    {
        
    }

    public void SetIconMechanic(Type mechanic)
    {
        heldMechanic = mechanic;
        image.color = Color.white;
        image.sprite = MechanicController.GetIcon(mechanic);
        if(mechanic == null)
        {
            image.color = Color.clear;
        }
    }
}
