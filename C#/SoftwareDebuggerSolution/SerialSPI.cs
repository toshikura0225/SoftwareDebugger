using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class SerialSPI : IVirtualSPI<Arduino.PinType>
	{
		public void Open()
		{
			throw new NotImplementedException();
		}

		public void Close()
		{
			throw new NotImplementedException();
		}
		
		public void setDataMode(SPIModeType modeType)
		{
			throw new NotImplementedException();
		}

		public void Write(Arduino.PinType port, byte data)
		{
			throw new NotImplementedException();
		}
	}

}