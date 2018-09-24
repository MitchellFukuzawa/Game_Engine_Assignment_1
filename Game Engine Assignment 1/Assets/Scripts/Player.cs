using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 100.0f;
    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        //float v = Input.GetAxisRaw("Horizontal");
        //print(Input.GetAxisRaw("Horizontal"));

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        //GetComponent<Rigidbody>().velocity = new Vector3(0, v, 0) * speed;
    }
}
