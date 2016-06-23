using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class SerialI2C : IVirtualI2C
	{
		public void Open(byte address)
		{
			throw new NotImplementedException();
		}

		public void Close()
		{
			throw new NotImplementedException();
		}

		public void Write(byte data)
		{
			throw new NotImplementedException();
		}
	}
}