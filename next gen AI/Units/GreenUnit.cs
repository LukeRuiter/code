using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenUnit : UnitClass
{
    // Start is called before the first frame update
    private Weapons Weapon;
    private Vector3 direction;

    public Weapons weapon
    {
        get { return Weapon; }
        set { Weapon = value; }
    }

    private int Health;

    public int health
    {
        get { return Health; }
        set { Health = value; }
    }

    private string Team;

    public string team
    {
        get { return Team; }
        set { Team = value; }
    }


    private float X;

    public float x
    {
        get { return X; }
        set { X = value; }
    }

    private float Y;

    public float y
    {
        get { return Y; }
        set { Y = value; }
    }

    private bool alive;

    public bool Alive
    {
        get { return alive; }
        set { alive = value; }
    }

    private void Start()
    {
    

        Constuctor();
       
    }

    public override string ToString()
    {
        string ret = "Team: " + team + "\n";
        ret = ret + "Health: " + health + "\n";
        ret = ret + "Weapon: " + Weapon.ToString() + "\n";
        ret = ret + "Position: " + x.ToString()+ ""+ y.ToString()+ "\n";

        return ret;
    }

    public override void Constuctor()
    {
        health = 5;
        team = "Green";
        alive = true;
        //x = this.transform.position.x;
        //y = this.transform.position.y;
       // weapon = null;
      
    }

    public override void Atack(UnitClass enemy)
    {
        PurpleUnit en = (PurpleUnit)enemy;

        if (weapon.ReturnType() == "HandGun")
        {
            HandGun wp = (HandGun)weapon;
            en.health = en.health - wp.Damage;
        }
        else if (weapon.ReturnType() == "Grenade")
        {
            NadeClass wp = (NadeClass)weapon;
            en.health = en.health - wp.Damage;
        }
        else if (weapon.ReturnType() == "SniperRifle")
        {
            SniperRifle wp = (SniperRifle)weapon;
            en.health = en.health - wp.Damage;
        }
        else
        {
            MachineGun wp = (MachineGun)weapon;
            en.health = en.health - wp.Damage;
        }

       // Debug.Log(en.ToString());
    }

    public override void Death()
    {
       alive= false;
    }

    public override void Move(Vector3 tile)
    {
        Vector3 pos = tile;
        pos.z = transform.position.z;
        transform.position = pos;


    } // done

    public override Vector3 Move(int pos,float xpos, float ypos)
    {
        switch (pos)
        {


            case 0:
                direction = new Vector3(-1, 1);
                break;
            case 1:
                direction = new Vector3(0, 1);
                break;
            case 2:
                direction = new Vector3(1, 1);
                break;
            case 3:
                direction = new Vector3(1, 0);
                break;
            case 4:
                direction = new Vector3(1, -1);
                break;
            case 5:
                direction = new Vector3(0, -1);
                break;
            case 6:
                direction = new Vector3(-1, -1);
                break;
            case 7:
                direction = new Vector3(-1, 0);
                break;

        }

        direction = new Vector3(xpos + direction.x, ypos + direction.y);
        return direction;
    }
    //public override Vector3 Move(RaycastHit ray1, Vector3 ogPos) //auto move
    //{
    //    Vector3 ray = ray1.point;

    //    var heading = ray - ogPos; // direction from unit to mouse position as v3

    //    if (heading.x < 0)
    //    {
    //        if (heading.y > 0.275) // decimals to chose between hex tiles 
    //        {

    //            direction = new Vector3(-0.5f, 0.75f);
    //            //   Debug.Log("move left up");
    //        }
    //        else if (heading.y < -0.275)
    //        {
    //            direction = new Vector3(-0.5f, -0.75f);
    //            // Debug.Log("move left down");
    //        }
    //        else
    //        {
    //            direction = new Vector3(-1f, 0, 0);

    //            // Debug.Log("move left");
    //        }

    //       // transform.position += direction;

    //    }
    //    else if (heading.x > 0)
    //    {
    //        if (heading.y > 0.275)
    //        {
    //            direction = new Vector3(0.5f, 0.75f);
    //        }
    //        else if (heading.y < -0.275)
    //        {
    //            direction = new Vector3(0.5f, -0.75f);
    //        }
    //        else
    //        {
    //            direction = new Vector3(1f, 0, 0);
    //        }

    //        //   transform.position += direction;
    //    }
    //    ogPos += direction;
    //    Debug.Log("simply moved");
    //    return ogPos;
    //}


    public override void CollectData()
    {
        Debug.Log("game done green wins");
    }
}
