using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.genTest == true)
        {
            GameManager.Instance.testcount++;
            Debug.Log(GameManager.Instance.testcount);
            SceneManager.LoadScene("GameScene");

        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Start");
    }
}
