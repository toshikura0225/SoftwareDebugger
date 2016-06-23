using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public interface IVirtualSPI<TPort>
	{
		void Open();
		void Close();
		void Write(TPort port, byte data);
		void setDataMode(SPIModeType modeType);


	}

	public enum SPIModeType
	{
		SPI_MODE0,
		SPI_MODE1,
		SPI_MODE2,
		SPI_MODE3,
	}
}