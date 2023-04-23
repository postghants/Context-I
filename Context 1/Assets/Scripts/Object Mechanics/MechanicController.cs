using System;
using UnityEngine;

public abstract class MechanicController : MonoBehaviour
{
    private float bumpStrength = 2f;
    private void Start()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity += new Vector2(0, bumpStrength);
    }
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
