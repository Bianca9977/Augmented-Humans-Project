using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody controller;

    public UnityEvent event_TurnLeft, event_TurnRight;

    public float speed = 12f;

    private float headingAngle, initialAngle = 0f;
    private bool triggerTurn = false;

    void Start()
    {
        controller = GetComponent<Rigidbody>(); //controller equals the rigidbody on the player

        if (event_TurnLeft == null)
            event_TurnLeft = new UnityEvent();
        if (event_TurnRight == null)
            event_TurnRight = new UnityEvent();

        event_TurnLeft.AddListener(TurnLeft);

        event_TurnRight.AddListener(TurnRight);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //input
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z)* speed * Time.deltaTime; // transform.right = takes the direction player is facing and goes to the right // tranform.forward = takes the direction player is facing and goes forward
        
        controller.MovePosition(controller.position + move);


        // Get a copy of your forward vector
        Vector3 forward = transform.forward;
        // Zero out the y component of your forward vector to only get the direction in the X,Z plane
        forward.y = 0;

        headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;

        /* if ((headingAngle > 90f) && (headingAngle <= 180f))
         {
             headingAngle -= 180f;
         }
         else if ((headingAngle > 180f) && (headingAngle <= 270f))
         {
             headingAngle -= 270f;
         }
         else if ((headingAngle > 270f) && (headingAngle <= 360f))
         {
             headingAngle -= 360f;
         }*/

        //headingAngle = Mathf.Abs(headingAngle);

        //Debug.Log("character rotation " + headingAngle);


        if (event_TurnLeft != null)
        {
            event_TurnLeft.Invoke();

        }
        if (event_TurnRight != null)
        {
            event_TurnRight.Invoke();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Get a copy of your forward vector
        Vector3 forward = transform.forward;
        // Zero out the y component of your forward vector to only get the direction in the X,Z plane
        forward.y = 0;

        initialAngle = Quaternion.LookRotation(forward).eulerAngles.y;

        if (other.tag == "TurnLeft")
        {
            Debug.Log("turn left " + initialAngle);
            triggerTurn = true;
        } else if (other.tag == "TurnRight")
        {
            Debug.Log("turn right " + initialAngle);
            triggerTurn = true;
        }
    }

    void TurnLeft()
    {

        float targetAngle = initialAngle - 90;

        if (targetAngle < 0)
        {
            targetAngle = 360 - (Mathf.Abs(targetAngle));
        }

        float diff = headingAngle - targetAngle;

        if ( (diff > 0) && (diff < 15) && (triggerTurn == true))
        {
            Debug.Log("Turned Left " +" " + initialAngle + " " + targetAngle + " " + headingAngle + " " + (headingAngle - targetAngle));
            triggerTurn = false;
        }
        

    }

    void TurnRight()
    {

        float targetAngle = initialAngle + 90;

        if (targetAngle > 360)
        {
            targetAngle = targetAngle - 360;
        }

        float diff = targetAngle - headingAngle;

        if ((diff > 0) && (diff < 15) && (triggerTurn == true))
        {
            Debug.Log("Turned Right " + " " + initialAngle + " " + targetAngle + " " + headingAngle + " " + (headingAngle - targetAngle));
            triggerTurn = false;
        }


    }

    }
