using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvoUI : MonoBehaviour
{
    // Start is called before the first frame update
   public void returnhome()
    {
        SceneManager.LoadScene("Start");
    }
}
