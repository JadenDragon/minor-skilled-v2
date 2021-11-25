using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        //TODO:
        //add the movement in the direction of slash
        //add the animation for the slash
        //get the movement input from parent object
        PlayerController player = parent.GetComponent<PlayerController>();
        CharacterController controller = parent.GetComponent <CharacterController>();
    }

    public override void CoolDown(GameObject parent)
    {
        //TODO:
        //stop the dash activation
        //reset dash to normal movement
    }
}
