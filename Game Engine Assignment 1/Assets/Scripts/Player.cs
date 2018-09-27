using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 1.0f;

    private Vector3 playerPos = new Vector3(0, -50.0f, 0); 
    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        if (GM.instance.gamePaused == true)
        {
            return;
        }

        //float v = Input.GetAxisRaw("Horizontal");
        //print(Input.GetAxisRaw("Horizontal"));

        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -90.0f, 90.0f), transform.position.y, 0f);
        transform.position = playerPos;

        /* if (Input.GetKey(KeyCode.A))
             transform.Translate(Vector3.left * Time.deltaTime * speed);
         if (Input.GetKey(KeyCode.D))
             transform.Translate(Vector3.right * Time.deltaTime * speed); */

        //GetComponent<Rigidbody>().velocity = new Vector3(0, v, 0) * speed;

        if (Input.GetKey(GM.instance.left))
        {

        }

    }
}
