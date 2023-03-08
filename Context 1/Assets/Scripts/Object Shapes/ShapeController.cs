using System;
using UnityEngine;

public abstract class ShapeController : MonoBehaviour
{
    [SerializeField] private bool applyInstantly;
    private float shapeChangeDuration = 0.8f;
    private float shapeChangeState = 0f;
    private bool shapeChangeDone = false;

    protected float xScale = 1f;
    protected float yScale = 1f;

    private Vector3 oldScale;
    private float sizeFactor;

    protected virtual void Awake()
    {
        oldScale = transform.localScale;
        sizeFactor = transform.localScale.z;

        if (applyInstantly)
        {
            transform.localScale = new Vector3(xScale * sizeFactor, yScale * sizeFactor, oldScale.z);
            shapeChangeDone = true;
        }
    }

    protected virtual void FixedUpdate()
    {
        if (!shapeChangeDone) {
            shapeChangeState += Time.fixedDeltaTime;
            shapeChangeState = Mathf.Min(shapeChangeState, shapeChangeDuration);

            transform.localScale = Vector3.Lerp(oldScale, new Vector3(xScale * sizeFactor, yScale * sizeFactor, oldScale.z), shapeChangeState / shapeChangeDuration);

            if (shapeChangeState >= shapeChangeDuration) shapeChangeDone = true;
        }
    }

    public void SwapShape(Type newShapeType)
    {
        Destroy(this);
        transform.gameObject.AddComponent(newShapeType);
    }

    public Type GetShape()
    {
        return this.GetType();
    }

    public static Sprite GetIcon(Type shape)
    {
        return Resources.Load<Sprite>("Icons/" + shape.Name + "Icon");
    }
}
