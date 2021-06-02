using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : Weapons
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
    public override string ToString()
    {
        string ret = "handgun \n";
        ret = ret + "   range: " + range + "\n";
        ret = ret + "   damage: " + damage + "\n";
        ret = ret + "   owned: " + owned + "\n";
      

        return ret;
    }

    public override void SetCooldown()
    {
        coolDownCount = CoolDown;
    }

    public override int GetCooldown()
    {
        return 0;
    }
    public override void Constuctor()
    {
        //HandGun handgun = new HandGun();
        Name = "HandGun";
        damage = 1;
        range = 1;
        areaofeffect = 1;
        uses = 1000;
        cooldown = 0;
        owned = false;
        coolDownCount = 0;

     //   throw new System.NotImplementedException();
    }
    public override bool ReturnOwner()
    {
        return owned;
    }
    public override void Ownership(bool own)
    {
        Owned = own;
    }
    public override int CheckRange()
    {
        return range;
    }


    public override int CheckUses()
    {
        throw new System.NotImplementedException();
    }

    public override void DamageArea(Vector2 CentrePoint, GameObject GM)
    {
       
    }

    public override int CheckCooldown()
    {
        return coolDownCount;
    }

    public override void LowerCooldown()
    {
        cooldown--;
    }

    public override string ReturnType()
    {
        return name;
    }
}
