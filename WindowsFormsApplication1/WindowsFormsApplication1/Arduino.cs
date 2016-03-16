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

		public static SerialPort Serial;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Arduino()
		{
			Serial = new SerialPort()
			{
				BaudRate = 9600,
				Handshake = System.IO.Ports.Handshake.None,
			};

			Serial.DataReceived += (s, e) =>
				{
					byte[] buf = new byte[Serial.ReadBufferSize];
					int len = Serial.Read(buf, 0, Serial.ReadBufferSize);

					for(var index = 0; index < len; index++)
					{
						Console.Write(buf[index] + ",");
					}

					Console.WriteLine();
				};
		}

	}
}
