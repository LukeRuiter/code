using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    float normalSpeed = 40.0f;
    float Counter = 0;
    float originalY;
    float jumpHeight;
    private MeshRenderer MeshRen;
    AudioSource audioData;
    bool inAir = false;
    Rigidbody RB;
    float jumpforce = 5000;

    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y - 1; //dropped by 2
        
        MeshRen = GetComponent<MeshRenderer>();
        MeshRen.enabled = !MeshRen.enabled;
        audioData = GetComponent<AudioSource>();
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MeshRen.enabled == true)
        {
            Counter++;

            if (Counter == 20)
            {
                RB.AddForce(Vector3.up * Time.deltaTime * jumpforce);
                jumpHeight = jumpHeight + 1f;
                Counter = 0;
                audioData.Play(0);
            }
            else
            {

            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            MeshRen.enabled = MeshRen.enabled;
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            MeshRen.enabled = !MeshRen.enabled;
        }
    }

    //void OnCollisionEnter(Collision target)
    //{
    //    if (target.gameObject.tag == "Player" && MeshRen.enabled == true)
    //    {
    //        Destroy(this);
    //        Debug.Log("Eaten");
    //    }

    //}

}
