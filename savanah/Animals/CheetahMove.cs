using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheetahMove : MonoBehaviour
{
    float sprintSpeed = 200.0f;
    float normalSpeed = 150.0f;
    int stamina;
    public Text staminaText;
    Rigidbody RB;
    float jumpHeight;
    float jumpforce = 5000;
    float Counter = 0;
    public Slider StaminaBar;
    void Start()
    {
        stamina = 0;
        RB = GetComponent<Rigidbody>();
        StaminaBar.value = stamina;
    }

    void Update()
    { 
     
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * normalSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && stamina>0)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * sprintSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
            stamina = stamina - 2;
        }
        if (Input.GetKey(KeyCode.Space) && Counter >= 20)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * sprintSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
            RB.AddForce(Vector3.up * Time.deltaTime * jumpforce);
            jumpHeight = jumpHeight + 1f;
            Counter = 0;
            Debug.Log("eish");
           
        }
        if (Counter <= 20)
        {
            Counter++;
        }
        if (!(Input.GetKey(KeyCode.LeftShift)))
        {
            stamina = stamina + 1;
        }
        
        if (stamina > 100)
        {
            stamina = 100;
        }
        if(stamina < 0)
        {
            stamina = 0;
        }
        staminaText.text = "" + stamina;
        

        StaminaBar.value = stamina;
    }

     
    


}
