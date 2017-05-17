using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Delivery : MonoBehaviour
{




    //Holds all the dialgue for the game
    [SerializeField]
    public List<Dialogue> sceneDialogue = new List<Dialogue>();

    public string sceneName;
    public GameObject boss;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        //This is how dialgue is added to an entity for a particular Delivery

    }


    void AddDialogue(string _text, ref GameObject _entity)
    {

        sceneDialogue.Add(new Dialogue(_text, ref _entity, sceneDialogue.Count));

    }
}
