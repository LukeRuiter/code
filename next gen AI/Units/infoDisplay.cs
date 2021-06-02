using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoDisplay : MonoBehaviour
{
    public Text InfoDis;

    private void OnMouseEnter()
    {
        if (this.tag == "Unit02")
        {
           InfoDis.text = gameObject.GetComponent<GreenUnit>().ToString();

        }
        else
        {
            InfoDis.text = gameObject.GetComponent<PurpleUnit>().ToString();

        }

    }
}
