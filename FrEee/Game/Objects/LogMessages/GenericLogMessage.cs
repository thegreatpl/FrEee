﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrEee.Game.Objects.LogMessages
{
	/// <summary>
	/// A generic text log message with no picture.
	/// </summary>
	public class GenericLogMessage : LogMessage
	{
		public GenericLogMessage(string text, int turn) : base(text, turn)
		{ }

		public override System.Drawing.Image Picture
		{
			get { return null; }
		}
	}
}
