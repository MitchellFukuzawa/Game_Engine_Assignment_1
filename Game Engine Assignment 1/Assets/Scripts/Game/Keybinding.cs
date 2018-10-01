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
    private void KickChildOut(Ball gameObj)
    {

        gameObj.GetComponent<Transform>().parent = null;
        gameObj.ballInPlay = true;
        gameObj.GetComponent<Rigidbody>().isKinematic = false;
        gameObj.GetComponent<Rigidbody>().AddForce(new Vector3(gameObj.ballVelocity.x * 4 * RandPlugin.Random(1, 1), gameObj.ballVelocity.y * 4 * RandPlugin.Random(1, 1), 0));
    }

    public override void ButtonPressed(GameObject affectedObj)
    {
        if (affectedObj.transform.childCount > 0)
        {
            KickChildOut(affectedObj.transform.GetChild(0).GetComponent<Ball>());
        }
    }
}
public class Left : Keybinding
{
    public override void ButtonPressed(GameObject affectedObj)
    {
        float xPos = affectedObj.transform.position.x + (-5.0f) * Time.timeScale;
        Vector3 pos = new Vector3(Mathf.Clamp(xPos, -90.0f, 90.0f), affectedObj.transform.position.y, 0.0f);
        affectedObj.transform.position = pos;
    }

}
public class Right : Keybinding
{
    public override void ButtonPressed(GameObject affectedObj)
    {
        float xPos = affectedObj.transform.position.x + ( 5.0f) * Time.timeScale;
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