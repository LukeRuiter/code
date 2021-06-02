using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject Bullet_Emitter;

    public float Bullet_Forward_Force;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fire();
        }
    }

    private void fire()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);

       // Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

        Rigidbody Temp_RigidBody;
        Temp_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        Temp_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

        Destroy(Temporary_Bullet_Handler, 10.0f);
    }
}
