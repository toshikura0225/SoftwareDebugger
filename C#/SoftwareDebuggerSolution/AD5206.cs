using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class AD5206 : SerialSPI<AD5206.PinType>
	{
		public enum PinType
		{
			pin1,
			pin2,
			pin3,
			pin4,
			pin5,
			pin6,
		}



	}


}