using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class artMechanicController : MonoBehaviour
{
    public Type heldShape;
    public Transform aimArrow;
    public artUIController artUI;
    public ParticleSystem scanParticles;
    public movementLimiter movementLimiter;
    public AudioSource shootAudio;
    public AudioSource suckAudio;

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
        if (context.started)
        {
            if (suckAudio.isPlaying)
                suckAudio.Stop();
            if (scanParticles.isPlaying)
                scanParticles.Stop();

            suckAudio.Play();
            scanParticles.Play();
            if (closestShape != null)
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
        artUI.SetIconShape(newShape);
    }

    public void ShootProjectile()
    {
        if (heldShape != null)
        {
            if (shootAudio.isPlaying)
            {
                shootAudio.Stop();
            }
            shootAudio.Play();
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
