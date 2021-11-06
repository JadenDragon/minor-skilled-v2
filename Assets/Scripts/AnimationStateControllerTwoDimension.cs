using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateControllerTwoDimension : MonoBehaviour
{
    Animator animator;

    float anim_VelocityX = 0.0f;
    float anim_VelocityZ = 0.0f;
    public float anim_Acceleration = 2.0f;
    public float anim_decceleration = 2.0f;
    public float maxWalkVelocity = 0.5f;
    public float maxRunVelocity = 2.0f;

    int VelocityZHash;
    int VelocityXHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        VelocityZHash = Animator.StringToHash("VelocityZ");
        VelocityXHash = Animator.StringToHash("VelocityX");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardInput = Input.GetKey("w");
        bool leftInput = Input.GetKey("a");
        bool rightInput = Input.GetKey("d");
        bool activeRun = Input.GetKey("left shift");

        updateAnimVelocity(forwardInput, leftInput, rightInput, activeRun);
        resetAnimVelocity(forwardInput, leftInput, rightInput, activeRun);   

        //sets values of anim_Velocity to Animator
        animator.SetFloat(VelocityZHash, anim_VelocityZ);
        animator.SetFloat(VelocityXHash, anim_VelocityX);

    }

    private void updateAnimVelocity(bool forwardInput, bool leftInput, bool rightInput, bool activeRun)
    {
        //sets currentVelocity to maxRunVelocity if activeRun is true
        //if not activeRun sets currentVelocity to maxWalkVelocity
        float currentVelocity = activeRun ? maxRunVelocity : maxWalkVelocity;

        if (forwardInput && anim_VelocityZ < currentVelocity)
        {
            anim_VelocityZ += Time.deltaTime * anim_Acceleration;
            Debug.Log("moving forward: " + anim_VelocityZ);
        }

        //increase velocity in -X (negative)
        if (leftInput && anim_VelocityX > -currentVelocity)
        {
            anim_VelocityX -= Time.deltaTime * anim_Acceleration;
            Debug.Log("moving left");
        }

        //increase velocity in positive X
        if (rightInput && anim_VelocityX < currentVelocity)
        {
            anim_VelocityX += Time.deltaTime * anim_Acceleration;
            Debug.Log("moving right");
        }

        //deccelerates the forward velocity
        if (!forwardInput && anim_VelocityZ > 0.0f)
        {
            anim_VelocityZ -= Time.deltaTime * anim_decceleration;
        }

        if (!forwardInput && anim_VelocityZ < 0.0f)
        {
            //resets the velocity to 0 when it goes below 0
            anim_VelocityZ = 0.0f;
        }

        if (!leftInput && anim_VelocityX < 0.0f)
        {
            //deccelerates the X velocity if less than 0 and leftInput is not pressed
            anim_VelocityX += Time.deltaTime * anim_decceleration;
        }
    }

    private void resetAnimVelocity(bool forwardInput, bool leftInput, bool rightInput, bool activeRun)
    {
        if (!rightInput && anim_VelocityX > 0.0f)
        {
            anim_VelocityX -= Time.deltaTime * anim_decceleration;
        }

        if (!leftInput && !rightInput && anim_VelocityX != 0.0f)
        {
            //resets X velocity if left & right are not pressed
            anim_VelocityX = 0.0f;
        }
    }

}
