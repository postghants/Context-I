using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicController : MonoBehaviour
{
    public enum Mechanic { None, Door, Enemy, Ball, Balloon, Rock }
    public Mechanic currentMechanic;

    public doorMechanic doorMechanic;
    public enemyMechanic enemyMechanic;
    public ballMechanic ballMechanic;
    public balloonMechanic balloonMechanic;
    public rockMechanic rockMechanic;

    private void FixedUpdate()
    {
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
    }

}
