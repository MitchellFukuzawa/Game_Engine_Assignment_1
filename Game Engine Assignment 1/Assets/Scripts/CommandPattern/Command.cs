﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandDesign
{
	public abstract class Command
	{
		public abstract void Execute(Transform paddle, Command command);
		public virtual void Undo(Transform paddle) {}
		public virtual void Move(Transform paddle) {}
	}

	public class DoNothing : Command
	{
		public override void Execute(Transform paddle, Command command)
		{
			// Do nothing if this key is pressed
		}
	}
}
