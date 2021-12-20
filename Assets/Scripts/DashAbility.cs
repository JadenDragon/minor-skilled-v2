using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu]
public class DashAbility : Ability
{
    //private float dashVelocity = 7.5f;
    
    private Vector3 dashStartPosition;
    private Vector3 dashEndPosition;

    [SerializeField]
    private Image i_imageCooldown;
    [SerializeField]
    private TMP_Text t_cooldownTime;

    public override void Activate(GameObject parent)
    {
        //TODO:
        //add the movement in the direction of slash
        //add the animation for the slash
        //get the movement input from parent object
        //has to check if null first

        //i_imageCooldown.fillAmount = 0.0f;
        //t_cooldownTime.gameObject.SetActive(false);

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

        //t_cooldownTime.gameObject.SetActive(true);
    }
}
