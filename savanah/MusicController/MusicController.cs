using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public static MusicController instance = null; //Creates an instance of a musiccontroller, set gameobject in unity 
    public AudioSource MenuMusic;

    public bool menuPlaying = true;

    public float volume = 1.00f;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Awaken");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Doesnt destroy GameManager on load
            DontDestroyOnLoad(MenuMusic); //Doesnt destroy music on load
        }
        else
        {
            Destroy(MenuMusic);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
