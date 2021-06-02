using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MOVEMENT : MonoBehaviour
{
    public PlayManager pManager;

    public bool InWater = false;
    public bool InConvo = false;
    public bool InHome = false;
    public bool InMeal = false;
    public AudioSource Sleeping;
    public AudioSource Drinking;
    public AudioSource Talking;
    public float Water = 0;
    public float Food = 0;
    public float Rest = 100;
    public float Loneliness = 0;
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float gravity = -12;
    public float jumpHeight = 1;
    private Vector3 BowStart;
    public SkinnedMeshRenderer PlayerMesh;
    [Range(0, 1)]
    public float airControlPercent;
    public bool interactedRanger = false, interactedFrontCar = false, interactedBackCar = false;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    float velocityY;

    public List<GameObject> PlayerSpawn;

    public Animator animator;
    Transform cameraT;
    public Camera C;
    CharacterController controller;

    [Header("LEVEL 2 PLAYER UI:")]
    public bool Level2PlayerUI = false;
    public GameObject Level2PlayerUICanvas;
    public Text WaterText;
    public Text FoodText;

    void Awake()
    {

        cameraT = C.transform;
        controller = GetComponent<CharacterController>();


    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        bool running = Input.GetKey(KeyCode.LeftShift);

        Move(inputDir, running);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();

        }
        if (controller.isGrounded)
        {
            // animator
            float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
            animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
        }

        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space) == false)
        {
            animator.SetBool("JumpIs", false);
        }

        Level2UIBehaviour();
    }

    void Move(Vector2 inputDir, bool running)
    {
        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
        }

        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        velocityY += Time.deltaTime * gravity;
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded)
        {
            velocityY = 0;
        }

    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
            animator.SetBool("JumpIs", true);
        }
    }

    float GetModifiedSmoothTime(float smoothTime)
    {
        if (controller.isGrounded)
        {
            return smoothTime;
        }

        if (airControlPercent == 0)
        {
            return float.MaxValue;
        }
        return smoothTime / airControlPercent;
    }

    public void locationChange(int level)
    {
        switch (level)
        {
            case 0:
                transform.position = PlayerSpawn[0].transform.position;
                break;
            case 1:
                transform.position = PlayerSpawn[1].transform.position;
                break;
            case 2:
                transform.position = PlayerSpawn[2].transform.position;
                break;
            case 3:
                transform.position = PlayerSpawn[3].transform.position;
                break;
            case 4:
                transform.position = PlayerSpawn[4].transform.position;
                break;
            case 5:
                transform.position = PlayerSpawn[5].transform.position;
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            if (Input.GetKey(KeyCode.E) && pManager.Level2GameplayEnabled)
            {
                if (Water <= 100)
                {
                    Water += 1;
                    WaterText.text = "Water: " + Water.ToString() + "/100";
                }

                if (Water >= 100)
                {
                    level2Check();
                }
            }
        }

        if (other.gameObject.tag == "GameRanger")
        {
            
            if (Input.GetKey(KeyCode.E) && pManager.Level4GameplayEnabled && interactedRanger == false)
            {
                pManager.gsManager.playLevel4Extra();
                Debug.Log("ranger");
                interactedRanger = true;
                //play audio here
                level4Check();
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "CarFront")
        {
            
            if (Input.GetKey(KeyCode.E) && pManager.Level4GameplayEnabled && interactedFrontCar == false)
            {
                pManager.gsManager.playLevel4Extra();
                Debug.Log("front");
                interactedFrontCar = true;
                //play audio here
                level4Check();
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "CarBack")
        {
            

            if (Input.GetKey(KeyCode.E) && pManager.Level4GameplayEnabled && interactedBackCar == false)
            {
                pManager.gsManager.playLevel4Extra();
                Debug.Log("back");
                interactedBackCar = true;
                //play audio here
                level4Check();
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            Food++;
            FoodText.text = "Food: " + Food.ToString() + "/3";

            level2Check();
            Destroy(other.gameObject);
        }
    }

    void level4Check()
    {
        if(interactedRanger == true && interactedFrontCar == true && interactedBackCar == true)
        {
           pManager.Level4Complete = true;
        }
    }

    void level2Check()
    {
        if (Food == 3 && Water >= 100)
        {
            pManager.Level2Complete = true;
        }
    }

    //PLAYER UI CONTROLLERS
    void HideLevel2UI()
    {
        Level2PlayerUICanvas.SetActive(false);
    }

    void ShowLevel2UI()
    {
        Level2PlayerUICanvas.SetActive(true);
    }

    void Level2UIBehaviour()
    {
        if (Level2PlayerUI)
        {
            ShowLevel2UI();
        }
        else
        {
            HideLevel2UI();
        }
    }
}

