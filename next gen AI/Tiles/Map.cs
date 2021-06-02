using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject[,] maparray = new GameObject[20, 8];

    int Width = 20;
    int Height = 8;

    public GameObject GreenData;
    public GameObject PurpleData;

    public GameObject G1;
    public GameObject G2;
    public GameObject G3;
    public GameObject G4;

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;


    public int width = 20;
    public int height = 8;

    public GameObject[] tiles = new GameObject[2];
    public GameObject[] pathtiles = new GameObject[3];

    GameObject[,] tilearray = new GameObject[20,8];
    // Start is called before the first frame update
    void Start()
    {
        float ran;

        ran = Random.Range(0, 2);

        if (ran == 0)
        {
            placepath(true);
        }
        else
        {
            placepath(false);
        }


        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {

               // Instantiate(tiles[0], new Vector3(x, y), Quaternion.identity);

                if (tilearray[x, y] == null)
                {
                    ran = Random.Range(0, 100);

                    if ((x>=5)&&(x<=15) &&(y>=2)&&(y<=6))
                    {
                        
                        if (ran > 90)
                        {
                            Instantiate(tiles[1], new Vector3(x, y), Quaternion.identity);

                        }

                        else
                        {
                            Instantiate(tiles[0], new Vector3(x, y), Quaternion.identity);

                        }
                    }
                    else
                    {
                        Instantiate(tiles[0], new Vector3(x, y), Quaternion.identity);

                    }

                }


            }


        }


        //path placement

      
     
        Vector3 data = new Vector3(0, Height);

        GreenData.transform.position = data;
        data = new Vector3(Width,0);
        PurpleData.transform.position = data;
     
    }

    void placepath(bool vert)
    {
        bool placedresup = false;

        if (!vert) // will goo hor
        {

            Debug.Log("should go up");
            int rant = Random.Range(2, 18);

            Debug.Log(Height);
            for (int y = 0; y < Height; y ++)
            {
                int x;

                if (rant >0 || rant<19)
                {
                   x = Random.Range(rant - 1, rant + 1);
                }
                else
                {
                    x = Random.Range(rant - 1, rant + 1);
                }
                if (x>0)
                {

                    if (placedresup == false)
                    {
                        int resup = Random.Range(0, 10);

                        if (resup == 9)
                        {
                            int ran = Random.Range(1, 3);

                            GameObject pathtile = new GameObject();
                            pathtile = pathtiles[3];
                            Debug.Log(x + " " + y);
                            tilearray[x, y] = pathtile;
                            Instantiate(pathtile, new Vector3(x, y), Quaternion.identity);

                            placedresup = true;
                        }
                        else
                        {
                            int ran = Random.Range(1, 3);

                            GameObject pathtile = new GameObject();
                            pathtile = pathtiles[ran];
                            Debug.Log(x + " " + y);
                            tilearray[x, y] = pathtile;
                            Instantiate(pathtile, new Vector3(x, y), Quaternion.identity);
                        }
                    }
                    else
                    {
                        int ran = Random.Range(1, 3);

                        GameObject pathtile = new GameObject();
                        pathtile = pathtiles[ran];
                        Debug.Log(x + " " + y);
                        tilearray[x, y] = pathtile;
                        Instantiate(pathtile, new Vector3(x, y), Quaternion.identity);

                    }
                }
                            rant = x;
                   
             

            }
        }
        else // vert
        {
            int rant = Random.Range(2, 8);
            Debug.Log("should go hor");

            

            for (int x = 0; x < Width-1; x++)
            {
                int Y;

                if (rant > 0 || rant < 7)
                {
                    Y = Random.Range(rant - 1, rant + 1);
                }
                else
                {
                    Y = Random.Range(rant - 1, rant + 1);
                }

                if (Y>0)
                {
                    int resup = Random.Range(0, 10);
                  
                    if (placedresup == false)
                    {
                        if (resup == 9)
                        {
                            rant = Y;
                            int ran = Random.Range(0, 3);
                            Debug.Log("placeing loot");

                            GameObject pathtile = new GameObject();
                            pathtile = pathtiles[3];
                            tilearray[x, Y] = pathtile;
                            Instantiate(pathtile, new Vector3(x, Y), Quaternion.identity);
                            placedresup = true;

                        }
                        else
                        {
                            rant = Y;
                            int ran = Random.Range(0, 3);
                            Debug.Log(rant);

                            GameObject pathtile = new GameObject();
                            pathtile = pathtiles[ran];
                            tilearray[x, Y] = pathtile;
                            Instantiate(pathtile, new Vector3(x, Y), Quaternion.identity);
                        }
               
                    }
                    else
                    {
                        rant = Y;
                        int ran = Random.Range(0, 3);
                        Debug.Log(rant);

                        GameObject pathtile = new GameObject();
                        pathtile = pathtiles[ran];
                        tilearray[x, Y] = pathtile;
                        Instantiate(pathtile, new Vector3(x, Y), Quaternion.identity);
                    }
 
                }
              

            }
        }
    } 
}
