using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f; //Speed of the mouse

    public Transform playerBody; //reference to our FPS

    float xRotation = 0f; // move up down we need tp rotate around the x-axis

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //to hide the cursor
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //get input here
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; //decreased xRotation based on mouseY
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //this will prevent from flipping the camera, (xRotation = value we want to clamp, we want to clamp between -90 to 90 degrees

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //rotation up down
        playerBody.Rotate(Vector3.up * mouseX); //rotate around y-axis multiplied by mouseX (look around using mouseX movement = rotate <- ->)

    }
}
