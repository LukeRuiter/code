using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{

    public bool AIOn;
    public bool AIHard; // true if hard, false if med
    public bool genTest;
    public int testcount;
    public bool newgame;
    public List<List<string>> EvotestData = new List<List<string>>();
    public List<string> bestmoves = new List<string>();

    public bool EvoAI;

    public  static GameManager Instance;
    //public  GameManager inst
    //{
    //    get
    //    {
    //        if (Instance == null)
    //        {
    //            Instance = new GameManager();
    //        }
    //        else
    //        {
    //            Destroy(this);
    //        }
    //        return Instance;
    //    }
    //}

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }


    }

    void Start()
    {
        AIOn = true;
        AIHard = false;
        genTest = false;
        testcount = 0;
        EvoAI = true;
       ReadinData1();

        //AIManager.Instance.AIOn = true;
        //  AIManager.Instance.ToggleAIOn();
      //  Debug.Log("Called the ai toggle");
    }

    public void AITog(bool ai)
    {
        AIOn = ai;
        Debug.Log(ai + "is ai");
        //AIManager.Instance.ToggleAIOn(ai);
        //Debug.Log("tog");

    }

    public void SetAIHard(bool diff)
    {
        AIHard = diff;
    }

    public bool returnAIHard()
    {
        return AIHard;
    }

    public void setEvoAI(bool ai)
    {
        EvoAI = ai;
    }
    public bool returnEvo()
    {
        return EvoAI;
    }
    public bool returnAI()
    {
        return AIOn;
    }

    public void setTest(bool test)
    {
        genTest = test;
    }

    public bool getTest()
    {
        return genTest;
    }

    private void ReadinData1()
    {
        string path = Application.dataPath + "/TestDatafinal.txt";

        StreamReader reader = new StreamReader(path);

        List<string> movelist = new List<string>();


        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            bestmoves.Add(line);
            //if(line.Contains("!")) // che
            //{
            //    movelist.Clear(); // reset
            //    line.Remove(0, 1);
            //   // Debug.Log(line);
            //    movelist.Add(line);

            //}
            //else if (!line.Contains("#"))
            //{
            //    movelist.Add(line);
            //}
           

            //if (line.Contains("#"))
            //{
            //    List<string> temlist = new List<string>(movelist);

            //   //Debug.Log(movelist[0]);
            //    EvotestData.Add(temlist);
            //   // Debug.Log(EvotestData[0][0]);
            //}
            ////  Debug.Log(reader.ReadLine());
        }

        Debug.Log(bestmoves.Count);

    }
}
