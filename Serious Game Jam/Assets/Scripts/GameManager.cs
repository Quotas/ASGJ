﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    public class Delivery
    {

        //Holds all the dialgue for the game
        public List<Dialogue> sceneDialogue = new List<Dialogue>();

        public List<GameObject> items = new List<GameObject>();
        public bool active;
        public string name;
        public GameObject boss;

        public void AddDialogue(string _text, ref GameObject _entity)
        {

            sceneDialogue.Add(new Dialogue(_text, ref _entity, sceneDialogue.Count));

        }

        public void AddItem(GameObject item)
        {


            items.Add(item);


        }

        public bool ProcessDialogue(int index)
        {

            if (index > sceneDialogue.Count - 1)
            {
                return false;
            }
            sceneDialogue[index].Fire();
            return true;

        }

        public bool SetActiveItem(int index)
        {
            if (index > items.Count - 1)
            {
                return false;
            }
            else
            {
                items[index].gameObject.SetActive(true);
                return true;
            }


        }
    }

    public struct Dialogue
    {

        public string text { get; set; }
        int id { get; set; }
        GameObject actor;

        public Dialogue(string _text, ref GameObject _entity, int _id)
        {

            text = _text;
            id = _id;
            actor = _entity;



        }


        public void Fire()
        {
            actor.GetComponent<BossController>().BossEnter();
            actor.GetComponent<BossController>().BossSpeaks(text);

        }
    }


    //UI Elements go here





    public int curDeliveryIndex = 0;
    public int curItemIndex = 0;
    private List<Delivery> deliveries = new List<Delivery>();


    [SerializeField]
    public List<GameObject> items = new List<GameObject>();
    [SerializeField]
    public List<string> itemKey = new List<string>();

    public GameObject curObject;
    public GameObject boss;
    // Use this for initialization
    void Start()
    {

        DontDestroyOnLoad(gameObject);

        #region Delivery Content
        Delivery d = new Delivery();

        d.name = "Main";
        d.AddDialogue("Hello", ref boss);
        d.AddDialogue("We have a new Delivery", ref boss);




        d.AddItem(items[itemKey.IndexOf("Cigarette Fake")]);
        d.AddItem(items[itemKey.IndexOf("Cigarette Real")]);
        d.AddItem(items[itemKey.IndexOf("DVD Fake")]);
        d.AddItem(items[itemKey.IndexOf("DVD Real")]);



        deliveries.Add(d);
        #endregion


        deliveries[curDeliveryIndex].active = true;



    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            curItemIndex++;

        }
        if (deliveries[curDeliveryIndex].active == true)
        {

            if (!boss.GetComponent<BossController>().speaking)
            {
                //TODO fix getting current delivery
                if (!deliveries[curDeliveryIndex].ProcessDialogue(boss.GetComponent<BossController>().curIndex))
                {
                    if (boss.GetComponent<BossController>().state != BossController.BossState.EXIT)
                    {
                        boss.GetComponent<BossController>().BossExit();

                    }
                }
            }

            if (!deliveries[curDeliveryIndex].SetActiveItem(curItemIndex))
            {

                deliveries[curDeliveryIndex].active = false;
                curItemIndex = 0;
            }

        }

        else if (deliveries[curDeliveryIndex].active == false)
        {
            if (curDeliveryIndex + 1 > deliveries.Count - 1)
            {

                //THis should be the end of the game I.E. the last delivery get the score here
                return;
            }
            else
            {
                //Otherwise increment the delivery index
                curDeliveryIndex++;
                deliveries[curDeliveryIndex].active = true;

            }

        }

        //curItemIndex++;


    }


    // This is the UI interface to the current item to allow it to be rotated.
    void RotateRight()
    {
        curObject.GetComponent<ClickRotate>().Rotate(-90.0f);
    }

    void RotateLeft()
    {

        curObject.GetComponent<ClickRotate>().Rotate(90.0f);

    }

}
