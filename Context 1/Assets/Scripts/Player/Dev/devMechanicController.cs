using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class devMechanicController : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab;
    [SerializeField] private float copyCooldown, pasteCooldown;
    private float currentCopyCooldown, currentPasteCooldown = 0f;
    private bool isCopyOnCooldown, isPasteOnCooldown = true;

    public Type heldMechanic;
    public Transform aimArrow;
    public devUIController devUI;
    public ParticleSystem scanParticles;
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
        
        if (context.started && !isCopyOnCooldown)
        {
            if (suckAudio.isPlaying)
                suckAudio.Stop(); 
            if (scanParticles.isPlaying)
                scanParticles.Stop();


            if (closestMechanic != null)
            {
                suckAudio.Play();
                //scanParticles.Play();
                ChangeHeldMechanic(closestMechanic.GetMechanic());
                isCopyOnCooldown = true;
            }
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
        UpdateCooldowns();

        ScanForMechanics();
        if (aiming)
        {
            aimArrow.SetPositionAndRotation(aim * aimArrowOffset + new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, aimAngle));
        }
    }

    private void UpdateCooldowns()
    {
        if (isCopyOnCooldown) currentCopyCooldown -= Time.deltaTime;
        if (isPasteOnCooldown) currentPasteCooldown -= Time.deltaTime;

        if (currentCopyCooldown <= 0f)
        {
            currentCopyCooldown = copyCooldown;
            isCopyOnCooldown = false;
        }

        if (currentPasteCooldown <= 0f)
        {
            currentPasteCooldown = pasteCooldown;
            isPasteOnCooldown = false;
        }
    }

    public void ScanForMechanics()
    {
        closestMechanic = null;
        closestMechanicDistance = scanRadius;
        Collider2D[] colliderList = Physics2D.OverlapCircleAll(transform.position, scanRadius);
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
        if(closestMechanic != null && !isCopyOnCooldown)
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
        SpawnCollectible();
    }

    private void SpawnCollectible()
    {
        CollectibleIcon collectible = Instantiate(collectiblePrefab).GetComponent<CollectibleIcon>();

        collectible.transform.position = devScanIcon.transform.position;
        collectible.SetIconType(heldMechanic);
        collectible.SetTarget(transform);
    }

    public void ShootProjectile()
    {
        if (heldMechanic != null && !isPasteOnCooldown)
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

            dpc.SetIconMechanic(heldMechanic);
            isPasteOnCooldown = true;
        }
    }
}
