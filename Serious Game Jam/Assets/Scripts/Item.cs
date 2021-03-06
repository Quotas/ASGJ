﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public bool fake;
    Camera mainCamera;
    Vector3 destination;
    public bool active;
    public float speed = 1.0f;

	public AudioClip swoosh;
	public SoundManager soundManager;

    // This reference is for the correct Answer Image 
	public Sprite correctAnswerImage;

    private void Start()
    {

        mainCamera = Camera.main;
        destination = new Vector3(Screen.height / 2.0f, Screen.width / 2.0f, 0);

    }

    private void Awake()
    {


        active = true;
		soundManager.PlaySound (swoosh, 0);

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

        if (transform.position.x <= -20)
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
