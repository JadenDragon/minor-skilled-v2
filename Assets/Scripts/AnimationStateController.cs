using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;

    int isWalkingHash;
    int isRunningHash;
    int VelocityHash;

    //velocity to control animation
    float anim_Velocity = 0f;
    public float anim_Acceloration = 0.9f;
    public float anim_Decceloration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //sets isWalking from string to int
        //increase performance in playMode
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        //passes the isWalking from animator
        //bool isWalking = animator.GetBool("isWalking");
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool moveForward = Input.GetKey("q");
        bool runActive = Input.GetKey("left shift");

        //set the bool for isWalking to true when key is pressed and the player is not walking
        if (moveForward && !isWalking)
            animator.SetBool(isWalkingHash, true);
        
        //set isWalking to false if key is not pressed and isWalking is true
        if (isWalking && !moveForward)
            animator.SetBool(isWalkingHash, false);

        //checks if player is moving forward and pressing run
        if (moveForward && runActive && anim_Velocity < 1.0f) 
        {
            anim_Velocity += Time.deltaTime * anim_Acceloration;
            animator.SetBool("isRunning", true);
        }
            

        //stops running if moveForward is not pressed or if not runActive
        if(!moveForward || !runActive && anim_Velocity > 0.0f)
        {
            animator.SetBool("isRunning", false);
            anim_Velocity -= Time.deltaTime * anim_Decceloration;
        }

        if (!moveForward && anim_Velocity < 0.0f)
        {
            //resets the velocity to 0 when it goes below 0
            anim_Velocity = 0.0f;
        }

        animator.SetFloat(VelocityHash, anim_Velocity);
    }
}
