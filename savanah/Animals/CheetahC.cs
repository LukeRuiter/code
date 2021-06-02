using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    class CheetahC
    {
    private int hp;

    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }

    private float xpos;

    public float XPos
    {
        get { return xpos; }
        set { xpos = value; }
    }

    private float ypos;

    public float YPos
    {
        get { return ypos; }
        set { ypos = value; }
    }

    private bool isalive;

    public bool IsAlive
    {
        get { return isalive; }
        set { isalive = value; }
    }

    private GameObject cheetahbody;

    public GameObject CheetahBody
    {
        get { return cheetahbody; }
        set { cheetahbody = value; }
    }


    public CheetahC(GameObject CB) //Constructor
    {
        CheetahBody = CB;
        IsAlive = true;
        XPos = CB.transform.position.x; //Not sure if i need this
        YPos = CB.transform.position.y;
        HP = 100;
    }
}

