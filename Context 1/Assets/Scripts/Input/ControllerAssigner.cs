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

    public void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var index = playerInput.playerIndex;
        var jumps = FindObjectsOfType<characterJump>();
        characterJump = jumps.FirstOrDefault(m => m.GetPlayerIndex() == index);
        characterMovement = characterJump.GetComponent<characterMovement>();
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
}
