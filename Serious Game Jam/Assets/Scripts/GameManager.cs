﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    //UI Elements go here





    private int index = -1;
    private List<Delivery> deliveries = new List<Delivery>();
    public Dictionary<string, GameObject> items = new Dictionary<string, GameObject>();
    public GameObject curObject;
    public GameObject boss;
    // Use this for initialization
    void Start()
    {

        DontDestroyOnLoad(gameObject);

        #region Delivery Content
        Delivery d = new Delivery();

        d.name = "China";
        d.AddDialogue("Hello", ref boss);
        d.AddDialogue("We have a new Delivery", ref boss);
        //d.AddItem(items["DVD Fake"]);

        deliveries.Add(d);

        #endregion



    }

    // Update is called once per frame
    void Update()
    {

        //TODO get the current delivery


        if (!boss.GetComponent<BossController>().speaking)
        {
            if (!deliveries[0].ProcessDialogue(boss.GetComponent<BossController>().curIndex))
            {

                boss.GetComponent<BossController>().BossExit();
            }
        }


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
