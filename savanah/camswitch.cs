using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.Networking;
[Serializable]
public class camswitch : NetworkBehaviour
{
    public GameObject cam;
  
    // Use this for initialization
    void Start () {
      

    }
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer == true)
        {
            cam.SetActive(true);
        }
        else
        {
            cam.SetActive(false);
        }
    }
}
