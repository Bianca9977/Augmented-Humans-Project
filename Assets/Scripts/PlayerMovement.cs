using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody controller;

    public float speed = 12f;

    void Start()
    {
        controller = GetComponent<Rigidbody>(); //controller equals the rigidbody on the player
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //input
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z)* speed * Time.deltaTime; // transform.right = takes the direction player is facing and goes to the right // tranform.forward = takes the direction player is facing and goes forward
        
        controller.MovePosition(controller.position + move);
    }
}
