﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRotate : MonoBehaviour
{




    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float speedH = 10.0f;
    private float speedV = 10.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //speedH = speedH * Mathf.Abs(Input.GetAxis("Mouse X"));
        //speedV = speedV * Mathf.Abs(Input.GetAxis("Mouse Y"));


        yaw = speedH * Input.GetAxis("Mouse X");
        pitch = speedV * Input.GetAxis("Mouse Y");
        Debug.Log(yaw);
        Debug.Log(pitch);



        if (Input.GetKeyDown(KeyCode.R))
        {

            transform.rotation = Quaternion.identity;

        }

        if (Input.GetMouseButton(0))
        {

            //Cursor.lockState = CursorLockMode.Locked;
            transform.Rotate(new Vector3(pitch, -1.0f * yaw, 0.0f), Space.World);
            //var curRotation = transform.rotation;
            //var toRotation = Quaternion.Euler(pitch, yaw, 0);
            //transform.rotation = Quaternion.Lerp(curRotation, toRotation, Time.deltaTime * 1.0f);


        }



    }
}