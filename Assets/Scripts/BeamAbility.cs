using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BeamAbility : Ability
{
    //TODO:
    //generate a prefab when activated
    //fire prefab in forward direction of player
    //destroy prefab on impact with other objects
    public GameObject projectile;
    public float slashVelocity = 200f;
    

    //parameters references the gameObject holding the ability
    public override void Activate(GameObject parent) {
        CharacterController character = parent.GetComponent<CharacterController>();
        Debug.Log("sword beam!");

        Vector3 init = character.transform.position + new Vector3(0, 0, 3);
        Vector3 slashDirection = new Vector3(0, 0, slashVelocity);
        
        GameObject currentBeam = Instantiate(projectile, init, Quaternion.identity);
        currentBeam.GetComponent<Rigidbody>().AddRelativeForce(slashDirection);

        Collider.Destroy(currentBeam, 5);
    }

    public override void CoolDown(GameObject parent) {
        
    }

}


/*
 create the prefab
 
 */