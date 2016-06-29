using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class MAX335 : Component
	{

		public ISPI spi{ get; set; }

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
		
		public MAX335()
		{

		}

		public MAX335(ISPI spi)
		{
			this.spi = spi;
		}
	}
}