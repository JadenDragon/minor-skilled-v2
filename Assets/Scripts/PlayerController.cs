﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController charCntrl;
    Animator animator;

    int isJumpingHash;
    [SerializeField] Vector3 currentMovement;

    //[SerializeField] float charVelocity;
    float moveZ;
    float moveX;
    bool jump;
    float playerSpeed = 3.0f;
    float rotateSpeed = 3.0f;
    //values for animation
    //float anim_VelocityX = 0.0f;
    //float anim_VelocityZ = 0.0f;

    Vector3 playerMovement;

    //bool playerIsGrounded;
    bool isJumping;
    float jumpVelocity = 8.0f;
    float gravity = 9.81f;
    private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        charCntrl = this.GetComponent<CharacterController>();
        //transform.position = Vector3.zero;
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(charCntrl)
        {
            handlePlayerMovement();
            handlePlayerRotation();
            //charIsGrounded = charCntrl.isGrounded;
        }
    }


    void handlePlayerMovement()
    {
        /*moveZ = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");

        playerMovement = new Vector3(moveX, 0f, moveZ);

        //instantiate currentMove and pass to charCntrl to move player
        currentMovement = new Vector3(playerMovement.x, *//*charIsGrounded ? 0.0f : 0.0f*//*-10f, playerMovement.z) * Time.deltaTime;

        if (charIsGrounded)
        {
            //currentMovement.y = 
            //temp fix for setting the player on the ground
            charCntrl.center = new Vector3(0, 1, 0);
        }
        charCntrl.Move(((currentMovement)));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.red);*/

        //characterSimpleMove();
        characterMove();
    }

    //moves withe characterController SimpleMove
    void characterSimpleMove()
    {
        transform.Rotate(0.0f, Input.GetAxis("Horizontal") * rotateSpeed, 0.0f);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float currentSpeed = playerSpeed * Input.GetAxis("Vertical");
        charCntrl.SimpleMove(forward * currentSpeed);
    }

    //moves with the characterController.Move
    void characterMove()
    {
        isJumping = animator.GetBool(isJumpingHash);

        /*playerIsGrounded = charCntrl.isGrounded;
        if (playerIsGrounded && playerMovement.y < 0)
        {
            playerMovement.y = 0f;
        }*/

        /*Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        charCntrl.Move(moveDirection * Time.deltaTime * playerSpeed);

        if (moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection;
        }

            // Changes the height position of the player..
            if (jump && playerIsGrounded)
            {
                playerMovement.y += Mathf.Sqrt(jumpVelocity * -3.0f * gravity);
                animator.SetBool(isJumpingHash, true);
                Debug.Log("we jumping");
            }
            else
                animator.SetBool(isJumpingHash, false);

            playerMovement.y += gravity * Time.deltaTime;
            charCntrl.Move(playerMovement * Time.deltaTime);*/

        if (charCntrl.isGrounded)
        {
            animator.SetBool(isJumpingHash, false);
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= playerSpeed;
            if (Input.GetButton("Jump"))
            {
                animator.SetBool(isJumpingHash, true);
                moveDirection.y = jumpVelocity;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        charCntrl.Move(moveDirection * Time.deltaTime); 
        //Debug.Log(moveDirection);
    }


    void handlePlayerRotation()
    {
        if (moveX > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 2f * Time.deltaTime);
            //transform.forward;
        }

        else if (moveX < 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 2f * Time.deltaTime);
        if (moveZ > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 2f * Time.deltaTime);
        else if (moveX < 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 2f * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 2.0f);
    }
}
