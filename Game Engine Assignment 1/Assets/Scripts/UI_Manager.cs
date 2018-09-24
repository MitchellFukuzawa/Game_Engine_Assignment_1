using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour {

	public GameObject mainmenu;
	public GameObject options;

	void Awake()
	{
		mainmenu.SetActive(true);
		options.SetActive(false);
	}

	public void Play()
	{
		SceneManager.LoadScene(1);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
