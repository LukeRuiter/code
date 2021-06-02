using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapons 
{
    //protected int Damage;
    //protected string Name;
    //protected int Range;
    //protected int AreaOfEffect;
    //protected int Uses;
    //protected bool Owned;
    //protected int CoolDown;
    //protected int CoolDownCount;

    //   protected UnitClass Owner; // who is holding the weapon
    abstract public void Constuctor();
    abstract public int CheckRange(); // if the targeted enemy is in range
  //  abstract public void attack(UnitClass unit); // attack the targeted enemy
    abstract public int CheckUses(); // retuen how many more time the weapon can be used
    abstract public void DamageArea(Vector2 CentrePoint, GameObject GM); // the area damaged by this weapon
    abstract public int CheckCooldown(); // check the cooldown timer of this weapon
    abstract public void LowerCooldown();
    abstract public void Ownership(bool own);
    abstract public bool ReturnOwner();

    abstract public override string ToString();

    abstract public string ReturnType();

    abstract public void SetCooldown();

    abstract public int GetCooldown();
}
