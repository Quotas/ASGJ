using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickRotate : MonoBehaviour
{

    // reference to the camera (assumes there is only one camera in the scene)
    Camera cam;


    // *********These variables handle the rotation element of the control *********
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float speedH = 10.0f;
    private float speedV = 10.0f;

    // These variables control the double click functionality *********
    // Public settings for tweaking the performance of the double click 
    public float doubleClickDelayTimer;
    public float rotationSpeed;

    // private variables for holding the directions for rotations to face the camera
    private Vector3 cameralLookDirection;
    private Vector3 localNormal;
    private Quaternion requiredRotation;
    private Quaternion currentRotation;
    private float implementTimer;
    // Local management of the double click 
    private bool recentlyclicked;
    private float clickTimer;
    // the position of the click in real world space for determining the face
    private Vector3 realWorldNormal;
    // Control Logic for Rotating the Camera
    private bool rotateToFaceCamera;


    // Use this for initialization
    void Start()
    {

        // Locking the cursur for the drag 
        Cursor.lockState = CursorLockMode.Confined;

        cam = Camera.main;
        // Variables for the double click functionality 
        recentlyclicked = false;
        rotateToFaceCamera = false;
        requiredRotation = new Quaternion();
        implementTimer = 1.5f;
        clickTimer = 0.0f;


    }

    // Update is called once per frame
    void Update()
    {


        //speedH = speedH * Mathf.Abs(Input.GetAxis("Mouse X"));
        //speedV = speedV * Mathf.Abs(Input.GetAxis("Mouse Y"));


        yaw = speedH * Input.GetAxis("Mouse X");
        pitch = speedV * Input.GetAxis("Mouse Y");


        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = Quaternion.identity;
        }

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0) && recentlyclicked == false)
            {
                // start a timer for detecting the second click 
                recentlyclicked = true;
            }
            else if (Input.GetMouseButton(0))
            {
                transform.Rotate(new Vector3(pitch, -1.0f * yaw, 0.0f), Space.World);
            }
        }


        // detecting the double click 
        if (Input.GetMouseButtonDown(0) && recentlyclicked == false)
        {
            // start a timer for detecting the second click 
            recentlyclicked = true;
        }
        else if (recentlyclicked == true && clickTimer < doubleClickDelayTimer)
        {

            clickTimer += Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {

                // A double click has been detected  

                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    realWorldNormal = hit.normal;
                    rotateToFaceCamera = true;
                    recentlyclicked = false;
                }
            }
        }
        else
        {
            clickTimer = 0.0f;
        }



        // Time to rotate the camera 
        if (rotateToFaceCamera == true)
        {
            // Convert the normal from world coordinates to local coordinates 
            localNormal = transform.InverseTransformDirection(realWorldNormal);
            cameralLookDirection = cam.transform.position - transform.position;
            requiredRotation = Quaternion.FromToRotation(localNormal, cameralLookDirection);
            currentRotation = transform.localRotation;
            implementTimer = 0.0f;
            rotateToFaceCamera = false;
        }

        if (implementTimer < 1.0f)
        {
            implementTimer += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Slerp(currentRotation, new Quaternion(requiredRotation.x, requiredRotation.y, 0.0f, requiredRotation.w), implementTimer * rotationSpeed);
        }

    }


    public void Rotate(float rotation)
    {

        transform.Rotate(0.0f, 0.0f, rotation, Space.World);

    }

}