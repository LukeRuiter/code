using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool activateTrigger = false;
    public GameObject tpObject;

    int Level = 1;
    int levelTime = 80;
    public Text levelTimer;

    public Text CubInfo;
    public int cubHealth;
    public Slider CubBar;
    int counter = -1;

    public Text MeatInfo;

    public Text ToDo;

    public Text DayNumber;
    
    public Text Gameover;
    public Text GameoverText;
    public Button GameOverButton;
    public RawImage GameOverImage;

    public Text Paused;

    public Text MainMenuText;
    public Button MainMenuButton;
    public RawImage MainMenuImage;

    GameObject[] buckOnMap = new GameObject[200];
    int[] levelSpawn = new int[10] { 250, 150, 140, 135, 130, 125, 120, 115, 110, 105 }; //Number of buck to spawn per level

    public GameObject BuckBody;
    public GameObject PlayerBody;
    public GameObject newPlayer;

    public AudioSource audioData;

    public Light Sun;
    float speed = 1.0f;

    //public GameObject cheetahBody;
    //CheetahC Player;

    // Start is called before the first frame update
    void Start()
    {
        //Player = new CheetahC(cheetahBody); //gets Cheetah gameobject, NOT SURE IF I NEED THIS  
        SpawnLevelBuck();
        CubBar.value = cubHealth;

        ToDo.enabled = ToDo.enabled;

        GameOverButton.enabled = !GameOverButton.enabled;
        Gameover.enabled = !Gameover.enabled;
        GameOverImage.enabled = !GameOverImage.enabled;
        GameoverText.enabled = !GameoverText.enabled;

        MainMenuText.enabled = !MainMenuText.enabled;
        MainMenuButton.enabled = !MainMenuButton.enabled;
        MainMenuImage.enabled = !MainMenuImage.enabled;

        Paused.enabled = !Paused.enabled;

        if (Level == 1)
        {
            cubHealth = 80;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter++;
        Sun.transform.Rotate(Vector3.right * speed * Time.deltaTime);

     
        if (counter == 60)
        {
            cubHealth = cubHealth - 1;
            levelTime--;
            counter = 0;
        }

        if (levelTime <= 76)
        {
            ToDo.enabled = false;

        }

        levelTimer.text = "TIME LEFT: " + (levelTime).ToString();

        CubInfo.text = "" + cubHealth;
        CubBar.value = cubHealth;

        if (levelTime <= 0)
        {
            Level++;
            newDay();
            levelTime = 80;
            DayNumber.text = "Day " + (Level).ToString();
        }

        if(cubHealth == 0|| cubHealth<0)
        {
            GameOverButton.enabled = true;
            Gameover.enabled = true;
            GameOverImage.enabled = true;
            GameoverText.enabled = true;

            MainMenuText.enabled = true;
            MainMenuButton.enabled = true;
            MainMenuImage.enabled = true;

            Time.timeScale = 0;
            cubHealth = 0;

            audioData.Play(0);
        }
        if(Time.timeScale == 0 && cubHealth > 0)
        {
            Time.timeScale = 1;
        }

        if (activateTrigger == true && tpObject.tag == "FeedZone")
        {
            cubHealth = cubHealth + int.Parse(MeatInfo.text);
            MeatInfo.text = "0";
           
        }

        if (cubHealth >100)
        {
            cubHealth = 100;
        }
    }

    void SpawnLevelBuck()
    {
        for (int i = 0; i < levelSpawn[Level]; i++)
        {
            int rX = Random.Range(-40, 47);
            int rZ = Random.Range(-40, 47);
            int rR = Random.Range(0, 361);

            Instantiate(BuckBody, new Vector3(rX, 2, rZ), Quaternion.Euler(new Vector3(0, rR, 0)));
        }
    }

    void DestroyLevelBuck()
    {
        for (int i = 0; i < buckOnMap.Length; i++)
        {
            if (buckOnMap[i] != null)
            {
                Destroy(buckOnMap[i].gameObject);
                buckOnMap[i] = null;
            }
        }
    }

    void newDay()
    {
        PlayerBody.transform.position = new Vector3(-9.526f, 1.71f, 4.342f);

        Sun.transform.localRotation = Quaternion.Euler(0, 277f, 0);

        cubHealth = cubHealth + int.Parse(MeatInfo.text);
        MeatInfo.text = "0";

        if (Level == 2)
        {
            cubHealth = 70;
        }
        else if(Level == 3)
        {
            cubHealth = 60;
        }
        else if(Level >= 4)
        {
            cubHealth = 50;
        }
      
        //DayNumber.text = "Day " + (Level).ToString();
        //Level++;
        //DestroyLevelBuck();
        //SpawnLevelBuck();

        //PlayerBody.transform.Translate(-9.526f, 1.71f, 4.342f);
        //PlayerBody.transform.Rotate(0, 0, 0);
        //PlayerBody.transform.Rotate(0, 45.32f, 0);

        //Destroy(PlayerBody);

        //Instantiate(newPlayer, new Vector3(-9.526f, 1.71f, 4.342f), Quaternion.identity);
    }

    void OnTriggerEnter(Collider col)
    {
        activateTrigger = true;

        tpObject = col.gameObject;

    }
}
