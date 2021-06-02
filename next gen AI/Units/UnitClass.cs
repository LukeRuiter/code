using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class UnitClass : MonoBehaviour
{
    //protected int health;
    //protected Weapons EqWeapon;
    //protected string team;
    //protected float xPos;
    //protected float yPos;
    //protected bool Alive;

    abstract public void Constuctor();
    abstract public void Death(); // unit death
    abstract public void CollectData(); // collect enemy data and end the game
    abstract public void Move(Vector3 tile);
    abstract public Vector3 Move(int pos, float xpos, float ypos);
   // abstract public void Move(RaycastHit hit);
  //  abstract public Vector3 Move(RaycastHit hit, Vector3 ogPos);

    abstract public void Atack(UnitClass enemy);
    abstract public  override string ToString();

   
}
