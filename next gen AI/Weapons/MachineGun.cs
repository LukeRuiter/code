using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapons
{


    private int CoolDownCount;

    public int coolDownCount
    {
        get { return CoolDownCount; }
        set { CoolDownCount = value; }
    }

    private string Name;

    public string name
    {
        get { return Name; }
        set { Name = value; }
    }


    private bool Owned;

    public bool owned
    {
        get { return Owned; }
        set { Owned = value; }
    }

    private int damage;

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }


    private int range;

    public int Range
    {
        get { return range; }
        set { range = value; }
    }

    private int areaofeffect;

    public int AreaOfEffect
    {
        get { return areaofeffect; }
        set { areaofeffect = value; }
    }


    private int uses;

    public int Uses
    {
        get { return uses; }
        set { uses = value; }
    }

    private int cooldown;

    public int CoolDown
    {
        get { return cooldown; }
        set { cooldown = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override int GetCooldown()
    {
      //  Debug.Log("mg cooldown =" + CoolDownCount);
        return cooldown;
    }
    public override string ToString()
    {
        string ret = "machine gun \n";
        ret = ret + "   range: " + range + "\n";
        ret = ret + "   damage: " + damage + "\n";
        

        return ret;
    }

    public override void Ownership(bool own)
    {
        Owned = own;
    }

    public override int CheckCooldown()
    {
        return coolDownCount;
    }
    public override bool ReturnOwner()
    {
        return owned;
    }
    public override void LowerCooldown()
    {
        coolDownCount--;
    }
    public override int CheckRange()
    {
        return range;
    }

    public override int CheckUses()
    {
        throw new System.NotImplementedException();
    }
    public override void SetCooldown()
    {
        coolDownCount = CoolDown;
    }
    public override void Constuctor()
    {
        Name = "MachineGun";
        damage = 1;
        range = 2;
        areaofeffect = 2;
        uses = 1000;
        cooldown = 2;
        owned = false;
        coolDownCount = 0;

    }

    public override void DamageArea(Vector2 CentrePoint,GameObject GM)
    {

        foreach (GameObject u in GM.GetComponent<GameEngine>().PurpleUnitList)
        {
            float distance = Vector2.Distance(u.transform.position, CentrePoint);
            if (distance <= areaofeffect)
            {
                u.GetComponent<PurpleUnit>().health = u.GetComponent<PurpleUnit>().health - damage;
            }
        }

        foreach (GameObject u in GM.GetComponent<GameEngine>().GreenUnitList)
        {
            float distance = Vector2.Distance(u.transform.position, CentrePoint);
            if (distance <= areaofeffect)
            {
                u.GetComponent<GreenUnit>().health = u.GetComponent<GreenUnit>().health - damage;
            }
        }
    }

    public override string ReturnType()
    {
       // Debug.Log(name);

        return name;
    }
}
