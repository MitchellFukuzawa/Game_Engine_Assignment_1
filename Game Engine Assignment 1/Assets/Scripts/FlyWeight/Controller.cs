using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	//FlyWeight Variables
	public GameObject brickParent;
	public Texture brickTex;

	//Observer Variables (First row of bricks)
	public GameObject brick0Obj;
	public GameObject brick4Obj;
	public GameObject brick8Obj;
	public GameObject brick12Obj;
	public GameObject brick16Obj;
	public GameObject brick20Obj;
	public GameObject brick24Obj;
	public GameObject brick28Obj;
	public GameObject brick32Obj;
	public GameObject brick36Obj;

	public GameObject winTextObj;
	Subject subject = new Subject();
	private bool once = false;
	void Start()
	{
		//Fly
		brickParent.transform.Find("Brick0").GetComponent<Renderer>().sharedMaterial.mainTexture = brickTex;
		
		//Observer
		winTextObj.SetActive(false);
		BrickObserver brick0 = new BrickObserver(brick0Obj, winTextObj);
		subject.AddObserver(brick0);
		
	}

	void Update()
	{
		if ((brick0Obj == null || brick4Obj == null || brick8Obj == null || brick12Obj == null || brick16Obj == null || brick20Obj == null || brick24Obj == null || brick28Obj == null || brick32Obj == null || brick36Obj == null) && once == false)
		{
			subject.Notify();
			once = true;
		}
	}
}