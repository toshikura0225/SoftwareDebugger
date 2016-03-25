using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLibrary.SerialPort.Modbus;
using System.Threading.Tasks;
using System.Threading;

namespace SoftwareDebuggerSolution
{

	public class VirtualResistorIC
	{
		
		public enum PinType
		{
			pin1 = 0,
			pin2,
			pin3,
			pin4,
			pin5,
			pin6,
		}

		Arduino.PinType latchPin;

		public void Init()
		{
			//pinMode(slaveSelectPin, OUTPUT);
			this.write(new byte[] { 0x00, 0x06, 0x00, (byte)this.latchPin, 0x01, 0x00, 0xAA, 0xAA});
			
			//// initialize SPI:
			//SPI.begin();
			this.write(new byte[] { 0x00, 0x06, 0x05, 0x00, 0x00, 0x00, 0xAA, 0xAA });

			//SPI.setDataMode(SPI_MODE0);
			//SPI.setClockDivider(SPI_CLOCK_DIV32);
			this.write(new byte[] { 0x00, 0x06, 0x05, 0x01, 0x00, 0x06, 0xAA, 0xAA });

		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="latchPin"></param>
		public VirtualResistorIC(Arduino.PinType latchPin)
		{
			this.latchPin = latchPin;
		}

		/// <summary>
		/// 抵抗値をセットする
		/// </summary>
		/// <param name="pinType">ピン</param>
		/// <param name="outputValue">出力値（０～２５５）</param>
		public void SetResistor(PinType pinType, byte outputValue)
		{
			//digitalWrite(slaveSelectPin, LOW);
			this.write(new byte[] { 0x00, 0x06, 0x01, (byte)this.latchPin, 0x00, 0x00, 0xAA, 0xAA });

			////  send in the address and value via SPI:
			//SPI.transfer(address);
			this.write(new byte[] { 0x00, 0x06, 0x05, 0x02, 0x00, (byte)pinType, 0xAA, 0xAA });

			//SPI.transfer(value);
			this.write(new byte[] { 0x00, 0x06, 0x05, 0x02, 0x00, outputValue, 0xAA, 0xAA });

			//// take the SS pin high to de-select the chip:
			//digitalWrite(slaveSelectPin, HIGH);
			this.write(new byte[] { 0x00, 0x06, 0x01, (byte)this.latchPin, 0x00, 0x01, 0xAA, 0xAA });
		}

		//async void write(byte[] buf)
		void write(byte[] buf)
		{
			Arduino.Serial.Write(buf, 0, 8);
			//await Task.Run(() => Thread.Sleep(10));
			//Task.Run(() => Thread.Sleep(10));
		}

		
	}
}
