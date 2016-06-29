using SharedLibrary.SerialPort.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class AD5206<TLatchPinType> : LatchingSPI<TLatchPinType>
	{
		public AD5206(ISPI spi, IDigitalOutput<TLatchPinType> digitalouput) : base(spi, digitalouput)
		{
			// コンストラクタ
		}

		public enum PinType
		{
			pin1,
			pin2,
			pin3,
			pin4,
			pin5,
			pin6,
		}

		public void SetRegister(AD5206<TLatchPinType>.PinType pin, byte outputValue)
		{
			// データ転送
			this.Transfer(new List<byte>() { (byte)pin, outputValue });
		}

	}


}