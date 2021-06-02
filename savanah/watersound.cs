using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watersound : MonoBehaviour
{
    AudioSource audioData;
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
        if (target.tag == "Player")
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
           
        }
    
    }
    void OnTriggerExit(Collider target)
    {
        audioData.Pause();
    }

}
