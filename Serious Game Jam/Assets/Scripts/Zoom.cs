using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivity = 10f;


    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;


    }

    void ZoomIn()
    {


        var fov = Camera.main.fieldOfView;
        fov += -1.0f * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;


    }

    void ZoomOut()
    {


        var fov = Camera.main.fieldOfView;
        fov += 1.0f * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;




    }








}