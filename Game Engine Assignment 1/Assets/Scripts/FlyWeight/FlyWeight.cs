using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeight : MonoBehaviour
{
		
	public GameObject brickParent;
	public Texture brickTex;
	void Start()
	{
		// Create Bricks
		for (int i = 0; i < 40; i++)
		{
			//Reference brick texture and apply to each brick in scene
			brickParent.transform.Find("Brick" + i).GetComponent<Renderer>().material.mainTexture = brickTex;
		}
	}
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace FlyWeightPattern
// {
// 	public class FlyWeight : MonoBehaviour
// 	{
// 		List<Brick> Bricks = new List<Brick>();
		
// 		List<Vector3> brickColor;
// 		void Start()
// 		{
// 			brickColor = BrickColor();

// 			// Create Bricks
// 			for (int i = 1; i < 1000; i++)
// 			{
// 				Brick newBrick = new Brick();

// 				//Without FlyWeight
// 				//newBrick.brickColor = BrickColor();

// 				//With FlyWeight
// 				newBrick.brickColor = brickColor;

// 				Bricks.Add(newBrick);
// 			}
// 		}

// 		List<Vector3> BrickColor() // BRICK PROPERTIES
// 		{
// 			List<Vector3> brickCol = new List<Vector3>();

// 			for (int i = 1; i < 8; i++)
// 			{
// 				for (int j = 1; j < 4; j++)
// 				{
// 					if (j == 1)
// 						brickCol.Add(new Vector3(1, 0, 0));
// 					else if (j == 2)
// 						brickCol.Add(new Vector3(0, 1, 0));
// 					else if (j == 3)
// 						brickCol.Add(new Vector3(0, 0, 1));
// 					else if (j == 4)
// 						brickCol.Add(new Vector3(1, 1, 0));
// 				}
// 			}

// 			return brickCol;
// 		}
// 	}
// }