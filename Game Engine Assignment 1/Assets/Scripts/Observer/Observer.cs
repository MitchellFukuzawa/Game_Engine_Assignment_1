using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer
{
	public abstract void OnNotify();
}

public class BrickObserver : Observer
{
	GameObject brickObj;
	GameObject winText;

	public BrickObserver(GameObject obj, GameObject win)
	{
		this.brickObj = obj;
		this.winText = win;
	}

	public override void OnNotify()
	{
		winText.SetActive(true);
	}
}
