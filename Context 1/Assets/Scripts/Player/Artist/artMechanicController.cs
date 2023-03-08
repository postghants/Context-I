using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class artMechanicController : MonoBehaviour
{
    public Type heldShape;
    public Transform aimArrow;
    public movementLimiter movementLimiter;

    public artScanIcon artScanIcon;
    public Vector3 scanIconOffset;
    public float scanRadius;
    [HideInInspector] public ShapeController closestShape;
    [HideInInspector] public float closestShapeDistance;


    public bool aiming = false;
    public Vector2 aim;
    public float aimAngle;

    public float aimArrowOffset = 2;

    public GameObject projectilePrefab;
    public float projectileSpeed;
    public float projectileSpawnOffset;
    public float projectileLifespan;

    public void OnAction1(InputAction.CallbackContext context)
    {
        if (context.started && closestShape != null)
        {
            ChangeHeldShape(closestShape.GetShape());
        }
    }
    public void OnAction2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            aiming = true;
            aimArrow.gameObject.SetActive(true);
            movementLimiter.characterCanMove = false;

        }

        if (context.canceled)
        {
            aiming = false;
            aimArrow.gameObject.SetActive(false);
            ShootProjectile();
            movementLimiter.characterCanMove = true;
        }
    }

    private void Update()
    {
        ScanForShapes();
        if (aiming)
        {
            aimArrow.SetPositionAndRotation(aim * aimArrowOffset + new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, aimAngle));
        }
    }

    public void ScanForShapes()
    {
        closestShape = null;
        closestShapeDistance = scanRadius;
        Collider2D[] colliderList = Physics2D.OverlapCircleAll(transform.position, scanRadius);
        Debug.Log(colliderList.Length);
        for(int i = 0; i < colliderList.Length; i++)
        {
            ShapeController sc = colliderList[i].GetComponent<ShapeController>();
            if(sc != null)
            {
                if(Vector2.Distance(sc.transform.position, transform.position) < closestShapeDistance)
                {
                    closestShapeDistance = Vector2.Distance(sc.transform.position, transform.position);
                    closestShape = sc;
                }
            }
        }
        if(closestShape != null)
        {
            artScanIcon.gameObject.SetActive(true);
            artScanIcon.transform.position = closestShape.transform.position + scanIconOffset;
            artScanIcon.SetIconShape(closestShape.GetShape());
        }
        else
        {
            artScanIcon.gameObject.SetActive(false);
        }
    }

    public void ChangeHeldShape(Type newShape)
    {
        heldShape = newShape;
    }

    public void ShootProjectile()
    {
        if (heldShape != null)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            artProjectileController apc = projectile.GetComponent<artProjectileController>();
            apc.transform.position = new Vector2(transform.position.x, transform.position.y) + aim * projectileSpawnOffset;
            apc.heldShape = heldShape;
            apc.speed = projectileSpeed;
            apc.direction = aim;
            apc.lifespan = projectileLifespan;
        }
    }
}
