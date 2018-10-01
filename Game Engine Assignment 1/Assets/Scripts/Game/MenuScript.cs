using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{

    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;
    bool waitingForKey;

    void Start()
    {

        menuPanel = transform.Find("Panel");
        menuPanel.gameObject.SetActive(false);
        waitingForKey = false;
        int numberOfButtons = 4;
        // Go through every child of menuPanel to look for ButtonNames
        // Replaces the Text cild of Button with what's stored in the instance keybinding.
        for (int i = 0; i < numberOfButtons; i++)
        {
            // These will replace the text in the Buttons with current Assigned Keys
            if (menuPanel.GetChild(i).name == "Start")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GM.instance.commandList[i].button.ToString(); // look at GM.instance.<button command> and convert it to string
            else if (menuPanel.GetChild(i).name == "Left")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GM.instance.commandList[i].button.ToString();
            else if (menuPanel.GetChild(i).name == "Right")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GM.instance.commandList[i].button.ToString();
            else if (menuPanel.GetChild(i).name == "Restart")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GM.instance.commandList[i].button.ToString();

        }
    }


    void Update()
    {
        // Make sure we are in menue mode, if we are activate panel obj
        if (Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(true);
            GM.instance.gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(false);
            GM.instance.gamePaused = false;
        }

    }

    // Activates when Key pressed while wating for key
    private void OnGUI()
    {

        keyEvent = Event.current;

        if (keyEvent.isKey && waitingForKey)
        {

            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {

        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(Text text)
    {
        buttonText = text;
    }
    // Stop code routine from executing until we press a key
    IEnumerator WaitforKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }
    // Make sure we only wait for 1 button remapping
    // Make sure that SendText() is called in prefabs before AssignKey
    // on button press, this activates

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;
        yield return WaitforKey();

        switch (keyName)
        {
            case "Start":
                GM.instance.commandList[0].button = newKey;
                buttonText.text = GM.instance.commandList[0].button.ToString();
                PlayerPrefs.SetString("startKey", GM.instance.commandList[0].button.ToString()); // rplaces string
                GM.instance.commandQueue.Enqueue(newKey); // Add old key bind to queue
                GM.instance.keyBindQueue.Enqueue(GM.instance.commandList[0].ID); // make sure we know what keyclass it was
                break;
            // Repeat for each Button
            case "Left":
                GM.instance.commandList[1].button = newKey;
                buttonText.text = GM.instance.commandList[1].button.ToString();
                PlayerPrefs.SetString("leftKey", GM.instance.commandList[1].button.ToString());
                GM.instance.commandQueue.Enqueue(newKey); // Add old key bind to queue
                GM.instance.keyBindQueue.Enqueue(GM.instance.commandList[1].ID); // make sure we know what keyclass it was
                break;
            case "Right":
                GM.instance.commandList[2].button = newKey;
                buttonText.text = GM.instance.commandList[2].button.ToString();
                PlayerPrefs.SetString("rightKey", GM.instance.commandList[2].button.ToString());
                GM.instance.commandQueue.Enqueue(newKey); // Add old key bind to queue
                GM.instance.keyBindQueue.Enqueue(GM.instance.commandList[2].ID); // make sure we know what keyclass it was
                break;
            case "Restart":
                GM.instance.commandList[3].button = newKey;
                buttonText.text = GM.instance.commandList[3].button.ToString();
                PlayerPrefs.SetString("restartKey", GM.instance.commandList[3].button.ToString());
                GM.instance.commandQueue.Enqueue(newKey); // Add old key bind to queue
                GM.instance.keyBindQueue.Enqueue(GM.instance.commandList[3].ID); // make sure we know what keyclass it was
                break;
        }
        yield return null;
    }

}
