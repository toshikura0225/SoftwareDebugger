using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class MAX335
	{

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

		ISPI spi;
		public MAX335(ISPI spi)
		{
			this.spi = spi;
		}
	}
}