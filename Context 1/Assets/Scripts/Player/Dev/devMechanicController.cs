using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class devMechanicController : MonoBehaviour
{
    public Type heldMechanic;
    public Transform aimArrow;
    public devUIController devUI;
    public movementLimiter movementLimiter;
    public AudioSource shootAudio;
    public AudioSource suckAudio;

    public devScanIcon devScanIcon;
    public Vector3 scanIconOffset;
    public float scanRadius;
    [HideInInspector] public MechanicController closestMechanic;
    [HideInInspector] public float closestMechanicDistance;

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

            suckAudio.Play();
            if(closestMechanic != null) 
                ChangeHeldMechanic(closestMechanic.GetMechanic());
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
        ScanForMechanics();
        if (aiming)
        {
            aimArrow.SetPositionAndRotation(aim * aimArrowOffset + new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, aimAngle));
        }
    }

    public void ScanForMechanics()
    {
        closestMechanic = null;
        closestMechanicDistance = scanRadius;
        Collider2D[] colliderList = Physics2D.OverlapCircleAll(transform.position, scanRadius);
        Debug.Log(colliderList.Length);
        for(int i = 0; i < colliderList.Length; i++)
        {
            MechanicController mc = colliderList[i].GetComponent<MechanicController>();
            if(mc != null)
            {
                if(Vector2.Distance(mc.transform.position, transform.position) < closestMechanicDistance)
                {
                    closestMechanicDistance = Vector2.Distance(mc.transform.position, transform.position);
                    closestMechanic = mc;
                }
            }
        }
        if(closestMechanic != null)
        {
            devScanIcon.gameObject.SetActive(true);
            devScanIcon.transform.position = closestMechanic.transform.position + scanIconOffset;
            devScanIcon.SetIconMechanic(closestMechanic.GetMechanic());
        }
        else
        {
            devScanIcon.gameObject.SetActive(false);
        }
    }

    public void ChangeHeldMechanic(Type newMechanic)
    {
        heldMechanic = newMechanic;
        devUI.SetIconMechanic(newMechanic);
    }

    public void ShootProjectile()
    {
        if (heldMechanic != null)
        {
            if (shootAudio.isPlaying)
            {
                shootAudio.Stop();
            }
            shootAudio.Play();
            GameObject projectile = Instantiate(projectilePrefab);
            devProjectileController dpc = projectile.GetComponent<devProjectileController>();
            dpc.transform.position = new Vector2(transform.position.x, transform.position.y) + aim * projectileSpawnOffset;
            dpc.heldMechanic = heldMechanic;
            dpc.speed = projectileSpeed;
            dpc.direction = aim;
            dpc.lifespan = projectileLifespan;
        }
    }
}
