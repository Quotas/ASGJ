using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public struct Dialogue
{

    string text { get; set; }
    int id { get; set; }
    GameObject actor;

    public Dialogue(string _text, ref GameObject _entity, int _id)
    {

        text = _text;
        id = _id;
        actor = _entity;

    }


}

