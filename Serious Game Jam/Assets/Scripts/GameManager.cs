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


	// This is the UI interface to the current item to allow it to be rotated.
    void RotateRight()
    {
		curObject.GetComponent<ClickRotate> ().Rotate (-90.0f);
    }

    void RotateLeft()
    {
		curObject.GetComponent<ClickRotate> ().Rotate (90.0f);
    }

}
