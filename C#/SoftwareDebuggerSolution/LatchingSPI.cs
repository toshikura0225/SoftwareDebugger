using SharedLibrary.SerialPort.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class LatchingSPI<TLatchPinName>
	{
		protected ISPI spi { get; set; }

		protected IDigitalOutput<TLatchPinName> digitalOutput { get; set; }


		public LatchingSPI(ISPI spi, IDigitalOutput<TLatchPinName> digitalouput)
		{
			this.spi = spi;

			this.digitalOutput = digitalOutput;

			this.spi.begin();
			this.digitalOutput.SetDirection(true);
		}

		~LatchingSPI()
		{
			this.spi.end();
		}

		protected void Transfer(List<byte> dataList)
		{
			// スレーブ選択
			this.digitalOutput.SetLevel(false);

			// データ転送
			this.spi.transfer(dataList);

			// スレーブに適用
			this.digitalOutput.SetLevel(true);
		}
	}


}