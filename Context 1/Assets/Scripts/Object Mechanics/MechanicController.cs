using System;
using UnityEngine;

public abstract class MechanicController : MonoBehaviour
{
    public static Sprite GetIcon(Type mechanic)
    {
        return Resources.Load<Sprite>("Icons/" + mechanic.Name + "Icon");
    }

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
