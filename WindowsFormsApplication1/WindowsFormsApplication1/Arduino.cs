using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLibrary.SerialPort.Modbus;
using System.IO.Ports;

namespace SoftwareDebuggerSolution
{
	public class Arduino
	{
		
		public enum PinType
		{
			pin0 = 0,	// RX
			pin1,		// TX
			pin2,
			pin3,
			pin4,
			pin5,
			pin6,
			pin7,
			pin8,
			pin9,
			pin10,
			pin11,
			pin12,
			pin13,
			pinA0,
			pinA1,
			pinA2,
			pinA3,
			pinA4,
			pina5,
		}

		public static ModbusSerialPort ModbusSerial;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Arduino()
		{
			ModbusSerial = new ModbusSerialPort()
			{
				BaudRate = 9600,
				Handshake = System.IO.Ports.Handshake.None,
			};

			ModbusSerial.ModbusDataReceived += (s, e) =>
				{
					Console.Write("受信：");
					byte[] buf = e.ReadData.GetBytes();
					for (int i = 0; i < buf.Length; i++ )
					{
						Console.Write(buf[i] + ",");
					}
					Console.WriteLine();
					Console.WriteLine();
				};
		}

	}
}
