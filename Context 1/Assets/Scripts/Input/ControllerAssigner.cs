using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class ControllerAssigner : MonoBehaviour
{
    private PlayerInput playerInput;
    private characterJump characterJump;
    private characterMovement characterMovement;
    private devMechanicController devMechanicController;
    private artMechanicController artMechanicController;

    public void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var index = playerInput.playerIndex;
        var jumps = FindObjectsOfType<characterJump>();
        characterJump = jumps.FirstOrDefault(m => m.GetPlayerIndex() == index);
        characterMovement = characterJump.GetComponent<characterMovement>();
        devMechanicController = characterJump.GetComponent<devMechanicController>();
        artMechanicController = characterJump.GetComponent<artMechanicController>();

        this.gameObject.name = "P" + (index + 1).ToString() + " Input Handler";
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        characterJump.OnJump(context);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        characterMovement.OnMovement(context);
    }

    public void OnAction1(InputAction.CallbackContext context)
    {
        if(devMechanicController != null)
        {
            devMechanicController.OnAction1(context);
        }
        if(artMechanicController != null) 
        {
            artMechanicController.OnAction1(context);
        }
    }
    public void OnAction2(InputAction.CallbackContext context)
    {
        if (devMechanicController != null)
        {
            devMechanicController.OnAction2(context);
        }
        if (artMechanicController != null)
        {
            artMechanicController.OnAction2(context);
        }
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        if (devMechanicController != null)
        {
            if (context.ReadValue<Vector2>() != Vector2.zero)
            {
                devMechanicController.aim = context.ReadValue<Vector2>().normalized;
                devMechanicController.aimAngle = Vector2.SignedAngle(Vector2.up, context.ReadValue<Vector2>());
            }
        }

        if (artMechanicController != null)
        {
            if (context.ReadValue<Vector2>() != Vector2.zero)
            {
                artMechanicController.aim = context.ReadValue<Vector2>().normalized;
                artMechanicController.aimAngle = Vector2.SignedAngle(Vector2.up, context.ReadValue<Vector2>());
            }
        }
    }
}
