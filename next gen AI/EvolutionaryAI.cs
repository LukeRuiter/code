using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class EvolutionaryAI : MonoBehaviour
{
    List<string> testData = new List<string>();
    List<string> SortedList1 = new List<string>(); // filter out all the games where green lost
    List<int> fitnessScores = new List<int>();


    List<List<string>> gameList = new List<List<string>>(); // all the games <games>

    string path1;
    private TextAsset textasset;

    private void Start()
    {
        path1 = Application.dataPath + "/TestDataEvo.txt";
        ReadinData();
        //Debug.Log(testData.Count);
       // FilterFile1();
        //Debug.Log(SortedList1.Count);
        writefilter1totxt();
        Debug.Log("finished new");

        //ReadinData1();
    }
    public void ReadinData()
    {

        

        string path = Application.dataPath + "/TestData0.txt";

        StreamReader reader = new StreamReader(path);
       //int gamecount = -1;
        //int movescount = 0;


        List<string> templist = new List<string>();

        int filecount = 0;
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();

            
                bool end = false;


                //Debug.Log(line);
                //templine += reader.ReadLine();
                templist.Add(line);

                if (line.Contains('!'))
                {

                    // line.Remove(0,1);
                    //gamecount++;

                    Debug.Log("new game");

                    //gameList.Add(new List<string>());
                }

                if (line.Contains("#"))
                {
                    end = true;
                }



                if (end) // end of game 
                {
                    if (!templist[templist.Count - 1].Contains("p"))
                    {
                        //Debug.Log("added " + line);
                        List<string> temptemp = new List<string>(templist);
                        gameList.Add(temptemp);
                        Debug.Log(gameList[filecount]);
                        templist.Clear();
                        filecount++;
                        // movescount = 0;
                    }


                }


            
           

          //  Debug.Log(line);
        }



        //GameManager.Instance.EvotestData = gameList;
    }

    private void ReadinData1()
    {
        string path = Application.dataPath + "/TestData1.txt";

        StreamReader reader = new StreamReader(path);

        while (!reader.EndOfStream)
        {
            SortedList1.Add(reader.ReadLine());

        }

      //  GameManager.Instance.EvotestData = SortedList1;
    }

    
    public void FilterFile1() //filter all the winning moves
    {
        string path = Application.dataPath + "/TestData1.txt";

        foreach (string s in testData)
        {
            int poscount = 0;
            bool green = false;
            bool purple = false;

            int foundstartg = 0;
            int foundendg = 0;
            foreach (char c in s)
            {
                if (c == 'g')
                {
                    int start = s.IndexOf(c);
                    int end = s.IndexOf(c)+ 5;

                    foundstartg = start;
                     foundendg = end;
                    Debug.Log(s.Substring(start, end - start));
                    
                    if (s.Substring(start, end - start) =="green")
                    {
                        green = true;
                    }     
                }

                if (c == 'p')
                {
                    int start = s.IndexOf(c);
                    int end = s.IndexOf(c) + 6;
                    Debug.Log(s.Substring(start, end - start));

                    if (s.Substring(start, end - start) == "purple")
                    {
                        purple = true;
                    }

                }
                poscount++;

            }

            string temp = s;


            if (green == true )
            {
                 SortedList1.Add(temp);
            }

        }

        List<string> templist = new List<string>();

        foreach (string s in SortedList1)
        {
            string temp = "";
            foreach (char c in s )
            {
                if (c != 'p' & c != 'u'& c !='r' & c != 'l' & c != 'e' & c != 'g' & c!= 'n')
                {
                    temp = temp + c;
                }
            }

            templist.Add(temp);
        }

        SortedList1 = templist;
    }

    private void writefilter1totxt()
    {
        Debug.Log("file saved");

        if (!File.Exists(path1))
        {
            File.WriteAllText(path1, "");
        }


        foreach(List<string> s in gameList)
        {
            string temp = "";
            foreach (string ss in s)
            {
                Debug.Log(ss+"cfvghbnjkm,l");
                temp += ss+ "\n";
                //File.AppendAllText(path1, ss + "\n");

            }
            
            File.AppendAllText(path1,temp + "#"+"\n");
        }

    }

}
