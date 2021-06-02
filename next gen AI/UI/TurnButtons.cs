using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnButtons : MonoBehaviour // doesnt update all health bars
{
    public GameObject GE;
    public Button Granade;
    public Button MachineG;
    public Button Rifle;
  //  public Button EndPlanningButton;
    public Text PlayerTurnText;

    public Button Move;
    public Button Attack;

    public RawImage Boarder;

    public Texture GB;
    public Texture PB;


    public Texture H0; // min
    public Texture H1;
    public Texture H2;
    public Texture H3;
    public Texture H4; //max

    public RawImage U1;
    public RawImage U2;
    public RawImage U3;
    public RawImage U4;

    public GameObject RepandUtil;

    public void EndTurnButtonClick()
    {
       // Debug.Log(RepandUtil.GetComponent<Evaluation>().Representation());

      //  GE.gameObject.GetComponent<GameEngine>().turnCount++;
       
        Granade.enabled = true;
        MachineG.enabled = true;
        Rifle.enabled = true;

        Granade.image.color = Color.white;
        Granade.enabled = true;
        MachineG.image.color = Color.white;
        Granade.enabled = true;
        Rifle.image.color = Color.white;
        Granade.enabled = true;



      //  EndPlanningButton.enabled = true;
       // EndPlanningButton.image.color = Color.white;

        int turn = GE.gameObject.GetComponent<GameEngine>().turnCount;
        


        if (turn%2 ==0)
        {
            PlayerTurnText.text = "Purple Turn";
            GE.gameObject.GetComponent<GameEngine>().P1planning = true;

            Boarder.GetComponent<RawImage>().texture = PB;
         //   Debug.Log("switched to purple");

            foreach (Weapons w in GE.GetComponent<GameEngine>().PurpleWeaponList)
            {
                if (w.CheckCooldown() > 0)
                {
                    w.LowerCooldown();
                    if (w.ReturnType() == "SniperRifle")
                    {
                        Rifle.image.color = Color.gray;
                        Rifle.enabled = false;
                    }
                    else if (w.ReturnType() == "Grenade")
                    {
                        Granade.image.color = Color.grey;
                        Granade.enabled = false;
                    }
                    else if (w.ReturnType() == "MachineGun")
                    {
                        MachineG.image.color = Color.grey;
                        MachineG.enabled = false;
                    }
                }
            }
        }
        else
        {
            PlayerTurnText.text = "Green Turn";
            GE.gameObject.GetComponent<GameEngine>().P2planning = true;

            Boarder.GetComponent<RawImage>().texture = GB;
         //   Debug.Log("switched to green");

            foreach (Weapons w in GE.GetComponent<GameEngine>().GreenWeaponList)
            {
                if (w.CheckCooldown() > 0)
                {
                    w.LowerCooldown();
                    if (w.ReturnType() == "SniperRifle")
                    {
                       // Debug.Log("set sniper grey");
                        Rifle.image.color = Color.gray;
                        Rifle.enabled = false;
                    }
                    else if (w.ReturnType() == "Grenade")
                    {
                        Granade.image.color = Color.grey;
                        Granade.enabled = false;
                    }
                    else if (w.ReturnType() == "MachineGun")
                    {
                        MachineG.image.color = Color.grey;
                        MachineG.enabled = false;
                    }
                }
            }
        }

        //Debug.Log("turn count: " + turn);
       // turn++; // increase the turn after the stuff is done
       // GE.gameObject.GetComponent<GameEngine>().turnCount = turn;
       // Debug.Log("turn count: " + turn);

        GE.GetComponent<GameEngine>().batteries = 5; // reset the batteries
        HealthCheck();
        lowerCooldowns(GE.GetComponent<GameEngine>().turnCount);
    }

    public void MoveClick()
    {
        GE.GetComponent<GameEngine>().move = true;
        GE.GetComponent<GameEngine>().attack = false;
        //Debug.Log("Moving");
    }

    public void AttckClick()
    {
        GE.GetComponent<GameEngine>().move = false;
        GE.GetComponent<GameEngine>().attack = true;
        //Debug.Log("Attacking");

    }
    public void EndPlanning() // ends the planning faze of the turn
    {


        //Debug.Log("end planning");
     
            Granade.enabled = false;
            MachineG.enabled = false;
            Rifle.enabled = false;



        Granade.image.color = Color.gray;
        MachineG.image.color = Color.gray;
        Rifle.image.color = Color.gray;
       // EndPlanningButton.image.color = Color.gray;

        int planning = GE.gameObject.GetComponent<GameEngine>().turnCount;


        if (planning % 2 == 0)
        {
            GE.gameObject.GetComponent<GameEngine>().P1planning = false;
        }
        else
        {
            GE.gameObject.GetComponent<GameEngine>().P2planning = false;
        }

    }


    private void lowerCooldowns(int turn)
    {
        if(turn%2 == 0)
        {
            foreach(Weapons w in GE.gameObject.GetComponent<GameEngine>().PurpleWeaponList)
            {
                if(w.ReturnOwner()== false && w.CheckCooldown() != 0)
                {
                    w.LowerCooldown();
                }
            }
        }
        else
        {
            foreach (Weapons w in GE.gameObject.GetComponent<GameEngine>().GreenWeaponList)
            {
                if (w.ReturnOwner() == false && w.CheckCooldown() != 0)
                {
                    w.LowerCooldown();
                }
            }
        }
    }

    public void HealthCheck()
    {


        //  Debug.Log("checking health");

        int turn = GE.gameObject.GetComponent<GameEngine>().turnCount;

        if (turn % 2 == 0)
        {
            PlayerTurnText.text = "Purple Turn";
            int unitCount = 1; // will go up wiith each unit;

            foreach (GameObject u in GE.gameObject.GetComponent<GameEngine>().PurpleUnitList)
            {
                int Health = u.GetComponent<PurpleUnit>().health;
                // Debug.Log("Purple unit health checked: " + unitCount);
                switch (unitCount)
                {

                    case 1:
                        switch (Health)
                        {
                            case 1:
                                U1.texture = H0;
                                break;

                            case 2:
                                U1.texture = H1;
                                break;
                            case 3:
                                U1.texture = H2;
                                break;
                            case 4:
                                U1.texture = H3;
                                break;
                            case 5:
                                U1.texture = H4;
                                break;

                        }
                        break;
                    case 2:
                        switch (Health)
                        {
                            case 1:
                                U2.texture = H0;
                                break;

                            case 2:
                                U2.texture = H1;
                                break;
                            case 3:
                                U2.texture = H2;
                                break;
                            case 4:
                                U2.texture = H3;
                                break;
                            case 5:
                                U2.texture = H4;
                                break;

                        }
                        break;
                    case 3:
                        switch (Health)
                        {
                            case 1:
                                U3.texture = H0;
                                break;

                            case 2:
                                U3.texture = H1;
                                break;
                            case 3:
                                U3.texture = H2;
                                break;
                            case 4:
                                U3.texture = H3;
                                break;
                            case 5:
                                U3.texture = H4;
                                break;

                        }
                        break;
                    case 4:
                        switch (Health)
                        {
                            case 1:
                                U4.texture = H0;
                                break;

                            case 2:
                                U4.texture = H1;
                                break;
                            case 3:
                                U4.texture = H2;
                                break;
                            case 4:
                                U4.texture = H3;
                                break;
                            case 5:
                                U4.texture = H4;
                                break;

                        }
                        break;
                }

                unitCount++;
            }

        }
        else
        {
            PlayerTurnText.text = "Green Turn";

            int unitCount = 1;
            foreach (GameObject u in GE.gameObject.GetComponent<GameEngine>().GreenUnitList)
            {
                //  Debug.Log("Green unit health checked: " + unitCount);

                int Health = u.GetComponent<GreenUnit>().health;
                switch (unitCount)
                {

                    case 1:
                        switch (Health)
                        {
                            case 1:
                                U1.texture = H0;
                                break;

                            case 2:
                                U1.texture = H1;
                                break;
                            case 3:
                                U1.texture = H2;
                                break;
                            case 4:
                                U1.texture = H3;
                                break;
                            case 5:
                                U1.texture = H4;
                                break;

                        }
                        break;
                    case 2:
                        switch (Health)
                        {
                            case 1:
                                U2.texture = H0;
                                break;

                            case 2:
                                U2.texture = H1;
                                break;
                            case 3:
                                U2.texture = H2;
                                break;
                            case 4:
                                U2.texture = H3;
                                break;
                            case 5:
                                U2.texture = H4;
                                break;

                        }
                        break;
                    case 3:
                        switch (Health)
                        {
                            case 1:
                                U3.texture = H0;
                                break;

                            case 2:
                                U3.texture = H1;
                                break;
                            case 3:
                                U3.texture = H2;
                                break;
                            case 4:
                                U3.texture = H3;
                                break;
                            case 5:
                                U3.texture = H4;
                                break;

                        }
                        break;
                    case 4:
                        switch (Health)
                        {
                            case 1:
                                U4.texture = H0;
                                break;

                            case 2:
                                U4.texture = H1;
                                break;
                            case 3:
                                U4.texture = H2;
                                break;
                            case 4:
                                U4.texture = H3;
                                break;
                            case 5:
                                U4.texture = H4;
                                break;

                        }
                        break;
                }

                unitCount++;
            }
        }
    }
}
