using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Keybinding
{
    public KeyCode button { get; set; }
    public float timePressed = 0.0f;
    public int ID = 0; 
    public abstract void ButtonPressed(GameObject affectedObj);
}
public class Start : Keybinding
{
    public override void ButtonPressed(GameObject affectedObj)
    {

    }
}
public class Left : Keybinding
{
    public override void ButtonPressed(GameObject affectedObj)
    {
        float xPos = affectedObj.transform.position.x + (Input.GetAxis("Horizontal") * 100.0f);
        Vector3 pos = new Vector3(Mathf.Clamp(xPos, -90.0f, 90.0f), affectedObj.transform.position.y, 0.0f);
        affectedObj.transform.position = pos;
    }

}
public class Right : Keybinding
{
    public override void ButtonPressed(GameObject affectedObj)
    {
        float xPos = affectedObj.transform.position.x + (Input.GetAxis("Horizontal") * 100.0f);
        Vector3 pos = new Vector3(Mathf.Clamp(xPos, -90.0f, 90.0f), affectedObj.transform.position.y, 0.0f);
        affectedObj.transform.position = pos;
    }
}


public class Restart : Keybinding
{
    public override void ButtonPressed(GameObject affectedObj)
    {
    }



}
