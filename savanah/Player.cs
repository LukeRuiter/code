using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
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
    public GameObject Gun;

    void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
        CmdSpawn();



    }

    void Update ()
            {
       
        if (isLocalPlayer == true)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.Space) && !jumped)
                {
                    anim.SetInteger("AnimationPar", 4);
                    Gun.SetActive(false);
                }
                else
                {
                    anim.SetInteger("AnimationPar", 2);
                    Gun.SetActive(false);
                }

            }
            else if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.Space) && !jumped)
                {
                    anim.SetInteger("AnimationPar", 4);
                    Gun.SetActive(false);
                }
                else 
                {
                    anim.SetInteger("AnimationPar", 1);
                    Gun.SetActive(false);
                }
                    
            }
            else if (Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("AnimationPar", 3);
                Gun.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Space))
            {
                anim.SetInteger("AnimationPar", 6);
                Gun.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.Space) && !jumped) 
            {
                anim.SetInteger("AnimationPar", 4);
                Gun.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Y))
            {
                anim.SetInteger("AnimationPar", 5);
                Gun.SetActive(false);
            }
            else
            {
                anim.SetInteger("AnimationPar", 0);
                Gun.SetActive(false);

            }

            if (controller.isGrounded)
            {
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Mouse0))
                {
                    moveDirection = transform.forward * Input.GetAxis("Vertical") * Sprintspeed;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        moveDirection = transform.up * Upspeed + transform.forward * Input.GetAxis("Vertical") * Sprintspeed;
                        jumped = true;
                        StartCoroutine(SpamBlockco());
                    }
                }
                else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Mouse0))
                {
                    moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                    if (Input.GetKeyDown(KeyCode.Space) && !jumped)
                    {
                        moveDirection = transform.up * Upspeed + transform.forward * Input.GetAxis("Vertical") * speed;
                        jumped = true;
                        StartCoroutine(SpamBlockco());
                    }
                }

                else if (Input.GetKey(KeyCode.S)&& !Input.GetKey(KeyCode.Mouse0))
                {
                    moveDirection = transform.forward * Input.GetAxis("Vertical") * backSpeed;


                }
                else if (Input.GetKey(KeyCode.Mouse0))
                {
                    //moveDirection = Vector3.zero;


                }
                else if (Input.GetKeyDown(KeyCode.Space) && !jumped && !Input.GetKey(KeyCode.Mouse0))
                {
                    Jump();
                }
           
                else
                {
                    moveDirection = Vector3.zero;

                }


            }

            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            controller.Move(moveDirection * Time.deltaTime);
            moveDirection.y -= gravity * Time.deltaTime;
        }
       
		}



    void Jump()
    {
        moveDirection = transform.up * Upspeed;
        jumped = true;
        StartCoroutine(SpamBlockco());

    }
    public IEnumerator SpamBlockco()
    {
        if (jumped == true)
        {
            yield return new WaitForSeconds(jumpdelay);
        }
        yield return null;
        jumped = false;
    }
    [Command]
    void CmdSpawn()
    {
       
        //door.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
    }

}
