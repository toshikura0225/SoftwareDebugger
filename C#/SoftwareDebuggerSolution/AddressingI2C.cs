using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class AddressingI2C
	{
		II2C i2c;
		byte deviceAddress;

		public AddressingI2C(II2C i2c, byte address)
		{
			this.deviceAddress = address;
			this.i2c = i2c;
			this.i2c.begin();

			// 入出力ポートを出力にセット
		}

		protected void write(List<byte> dataList)
		{
			this.i2c.beginTransmission(this.deviceAddress);
			this.i2c.write(dataList);
			this.i2c.endTransmission();
		}
	}
}