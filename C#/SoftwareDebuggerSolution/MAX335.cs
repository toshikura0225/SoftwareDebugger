using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class MAX335<TPinType>
	{

		protected ISPI spi { get; set; }

		protected IDigitalOutput<TPinType> digitalOutput { get; set; }

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

		public enum SwitchType
		{
			ON,
			OFF,
		}

		public MAX335()
		{

		}

		public MAX335(ISPI spi, IDigitalOutput<TPinType> digitalouput)
		{
			this.spi = spi;

			this.digitalOutput = digitalOutput;
		}


		public void SetSwitch(PinType pin, SwitchType state)
		{
			this.spi.transfer(new List<byte>() { 0x00 });
		}
	}
}