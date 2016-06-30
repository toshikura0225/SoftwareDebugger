using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class PCAL9555A : AddressingI2C
	{
		public PCAL9555A(II2C i2c, byte address) : base(i2c, address)
		{
		}

		public enum PinType
		{
			pin1,
			pin2,
			pin3,
		}

		public void SetLevel(PinType pin, bool level)
		{
			this.write(new List<byte>() { });
		}
	}
}