using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringbokMovement : MonoBehaviour
{

    int MovementDirection;
    int DirectionCounter = 0;

    private int nextUpdate = 1;

    // Start is called before the first frame update
    void Start()
    {
        MovementDirection = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (DirectionCounter == 10)
        {
            DirectionCounter = 0;
            MovementDirection = Random.Range(0, 4);
        }

        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            //Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            UpdateEverySecond();
        }

        if (DirectionCounter < 10)
        {
            //switch (MovementDirection)
            //{
            //    case 0:
            //        {
            //            transform.Translate(transform.position.x * Time.deltaTime * 100.0f, transform.position.y, transform.position.z);
            //            transform.Rotate(0, transform.position.x * Time.deltaTime * 100.0f, 0);
            //            break;
            //        }
                    //        case 1:
                    //            {
                    //                transform.Translate(transform.position.x * Time.deltaTime * -100.0f, transform.position.y, transform.position.z);
                    //                transform.Rotate(0, transform.position.x * Time.deltaTime * -100.0f, 0);
                    //                break;
                    //            }
                    //        case 2:
                    //            {
                    //                transform.Translate(transform.position.x , transform.position.y, transform.position.z * Time.deltaTime * 100.0f);
                    //                transform.Translate(0, 0, transform.position.z * Time.deltaTime * 100.0f);
                    //                break;
                    //            }
                    //        case 3:
                    //            {
                    //                transform.Translate(transform.position.x, transform.position.y, transform.position.z * Time.deltaTime * -100.0f);
                    //                transform.Translate(0, 0, transform.position.z * Time.deltaTime * -100.0f);
                    //                break;
                    //            }
                     // }

                    }

                    //Debug.Log(DirectionCounter);
    }

    void UpdateEverySecond()
    {
        DirectionCounter++;
    }
}
