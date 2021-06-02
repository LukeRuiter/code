using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{

    public GameObject Mapobj;
    public GameObject GreenData;
    public GameObject PurpleData;
    public GameObject RepandUtil;
    public GameObject unitselectMarker;
    GameManager gm;
    //float YMax = 2f;
    //float YMin = -4.2f;

    //float XMax = 10f;
    //float xMin = -18.4f;


    public Camera cam;

    Vector3 cameraPos;
    Vector3 cameraPosOg;
    Vector3 cameraPosMove;

    Vector3 GhostUnitPos; // unit pos for auto move 

    public GameObject unitslected;
    public GameObject UIEmpty;

    int moveCount = 0;
    public int batteries; // moves in te turn

    public int turnCount = 0;

    LayerMask groundMask;
    LayerMask unitMask;
    LayerMask dataMask;
    RaycastHit hit;


    public bool P1planning;
    public bool P2planning;
    //  public GameObject tilees;

    //shared guns
    public List<Weapons> PurpleWeaponList = new List<Weapons>();
    public List<Weapons> GreenWeaponList = new List<Weapons>();


    public List<GameObject> PurpleUnitList = new List<GameObject>();
    public List<GameObject> GreenUnitList = new List<GameObject>();

    //private List<string> evotestdata = new List<string>();

    private List<string> purplevo = new List<string>();
    private List<string> greenevo = new List<string>();


    public Text batteriesUI;

    public GameObject Eval;

    int auto;
    int timeout = 25;

    int unitCount = 1;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    public Vector2 pOg1;
    public Vector2 pOg2;
    public Vector2 pOg3;
    public Vector2 pOg4;

    public GameObject G1;
    public GameObject G2;
    public GameObject G3;
    public GameObject G4;

    public Vector2 gOg1;
    public Vector2 gOg2;
    public Vector2 gOg3;
    public Vector2 gOg4;

    public  bool move = true;
    public bool attack = false;

    float tick = 0;
    int bestmovecount = 0;
    // GameObject selectedtile;
    // the object selected with ray cast
    // Start is called before the first frame update

    int count =0;
    private void Awake()
    {
        //Debug.Log(gm.AIOn+" is the this");
        gm = GameManager.Instance; 
      //  Debug.Log(GameManager.Instance.AIHard);
        cameraPosOg = cam.transform.position;
        cameraPos = cameraPosOg;

        moveCount = 0;
        batteries = 2;
        turnCount = 0;
        auto = 0;
        move = true;
        //P1planning = true; // true for during planning faze player 1
        //P2planning = false;// true during planning faze player2

        PopWeaponList();
        SetUnitPos();
        UIEmpty.GetComponent<TurnButtons>().HealthCheck();


        pOg1 = P1.transform.position;
        pOg2 = P2.transform.position;
        pOg3 = P3.transform.position;
        pOg4 = P4.transform.position;

        gOg1 = G1.transform.position;
        gOg2 = G2.transform.position;
        gOg3 = G3.transform.position;
        gOg4 = G4.transform.position;

    }

    private void Start()
    {
        //Debug.Log("hello?");

        //gatherEvo();

        GameManager.Instance.newgame = true;
    }


    private void FixedUpdate()
    {
        //if(auto <= 1000)
        //{
        if (GameManager.Instance.getTest())
        {

            if (GameManager.Instance.testcount <= 10000)
            {
                GenTestData();
            }
        }
        else
        {
           
            RunEngine();

        }

        tick += Time.deltaTime;
       // Debug.Log(tick);
        if (tick>= 1 & tick <2)
        {
            unitslected.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (tick > 2)
        {
            unitslected.GetComponent<SpriteRenderer>().color = Color.white;
            tick = 0;
        }
        //}
        //else
        //{
        //    Debug.Log("jobs done");
        //}
        //auto++;

    }

    public void GenTestData()
    {
        batteriesUI.text = batteries.ToString();

        if (turnCount%2 ==0)
        {
            AutoP1();
        }
        else
        {
            AutoP2();
        }

        GameManager.Instance.newgame = false;
    }

    private void PlayEvo()
    {
        //int[] bestchoice = new int[2];

        //bestchoice = Eval.GetComponent<Evaluation>().MostLiklyMove(PurpleUnitList,GreenUnitList);
        //int game = bestchoice[0];
        //int move = bestchoice[1];

        //Debug.Log(game + " " + move);


        SetToRep(GameManager.Instance.bestmoves[bestmovecount]);
        if (CheckData() == true)
        {
            SceneManager.LoadScene("EndGame");
        }
        bestmovecount++;

        //Debug.Log("found move " + GameManager.Instance.EvotestData[game][move]);
        //Debug.Log("going with move " + GameManager.Instance.EvotestData[game][move + 16]);
        
     
        //Debug.Log(GameManager.Instance.EvotestData[game][move]);

        turnCount++;

    }


    public void GenTestDataEvo()
    {
        batteriesUI.text = batteries.ToString();

        if (turnCount % 2 == 0)
        {
            AutoP1();
        }
        else
        {
            if (turnCount <5)
            {
                //showevo(turnCount);
                Debug.Log(greenevo[0]+"       "+ greenevo[1]);
                Debug.Log(purplevo[0]);
               // AutoP2Evo(evotestdata[0]);
                count++;
            }
            
        }
    }
    public void RunEngine()
    {

        batteriesUI.text = batteries.ToString();
       
        if (turnCount % 2 == 0) // defines whoes turn it is 
        {
             Player1Turn();
                // AutoP1();
        }
        else
        {
            if (GameManager.Instance.returnEvo())
            {
                PlayEvo();
            }
            else
            {
                if (gm.AIOn)
                {

                    AutoP2();

                }
                else
                {
                    Player2Turn();
                }
            }
          
            //Player2Turn();

        }

    }

    public void Player1Turn()
    {
        UIEmpty.GetComponent<TurnButtons>().HealthCheck();

    

        switch (unitCount)
        {
            case 1:

                unitslected = P1;
             
                break;
            case 2:
                unitslected.GetComponent<SpriteRenderer>().color = Color.white;

                unitslected = P2;

                break;
            case 3:
                unitslected.GetComponent<SpriteRenderer>().color = Color.white;

                unitslected = P3;

                break;
            case 4:
                unitslected.GetComponent<SpriteRenderer>().color = Color.white;

                unitslected = P4;

                break;
                   
        }

        if (unitslected.GetComponent<PurpleUnit>().health > 0)
        {


            if (move)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit))
                    {
                        //  Debug.Log("trying to move");

                        if (hit.transform.tag == "Ground")
                        {
                            float distance = Vector2.Distance(unitslected.gameObject.transform.position, hit.transform.position);
                            if (distance < 1.5)
                            {
                                unitslected.GetComponent<PurpleUnit>().Move(hit.transform.position);
                                batteries--;
                            }
                            else
                            {
                                //Debug.Log("too far");
                            }
                        }
                    }
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.tag == "Unit02")
                        {
                            float distance = Vector2.Distance(unitslected.transform.position, hit.transform.position);
                            Weapons wp = unitslected.GetComponent<PurpleUnit>().weapon;

                            if (wp.CheckRange() >= distance)
                            {
                                unitslected.GetComponent<PurpleUnit>().Atack(hit.transform.gameObject.GetComponent<GreenUnit>());

                                if (wp.ReturnType() != "HandGun")
                                {
                                    wp.Ownership(false);
                                    wp.SetCooldown();

                                    foreach (Weapons w in PurpleWeaponList)
                                    {
                                        if (w.ReturnType() == "Handgun")
                                        {
                                            if (w.ReturnOwner() == false)
                                            {
                                                if (unitslected.GetComponent<PurpleUnit>().weapon.ReturnType() != "Handgun")  // should only get the first handgun on the list
                                                {

                                                    unitslected.GetComponent<PurpleUnit>().weapon = w;
                                                    Debug.Log("changed back to handgun");
                                                }
                                            }
                                        }

                                    }
                                }
                                Debug.Log("attacked");
                                batteries--;
                            }
                        }
                    }
                }
            }


            if (batteries == 0)
            {
                unitslected.GetComponent<SpriteRenderer>().color = Color.white;
                //Debug.Log("reset the bat");
                unitCount++;
                if (unitCount == 5)
                {
                    //Debug.Log("turnover");
                    turnCount++;
                    UIEmpty.GetComponent<TurnButtons>().EndTurnButtonClick();
                    batteries = 2;
                    unitCount = 1;

                    foreach (Weapons w in PurpleWeaponList) // lowers the cooldown of each weapon
                    {
                        if (w.ReturnType() != "Handgun")
                        {
                            if (w.GetCooldown() != 0)
                            {
                                w.LowerCooldown();
                            }
                        }
                    }

                    foreach (GameObject u in PurpleUnitList)
                    {
                        u.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                }
                else
                {
                    unitslected.GetComponent<SpriteRenderer>().color = Color.white;

                    batteries = 2;
                    //Debug.Log(unitCount + "'s turn now");
                }

            }


        }
        else
        {
            
            unitslected.GetComponent<SpriteRenderer>().color = Color.white;
            //Debug.Log("reset the bat");
            unitCount++;
            if (unitCount == 5)
            {
                //Debug.Log("turnover");
                turnCount++;
                UIEmpty.GetComponent<TurnButtons>().EndTurnButtonClick();
                batteries = 2;
                unitCount = 1;

                foreach (Weapons w in PurpleWeaponList) // lowers the cooldown of each weapon
                {
                    if (w.ReturnType() != "Handgun")
                    {
                        if (w.GetCooldown() != 0)
                        {
                            w.LowerCooldown();
                        }
                    }
                }

                foreach (GameObject u in PurpleUnitList)
                {
                    u.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
            else
            {
                unitslected.GetComponent<SpriteRenderer>().color = Color.white;

                batteries = 2;
                //Debug.Log(unitCount + "'s turn now");
            }

        }

  
    }

    public void Player2Turn()
    {
        UIEmpty.GetComponent<TurnButtons>().HealthCheck();

   

        switch (unitCount)
        {
            case 1:
                unitslected = G1;
                break;
            case 2:
                unitslected = G2;

                break;
            case 3:
                unitslected = G3;

                break;
            case 4:
                unitslected = G4;

                break;

        }

       
        if (move)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 20000f))
                {
                   
                    if (hit.transform.tag == "Ground")
                    {
                        float distance = Vector2.Distance(unitslected.gameObject.transform.position, hit.transform.position);
                        if (distance < 1.5)
                        {
                            unitslected.GetComponent<GreenUnit>().Move(hit.transform.position);
                            batteries--;
                            Debug.Log("moved");
                        }
                        else
                        {
                            Debug.Log("too far");
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Unit02")
                    {
                        float distance = Vector2.Distance(unitslected.transform.position, hit.transform.position);
                        Weapons wp = unitslected.GetComponent<GreenUnit>().weapon;

                        if (wp.CheckRange() >= distance)
                        {
                            unitslected.GetComponent<GreenUnit>().Atack(hit.transform.gameObject.GetComponent<PurpleUnit>());

                            if (wp.ReturnType() != "HandGun")
                            {
                                wp.Ownership(false);
                                wp.SetCooldown();

                                foreach (HandGun w in GreenWeaponList)
                                {
                                    if (w.owned == false)
                                    {
                                        if (unitslected.GetComponent<GreenUnit>().weapon.ReturnType() != "Handgun")  // should only get the first handgun on the list
                                        {

                                            unitslected.GetComponent<GreenUnit>().weapon = w;
                                            Debug.Log("changed back to handgun");
                                        }
                                    }
                                }
                            }
                            Debug.Log("attacked");
                            batteries--;
                        }
                    }
                }
            }
        }


        if (batteries == 0)
        {
            unitCount++;
            if (unitCount == 5)
            {
                Debug.Log("turnover");
                turnCount++;
                UIEmpty.GetComponent<TurnButtons>().EndTurnButtonClick();
                batteries = 2;
                unitCount = 1;

                foreach (Weapons w in GreenWeaponList) // lowers the cooldown of each weapon
                {
                    if (w.ReturnType() != "Handgun")
                    {
                        if (w.GetCooldown() != 0)
                        {
                            w.LowerCooldown();
                        }
                    }
                }

                foreach (GameObject u in GreenUnitList)
                {
                    u.GetComponent<SpriteRenderer>().color = Color.white;
                }

            }
            else
            {
                batteries = 2;
                Debug.Log(unitCount + "'s turn now");
            }

        }


    }

   public void SetUnitPos()
    {
        foreach (GameObject u in PurpleUnitList)
        {
            u.GetComponent<PurpleUnit>().x = u.transform.position.x;
            u.GetComponent<PurpleUnit>().y = u.transform.position.y;
        }
    }

   public void PopWeaponList()
    {
       // Debug.Log("pop the list");

        foreach (GameObject u in PurpleUnitList)
        {
            u.gameObject.GetComponent<PurpleUnit>().Constuctor();
        }
        foreach (GameObject u in GreenUnitList)
        {
            u.gameObject.GetComponent<GreenUnit>().Constuctor();
        }


        NadeClass Pgran = new NadeClass();
        NadeClass Ggran = new NadeClass();
        Pgran.Constuctor();
        Ggran.Constuctor();

        MachineGun PMG = new MachineGun();
        MachineGun GMG = new MachineGun();
        PMG.Constuctor();
        GMG.Constuctor();

        SniperRifle Prifle = new SniperRifle();
        SniperRifle Grifle = new SniperRifle();
        Prifle.Constuctor();
        Grifle.Constuctor();


        PurpleWeaponList.Add(Pgran);
        PurpleWeaponList.Add(PMG);
        PurpleWeaponList.Add(Prifle);

        GreenWeaponList.Add(Ggran);
        GreenWeaponList.Add(GMG);
        GreenWeaponList.Add(Grifle);

        foreach (GameObject u in PurpleUnitList)
        {

            HandGun HG = new HandGun();
            HG.Constuctor();

            PurpleWeaponList.Add(HG);
            u.gameObject.GetComponent<PurpleUnit>().weapon = HG;
            HG.owned = true;


         


        }


        foreach (GameObject u in GreenUnitList)
        {



            HandGun HG = new HandGun();
            HG.Constuctor();

            GreenWeaponList.Add(HG);
            u.gameObject.GetComponent<GreenUnit>().weapon = HG;
            HG.owned = true;

        }

        //foreach(Weapons w in PurpleWeaponList)
        //{
        //    Debug.Log(w.ToString() + " Purple");
        //}
        //foreach (Weapons w in GreenWeaponList)
        //{
        //    Debug.Log(w.ToString() + " green");
        //}
    } //populate shared weapons list and eq hand guns

   void CamFocus(Vector3 aim)
    {
       // cameraPosMove = aim;

        Vector3 lewayPos = new Vector3(aim.x + (float)2, aim.y + (float)2, (float)-2);


        //if (cam.transform.position.x < aim.x && cam.transform.position.x< lewayPos.x) //x
        //{
        //    cameraPos.x += Time.deltaTime*6;
        //}
        //else if (cam.transform.position.x > aim.x && cam.transform.position.x < lewayPos.x)
        //{
        //    cameraPos.x -= Time.deltaTime*6;

        //}

        //if (cam.transform.position.y < aim.y && cam.transform.position.y < lewayPos.y) //y
        //{
        //    cameraPos.y += Time.deltaTime*6;

        //}
        //else if (cam.transform.position.y > aim.y && cam.transform.position.y < lewayPos.y)
        //{
        //    cameraPos.y -= Time.deltaTime*6;

        //}

        //if (cam.transform.position.z > -2 && cam.transform.position.z < lewayPos.z) //z
        //{
        //    cameraPos.z -= Time.deltaTime *6;

        //}

   
            cam.transform.position -= aim;
        


    }

   void CheckDeath()
    {
        foreach(GameObject u in PurpleUnitList)
        {
            if (u.GetComponent<PurpleUnit>().health<= 0)
            {
                u.GetComponent<PurpleUnit>().Death();
                PurpleUnitList.Remove(u);
            }
        }

        foreach (GameObject u in GreenUnitList)
        {
            if (u.GetComponent<GreenUnit>().health <= 0)
            {
                u.GetComponent<GreenUnit>().Death();
                PurpleUnitList.Remove(u);

            }
        }
    }


    void AutoP1()
    {
        switch (unitCount)
        {
            case 1:
                unitslected = P1;
                break;
            case 2:
                unitslected = P2;

                break;
            case 3:
                unitslected = P3;

                break;
            case 4:
                unitslected = P4;

                break;

        }


        // unitslected.transform.position = Eval.GetComponent<Evaluation>().bestmove(1, PurpleUnitList, GreenUnitList, unitCount);


        Vector3 pos = new Vector3();

        if (gm.AIHard)
        {
            pos = Eval.GetComponent<Evaluation>().bestmove(0, PurpleUnitList, GreenUnitList, unitCount);
          //  Debug.Log("its hard");
        }
        else
        {
            pos = Eval.GetComponent<Evaluation>().MaybeBestMove(0, PurpleUnitList, GreenUnitList, unitCount);
            //Debug.Log("Maybe the best move");
        }
        //Debug.Log(unitCount + " is moveing to " + pos);

        if (pos == GreenData.transform.position)
        {
             SceneManager.LoadScene("EndGame");

          //  Reset();
        }

        if (move)
        {
           // Debug.Log(pos);
           //move messed up before here.
            unitslected.GetComponent<PurpleUnit>().Move(pos);
            batteries--;

        }
        else if (attack)
        {
            foreach (GameObject e in GreenUnitList)
            {
                if (e.transform.position == pos)
                {
                    unitslected.GetComponent<PurpleUnit>().Atack(e.GetComponent<GreenUnit>());
                    Weapons wp = unitslected.GetComponent<PurpleUnit>().weapon;

                    if (wp.ReturnType() != "HandGun")
                    {
                        wp.Ownership(false);
                        wp.SetCooldown();

                        foreach (Weapons w in PurpleWeaponList)
                        {
                            HandGun H = new HandGun();
                            if (w.ReturnType() == "Handgun")
                            {
                                H = (HandGun)w;
                            }
                            if (H.owned == false)
                            {
                                if (unitslected.GetComponent<PurpleUnit>().weapon.ReturnType() != "Handgun")  // should only get the first handgun on the list
                                {

                                    unitslected.GetComponent<PurpleUnit>().weapon = w;
                                    Debug.Log("changed back to handgun");
                                }
                            }
                        }
                    }
                }
            }

            batteries--;
        }

        if (batteries == 0)
        {
            unitCount++;
            if (unitCount == 5)
            {
                //Debug.Log("turnover");
                turnCount++;
                UIEmpty.GetComponent<TurnButtons>().EndTurnButtonClick();
                batteries = 2;
                unitCount = 1;


                foreach (Weapons w in GreenWeaponList) // lowers the cooldown of each weapon
                {
                    if (w.ReturnType() != "Handgun")
                    {
                        if (w.GetCooldown() != 0)
                        {
                            w.LowerCooldown();
                        }
                    }
                }

                foreach (GameObject u in PurpleUnitList)
                {
                    u.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
            else
            {
                batteries = 2;
                //Debug.Log(unitCount + "'s turn now");
            }

        }


    } // for FSM

    void AutoP2()
    {


        switch (unitCount)
        {
            case 1:
                unitslected = G1;
                break;
            case 2:
                unitslected = G2;

                break;
            case 3:
                unitslected = G3;

                break;
            case 4:
                unitslected = G4;

                break;

        }


        // unitslected.transform.position = Eval.GetComponent<Evaluation>().bestmove(1, PurpleUnitList, GreenUnitList, unitCount);


        Vector3 pos = new Vector3();

        if (gm.AIHard)
        {
            pos = Eval.GetComponent<Evaluation>().bestmove(1, PurpleUnitList, GreenUnitList, unitCount);
            Debug.Log("its hard");
        }
        else
        {
            pos = Eval.GetComponent<Evaluation>().MaybeBestMove(1, PurpleUnitList, GreenUnitList, unitCount);
            //Debug.Log("Maybe the best move");
        }
        //Debug.Log(unitCount + " is moveing to " + pos);

        if (pos == PurpleData.transform.position)
        {
            // SceneManager.LoadScene("EndGame");
          //  Reset();
        }

        if (move)
        {
            unitslected.GetComponent<GreenUnit>().Move(pos);
            batteries--;

        }
        else if (attack) 
        {
            foreach (GameObject e in PurpleUnitList)
            {
                if (e.transform.position == pos)
                {
                    unitslected.GetComponent<GreenUnit>().Atack(e.GetComponent<PurpleUnit>());
                    Weapons wp = unitslected.GetComponent<GreenUnit>().weapon;

                    if (wp.ReturnType() != "HandGun")
                    {
                        wp.Ownership(false);
                        wp.SetCooldown();

                        foreach (Weapons w in GreenWeaponList)
                        {
                            HandGun H = new HandGun();
                            if (w.ReturnType() == "Handgun")
                            {
                                H = (HandGun)w;
                            }
                            if (H.owned == false)
                            {
                                if (unitslected.GetComponent<GreenUnit>().weapon.ReturnType() != "Handgun")  // should only get the first handgun on the list
                                {

                                    unitslected.GetComponent<GreenUnit>().weapon = w;
                                   // Debug.Log("changed back to handgun");
                                }
                            }
                        }
                    }
                }
            }

            batteries--;
        }

        if (batteries == 0)
        {
            unitCount++;
            if (unitCount == 5)
            {
                //Debug.Log("turnover");
                turnCount++;
                UIEmpty.GetComponent<TurnButtons>().EndTurnButtonClick();
                batteries = 2;
                unitCount = 1;


                foreach (Weapons w in GreenWeaponList) // lowers the cooldown of each weapon
                {
                    if (w.ReturnType() != "Handgun")
                    {
                        if (w.GetCooldown() != 0)
                        {
                            w.LowerCooldown();
                        }
                    }
                }

                foreach (GameObject u in GreenUnitList)
                {
                    u.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
            else
            {
                batteries = 2;
                //Debug.Log(unitCount + "'s turn now");
            }

        }


        //  CheckDeath();
    } //FOR FSM

    private bool CheckData() // see how close enemy data is
    {
        float distance;
        if (turnCount%2 == 0) // purp
        {
            distance = Vector2.Distance(unitslected.gameObject.transform.position, GreenData.gameObject.transform.position);


        }
        else
        {
             distance = Vector2.Distance(unitslected.gameObject.transform.position, PurpleData.gameObject.transform.position);

        }

        if (distance <= 1.5)
        {
            return true;
        }

        Vector3 purpledatapos = new Vector3(19, 0);
        foreach (GameObject u in GreenUnitList)
        {
            Debug.Log(u.transform.position);
            if (u.transform.position == purpledatapos)
            {
                return true;

            }
        }


        return false;
    }

    private GameObject CheckAttack()
    {


        float distance;

        if (turnCount%2 == 0)
        {
            foreach(GameObject u in GreenUnitList)
            {
                distance = Vector2.Distance(unitslected.gameObject.transform.position, u.gameObject.transform.position);
                if (distance<= unitslected.gameObject.GetComponent<PurpleUnit>().weapon.CheckRange())
                {
                    return u;
                }
            }
        }
        else
        {
            foreach (GameObject u in PurpleUnitList)
            {
                distance = Vector2.Distance(unitslected.gameObject.transform.position, u.gameObject.transform.position);
                if (distance <= unitslected.gameObject.GetComponent<GreenUnit>().weapon.CheckRange())
                {
                    return u;
                }
            }
        }

        return null;
    } // see if there is any enemy units in attacking range of the selected unit


    public void SelectUnit()
    {
        bool selected = false;
        //Debug.Log("selecting: " + turnCount.ToString());
        
       // Debug.Log(ran);
        if (turnCount%2 !=0) //green turn
        {
            int ran = Random.Range(0, GreenUnitList.Count-1);

                if (GreenUnitList[ran].GetComponent<GreenUnit>().Alive == true)
                {
                    unitslected = GreenUnitList[ran];
                   // Debug.Log(unitslected.GetComponent<GreenUnit>().ToString());
                    selected = true;
                }
              
            

         //   Debug.Log("selecting green");
          
        }
        else
        {
            while(selected == false)
            {
                int ran = Random.Range(0, PurpleUnitList.Count-1);
                if (PurpleUnitList[ran].GetComponent<PurpleUnit>().Alive == true)
                {
                    //Debug.Log("purp unit selected");
                    unitslected = PurpleUnitList[ran];
                    selected = true;
                }
             
            }

         
        }
    }

    public void SetToRep(string rep) // set the board to the rep
    {

        string keenrep = rep;

        string unit0;
        string unit1 = "";
        string unit2 = "";
        string unit3 = "";

        int dotindex;
       // int uindex;

        rep = rep.Substring(0, rep.IndexOf("|"));
        Debug.Log(rep);

        //1st unit
        dotindex = rep.IndexOf("_");
        Debug.Log("dotindex: " + dotindex);
        string temprep = rep.Substring(dotindex - 2);
        if (temprep[0] == '1' || temprep[0] == '2')
        {
            Debug.Log("doubltdiget");

            unit0 = rep.Substring(dotindex - 2, dotindex + 2);

        }
        else
        {
            unit0 = rep.Substring(dotindex - 1, dotindex + 2);

        }
        dotindex = unit0.IndexOf("_");
        int posx = int.Parse(unit0.Substring(0, dotindex));
        int posy = int.Parse(unit0.Substring(dotindex+1, 1));
        Vector2 pos = new Vector2(posx, posy);
        GreenUnitList[0].transform.position = pos;
        Debug.Log(unit0);

        // 2nd unit;

        rep = rep.Remove(0,unit0.Length);
        dotindex = rep.IndexOf("_");
        temprep = rep.Substring(dotindex - 2);

        if (temprep[0] == '1' || temprep[0] == '2')
        {
            unit1 = rep.Substring(dotindex - 2, dotindex + 2);

        }
        else
        {
            unit1 = rep.Substring(dotindex - 1, dotindex + 2);

        }
        dotindex = unit1.IndexOf("_");
        posx = int.Parse(unit1.Substring(0, dotindex));
        posy = int.Parse(unit1.Substring(dotindex + 1, 1));
        pos = new Vector2(posx, posy);
        GreenUnitList[1].transform.position = pos;

        //3rd unit

        rep = rep.Remove(0, unit1.Length);
        dotindex = rep.IndexOf("_");
        temprep = rep.Substring(dotindex - 2);

        if (temprep[0] == '1' || temprep[0] == '2')
        {
            unit2 = rep.Substring(dotindex - 2, dotindex + 2);

        }
        else
        {
            unit2 = rep.Substring(dotindex - 1, dotindex + 2);

        }
        dotindex = unit2.IndexOf("_");
        posx = int.Parse(unit2.Substring(0, dotindex));
        posy = int.Parse(unit2.Substring(dotindex + 1, 1));
        pos = new Vector2(posx, posy);
        GreenUnitList[2].transform.position = pos;

        // 4th unit


        rep = rep.Remove(0, unit2.Length);
        dotindex = rep.IndexOf("_");
        temprep = rep.Substring(dotindex - 2);

        if (temprep[0] == '1' || temprep[0] == '2')
        {

            unit3 = rep.Substring(dotindex - 2, dotindex + 2);

        }
        else
        {
            unit3 = rep.Substring(dotindex - 1, dotindex + 2);

        }
        dotindex = unit3.IndexOf("_");
        posx = int.Parse(unit3.Substring(0, dotindex));
        posy = int.Parse(unit3.Substring(dotindex + 1, 1));
        pos = new Vector2(posx, posy);
        GreenUnitList[3].transform.position = pos;
        //rep = rep.Substring(dotindex+2,rep.Length);
        //Debug.Log(rep);
        // dotindex = unit0.IndexOf("_");

        //if (unit0[dotindex - 2] == '1' || unit0[dotindex - 2] == '2')
        //{


        //}
        //else
        //{
        //    //string xpox = unit0.Substring(dotindex - 1, dotindex);
        //    //string ypos = unit0.Substring(unit0.Length);
        //    //Vector3 pos = new Vector3(int.Parse(xpox), int.Parse(ypos));

        //    //GreenUnitList[0].transform.position = pos;
        //    //Debug.Log(pos);
        //}
        //rep = rep.Substring(dotindex + 2);
        //Debug.Log(rep);
        //uindex = rep.IndexOf("U");
        //dotindex = rep.IndexOf("_");
        //unit1 = rep.Substring(uindex, dotindex + 2);
        //Debug.Log(unit1);

        //rep = rep.Substring(dotindex + 2);
        //Debug.Log(rep);
        //uindex = rep.IndexOf("U");
        //dotindex = rep.IndexOf("_");
        //unit2 = rep.Substring(uindex, dotindex + 2);
        //Debug.Log(unit2);

        //rep = rep.Substring(dotindex + 2);
        //dotindex = rep.IndexOf("_");
        //unit3 = rep.Substring(0, dotindex + 2);
        //Debug.Log(unit3);


    }

    private void Reset()
    {
        foreach (GameObject u in PurpleUnitList)
        {
            u.GetComponent<PurpleUnit>().health = 5;

        }
        foreach (GameObject u in GreenUnitList)
        {
            u.GetComponent<GreenUnit>().health = 5;

        }

        P1.transform.position = pOg1;
        P2.transform.position = pOg2;
        P3.transform.position = pOg3;
        P4.transform.position = pOg4;

        G1.transform.position = gOg1;
        G2.transform.position = gOg2;
        G3.transform.position = gOg3;
        G4.transform.position = gOg4;

        Awake();
    }

}



