using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{



    public void Speech(string text, ref Text dialogueBox)
    {

        dialogueBox.text = text;


    }


}
