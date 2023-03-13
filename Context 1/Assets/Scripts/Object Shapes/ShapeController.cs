using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public abstract class ShapeController : MonoBehaviour
{
    [SerializeField] private bool applyInstantly;
    private float shapeChangeDuration = 0.8f;
    private float shapeChangeState = 0f;
    private bool shapeChangeDone = false;

    protected float xScale = 1f;
    protected float yScale = 1f;
    protected Vector2[] colliderPath;

    private Vector3 oldScale;
    private float sizeFactor;
    private PolygonCollider2D colliderShape;
    private SpriteSkin spriteSkin;
    private Vector2[] oldColliderPath;

    protected virtual void Awake()
    {
        colliderShape = GetComponent<PolygonCollider2D>();
        spriteSkin = GetComponent<SpriteSkin>();
        oldColliderPath = colliderShape.GetPath(0);
        if(colliderPath == null) colliderPath = new[] {
            new Vector2(-0.5f, 0.5f),
            new Vector2(-0.5f, -0.5f),
            new Vector2(0.5f, -0.5f),
            new Vector2(0.5f, 0.5f)
        }; //Set Collider to basic Square

        oldScale = transform.localScale;
        sizeFactor = transform.localScale.z;

        if (applyInstantly)
        {
            transform.localScale = new Vector3(xScale * sizeFactor, yScale * sizeFactor, oldScale.z);
            colliderShape.SetPath(0, colliderPath);
            for (int i = 0; i < oldColliderPath.Length; i++)
            {
                spriteSkin.boneTransforms[i].localPosition = colliderPath[i];
            }

            shapeChangeDone = true;
        }
    }

    protected virtual void FixedUpdate()
    {
        if (!shapeChangeDone) {
            shapeChangeState += Time.fixedDeltaTime;
            shapeChangeState = Mathf.Min(shapeChangeState, shapeChangeDuration);

            transform.localScale = Vector3.Lerp(oldScale, new Vector3(xScale * sizeFactor, yScale * sizeFactor, oldScale.z), shapeChangeState / shapeChangeDuration);

            List<Vector2> newColliderPath = new();
            for(int i = 0; i < oldColliderPath.Length; i++)
            {
                Vector2 newPoint = Vector2.Lerp(oldColliderPath[i], colliderPath[i], shapeChangeState / shapeChangeDuration);
                newColliderPath.Add(newPoint);
                spriteSkin.boneTransforms[i].localPosition = newPoint;
            }
            colliderShape.SetPath(0, newColliderPath);

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
