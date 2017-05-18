using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool fake;
    Camera mainCamera;
    Vector3 destination;
    public bool active;
    public float speed = 1.0f;

    private void Start()
    {

        mainCamera = Camera.main;
        destination = new Vector3(Screen.height / 2.0f, Screen.width / 2.0f, 0);



    }

    private void Awake()
    {


        active = true;

    }

    private void Update()
    {


        //TODO items need to move across the screen towards the middle when they become active

        if (active)
        {


            TransitionEnter();

        }
        else
        {
            TransitionExit();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            active = false;

        }

        if (transform.position.x <= -140)
        {

            this.gameObject.SetActive(false);

        }


    }

    void TransitionEnter()
    {

        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);


    }


    void TransitionExit()
    {

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-150, 0.0f, 0.0f), speed * Time.deltaTime);


    }


}
