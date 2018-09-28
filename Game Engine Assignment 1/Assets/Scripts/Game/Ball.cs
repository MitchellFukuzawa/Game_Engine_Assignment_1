using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float ballInitialVelocity = 100000.0f;

    private Rigidbody rb;
    private bool ballInPlay; 

	// Use this for initialization
	void Awake () {

        rb = GetComponent<Rigidbody>(); 

	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null; //unparent ball from paddle 
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity * 5, ballInitialVelocity * 5, 0)); 
        }

	}
}
