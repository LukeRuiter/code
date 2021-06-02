using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleport : MonoBehaviour
{
    public bool activateTrigger = false;
    
    public GameObject tpObject;
    public GameObject VFX;

    public Text MeatInfo;
    public int MeatValue;
    public Slider MeatBar;

    public GameObject MeatIconCheetah;

    // Start is called before the first frame update
    void Start()
    {
        MeatValue = 0;
        MeatIconCheetah.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (activateTrigger == true && tpObject.tag == "buck")
        {

            //int numberOfChild = transform.childCount;
            //for (int i = 0; i < numberOfChild; i++)
            //{
            Instantiate(VFX, tpObject.transform.position, Quaternion.identity);
            Destroy(tpObject);
            //}
            //tpObject.SetActive(false);
      
            MeatIconCheetah.SetActive(true);
            MeatValue = MeatValue + 1;
        }
        MeatInfo.text = " " + MeatValue;
        MeatBar.value = MeatValue;

        if (activateTrigger == true && tpObject.tag == "FeedZone")
        {
            MeatValue = 0;
            MeatIconCheetah.SetActive(false);
        }

        if(MeatValue>= 10)
        {
            MeatValue = 10;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        activateTrigger = true;
       
        tpObject = col.gameObject;

    }
    private void OnTriggerExit(Collider other)
    {
       
        activateTrigger = false;
    }
}
