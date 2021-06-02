using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolves : MonoBehaviour
{
    AudioSource audioData;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player" && counter == 0)
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            counter++;
        }

    }
}
