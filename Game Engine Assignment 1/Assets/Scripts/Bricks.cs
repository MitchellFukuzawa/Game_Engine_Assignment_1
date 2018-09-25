using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

    public GameObject brickParticle; 

void OnCollisionEnter (Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.instance.Destroybrick(); //call destroy brick function GM because of the static function we created in GM 
        Destroy(gameObject); 
    }
}
