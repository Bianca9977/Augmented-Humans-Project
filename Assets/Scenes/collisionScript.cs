using UnityEngine;

public class collisionScript : MonoBehaviour
{
    void OnCollisionEnter(Collision obstacleCollision) //information about collision, obstackeCollisio is the name of that information
    {
        Debug.Log("hittttt");

        if (obstacleCollision.collider.tag == "Obstacle") //information.collider (which collider we hit).tag
        {
            Debug.Log("hit");
        }
    }
}
