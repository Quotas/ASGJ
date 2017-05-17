using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    //UI Elements go here






    private List<Delivery> deliveries = new List<Delivery>();
    public GameObject curObject;

    // Use this for initialization
    void Start()
    {

        DontDestroyOnLoad(gameObject);



    }

    // Update is called once per frame
    void Update()
    {

        //TODO 



    }

    void LoadDelivery(Delivery d)
    {

        //Load the delivery here


    }


    void RotateRight()
    {

        curObject.transform.Rotate(0.0f, 0.0f, -90.0f, Space.World);


    }

    void RotateLeft()
    {

		curObject.transform.Rotate(0.0f, 0.0f, 90.0f, Space.World);


    }

}
