using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity = 7.5f;
    
    public Vector3 dashStartPosition;
    public Vector3 dashEndPosition;

    public override void Activate(GameObject parent)
    {
        //TODO:
        //add the movement in the direction of slash
        //add the animation for the slash
        //get the movement input from parent object
        //has to check if null first

        CharacterController character = parent.GetComponent<CharacterController>();
        Debug.Log("dashing through the snow!");

        
        dashStartPosition = character.transform.position;
        Debug.Log(dashStartPosition);


        Vector3 dashDirection = dashStartPosition * Input.GetAxis("Vertical") + dashStartPosition * Input.GetAxis("Horizontal");
        dashEndPosition = character.transform.forward * 5;
        character.Move(dashDirection + dashEndPosition);
    }

    public override void CoolDown(GameObject parent) 
    {
        //TODO:
        //stop the dash activation
        //reset dash to normal movement
    }
}
