using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Evaluation : MonoBehaviour
{
    public GameEngine GE;


    public GameObject GData;
    public GameObject PData;
    public GameObject buttonempty;
    float functScore;


    //public string BestMove(int turn)
    //{
    //    //Debug.Log("run");
    //    string bestmove="";

    //    PurpleUnitList = GE.GetComponent<GameEngine>().PurpleUnitList;
    //    GreenUnitList = GE.GetComponent<GameEngine>().GreenUnitList;

    //    List<string> movesrep = new List<string>();
    //    List<int> movesscore = new List<int>();



    //    if (turn%2 == 0) // purple team
    //    {


    //        foreach (GameObject u in PurpleUnitList) //GameObject u in PurpleUnitList
    //        {
    //           // Debug.Log("unit count " + u);

    //            List<GameObject> templist = new List<GameObject>(PurpleUnitList);

    //            for (int i = 0; i < 6; i++)
    //            {
    //                GameObject tempUnit = new GameObject();

    //                foreach (GameObject up in templist)
    //                {
    //                    if (u == up)
    //                    {
    //                        tempUnit = up;
    //                    }
    //                }

    //                tempUnit.transform.position += tempUnit.GetComponent<PurpleUnit>().Move(i);
    //                Debug.Log("move purp: " + i);

    //                string rep = Representation(GreenUnitList, templist);
    //                int util = utilityFunction(0, GreenUnitList, templist);

    //                movesrep.Add(rep);
    //                movesscore.Add(util);
    //            }
    //        }

    //        //Debug.Log(movesscore.Count + "efbhj");
    //        int bestpos = 0;
    //        int countpos = 0;
    //        int bestMove = 0;


    //        foreach (int i in movesscore)
    //        {

    //            if (i ==0)
    //            {
    //                bestMove = i;
    //            }
    //            else
    //            {
    //                if (i> bestMove)
    //                {
    //                    bestMove = i;
    //                    bestpos = countpos;
    //                }
    //            }
    //            countpos++;

    //        }

    //        bestmove = movesrep[bestpos];

    //        // Debug.Log("Best move: " + bestmove);

    //        return bestmove;

    //    }
    //    else
    //    {

    //        foreach (GameObject u in GreenUnitList)
    //        {
    //           List<GameObject> templist =new List<GameObject>(GreenUnitList);


    //            for (int i = 0; i < 6; i++)
    //            {
    //                GameObject tempUnit = new GameObject();

    //                foreach (GameObject up in templist)
    //                {
    //                    if (u == up)
    //                    {
    //                        tempUnit = up;
    //                    }
    //                }

    //                tempUnit.transform.position += tempUnit.GetComponent<GreenUnit>().Move(i);
    //                Debug.Log("Moved " + i);
    //                for (int tu = 0; tu < templist.Count; tu++)
    //                {
    //                    if (templist[tu] == u)
    //                    {
    //                        templist[tu] = tempUnit;
    //                    }
    //                }

    //                string rep = Representation(templist, PurpleUnitList);
    //                int util = utilityFunction(1, templist, PurpleUnitList);

    //                movesrep.Add(rep);
    //                movesscore.Add(util);

    //            }
    //        }

    //        int bestpos = 0;
    //        int countpos = 0;
    //        int bestMove = 0;
    //        foreach (int i in movesscore)
    //        {
    //            if (i == 0)
    //            {
    //                bestMove = i;
    //            }
    //            else
    //            {
    //                if (i > bestMove)
    //                {
    //                    bestMove = i;
    //                    bestpos = countpos;
    //                }
    //            }
    //            countpos++;
    //        }
    //        bestmove = movesrep[bestpos];
    //      //  Debug.Log("done run purp");
    //        return bestmove;
    //    }



    //}

    public float utilityFunction(int Team, List<GameObject> Plist, List<GameObject> Glist, GameObject unit)// how good is the position
    {
        functScore = 0;

        if (Team % 2 != 0)
        {
            functScore += unit.GetComponent<GreenUnit>().health;
            if (unit.GetComponent<GreenUnit>().weapon.ReturnType().ToUpper() != "HANDGUN") // if holding a wp
            {
                functScore += 4;
            }

            foreach (GameObject e in Plist) // inrange to shoot wp
            {
                float distance = Vector2.Distance(e.transform.position, unit.transform.position);
                if (distance < unit.GetComponent<GreenUnit>().weapon.CheckRange())
                {
                    functScore += 15;
                }
            }

            float datadis = Vector2.Distance(unit.transform.position, GE.GetComponent<GameEngine>().PurpleData.transform.position);

            functScore += (200 - (datadis * datadis) / 2); // the further the less score

            if (unit.transform.position.x < 0 || unit.transform.position.x > 19)
            {
                functScore = functScore - 10000;
                //Debug.Log("out of counds on x");
            }

            if (unit.transform.position.y > 7 || unit.transform.position.y < 0)
            {
                functScore = functScore - 10000;
                //Debug.Log("out of counds on y");
            }

            //foreach (GameObject u in Glist)
            //{
            //    if (unit.transform.position == u.transform.position)
            //    {
            //        functScore = functScore - 10000;
            //        Debug.Log("sitting on eachother");
            //    }
            //}
        }
        else
        {
            functScore += unit.GetComponent<PurpleUnit>().health;
            if (unit.GetComponent<PurpleUnit>().weapon.ReturnType().ToUpper() != "HANDGUN") // if holding a wp
            {
                functScore += 4;
            }

            foreach (GameObject e in Glist) // inrange to shoot wp
            {
                float distance = Vector2.Distance(e.transform.position, unit.transform.position);
                if (distance < unit.GetComponent<PurpleUnit>().weapon.CheckRange())
                {
                    functScore += 15;
                }
            }

            float datadis = Vector2.Distance(unit.transform.position, GE.GetComponent<GameEngine>().GreenData.transform.position);

            functScore += (200 - (datadis * datadis) / 2); // the further the less score

            if (unit.transform.position.x < 0 || unit.transform.position.x > 19)
            {
                functScore = functScore - 10000;
                //Debug.Log("out of counds on x");
            }

            if (unit.transform.position.y > 7 || unit.transform.position.y < 0)
            {
                functScore = functScore - 10000;
                //Debug.Log("out of counds on y");
            }

            //foreach (GameObject u in Glist)
            //{
            //    if (unit.transform.position == u.transform.position)
            //    {
            //        functScore = functScore - 10000;
            //        Debug.Log("sitting on eachother");
            //    }
            //}
        }
        return functScore;
    }

    public Vector3 bestmove(int Team, List<GameObject> Plist, List<GameObject> Glist, int unit)
    {
        Debug.Log("best move");
        Vector3 pos = new Vector3();
        List<GameObject> PurpleUnitList = new List<GameObject>(Plist);
        List<GameObject> GreenUnitList = new List<GameObject>(Glist);
        GameObject bestunitmove = new GameObject();
        float bestscore = 0;
        float currentscore = 0;
        GameObject tempunit = new GameObject();
        bool attacked = false;

        Vector3 OGpos1 = new Vector3();
        Vector3 OGpos2 = new Vector3();
        Vector3 OGpos3 = new Vector3();
        Vector3 OGpos4 = new Vector3();

        Vector3 ENpos1 = new Vector3();
        Vector3 ENpos2 = new Vector3();
        Vector3 ENpos3 = new Vector3();
        Vector3 ENpos4 = new Vector3();

        if (Team % 2 != 0)
        {
            Debug.Log("green");
            switch (unit)
            {
                case 1:
                    tempunit = Glist[unit - 1];
                    pos = tempunit.transform.position;
                    OGpos1 = tempunit.transform.position;
                    break;
                case 2:
                    tempunit = Glist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos2 = tempunit.transform.position;

                    break;
                case 3:
                    tempunit = Glist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos3 = tempunit.transform.position;

                    break;
                case 4:
                    tempunit = Glist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos4 = tempunit.transform.position;

                    break;
            }

            ENpos1 = Plist[0].transform.position;
            ENpos2 = Plist[1].transform.position;
            ENpos3 = Plist[2].transform.position;
            ENpos4 = Plist[3].transform.position;
            //ally weapons
            bool weaponapplied = false;
            if (tempunit.GetComponent<GreenUnit>().weapon.ReturnType().ToUpper() == "HANDGUN")
            {
                // Debug.Log("wp pplying");
                foreach (Weapons w in GE.GetComponent<GameEngine>().GreenWeaponList)
                {
                    // Debug.Log("loooooking");
                    if (!weaponapplied)
                    {
                        // Debug.Log("this ones owned");
                        if (w.ReturnType().ToUpper() != "HANDGUN")
                        {
                            if (!w.ReturnOwner())
                            {
                                //  Debug.Log("found one");

                                if (w.ReturnType().ToUpper() == "MACHINEGUN")
                                {
                                    buttonempty.GetComponent<WeaponButtons>().weaponseleted = "M";
                                    buttonempty.GetComponent<WeaponButtons>().applywp();
                                    //   Debug.Log("m gun");
                                    weaponapplied = true;

                                } else if (w.ReturnType().ToUpper() == "GRENADE")
                                {
                                    buttonempty.GetComponent<WeaponButtons>().weaponseleted = "G";
                                    buttonempty.GetComponent<WeaponButtons>().applywp();
                                    // Debug.Log("G gun");


                                    weaponapplied = true;

                                }
                                else
                                {
                                    buttonempty.GetComponent<WeaponButtons>().weaponseleted = "R";
                                    buttonempty.GetComponent<WeaponButtons>().applywp();
                                    // Debug.Log("r gun");

                                    weaponapplied = true;

                                }

                            }
                        }
                    }

                }
            }

            //check data first
            float distance = Vector3.Distance(PData.transform.position, tempunit.transform.position);
            if (distance <= 1.5)
            {
                pos = PData.transform.position;
                Debug.Log("green won");
                Representation(Glist, Plist, true, "g", GameManager.Instance.newgame);
                return pos;
            }

            //check attacking
            foreach (GameObject e in Plist) // check if we can attack
            {

                distance = Vector2.Distance(e.transform.position, tempunit.transform.position);
                if (distance <= tempunit.GetComponent<GreenUnit>().weapon.CheckRange())
                {
                    buttonempty.GetComponent<TurnButtons>().AttckClick();
                    pos = e.transform.position;
                    attacked = true;
                    Representation(Glist, Plist, false, "g", GameManager.Instance.newgame);

                    return pos;
                }
            }

            //do moving
            if (attacked == false)
            {
                buttonempty.GetComponent<TurnButtons>().MoveClick();

                for (int i = 0; i < 8; i++)
                {

                    switch (unit) // reset it evrey time
                    {
                        case 1:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos1;
                            //   Debug.Log("unit 1 at pos: " + tempunit.transform.position);
                            break;
                        case 2:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos2;

                            break;
                        case 3:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos3;

                            break;
                        case 4:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos4;

                            break;
                    }


                    GameObject checkunit = tempunit;
                    checkunit.transform.position = checkunit.GetComponent<GreenUnit>().Move(i, tempunit.transform.position.x, tempunit.transform.position.y);
                    bool validmove = true;

                    if ((checkunit.transform.position == OGpos1) || (checkunit.transform.position == OGpos2) || (checkunit.transform.position == OGpos3) || (checkunit.transform.position == OGpos4))
                    {
                        validmove = false;
                    }


                    if ((checkunit.transform.position == ENpos1) || (checkunit.transform.position == ENpos2) || (checkunit.transform.position == ENpos3) || (checkunit.transform.position == ENpos4))
                    {
                        validmove = false;
                    }


                    switch (unit) // reset it evrey time
                    {
                        case 1:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos1;
                            // Debug.Log("unit 1 at pos: " + tempunit.transform.position);
                            break;
                        case 2:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos2;

                            break;
                        case 3:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos3;

                            break;
                        case 4:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos4;

                            break;
                    }

                    if (validmove)
                    {

                        //Debug.Log("checking unit " + unit + " option number: " + i);
                        //Debug.Log("OG pos: " + tempunit.transform.position);
                        tempunit.transform.position = tempunit.GetComponent<GreenUnit>().Move(i, tempunit.transform.position.x, tempunit.transform.position.y);// moving the temp unit

                        //Debug.Log(tempunit.transform.position);
                        //Debug.Log(utilityFunction(1, Plist, Glist, tempunit));
                        currentscore = utilityFunction(1, Plist, Glist, tempunit);
                        //Debug.Log(currentscore);


                        if (currentscore > bestscore)
                        {
                            //   Debug.Log("Prev best: " + bestscore);

                            // bestunitmove = tempunit;
                            pos = tempunit.transform.position;
                            bestscore = currentscore;
                            // Debug.Log("new best: " + bestscore);
                        }
                    }

                }


                // pos = bestunitmove.transform.position;
                //Debug.Log("the best score was: ");
                //Debug.Log(bestscore + " at pos");
                //Debug.Log(pos);
                Representation(Glist, Plist, false, "g", GameManager.Instance.newgame);

                return pos;
            }

        }
        else
        {
            switch (unit)
            {
                case 1:
                    tempunit = Plist[unit - 1];
                    pos = tempunit.transform.position;
                    OGpos1 = tempunit.transform.position;
                    break;
                case 2:
                    tempunit = Plist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos2 = tempunit.transform.position;

                    break;
                case 3:
                    tempunit = Plist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos3 = tempunit.transform.position;

                    break;
                case 4:
                    tempunit = Plist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos4 = tempunit.transform.position;

                    break;
            }

            ENpos1 = Glist[0].transform.position;
            ENpos2 = Glist[1].transform.position;
            ENpos3 = Glist[2].transform.position;
            ENpos4 = Glist[3].transform.position;
            //ally weapons
            bool weaponapplied = false;
            if (tempunit.GetComponent<PurpleUnit>().weapon.ReturnType().ToUpper() == "HANDGUN")
            {
                // Debug.Log("wp pplying");
                foreach (Weapons w in GE.GetComponent<GameEngine>().PurpleWeaponList)
                {
                    //  Debug.Log("loooooking");
                    if (!weaponapplied)
                    {
                        //Debug.Log("this ones owned");
                        if (w.ReturnType().ToUpper() != "HANDGUN")
                        {
                            if (!w.ReturnOwner())
                            {
                                //Debug.Log("found one");

                                if (w.ReturnType().ToUpper() == "MACHINEGUN")
                                {
                                    buttonempty.GetComponent<WeaponButtons>().weaponseleted = "M";
                                    buttonempty.GetComponent<WeaponButtons>().applywp();
                                    // Debug.Log("m gun");
                                    weaponapplied = true;

                                }
                                else if (w.ReturnType().ToUpper() == "GRENADE")
                                {
                                    buttonempty.GetComponent<WeaponButtons>().weaponseleted = "G";
                                    buttonempty.GetComponent<WeaponButtons>().applywp();
                                    // Debug.Log("G gun");


                                    weaponapplied = true;

                                }
                                else
                                {
                                    buttonempty.GetComponent<WeaponButtons>().weaponseleted = "R";
                                    buttonempty.GetComponent<WeaponButtons>().applywp();
                                    // Debug.Log("r gun");

                                    weaponapplied = true;

                                }

                            }
                        }
                    }

                }
            }

            //check data first
            float distance = Vector3.Distance(GData.transform.position, tempunit.transform.position);
            if (distance <= 1.5)
            {
                pos = GData.transform.position;
                Debug.Log("purple won");
                Representation(Glist, Plist, true, "p", GameManager.Instance.newgame);

                return pos;
            }

            //check attacking
            foreach (GameObject e in Glist) // check if we can attack
            {

                distance = Vector2.Distance(e.transform.position, tempunit.transform.position);
                if (distance <= tempunit.GetComponent<PurpleUnit>().weapon.CheckRange())
                {
                    buttonempty.GetComponent<TurnButtons>().AttckClick();
                    pos = e.transform.position;
                    attacked = true;
                    Representation(Glist, Plist, false, "p", GameManager.Instance.newgame);

                    return pos;
                }
            }

            //do moving
            if (attacked == false)
            {
                buttonempty.GetComponent<TurnButtons>().MoveClick();

                for (int i = 0; i < 8; i++)
                {

                    switch (unit) // reset it evrey time
                    {
                        case 1:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos1;
                            // Debug.Log("unit 1 at pos: " + tempunit.transform.position);
                            break;
                        case 2:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos2;

                            break;
                        case 3:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos3;

                            break;
                        case 4:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos4;

                            break;
                    }


                    GameObject checkunit = tempunit;
                    checkunit.transform.position = checkunit.GetComponent<PurpleUnit>().Move(i, tempunit.transform.position.x, tempunit.transform.position.y);
                    bool validmove = true;

                    if ((checkunit.transform.position == OGpos1) || (checkunit.transform.position == OGpos2) || (checkunit.transform.position == OGpos3) || (checkunit.transform.position == OGpos4))
                    {
                        validmove = false;
                    }


                    if ((checkunit.transform.position == ENpos1) || (checkunit.transform.position == ENpos2) || (checkunit.transform.position == ENpos3) || (checkunit.transform.position == ENpos4))
                    {
                        validmove = false;
                    }


                    switch (unit) // reset it evrey time
                    {
                        case 1:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos1;
                            // Debug.Log("unit 1 at pos: " + tempunit.transform.position);
                            break;
                        case 2:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos2;

                            break;
                        case 3:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos3;

                            break;
                        case 4:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos4;

                            break;
                    }

                    if (validmove)
                    {

                        //Debug.Log("checking unit " + unit + " option number: " + i);
                        //Debug.Log("OG pos: " + tempunit.transform.position);
                        tempunit.transform.position = tempunit.GetComponent<PurpleUnit>().Move(i, tempunit.transform.position.x, tempunit.transform.position.y);// moving the temp unit

                        //Debug.Log(tempunit.transform.position);
                        //Debug.Log(utilityFunction(1, Plist, Glist, tempunit));
                        currentscore = utilityFunction(0, Plist, Glist, tempunit);
                        //Debug.Log(currentscore);


                        if (currentscore > bestscore)
                        {
                            Debug.Log("Prev best: " + bestscore);

                            // bestunitmove = tempunit;
                            pos = tempunit.transform.position;
                            bestscore = currentscore;
                            //  Debug.Log("new best: " + bestscore);
                        }
                    }

                }


                // pos = bestunitmove.transform.position;
                //Debug.Log("the best score was: ");
                //Debug.Log(bestscore + " at pos");
                //Debug.Log(pos);
                Representation(Glist, Plist, false, "p", GameManager.Instance.newgame);

                return pos;
            }
            Representation(Glist, Plist, false, "p", GameManager.Instance.newgame);

            return pos;
        }
        Representation(Glist, Plist, false, "p", GameManager.Instance.newgame);

        return pos;
    }

    public Vector3 MaybeBestMove(int Team, List<GameObject> Plist, List<GameObject> Glist, int unit) // for the lower difficulty
    {

        Vector3 pos = new Vector3();
        List<GameObject> PurpleUnitList = new List<GameObject>(Plist);
        List<GameObject> GreenUnitList = new List<GameObject>(Glist);
        GameObject bestunitmove = new GameObject();
        float bestscore = 0;
        float currentscore = 0;
        GameObject tempunit = new GameObject();
        bool attacked = false;

        Vector3 OGpos1 = new Vector3();
        Vector3 OGpos2 = new Vector3();
        Vector3 OGpos3 = new Vector3();
        Vector3 OGpos4 = new Vector3();

        Vector3 ENpos1 = new Vector3();
        Vector3 ENpos2 = new Vector3();
        Vector3 ENpos3 = new Vector3();
        Vector3 ENpos4 = new Vector3();

        if (Team % 2 != 0)
        {
            switch (unit)
            {
                case 1:
                    tempunit = Glist[unit - 1];
                    pos = tempunit.transform.position;
                    OGpos1 = tempunit.transform.position;
                    break;
                case 2:
                    tempunit = Glist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos2 = tempunit.transform.position;

                    break;
                case 3:
                    tempunit = Glist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos3 = tempunit.transform.position;

                    break;
                case 4:
                    tempunit = Glist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos4 = tempunit.transform.position;

                    break;
            }

            ENpos1 = Plist[0].transform.position;
            ENpos2 = Plist[1].transform.position;
            ENpos3 = Plist[2].transform.position;
            ENpos4 = Plist[3].transform.position;
            //ally weapons
            bool weaponapplied = false;
            if (tempunit.GetComponent<GreenUnit>().weapon.ReturnType() == "HandGun")
            {
                // Debug.Log("wp pplying");
                foreach (Weapons w in GE.GetComponent<GameEngine>().GreenWeaponList)
                {
                    //  Debug.Log("loooooking");
                    if (!weaponapplied)
                    {
                        if (w.CheckCooldown() <= 0)
                        {
                            // Debug.Log("this ones owned "+ w.ReturnType());
                            if (w.ReturnType() != "HandGun")
                            {
                                if (w.ReturnOwner() == false)
                                {
                                    // Debug.Log("found one");

                                    if (w.ReturnType() == "MachineGun")
                                    {
                                        buttonempty.GetComponent<WeaponButtons>().weaponseleted = "M";
                                        buttonempty.GetComponent<WeaponButtons>().applywp();
                                        // Debug.Log("m gun");
                                        weaponapplied = true;

                                    }
                                    else if (w.ReturnType() == "Grenade")
                                    {
                                        buttonempty.GetComponent<WeaponButtons>().weaponseleted = "G";
                                        buttonempty.GetComponent<WeaponButtons>().applywp();
                                        //   Debug.Log("G gun");


                                        weaponapplied = true;

                                    }
                                    else if (w.ReturnType() == "SniperRifle")
                                    {
                                        buttonempty.GetComponent<WeaponButtons>().weaponseleted = "R";
                                        buttonempty.GetComponent<WeaponButtons>().applywp();
                                        //   Debug.Log("r gun");

                                        weaponapplied = true;

                                    }

                                }
                            }
                        }

                    }

                }
            }

            //check data first
            float distance = Vector3.Distance(PData.transform.position, tempunit.transform.position);
            if (distance <= 1.5)
            {
                pos = PData.transform.position;
                Debug.Log("green won");
                //return pos;
                Representation(Glist, Plist, true, "g", GameManager.Instance.newgame);
                SceneManager.LoadScene("Endgame");
            }

            //check attacking
            foreach (GameObject e in Plist) // check if we can attack
            {
                int ran = Random.Range(0, 10);

                distance = Vector2.Distance(e.transform.position, tempunit.transform.position);
                if (distance <= tempunit.GetComponent<GreenUnit>().weapon.CheckRange())
                {
                    if (ran > 5) // chance to not attack
                    {
                        buttonempty.GetComponent<TurnButtons>().AttckClick();
                        pos = e.transform.position;
                        attacked = true;
                        Representation(Glist, Plist, false, "", GameManager.Instance.newgame);

                        return pos;
                    }

                }
            }

            //do moving


            if (attacked == false)
            {
                buttonempty.GetComponent<TurnButtons>().MoveClick();

                for (int i = 0; i < 8; i++)
                {
                    int ran = Random.Range(0, 10);

                    switch (unit) // reset it evrey time
                    {
                        case 1:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos1;
                            //Debug.Log("unit 1 at pos: " + tempunit.transform.position);
                            break;
                        case 2:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos2;

                            break;
                        case 3:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos3;

                            break;
                        case 4:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos4;

                            break;
                    }


                    GameObject checkunit = tempunit;
                    checkunit.transform.position = checkunit.GetComponent<GreenUnit>().Move(i, tempunit.transform.position.x, tempunit.transform.position.y);
                    bool validmove = true;

                    if ((checkunit.transform.position == OGpos1) || (checkunit.transform.position == OGpos2) || (checkunit.transform.position == OGpos3) || (checkunit.transform.position == OGpos4))
                    {
                        validmove = false;
                    }


                    if ((checkunit.transform.position == ENpos1) || (checkunit.transform.position == ENpos2) || (checkunit.transform.position == ENpos3) || (checkunit.transform.position == ENpos4))
                    {
                        validmove = false;
                    }


                    switch (unit) // reset it every time
                    {
                        case 1:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos1;
                            //Debug.Log("unit 1 at pos: " + tempunit.transform.position);
                            break;
                        case 2:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos2;

                            break;
                        case 3:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos3;

                            break;
                        case 4:
                            tempunit = GreenUnitList[unit - 1];
                            tempunit.transform.position = OGpos4;

                            break;
                    }

                    if (validmove)
                    {

                        //Debug.Log("checking unit " + unit + " option number: " + i);
                        //Debug.Log("OG pos: " + tempunit.transform.position);
                        tempunit.transform.position = tempunit.GetComponent<GreenUnit>().Move(i, tempunit.transform.position.x, tempunit.transform.position.y);// moving the temp unit

                        //Debug.Log(tempunit.transform.position);
                        //Debug.Log(utilityFunction(1, Plist, Glist, tempunit));
                        currentscore = utilityFunction(1, Plist, Glist, tempunit);
                        //Debug.Log(currentscore);


                        if (currentscore > bestscore)
                        {
                            if (ran > 4) // chance to not pick the best move
                            {
                                //Debug.Log("Prev best: " + bestscore);

                                // bestunitmove = tempunit;
                                pos = tempunit.transform.position;
                                bestscore = currentscore;
                                //Debug.Log("new best: " + bestscore);
                            }

                        }
                    }

                }


                // pos = bestunitmove.transform.position;
                //Debug.Log("the best score was: ");
                //Debug.Log(bestscore + " at pos");
                //Debug.Log(pos);

                Representation(Glist, Plist, false, "", GameManager.Instance.newgame);

                return pos;
            }

        }
        else
        {
            switch (unit)
            {
                case 1:
                    tempunit = Plist[unit - 1];
                    pos = tempunit.transform.position;
                    OGpos1 = tempunit.transform.position;
                    break;
                case 2:
                    tempunit = Plist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos2 = tempunit.transform.position;

                    break;
                case 3:
                    tempunit = Plist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos3 = tempunit.transform.position;

                    break;
                case 4:
                    tempunit = Plist[unit - 1];
                    pos = tempunit.transform.position;

                    OGpos4 = tempunit.transform.position;

                    break;
            }

            ENpos1 = Glist[0].transform.position;
            ENpos2 = Glist[1].transform.position;
            ENpos3 = Glist[2].transform.position;
            ENpos4 = Glist[3].transform.position;
            //ally weapons
            bool weaponapplied = false;
            if (tempunit.GetComponent<PurpleUnit>().weapon.ReturnType() == "HandGun")
            {
                //Debug.Log("wp pplying");
                foreach (Weapons w in GE.GetComponent<GameEngine>().PurpleWeaponList)
                {
                    //Debug.Log("loooooking");
                    if (!weaponapplied)
                    {
                        if (w.CheckCooldown() <= 0)
                        {
                            if (w.ReturnType() != "HandGun")
                            {
                                // Debug.Log("looking at "+ w.ReturnType()+ " "+ w.ReturnOwner());
                                if (w.ReturnOwner() == false)
                                {
                                    //  Debug.Log("found one");

                                    if (w.ReturnType() == "MachineGun")
                                    {
                                        buttonempty.GetComponent<WeaponButtons>().weaponseleted = "M";
                                        buttonempty.GetComponent<WeaponButtons>().applywp();
                                        // Debug.Log("m gun");
                                        weaponapplied = true;

                                    }
                                    else if (w.ReturnType() == "Grenade")
                                    {
                                        buttonempty.GetComponent<WeaponButtons>().weaponseleted = "G";
                                        buttonempty.GetComponent<WeaponButtons>().applywp();
                                        //  Debug.Log("G gun");


                                        weaponapplied = true;

                                    }
                                    else if (w.ReturnType() == "SniperRifle")
                                    {
                                        buttonempty.GetComponent<WeaponButtons>().weaponseleted = "R";
                                        buttonempty.GetComponent<WeaponButtons>().applywp();
                                        // Debug.Log("r gun");

                                        weaponapplied = true;

                                    }

                                }
                            }
                        }

                    }

                }
            }

            //check data first
            float distance = Vector3.Distance(GData.transform.position, tempunit.transform.position);
            if (distance <= 1.5)
            {
                pos = GData.transform.position;
                // Debug.Log("purple won");
                //  return pos;
                Representation(Glist, Plist, true, "p", GameManager.Instance.newgame);

                SceneManager.LoadScene("Endgame");
            }

            //check attacking
            foreach (GameObject e in Glist) // check if we can attack
            {
                int ran = Random.Range(0, 10);

                distance = Vector2.Distance(e.transform.position, tempunit.transform.position);
                if (distance <= tempunit.GetComponent<PurpleUnit>().weapon.CheckRange())
                {
                    if (ran > 5) // chance to not attack
                    {
                        buttonempty.GetComponent<TurnButtons>().AttckClick();
                        pos = e.transform.position;
                        attacked = true;
                        Representation(Glist, Plist, false, "", GameManager.Instance.newgame);

                        return pos;
                    }

                }
            }

            //do moving


            if (attacked == false)
            {
                buttonempty.GetComponent<TurnButtons>().MoveClick();

                for (int i = 0; i < 8; i++)
                {
                    int ran = Random.Range(0, 10);

                    switch (unit) // reset it evrey time
                    {
                        case 1:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos1;
                            //Debug.Log("unit 1 at pos: " + tempunit.transform.position);
                            break;
                        case 2:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos2;

                            break;
                        case 3:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos3;

                            break;
                        case 4:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos4;

                            break;
                    }


                    GameObject checkunit = tempunit;
                    checkunit.transform.position = checkunit.GetComponent<PurpleUnit>().Move(i, tempunit.transform.position.x, tempunit.transform.position.y);
                    bool validmove = true;

                    if ((checkunit.transform.position == OGpos1) || (checkunit.transform.position == OGpos2) || (checkunit.transform.position == OGpos3) || (checkunit.transform.position == OGpos4))
                    {
                        validmove = false;
                    }


                    if ((checkunit.transform.position == ENpos1) || (checkunit.transform.position == ENpos2) || (checkunit.transform.position == ENpos3) || (checkunit.transform.position == ENpos4))
                    {
                        validmove = false;
                    }


                    switch (unit) // reset it evrey time
                    {
                        case 1:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos1;
                            //Debug.Log("unit 1 at pos: " + tempunit.transform.position);
                            break;
                        case 2:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos2;

                            break;
                        case 3:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos3;

                            break;
                        case 4:
                            tempunit = PurpleUnitList[unit - 1];
                            tempunit.transform.position = OGpos4;

                            break;
                    }

                    if (validmove)
                    {

                        //Debug.Log("checking unit " + unit + " option number: " + i);
                        //Debug.Log("OG pos: " + tempunit.transform.position);
                        tempunit.transform.position = tempunit.GetComponent<PurpleUnit>().Move(i, tempunit.transform.position.x, tempunit.transform.position.y);// moving the temp unit

                        //Debug.Log(tempunit.transform.position);
                        //Debug.Log(utilityFunction(1, Plist, Glist, tempunit));
                        currentscore = utilityFunction(0, Plist, Glist, tempunit);
                        //Debug.Log(currentscore);


                        if (currentscore > bestscore)
                        {
                            if (ran > 4) // chance to not pick the best move
                            {
                                //Debug.Log("Prev best: " + bestscore);

                                // bestunitmove = tempunit;
                                pos = tempunit.transform.position;
                                bestscore = currentscore;
                                //Debug.Log("new best: " + bestscore);
                            }

                        }
                    }

                }


                // pos = bestunitmove.transform.position;
                //Debug.Log("the best score was: ");
                //Debug.Log(bestscore + " at pos");
                //Debug.Log(pos);
                Representation(Glist, Plist, false, "", GameManager.Instance.newgame);

                return pos;
            }
            Representation(Glist, Plist, false, "", GameManager.Instance.newgame);

            return pos;
        }
        Representation(Glist, Plist, false, "", GameManager.Instance.newgame);

        return pos;
    }
    public string Representation(List<GameObject> Glist, List<GameObject> Plist, bool end, string winner, bool newgame) // put the bored into text
    {
        string Rep = "";
        if (newgame)
        {
            Rep = Rep + "!";

        }
        foreach (GameObject u in Glist)
        {
            if (u.GetComponent<GreenUnit>().Alive == true)
            {

                char health = u.GetComponent<GreenUnit>().health.ToString()[0];
                Rep = Rep + "U" + health;


                if (u.GetComponent<GreenUnit>().weapon.ReturnType().ToUpper() == "HANDGUN")
                {
                    Rep = Rep + "H";
                }
                else if (u.GetComponent<GreenUnit>().weapon.ReturnType().ToUpper() == "MACHINEGUN")
                {
                    Rep = Rep + "M";

                }
                else if (u.GetComponent<GreenUnit>().weapon.ReturnType().ToUpper() == "SNIPERRIFLE")
                {
                    Rep = Rep + "S";

                }
                else
                {
                    Rep = Rep + "G";

                }

                Rep = Rep + u.transform.position.x.ToString() + "_" + u.transform.position.y.ToString();
            }
        }

        Rep = Rep + ":";

        foreach (Weapons w in GE.GreenWeaponList)
        {
            if (w.CheckCooldown() != 0)
            {
                if (w.ReturnType().ToUpper() == "HANDGUN")
                {
                    Rep = Rep + "H" + w.CheckCooldown().ToString();
                }
                else if (w.ReturnType().ToUpper() == "MACHINEGUN")
                {
                    Rep = Rep + "M" + w.CheckCooldown().ToString();

                }
                else if (w.ReturnType().ToUpper() == "SNIPERRIFLE")
                {
                    Rep = Rep + "S" + w.CheckCooldown().ToString();

                }
                else
                {
                    Rep = Rep + "G" + w.CheckCooldown().ToString();

                }
            }
        }

        Rep = Rep + "|";

        foreach (GameObject u in Plist)
        {
            if (u.GetComponent<PurpleUnit>().Alive == true)
            {
                char health = u.GetComponent<PurpleUnit>().health.ToString()[0];
                Rep = Rep + "U" + health;

                if (u.GetComponent<PurpleUnit>().weapon.ReturnType().ToUpper() == "HADNGUN")
                {
                    Rep = Rep + "H";
                }
                else if (u.GetComponent<PurpleUnit>().weapon.ReturnType().ToUpper() == "MACHINEGUN")
                {
                    Rep = Rep + "M";

                }
                else if (u.GetComponent<PurpleUnit>().weapon.ReturnType().ToUpper() == "SNIPERRIFLE")
                {
                    Rep = Rep + "S";

                }
                else
                {
                    Rep = Rep + "G";

                }

                Rep = Rep + u.transform.position.x.ToString() + "_" + u.transform.position.y.ToString();
            }
        }

        Rep = Rep + ":";

        foreach (Weapons w in GE.PurpleWeaponList)
        {

            if (w.CheckCooldown() != 0)
            {

                if (w.ReturnType().ToUpper() == "HANDGUN")
                {
                    Rep = Rep + "H" + w.CheckCooldown().ToString();
                }
                else if (w.ReturnType().ToUpper() == "MACHINEGUN")
                {
                    Rep = Rep + "M" + w.CheckCooldown().ToString();

                }
                else if (w.ReturnType().ToUpper() == "SNIPERRIFLE")
                {
                    Rep = Rep + "S" + w.CheckCooldown().ToString();

                }
                else
                {
                    Rep = Rep + "G" + w.CheckCooldown().ToString();

                }
            }
        }

        // Debug.Log(Rep);
        if (end == true)
        {
            Rep = Rep + winner;
            savemove(Rep, true);

        }
        else
        {
            savemove(Rep, false);

        }
        // Debug.Log("dpne with the rep");
        return Rep;
    }

    public void savemove(string Data, bool end)
    {
        //  Debug.Log("saveing move");
        string path = Application.dataPath + "/TestDatafinal.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }

        // Debug.Log(path);
        if (end)
        {
            File.AppendAllText(path, Data + "#");

        }
        {
            File.AppendAllText(path, Data + '\n');

        }
    }

    public void SaveEvoData(string Data, bool end)
    {
        string path = Application.dataPath + "/TestDataEvo.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }

        // Debug.Log(path);
        if (end)
        {
            File.AppendAllText(path, Data + "#");

        }
        {
            File.AppendAllText(path, Data + '\n');

        }
    }

    public int[] MostLiklyMove(List <GameObject> pList, List<GameObject> glist)
    {
        int[] gamearray = new int[2];
        List<int> scores = new List<int>();

        int gameindex =0;

       
            foreach (List<string> s in GameManager.Instance.EvotestData)
            {
                foreach (string ss in s)
                {
  
                string Pmove = ss.Substring(ss.IndexOf("|"));

                string unit0 = "";
                string unit1 = "";
                string unit2 = "";
                string unit3 = "";

                int Uindex = ss.IndexOf("U");
                int dashindex = ss.IndexOf("_");

                unit0 = Pmove.Substring(Uindex, dashindex+3);

                float realposx = pList[0].transform.position.x;
                float realposy = pList[0].transform.position.y;
                string realpos = realposx.ToString() + "_" + realposy.ToString();
                Pmove = Pmove.Substring(dashindex);


                //dashindex = unit0.IndexOf("_");
                //Debug.Log(dashindex);
                //string unit0pos = unit0.Substring(dashindex - 2, dashindex +1);
                //Debug.Log(unit0pos);
                //Debug.Log(realpos);
                //Debug.Log(unit0pos);
                ////Pmove.Remove(dashindex);

                if (unit0.Contains(realpos))
                {
                    Pmove.Remove(0, dashindex + 1);
                     realposx = pList[1].transform.position.x;
                     realposy = pList[1].transform.position.y;
                     realpos = realposx.ToString() + "_" + realposy.ToString();

                    unit1 = Pmove.Substring(dashindex, dashindex + 3);

                    Debug.Log("passed 1");
                    // unit0pos = Pmove.Substring(dashindex - 2, dashindex + 1);
                    //Debug.Log(unit1 + "is pmove");



                    if (unit1.Contains(realpos))
                    {
                        Debug.Log("passed 2");

                        Pmove =  Pmove.Remove(0, dashindex + 2);
                        realposx = pList[2].transform.position.x;
                        realposy = pList[2].transform.position.y;
                        realpos = realposx.ToString() + "_" + realposy.ToString();

                        unit2 = Pmove.Substring(dashindex, dashindex + 3);

                        // Debug.Log(Pmove + "is pmove 2");


                        if (unit2.Contains(realpos))
                        {

                            realposx = pList[3].transform.position.x;
                            realposy = pList[3].transform.position.y;
                            realpos = realposx.ToString() + "_" + realposy.ToString();

                            unit3 = Pmove;
                            Debug.Log("passed 3");
                            gamearray[0] = GameManager.Instance.EvotestData.IndexOf(s);
                            gamearray[1] = GameManager.Instance.EvotestData[gamearray[0]].IndexOf(ss);

                            

                            if (unit3.Contains(realpos))
                            {
                       
                                    Debug.Log(unit2 + "             " + realpos);

                                    gamearray[0] = GameManager.Instance.EvotestData.IndexOf(s);
                                    Debug.Log(s);
                                    gamearray[1] = GameManager.Instance.EvotestData[gamearray[0]].IndexOf(ss);

                                    Debug.Log(gamearray[0]);
                                    Debug.Log(gamearray[1]);

                                    Debug.Log(unit0 + "|| " + unit1 + " ||" + unit2 + " ||" + unit3 + " ");

                                    return gamearray;
                                
                             
                            }

                        }


                        //Pmove = Pmove.Remove(0, dashindex + 1);
                

                        

                      //  return gamearray;

                    }
                }

                //unit0 = tempstring.Substring(Uindex, dashindex);


                //tempstring.Remove(dashindex);
                //Debug.Log(tempstring);
                //Uindex = ss.IndexOf("U");
                //dashindex = ss.IndexOf("_");
                //Debug.Log("1: "+Uindex + " " + dashindex);

                //unit1 = tempstring.Substring(Uindex,dashindex+1);

                //tempstring.Remove(dashindex);
                //Uindex = ss.IndexOf("U");
                //dashindex = ss.IndexOf("_");
                //Debug.Log("2: "+Uindex + " " + dashindex);

                //unit2 = tempstring.Substring(Uindex,dashindex + 1);

                //tempstring.Remove(dashindex);
                //Uindex = ss.IndexOf("U");
                //dashindex = ss.IndexOf("_");
                //Debug.Log("3: "+Uindex + " " + dashindex);

                //unit3 = tempstring.Substring(Uindex, dashindex+1);


                //Debug.Log(unit0);
                //Debug.Log(unit1);
                //Debug.Log(unit2);
                //Debug.Log(unit3);


                //if (unit0.Contains(pList[0].gameObject.transform.position.x.ToString()) && unit0.Contains(pList[0].gameObject.transform.position.y.ToString()))
                //{
                //    currentscore++;
                //}

                //if (unit1.Contains(pList[1].gameObject.transform.position.x.ToString()) && unit1.Contains(pList[1].gameObject.transform.position.y.ToString()))
                //{
                //    currentscore++;
                //}

                //if (unit2.Contains(pList[2].gameObject.transform.position.x.ToString()) && unit2.Contains(pList[2].gameObject.transform.position.y.ToString()))
                //{
                //    currentscore++;
                //}


                //if (unit3.Contains(pList[3].gameObject.transform.position.x.ToString()) && unit3.Contains(pList[3].gameObject.transform.position.y.ToString()))
                //{
                //    currentscore++;
                //}

                //// Debug.Log(currentscore);
                //if (currentscore == 4)
                //{
                //    // Debug.Log(currentscore);

                //    //moveindex = 
                //    gamearray[0] = gameindex;
                //    gamearray[1] = s.IndexOf(ss);

                //    Debug.Log(gamearray[0] + " " + gamearray[1]);
                //    return gamearray;
                //}
                //else if (currentscore == 3)
                //{
                //    gamearray[0] = gameindex;
                //    gamearray[1] = s.IndexOf(ss);

                //}

            }

            gameindex++;
            }


        return gamearray;

    }
}
