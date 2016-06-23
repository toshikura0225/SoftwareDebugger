using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class AD5206 : System.ComponentModel.Component
	{
		protected SPIModeType spiMode = SPIModeType.SPI_MODE0;

		public SPIModeType SPIMode { get; set; }
		

		public Arduino.PinType LatchPin { get; set; }

		public enum PinType
		{
			pin1,
			pin2,
			pin3,
			pin4,
			pin5,
			pin6,
		}

		protected SerialSPI serialSPI;

		public bool SetRegistor(AD5206.PinType pin, byte data)
		{
			return true;
		}


	}


}