using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //input
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; // transform.right = takes the direction player is facing and goes to the right // tranform.forward = takes the direction player is facing and goes forward
        
        controller.Move(move * speed * Time.deltaTime);
    }
}
