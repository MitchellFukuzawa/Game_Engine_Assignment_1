using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;
    bool waitingForKey;

	void Start () {
        menuPanel = transform.Find("Panel");
        menuPanel.gameObject.SetActive(false);
        waitingForKey = false;
        int numberOfButtons = 1;
        // Go through every child of menuPanel to look for ButtonNames
        // Replaces the Text cild of Button with what's stored in the instance keybinding.
        for (int i = 0; i < numberOfButtons; i++)
        {
            if (menuPanel.GetChild(i).name == "Start")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GM.instance.start.ToString(); // look at GM.instance.<button command> and convert it to string
        } 

	}

	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf) {
            menuPanel.gameObject.SetActive(true);
            GM.instance.gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf) {
            menuPanel.gameObject.SetActive(false);
            GM.instance.gamePaused = false;
        }
    }

    // Activates when Key pressed while wating for key
    private void OnGUI() {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }
        
    public void StartAssignment(string keyName) {

        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(Text text) {
        buttonText = text;
    }
    // Stop code routine from executing until we press a key
    IEnumerator WaitforKey() {
        while (!keyEvent.isKey)
            yield return null;
    }
    // Make sure we only wait for 1 button remapping
    // Make sure that SendText() is called in prefabs before AssignKey
    // on button press, this activates

    public IEnumerator AssignKey(string keyName){
        waitingForKey = true;
        yield return WaitforKey();

        switch (keyName) {
            case "Start":
                GM.instance.start = newKey;
                buttonText.text = GM.instance.start.ToString();
                PlayerPrefs.SetString("forwardKey", GM.instance.start.ToString()); // rplaces string
                break;
               // Repeat for each Button
        }
        yield return null;
    }

}
