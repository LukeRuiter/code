using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public Toggle setAiTog;
    public Toggle hardtog;
    public Toggle medtog;
    public Toggle testdata;
    public GameObject gmo;
    GameManager gm;

    int evocount = 0;
    private void Start()
    {
        gm = gmo.GetComponent<GameManager>();
        
        GameManager.Instance.setTest(true);
    }
    public void SetAI()
    {
        Debug.Log("thing");
        gm.AITog(setAiTog.isOn);
        Debug.Log("ai returning " + gm.AIOn);


        if (gm.AIOn)
        {
            hardtog.enabled = true;
            medtog.enabled = true;
            Debug.Log("enabled again");
        }
        else
        {
            hardtog.enabled = false;
            medtog.enabled = false;
        }


    }

    public void setTest()
    {

        if (GameManager.Instance.getTest()== false)
        {
            GameManager.Instance.setTest(true);
            Debug.Log("test set to " + GameManager.Instance.getTest());
        }
        else
        {
            GameManager.Instance.setTest(false);
            Debug.Log("test set to " + GameManager.Instance.getTest());

        }
    }

    public void setHard()
    {
        GameManager.Instance.SetAIHard(true);

        medtog.isOn = false;
      //  hardtog.isOn = true;
    }

    public void setMed()
    {
        GameManager.Instance.SetAIHard(false);
        hardtog.isOn = false;
       // medtog.isOn = true;

    }

    public void setEvoAI()
    {
        if (evocount % 2 == 0)
        {
            GameManager.Instance.setEvoAI(false);

        }
        else
        {
            GameManager.Instance.setEvoAI(true);

        }

        evocount++;
    }
   public void StartGamne()
    {
       
        SceneManager.LoadScene("GameScene");
    }

   public void LoadEvo()
    {
        SceneManager.LoadScene("EvolutionTesting");
    }
}
