using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandDesign
{
	public class InputManager : MonoBehaviour
	{
		public Transform paddlePos;
		private Command buttonA, buttonD;

		void Start()
		{
			buttonA = new MoveLeft();
			buttonD = new MoveRight();
		}

		public void HandleInput()
		{
			if(Input.GetKeyDown(KeyCode.A))
			{
				buttonA.Execute(paddlePos, buttonA);
			}
			else if(Input.GetKeyDown(KeyCode.D))
			{
				buttonD.Execute(paddlePos, buttonD);
			}
		}
	}
}
