using UnityEngine;
using System.Collections;

public class play_sound_on_trigger : MonoBehaviour
{
    public bool activateTrigger = false;

    public GameObject textO;
    public GameObject Sound;
    AudioSource audioData;
    public bool Spoken;
    public float Spokendelay;
    void Start()
    {
        textO.SetActive(false);
        Sound.SetActive(false);
    }


    void Update()
    {

        if (activateTrigger && Input.GetKey(KeyCode.F) && !Spoken)
        {
            //textO.SetActive(false);
            //Sound.SetActive(true);
            //Destroy(this.gameObject);
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            Spoken = true;
            StartCoroutine(SpamBlockco());
        }
      

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            textO.SetActive(true);
            activateTrigger = true;
        }

    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            textO.SetActive(false);
            activateTrigger = false;

        }

    }
    public IEnumerator SpamBlockco()
    {
        if (Spoken == true)
        {
            yield return new WaitForSeconds(Spokendelay);
        }
        yield return null;
        Spoken = false;
    }
}