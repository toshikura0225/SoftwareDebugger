using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLibrary.SerialPort.Modbus;
using System.Threading;
using System.Threading.Tasks;

namespace SoftwareDebuggerSolution
{
	public class VirtualTransistorIC
	{
		public enum PortType
		{
			port0,
			port1,
		}

		public enum PinType
		{
			pin1,
			pin2,
			pin3,
			pin4,
			pin5,
			pin6,
			pin7,
			pin8,
		}

		byte deviceAddress = 0;


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="deviceAddress">デバイスアドレス</param>
		public VirtualTransistorIC(byte deviceAddress)
		{
			this.deviceAddress = deviceAddress;
		}
		
		public void Init()
		{
			// Wire.begin(); // I2Cバスに接続
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x00, 0x00, 0x00, 0xAA, 0xAA });
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x00),
				PresetData = ModbusData.bytes2int(0x00, 0x00),
			};
			this.Write(query);
		}

		/// <summary>
		/// ポートの入出力方向を設定する（全ピン出力に固定）
		/// </summary>
		/// <param name="directionCollection"></param>
		public void WriteDirection(Dictionary<PortType, List<bool>> directionCollection)
		{
			// Wire.beginTransmission(0x20);	                // アドレスを7バイト
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x01, 0x00, this.deviceAddress, 0xAA, 0xAA });
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x01),
				PresetData = ModbusData.bytes2int(0x00, this.deviceAddress),
			};
			this.Write(query);

			// Wire.write(0x06);				// I/O direction(ic0)
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x02, 0x00, 0x06, 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x02),
				PresetData = ModbusData.bytes2int(0x00, 0x06),
			};
			this.Write(query);
			
			// Wire.write(0x00);				// ic0 directon
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x02, 0x00, 0x00, 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x02),
				PresetData = ModbusData.bytes2int(0x00, 0x00),
			};
			this.Write(query);

			// Wire.write(0x00);				// ic1 directionを続けて送信しても可
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x02, 0x00, 0x00, 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x02),
				PresetData = ModbusData.bytes2int(0x00, 0x00),
			};
			this.Write(query);

			// Wire.endTransmission();		// 送信
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x03, 0x00, 0x00, 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x03),
				PresetData = ModbusData.bytes2int(0x00, 0x00),
			};
			this.Write(query);
		}
		
		/// <summary>
		/// ポートの出力値を設定する
		/// </summary>
		/// <param name="levelCollection"></param>
		public void WriteLevel(Dictionary<PortType, List<bool>> levelCollection)
		{
			// Wire.beginTransmission(0x20);	                // アドレスを7バイト
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x01, 0x00, this.deviceAddress, 0xAA, 0xAA });
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x01),
				PresetData = ModbusData.bytes2int(0x00, this.deviceAddress),
			};
			this.Write(query);

			// Wire.write(0x02);				// コマンド
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x02, 0x00, 0x02, 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x02),
				PresetData = ModbusData.bytes2int(0x00, 0x02),
			};
			this.Write(query);

			// Wire.write(0x**);				// ic0 data
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x02, 0x00, this.Bool2Byte(levelCollection[PortType.port0]), 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x02),
				PresetData = ModbusData.bytes2int(0x00, this.Bool2Byte(levelCollection[PortType.port0])),
			};
			this.Write(query);

			// Wire.write(0x**);				// ic1 data
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x02, 0x00, this.Bool2Byte(levelCollection[PortType.port1]), 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x02),
				PresetData = ModbusData.bytes2int(0x00, this.Bool2Byte(levelCollection[PortType.port1])),
			};
			this.Write(query);

			// Wire.endTransmission();		// 送信
			//this.write(new byte[] { 0x00, 0x06, 0x06, 0x03, 0x00, 0x00, 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x03),
				PresetData = ModbusData.bytes2int(0x00, 0x00),
			};
			this.Write(query);
		}
		
		byte Bool2Byte(List<bool> list)
		{

			if(list.Count != 8)
			{
				throw new Exception("VirtualTransistorIC.Bool2Byte list.Count != 8");
			}

			byte ret = list[7] ? (byte)1 : (byte)0;

			for (int index = 6; index >= 0; index-- )
			{
				ret = (byte)(ret << 1);
				ret += list[index] ? (byte)1 : (byte)0;
			}

			return ret;
		}

		private void Write(Query_x06 query)
		{
			byte[] buffer = query.GetBytes();
			Console.Write("送信：");
			for (int i = 0; i < buffer.Length; i++)
			{
				Console.Write(buffer[i] + ",");
			}
			Console.WriteLine();
			VirtualArduino.ModbusSerial.Write(query);

		}

	}
}
