﻿using UnityEngine;

public class collisionScript : MonoBehaviour
{

    public OSC osc;
    OscMessage message = new OscMessage();

    void Start()
    {
        message.address = "/hitWall";
    }

        void OnCollisionEnter(Collision obstacleCollision) //information about collision, obstackeCollisio is the name of that information
    {
        Debug.Log("hittttt");

        if (obstacleCollision.collider.tag == "Obstacle") //information.collider (which collider we hit).tag
        {
            Debug.Log("hit");

            message.values.Add(1);
            sendOscMessage(message);
        }
    }

    void sendOscMessage(OscMessage message)
    {
        Debug.Log("osc message send " + message);
        osc.Send(message);
    }
}
