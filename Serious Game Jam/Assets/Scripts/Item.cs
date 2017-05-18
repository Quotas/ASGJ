using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool fake;
    Camera mainCamera;
    Vector3 destination;
    bool active;
    public float speed = 1.0f;

    private void Start()
    {

        mainCamera = Camera.main;
        destination = new Vector3(mainCamera.pixelHeight / 2.0f, mainCamera.pixelWidth / 2.0f, 0);


    }

    private void Update()
    {


        //TODO items need to move across the screen towards the middle when they become active

        if (active)
        {

            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);


        }


    }




}
