using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButtons : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;

    public Button Granade;
    public Button MachineG;
    public Button Rifle;
    public GameObject GE;
    public string weaponseleted;
    Weapons wp;

    LayerMask groundMask;
    LayerMask unitMask;
    RaycastHit hit;

    public GameObject UIEmpty;

    bool applyWeapon = false;

    public void GranadeClick()
    {
        weaponseleted = "G";
        Debug.Log("g");

        //  Debug.Log("grandade");


        // wp = new NadeClass();
        //applyWeapon = true;

        //int turn = GE.gameObject.GetComponent<GameEngine>().turnCount;
        //if (turn % 2 == 0)
        //{
        //    foreach (Weapons w in GE.gameObject.GetComponent<GameEngine>().PurpleWeaponList)
        //    {
        //        if (w.ReturnType()== "Grenade")
        //        {
        //            wp = w;
        //            w.SetCooldown();
        //        }
        //    }
        //}
        //else
        //{
        //    foreach (Weapons w in GE.gameObject.GetComponent<GameEngine>().GreenWeaponList)
        //    {
        //        if (w.ReturnType() == "Grenade")
        //        {
        //            wp = w;
        //            w.SetCooldown();

        //        }
        //    }
        //}

    }

    public void MachineGClick()
    {

        weaponseleted = "M";
        Debug.Log("m");
        //applyWeapon = true;
        //int turn = GE.gameObject.GetComponent<GameEngine>().turnCount;
        //if (turn % 2 == 0)
        //{
        //    foreach (Weapons w in GE.gameObject.GetComponent<GameEngine>().PurpleWeaponList)
        //    {
        //        if (w.ReturnType() == "MachineGun")
        //        {
        //            wp = w;
        //            w.SetCooldown();

        //        }
        //    }
        //}
        //else
        //{
        //    foreach (Weapons w in GE.gameObject.GetComponent<GameEngine>().GreenWeaponList)
        //    {
        //        if (w.ReturnType() == "MachineGun")
        //        {
        //            wp = w;
        //            w.SetCooldown();

        //        }
        //    }
        //}
    }

    public void RifleClick()
    {
        weaponseleted = "R";
        Debug.Log("r");

        //applyWeapon = true;
        //int turn = GE.gameObject.GetComponent<GameEngine>().turnCount;
        //if (turn % 2 == 0)
        //{
        //    foreach (Weapons w in GE.gameObject.GetComponent<GameEngine>().PurpleWeaponList)
        //    {
        //        if (w.ReturnType() == "SniperRifle")
        //        {
        //            wp = w;
        //            w.SetCooldown();


        //            // Debug.Log("sniper");
        //        }
        //    }
        //}
        //else
        //{
        //    foreach (Weapons w in GE.gameObject.GetComponent<GameEngine>().GreenWeaponList)
        //    {
        //        if (w.ReturnType() == "SniperRifle")
        //        {
        //            wp = w;
        //            w.SetCooldown();


        //        }
        //    }
        //}
    }


    private void CheckCooldowns()
    {
       int turn= GE.gameObject.GetComponent<GameEngine>().turnCount;

        if (turn % 2 == 0)
        {
            foreach (Weapons w in GE.gameObject.GetComponent<GameEngine>().PurpleWeaponList)
            {
                if (w.ReturnType() != "HandGun")
                {
                    if (w.ReturnType() == "Grenade")
                    {
                        NadeClass wp = (NadeClass)w;
                        if (wp.CheckCooldown() != 0 & wp.owned == false)
                        {
                            Granade.enabled = false;
                            Granade.image.color = Color.gray;
                        }
                    }
                    else if (w.ReturnType() == "MachineGun")
                    {
                        MachineGun wp = (MachineGun)w;
                        if (wp.CheckCooldown() != 0 & wp.owned == false)
                        {
                            MachineG.enabled = false;
                            MachineG.image.color = Color.gray;
                        }
                    }
                    else if (w.ReturnType() == "SniperRifle")
                    {

                        SniperRifle wp = (SniperRifle)w;
                        if (wp.CheckCooldown() != 0 & wp.owned == false)
                        {
                            Rifle.enabled = false;
                            Rifle.image.color = Color.gray;
                        }
                    }
                }
            }
        }
        else
        {
            foreach (Weapons w in GE.gameObject.GetComponent<GameEngine>().GreenWeaponList)
            {
                if (w.ReturnType() != "HandGun")
                {
                    if (w.ReturnType() == "Grenade")
                    {
                        NadeClass wp = (NadeClass)w;
                        if (w.CheckCooldown() != 0 & wp.owned == false)
                        {
                            Granade.enabled = false;
                            Granade.image.color = Color.gray;
                        }
                    }
                    else if (w.ReturnType() == "MachineGun")
                    {
                       MachineGun wp = (MachineGun)w;
                        if (w.CheckCooldown() != 0 & wp.owned == false)
                        {
                            MachineG.enabled = false;
                            MachineG.image.color = Color.gray;
                        }
                    }
                    else if (w.ReturnType() == "SniperRifle")
                    {
                      SniperRifle  wp = (SniperRifle)w;
                        if (w.CheckCooldown() != 0 & wp.owned == false)
                        {
                            Rifle.enabled = false;
                            Rifle.image.color = Color.gray;
                        }
                    }
                }
            }
        }

       
    }

   public void applywp()
    {
        //Debug.Log("applying");
        int turn = GE.gameObject.GetComponent<GameEngine>().turnCount;
        if (turn%2 ==0)
        {
            if (weaponseleted == "G")
            {
                foreach (Weapons w in GE.GetComponent<GameEngine>().PurpleWeaponList)
                {
                    if (w.ReturnType().ToUpper() == "GRENADE")
                    {
                        if (w.ReturnOwner() == false)
                        {
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<PurpleUnit>().weapon.Ownership(false);
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<PurpleUnit>().weapon = w;
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<PurpleUnit>().weapon.Ownership(true);
                            //Debug.Log("applied grenadge");
                          //  w.Ownership(true);
                        }
                    }
                }

            }else if (weaponseleted == "M")
            {
                foreach (Weapons w in GE.GetComponent<GameEngine>().PurpleWeaponList)
                {
                    if (w.ReturnType().ToUpper() == "MACHINEGUN")
                    {
                        if (w.ReturnOwner() == false)
                        {
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<PurpleUnit>().weapon.Ownership(false);
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<PurpleUnit>().weapon = w;
                            w.Ownership(true);
                            //Debug.Log("applied mg");

                        }
                    }
                }

            }
            else if (weaponseleted == "R")
            {
                foreach (Weapons w in GE.GetComponent<GameEngine>().PurpleWeaponList)
                {
                    if (w.ReturnType().ToUpper() == "SNIPERRIFLE")
                    {
                        if (w.ReturnOwner() == false)
                        {
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<PurpleUnit>().weapon.Ownership(false);
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<PurpleUnit>().weapon = w;
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<PurpleUnit>().weapon.Ownership(true);
                           // Debug.Log("applied sr");

                            //  w.Ownership(true);

                        }
                    }
                }
            }
            else
            {
                Debug.Log("no weaponselected");
            }

            weaponseleted = "";
        }
        else
        {

            if (weaponseleted == "G")
            {
                foreach (Weapons w in GE.GetComponent<GameEngine>().GreenWeaponList)
                {
                    if (w.ReturnType().ToUpper() == "GRENADE")
                    {
                        if (w.ReturnOwner() == false)
                        {
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon.Ownership(false);
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon = w;
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon.Ownership(true);

                        }
                    }
                }

            }
            else if (weaponseleted == "M")
            {
                foreach (Weapons w in GE.GetComponent<GameEngine>().GreenWeaponList)
                {
                    if (w.ReturnType().ToUpper() == "MACHINEGUN")
                    {
                        if (w.ReturnOwner() == false)
                        {
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon.Ownership(false);
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon = w;
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon.Ownership(true);

                        }
                    }
                }

            }
            else if (weaponseleted == "R")
            {
                foreach (Weapons w in GE.GetComponent<GameEngine>().GreenWeaponList)
                {
                    if (w.ReturnType().ToUpper() == "SNIPERRIFLE")
                    {
                        if (w.ReturnOwner() == false)
                        {
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon.Ownership(false);
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon = w;
                            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon.Ownership(true);

                        }
                    }
                }
            }
            else
            {
                Debug.Log("no weaponselected");
            }

            weaponseleted = "";
        }

        //if (auto)
        //{
        //    if (applyWeapon)
        //    {


        //        int turn = GE.gameObject.GetComponent<GameEngine>().turnCount;
        //        if (turn % 2 == 0)
        //        {

        //            GE.GetComponent<GameEngine>().SelectUnit(); // ray to the screen

        //            wp.Ownership(true); // new weapon ownership to true

        //            GE.GetComponent<GameEngine>().unitslected.GetComponent<PurpleUnit>().weapon.Ownership(false);

        //            GE.GetComponent<GameEngine>().unitslected.GetComponent<PurpleUnit>().weapon = wp;

        //         //   Debug.Log("applied " + wp + "to " + GE.GetComponent<GameEngine>().unitslected);
        //            applyWeapon = false;


        //            CheckCooldowns();

        //        }
        //        else
        //        {
        //            GE.GetComponent<GameEngine>().SelectUnit(); // ray to the screen

        //            wp.Ownership(true); // sets new weapons ownership to true;

        //            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon.Ownership(false);

        //            GE.GetComponent<GameEngine>().unitslected.GetComponent<GreenUnit>().weapon = wp;


        //            Debug.Log("applied " + wp + "to " + GE.GetComponent<GameEngine>().unitslected);
        //            applyWeapon = false;


        //            CheckCooldowns();

        //        }
        //    } //auto

        //}
        //else
        //{
        //    if (applyWeapon)
        //    {


        //        int turn = GE.gameObject.GetComponent<GameEngine>().turnCount;
        //        if (turn % 2 == 0)
        //        {
        //            unitMask = LayerMask.GetMask("Units"); // only apply to unit masked layer


        //            Ray ray = cam.ScreenPointToRay(Input.mousePosition); // ray to the screen



        //            if (Physics.Raycast(ray, out hit, 2000f, unitMask))
        //            {


        //                if (hit.transform.gameObject.tag == "Unit01" && Input.GetKeyDown(KeyCode.Mouse0)) // if selected a unit
        //                {


        //                    wp.Ownership(true); // new weapon ownership to true
        //                    hit.transform.gameObject.GetComponent<PurpleUnit>().weapon.Ownership(false); // sets current weapon to unequip

        //                    hit.transform.gameObject.GetComponent<PurpleUnit>().weapon = wp; // apply new weapon

        //                    Debug.Log("applied " + wp + "to " + hit.transform.gameObject.tag);
        //                    applyWeapon = false;
        //                }
        //            }
        //            CheckCooldowns();

        //        }
        //        else
        //        {
        //            unitMask = LayerMask.GetMask("Units"); // only apply to unit masked layer


        //            Ray ray = cam.ScreenPointToRay(Input.mousePosition); // ray to the screen
        //                                                                 //var layerMask = 8;

        //            if (Physics.Raycast(ray, out hit, 2000f, unitMask))
        //            {


        //                if (hit.transform.gameObject.tag == "Unit02" && Input.GetKeyDown(KeyCode.Mouse0)) // if selected a unit
        //                {
        //                    wp.Ownership(true); // sets new weapons ownership to true;
        //                    hit.transform.gameObject.GetComponent<GreenUnit>().weapon.Ownership(false); // sets current weapon to unequip


        //                    hit.transform.gameObject.GetComponent<GreenUnit>().weapon = wp; // apply new weapon
        //                    Debug.Log("applied " + wp + "to " + hit.transform.gameObject.tag);
        //                    applyWeapon = false;
        //                }
        //            }
        //            CheckCooldowns();

        //        }
        //    }

        //}


    }

    public void AutoPlanning()
    {
        if (GE.GetComponent<GameEngine>().turnCount % 2 != 2)
        {
            foreach (Weapons w in GE.GetComponent<GameEngine>().GreenWeaponList)
            {
                if (w.ReturnOwner() == false & w.CheckCooldown() == 0)
                {
                    switch (w.ReturnType())
                    {
                        case "Grenade":
                            GranadeClick();
                            break;
                        case "SniperRifle":
                            RifleClick();
                            break;
                        case "MachineGun":
                            break;

                    }
                }
               // applywp(true);
            }
        }
        else
        {
            foreach (Weapons w in GE.GetComponent<GameEngine>().PurpleWeaponList)
            {

                if (w.ReturnOwner() == false & w.CheckCooldown() == 0)
                {
                    switch (w.ReturnType())
                    {
                        case "Grenade":
                            GranadeClick();
                            break;
                        case "SniperRifle":
                            RifleClick();
                            break;
                        case "MachineGun":
                            break;

                    }
                }

                //applywp(true);
            }
        }

        UIEmpty.GetComponent<TurnButtons>().EndPlanning();
    }
}
