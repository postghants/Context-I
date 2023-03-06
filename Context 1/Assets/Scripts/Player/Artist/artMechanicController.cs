using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class artMechanicController : MonoBehaviour
{


    public void OnAction1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            print("Art mechanic 1");
        }
    }
    public void OnAction2(InputAction.CallbackContext context)
    {

    }
}
