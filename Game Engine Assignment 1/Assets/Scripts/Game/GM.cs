using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{

    public int lives = 3;
    public int bricks = 32;
    public float resetDelay = 1.0f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    //public GameObject bricksPrefab; //instantiate new bricks
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null; //accessable from other scripts ex, GM.instance.bricks
    public bool gamePaused = false;

    private GameObject clonePaddle;

    public Keybinding[] commandList = new Keybinding[4];
    public Queue<KeyCode> commandQueue = new Queue<KeyCode>();
    public Queue<int> keyBindQueue = new Queue<int>();

    // Use this for initialization
    void Awake()
    {

        if (instance == null)
            instance = this; // check and see if we have a gm yet, if not then we set it to this
        else if (instance != this)
            Destroy(gameObject);

        // These will save last saved rebindings, if any. Otherwise, will go back to these defaults

        commandList[0] = new Start();
        commandList[1] = new Left();
        commandList[2] = new Right();
        commandList[3] = new Restart();

        commandList[0].button = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("startKey", "Space")); commandList[0].ID = 0;
         commandList[1].button = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A")); commandList[1].ID = 1;
        commandList[2].button = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D")); commandList[2].ID = 2;
        commandList[3].button = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("restartKey", "R")); commandList[3].ID = 3;


        Setup();

    }

    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        //Instantiate(bricksPrefab, transform.position, Quaternion.identity); 
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
        Invoke("SetupPaddle", resetDelay);
        Destroy(clonePaddle);
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

    public void undoQueue()
    {
     //   int undoID = keyBindQueue.Dequeue();
     //   commandList[undoID].button = newKey;
     //
     //    buttonText.text = commandList[undoID].button.ToString();
     //   PlayerPrefs.SetString("startKey", GM.instance.commandList[0].button.ToString()); // rplaces string

    }

    // Update is called once per frame
    void Update()
    {

        if (gamePaused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;

        for (int i = 0; i < commandList.Length; i++)
        {
            if (Input.GetKey(commandList[i].button))
            {
                if (clonePaddle != null)
                    commandList[i].ButtonPressed(clonePaddle);
            }
        }

        if (Input.GetKey(commandList[3].button))
        {
           


        }
    }

}
