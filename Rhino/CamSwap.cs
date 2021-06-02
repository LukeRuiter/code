using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwap : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject rhino1;
    public GameObject rhino2;
    // Start is called before the first frame update
    void Start()
        {
      
        }

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.C))
            {
            cam1.SetActive(false);
            rhino1.SetActive(false);
            cam2.SetActive(true);
            rhino2.SetActive(true);
        }
            if (Input.GetKeyDown(KeyCode.V))
            {
            cam1.SetActive(true);
            rhino1.SetActive(true);
            cam2.SetActive(false);
            rhino2.SetActive(false);
        }
    }
}