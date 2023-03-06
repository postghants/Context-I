using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class devMechanicController : MonoBehaviour
{
    public MechanicController.Mechanic heldMechanic;

    public bool aiming = false;
    public Vector2 aim;
    public float aimAngle;

    public void OnAction1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            print("Dev mechanic 1");
        }
    }
    public void OnAction2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            aiming = true;
        }

        if (context.canceled)
        {
            aiming = false;
        }
    }

    private void Update()
    {
        if (aiming)
        {

        }
    }
}
