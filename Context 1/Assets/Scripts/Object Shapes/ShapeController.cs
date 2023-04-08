using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public abstract class ShapeController : MonoBehaviour
{
    [SerializeField] private bool applyInstantly;
    private float bumpStrength = 2f;
    private float shapeChangeDuration = 0.8f;
    private float shapeChangeState = 0f;
    private bool shapeChangeDone = false;
    protected Vector2[] colliderPath;

    private PolygonCollider2D colliderShape;
    private Rigidbody2D body;
    private SpriteSkin spriteSkin;
    private Vector2[] oldColliderPath;

    protected virtual void Awake()
    {
        colliderShape = GetComponent<PolygonCollider2D>();
        spriteSkin = GetComponent<SpriteSkin>();
        body = GetComponent<Rigidbody2D>();
        oldColliderPath = colliderShape.GetPath(0);
        if(colliderPath == null) colliderPath = new[] {
            new Vector2(-0.5f, 0.5f),
            new Vector2(-0.5f, -0.5f),
            new Vector2(0.5f, -0.5f),
            new Vector2(0.5f, 0.5f)
        }; //Set Collider to basic Square

        if (applyInstantly)
        {
            colliderShape.SetPath(0, colliderPath);
            for (int i = 0; i < oldColliderPath.Length; i++)
            {
                spriteSkin.boneTransforms[i].localPosition = colliderPath[i];
            }

            shapeChangeDone = true;
        } else
        {
            body.velocity += new Vector2(0, bumpStrength);
        }
    }

    protected virtual void FixedUpdate()
    {
        if (!shapeChangeDone) {
            shapeChangeState += Time.fixedDeltaTime;
            shapeChangeState = Mathf.Min(shapeChangeState, shapeChangeDuration);

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
