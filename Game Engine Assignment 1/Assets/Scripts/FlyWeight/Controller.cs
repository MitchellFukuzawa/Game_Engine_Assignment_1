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

		//NoFly
		// for (int i = 0; i < 32; i++)
		// 	brickParent.transform.Find("Brick" + i).GetComponent<Renderer>().material.mainTexture = new Texture2D(1000,1000);
		
		//Observer
		winTextObj.SetActive(false);
		BrickObserver brick0 = new BrickObserver(brick0Obj, winTextObj);
		BrickObserver brick4 = new BrickObserver(brick4Obj, winTextObj);
		BrickObserver brick8 = new BrickObserver(brick8Obj, winTextObj);
		BrickObserver brick12 = new BrickObserver(brick12Obj, winTextObj);
		BrickObserver brick16 = new BrickObserver(brick16Obj, winTextObj);
		BrickObserver brick20 = new BrickObserver(brick20Obj, winTextObj);
		BrickObserver brick24 = new BrickObserver(brick24Obj, winTextObj);
		BrickObserver brick28 = new BrickObserver(brick28Obj, winTextObj);
		BrickObserver brick32 = new BrickObserver(brick32Obj, winTextObj);
		BrickObserver brick36 = new BrickObserver(brick36Obj, winTextObj);

		subject.AddObserver(brick0);
		subject.AddObserver(brick4);
		subject.AddObserver(brick8);
		subject.AddObserver(brick12);
		subject.AddObserver(brick16);
		subject.AddObserver(brick20);
		subject.AddObserver(brick24);
		subject.AddObserver(brick28);
		subject.AddObserver(brick32);
		subject.AddObserver(brick36);
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