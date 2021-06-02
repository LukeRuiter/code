using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickUpObject : MonoBehaviour
{
    public Transform player;
    public Rigidbody r;
    public float throwForce = 200;
    public int v = 0;
    bool hasPlayer = false;
    bool beingCarried = false;
    void Awake()
    {
        r = GetComponent<Rigidbody>();
        


    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            hasPlayer = true;
        }
       
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasPlayer = false;
        }
            
    }

    void Update()
    {
        if (beingCarried)
        {
            if (Input.GetMouseButtonDown(0) )
            {
                r.isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                r.AddForce(player.forward * throwForce);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && hasPlayer)
            {
                r.isKinematic = true;
                transform.parent = player;
                beingCarried = true;
            }
           
        }
    }
}
