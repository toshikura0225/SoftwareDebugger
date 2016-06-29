﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class MAX335<TLatchPinType> : LatchingSPI<TLatchPinType>
	{
		public MAX335(ISPI spi, IDigitalOutput<TLatchPinType> digitalouput) : base(spi, digitalouput)
		{
			// コンストラクタ
		}

		public enum PinType
		{
			pin0,
			pin1,
			pin2,
			pin3,
			pin4,
			pin5,
			pin6,
			pin7,
		}

		public enum SwitchType
		{
			ON,
			OFF,
		}

		public void SetSwitch(MAX335<TLatchPinType>.PinType pin, SwitchType state)
		{
			// データ転送
			this.Transfer(new List<byte>() { 0x00 });
		}
	}
}