using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public interface IVirtualI2C
	{
		void Open(byte address);
		void Close();
		void Write(byte data);
	}
}