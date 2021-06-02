using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    // Use this for initialization
    public static bool GamePause = false;

    public Text PausedText;

    public Text MainMenuText;
    public Button MainMenuButton;
    public RawImage MainMenuImage;

    public Text RestartText;
    public Button RestartButton;
    public RawImage RestartImage;

    public Text escape;

    void Start()
    {
        PausedText.enabled = false;

        MainMenuText.enabled = false;
        MainMenuButton.enabled = false;
        MainMenuImage.enabled = false;

        RestartText.enabled = false;
        RestartButton.enabled = false;
        RestartImage.enabled = false;
    }
    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}
    public void Resume()
    {
        PausedText.enabled = false;
        Time.timeScale = 1f;
        GamePause = false;

        MainMenuText.enabled = false;
        MainMenuButton.enabled = false;
        MainMenuImage.enabled = false;

        RestartText.enabled = false;
        RestartButton.enabled = false;
        RestartImage.enabled = false;

        escape.enabled = true;

    }
    void Pause()
    {
        PausedText.enabled = true;
        Time.timeScale = 0f;
        GamePause = true;

        MainMenuText.enabled = true;
        MainMenuButton.enabled = true;
        MainMenuImage.enabled = true;

        RestartText.enabled = true;
        RestartButton.enabled = true;
        RestartImage.enabled = true;

        escape.enabled = false;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
