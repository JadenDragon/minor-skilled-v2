using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity;
    private float rotationY;
    private float rotationX;

    //gameobject camera should be looking at
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distanceFromTarget = 0.0f;

    private Vector3 currentRotation;
    private Vector3 smoothSpeed = Vector3.zero; //velocity of camera movement
    
    [SerializeField]
    private float smoothTime = 3.0f;

    // Update is called once per frame
    void Update()
    {
        handlePlayerCamera();
    }

    void handlePlayerCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        // multiply by -mouseSensitivity otherwise inverted vertical camera
        float mouseY = Input.GetAxis("Mouse Y") * -mouseSensitivity;

        //add mouse X values to rotate around Y position of camera
        rotationY += mouseX;
        //add mouse Y values to rotate around X position of camera
        rotationX += mouseY;

        //limit the range that camera rotates
        rotationX = Mathf.Clamp(rotationX, -30, 30);

        Vector3 nextRotation = new Vector3(rotationX, rotationY, 0);

        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothSpeed, smoothTime);

        transform.localEulerAngles = currentRotation;
        //Debug.Log("mouse go zoom X " + mouseX);

        //sets the camera position distant of the target position
        //subtracts camera Z position from the target
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
