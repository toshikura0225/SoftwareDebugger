using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class PCAL9555A
	{
		II2C i2c;
		public PCAL9555A(II2C i2c)
		{
			this.i2c = i2c;
		}
	}
}