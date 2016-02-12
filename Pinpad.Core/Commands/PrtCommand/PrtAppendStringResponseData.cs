﻿using Pinpad.Core.TypeCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pinpad.Core.Commands {
	/// <summary>
	/// Controller for PRT append string response action
	/// </summary>
	public class PrtAppendStringResponseData : BasePrtResponseData {
		/// <summary>
		/// Constructor
		/// </summary>
		public PrtAppendStringResponseData() {
		}

		/// <summary>
		/// Response Event
		/// </summary>
		public override PrinterActionCode PRT_ACTION
		{
			get {
				return PrinterActionCode.AppendString;
			}
		}
	}
}