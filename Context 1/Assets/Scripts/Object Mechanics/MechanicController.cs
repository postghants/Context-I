using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicController : MonoBehaviour
{
    public enum Mechanic { None, Door, Enemy, Ball, Balloon, Rock }
    public Mechanic currentMechanic;
    private Mechanic referenceMechanic;

    public doorMechanic doorMechanic;
    public enemyMechanic enemyMechanic;
    public ballMechanic ballMechanic;
    public balloonMechanic balloonMechanic;
    public rockMechanic rockMechanic;

    private void FixedUpdate()
    {
        if (currentMechanic != referenceMechanic)
        {
            switch (referenceMechanic)
            {
                case Mechanic.None:
                    break;
                case Mechanic.Door:
                    doorMechanic.enabled = false;
                    break;
                case Mechanic.Enemy:
                    enemyMechanic.enabled = false;
                    break;
                case Mechanic.Ball:
                    ballMechanic.enabled = false;
                    break;
                case Mechanic.Balloon:
                    balloonMechanic.enabled = false;
                    break;
                case Mechanic.Rock:
                    rockMechanic.enabled = false;
                    break;
            }
            switch (currentMechanic)
            {
                case Mechanic.None:
                    break;
                case Mechanic.Door:
                    doorMechanic.enabled = true;
                    break;
                case Mechanic.Enemy:
                    enemyMechanic.enabled = true;
                    break;
                case Mechanic.Ball:
                    ballMechanic.enabled = true;
                    break;
                case Mechanic.Balloon:
                    balloonMechanic.enabled = true;
                    break;
                case Mechanic.Rock:
                    rockMechanic.enabled = true;
                    break;
            }
            referenceMechanic = currentMechanic;

        }

    }



}
