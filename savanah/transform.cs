using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class transform : NetworkBehaviour
{
    public GameObject Buck;
    public GameObject MainMan;
    public float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        MainMan.SetActive(true);
        Buck.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (counter == 0)
                {
                    MainMan.SetActive(false);
                    Buck.SetActive(true);
                    counter++;
                }
                else if (counter == 1)
                {
                    MainMan.SetActive(true);
                    Buck.SetActive(false);
                    counter--;
                }
            }
        }
       
    }
}
