using UnityEngine;
using System.Collections;


public class PlayerRock : MonoBehaviour
{
    public GameObject door;
		private Animator anim;
		private CharacterController controller;
        public float Sprintspeed = 600.0f;
        public float speed = 600.0f;
    public float Upspeed = 600.0f;
    public float backSpeed = 0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;
        AudioSource audioData;
    public bool jumped;
    public float jumpdelay;
  

    void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
        



    }

    void Update()
    {


        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.Space) && !jumped)
            {
                anim.SetInteger("AnimationPar", 4);

            }
            else
            {
                anim.SetInteger("AnimationPar", 2);

            }

        }
        else if (Input.GetKey(KeyCode.W))
        {

            anim.SetInteger("AnimationPar", 3);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("AnimationPar", 3);

        }

        else if (Input.GetKey(KeyCode.Space) && !jumped)
        {
            anim.SetInteger("AnimationPar", 4);

        }
        else if (Input.GetKey(KeyCode.Y))
        {
            anim.SetInteger("AnimationPar", 5);

        }
        else
        {
            anim.SetInteger("AnimationPar", 0);


        }

    }
 
}
