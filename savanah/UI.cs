using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject BucketInactive;
    public GameObject BucketActive;
    public GameObject TreeInactive;
    public GameObject TreeActive;
    public GameObject IdleInactive;
    public GameObject IdleActive;

    //public GameObject Buck;
    //public GameObject Idle;
    //public GameObject Tree;


    //bool bucket = false;
    //bool tree = false;
    //bool idle = false;

    int Scroller = 0;
    void Start()
    {
        StartUp();
    }

    void FixedUpdate()
    {
        scroll();
    }

    public void BucketActivate()
    {
        BucketInactive.SetActive(false);

        TreeInactive.SetActive(true);
        IdleInactive.SetActive(true);

        TreeActive.SetActive(false);
        IdleActive.SetActive(false);

        BucketActive.SetActive(true);


    }

    public void BucketDeActivate()
    {
        BucketInactive.SetActive(true);
        BucketActive.SetActive(false);
    }

    public void TreeActivate()
    {
        TreeInactive.SetActive(false);

        BucketInactive.SetActive(true);
        IdleInactive.SetActive(true);

        BucketActive.SetActive(false);
        IdleActive.SetActive(false);

        TreeActive.SetActive(true);

        //bucket = false;
        //idle = false;
        //tree = true;

    }

    public void TreeDeActivate()
    {
        TreeInactive.SetActive(true);
        TreeActive.SetActive(false);
    }

    public void IdleActivate()
    {
        IdleInactive.SetActive(false);

        BucketInactive.SetActive(true);
        TreeInactive.SetActive(true);

        BucketActive.SetActive(false);
        TreeActive.SetActive(false);

        IdleActive.SetActive(true);

        //bucket = false;
        //idle = true;
        //tree = false;

    }

    public void IdleDeActivate()
    {
        IdleInactive.SetActive(true);
        IdleActive.SetActive(false);
    }

    void StartUp()
    {
        BucketActive.SetActive(false);
        BucketInactive.SetActive(false);
        TreeActive.SetActive(false);
        TreeActive.SetActive(false);
        IdleActive.SetActive(false);
        IdleInactive.SetActive(false);
    }

    void scroll()
    {
        float w = Input.GetAxis("Mouse ScrollWheel");
        if (w < 0f)
        {
            Scroller = Scroller + 1;
        }
        else if (w > 0f)
        {
            Scroller = Scroller - 1;
        }

        if (Scroller < 0)
        {
            Scroller = 0;
        }
        if (Scroller > 2)
        {
            Scroller = 2;
        }


        if (Scroller == 0)
        {
            TreeActivate();
        }
        else if (Scroller == 1)
        {
            BucketActivate();
        }
        else if(Scroller == 2)
        {
            IdleActivate();
        }
    }

    





    //public void transform()
    //{
    //    if (bucket == true)
    //    {
    //        Buck.SetActive(true);
    //    }

    //    if (idle == true)
    //    {

    //        Idle.SetActive(true);
    //    }

    //    else if (bucket == false || Idle == false || Tree == false)
    //    {

    //        Buck.SetActive(false);
    //    }
    //}
}
