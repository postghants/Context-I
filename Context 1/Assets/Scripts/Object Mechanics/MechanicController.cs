using System;
using UnityEngine;

public abstract class MechanicController : MonoBehaviour
{
    public void SwapMechanic(Type newMechanicType)
    {
        Destroy(this);
        transform.gameObject.AddComponent(newMechanicType);
    }

    public Type GetMechanic()
    {
        return this.GetType();
    }
}
