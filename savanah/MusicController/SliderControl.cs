using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{

    public Slider volumeControl;

    // Start is called before the first frame update
    void Start()
    {
        volumeControl.value = MusicController.instance.volume;
    }

    // Update is called once per frame
    void Update()
    {
        MusicController.instance.volume = volumeControl.value;
        MusicController.instance.MenuMusic.volume = volumeControl.value;
    }
}
