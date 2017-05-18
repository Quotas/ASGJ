using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Delivery
{

    //Holds all the dialgue for the game
    public List<Dialogue> sceneDialogue = new List<Dialogue>();
    public List<GameObject> items = new List<GameObject>();

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
}
