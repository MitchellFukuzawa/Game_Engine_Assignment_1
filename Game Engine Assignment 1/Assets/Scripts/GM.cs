using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GM : MonoBehaviour {

    public int lives = 3;
    public int bricks = 32;
    public float resetDelay = 1.0f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab; //instantiate new bricks
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null; //accessable from other scripts ex, GM.instance.bricks


    private GameObject clonePaddle; 


	// Use this for initialization
	void Awake () {

        if (instance == null)
            instance = this; // check and see if we have a gm yet, if not then we set it to this
        else if (instance != this)
            Destroy(gameObject);

        Setup(); 
	}
	
    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity); 
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f; //slow mo 
            Invoke("Reset", resetDelay); 
       
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f; //slow mo 
            Invoke("Reset", resetDelay);
        }
    }

    void Reset()
    {
        Time.timeScale = 1.0f;
       // Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver(); 
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void Destroybrick()
    {
        bricks--;
        CheckGameOver(); 
    }
	// Update is called once per frame
	void Update () {
		
	}
}
