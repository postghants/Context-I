using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devScanIcon : MonoBehaviour
{
    public MechanicController.Mechanic heldMechanic;
    public SpriteRenderer spriteRenderer;

    public Sprite doorMechanicSprite;
    public Sprite enemyMechanicSprite;
    public Sprite ballMechanicSprite;
    public Sprite balloonMechanicSprite;
    public Sprite rockMechanicSprite;

    public void Awake()
    {
        transform.parent = null;
    }

    public void SetIconMechanic(MechanicController.Mechanic mechanic)
    {
        heldMechanic = mechanic;

        switch (heldMechanic)
        {
            case MechanicController.Mechanic.None:
                spriteRenderer.sprite = null; break;
            case MechanicController.Mechanic.Door: 
                spriteRenderer.sprite = doorMechanicSprite; break;
            case MechanicController.Mechanic.Enemy:
                spriteRenderer.sprite = enemyMechanicSprite; break;
            case MechanicController.Mechanic.Ball:
                spriteRenderer.sprite = ballMechanicSprite; break;
            case MechanicController.Mechanic.Balloon:
                spriteRenderer.sprite = balloonMechanicSprite; break;
            case MechanicController.Mechanic.Rock:
                spriteRenderer.sprite = rockMechanicSprite; break;
        }
    }
}
