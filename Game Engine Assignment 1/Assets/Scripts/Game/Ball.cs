using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Vector3 ballVelocity = new Vector3(100.0f, 100.0f, 0.0f);

    private Rigidbody rb;
    public bool ballInPlay;
    private Vector3 ballPausedVelocity;

    // Use this for initialization
    void Awake()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (ballInPlay == true)
        {
            // Don't update if game is paused
            if (GM.instance.gamePaused == true)
            {
                // Swap paused Vel with RB vel
                if (rb.velocity.x != 0.0f && rb.velocity.y != 0.0f)
                    ballPausedVelocity = rb.velocity;
                rb.velocity = new Vector3(0.0f, 0.0f);
                return;
            }
            else
            {
                // UnSwap paused Vel with RB vel
                if (ballPausedVelocity.x != 0.0f && ballPausedVelocity.y != 0.0f)
                    rb.velocity = ballPausedVelocity;
                ballPausedVelocity = new Vector3(0.0f, 0.0f);
            }
        }


        if (Input.GetKey(GM.instance.commandList[0].button) && ballInPlay == false && GM.instance.gamePaused == false)
        {
            // transform.parent = null; //unparent ball from paddle 
            ballInPlay = true;
            //rb.isKinematic = false;
            //rb.AddForce(new Vector3(ballVelocity.x * 5, ballVelocity.y * 5, 0));
        }

    }
}
