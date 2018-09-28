using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandDesign
{
	public abstract class Command
	{
		public float moveDistance = 10.0f;
		public abstract void Execute(Transform paddlePos, Command command);
		public virtual void Move(Transform paddlePos) { }
	}

	public class MoveLeft : Command
	{
		public override void Execute(Transform paddlePos, Command command)
		{
			Move(paddlePos);
			// InputManager.oldCommands.Add(command);
		}

		public override void Move(Transform paddlePos)
		{
			paddlePos.Translate(-paddlePos.right * moveDistance);
		}
	}

	public class MoveRight : Command
	{
		public override void Execute(Transform paddlePos, Command command)
		{
			Move(paddlePos);
			// InputManager.oldCommands.Add(command);
		}
		public override void Move(Transform paddlePos)
		{
			paddlePos.Translate(paddlePos.right * moveDistance);
		}
	}
	
	public class DoNothing : Command
	{
		public override void Execute(Transform paddlePos, Command command)
		{
			// Do nothing if this key is pressed
		}
	}
}
