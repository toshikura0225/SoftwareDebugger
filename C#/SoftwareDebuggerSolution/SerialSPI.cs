using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public abstract class SerialSPI<TICPinType> : System.ComponentModel.Component
	{
		protected SPIModeType spiMode = SPIModeType.SPI_MODE0;

		public SPIModeType SPIMode { get; set; }


		public VirtualArduino.PinType LatchPin { get; set; }

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

		public void Write(VirtualArduino.PinType port, byte data)
		{
			throw new NotImplementedException();
		}

		public abstract bool SetRegistor(TICPinType pin, byte data);

	}

}