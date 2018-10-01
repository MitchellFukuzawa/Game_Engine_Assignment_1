using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverP : MonoBehaviour
{
    bool blue;

    #region Singleton
    private static ObserverP _instance;
    public static ObserverP Instance
    {
        get
        {
            //create logic to create the instance 
            if (_instance == null)
            {
                GameObject go = new GameObject("ObserverP");
                go.AddComponent<ObserverP>();

            }
            return _instance;
        }
    }
    #endregion

    //public Enemy[] enemies; 
    //publisher
    public delegate void ChangePaddleColor(Color color); //delegate holds a reference to a a/several methods, used to raise events, delegates are multicasts
    //subscriber
    public static event ChangePaddleColor onPaddle; //event is used to raise events and permits the action of calling delegate reference, you can subscribe those events to add or remove methods

    // Use this for initialization
    void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        //damage enemy
        {
            if (onPaddle != null && blue) // check if anyone is subscribed to on enemy hit, if not null people are listening to this event 
            {
                onPaddle(Color.blue);
                blue = false;

                //    foreach (var enemy in enemies)
                //    {
                //        enemy.GetComponent<Renderer>().material.color = Color.red; 
                //    }
                //
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            //damage enemy
            {
                if (onPaddle != null && !blue)
                {
                    onPaddle(Color.black);
                    blue = true;
                }


            }
        }
    }
}
