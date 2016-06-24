using SharedLibrary.SerialPort.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class SerialI2C
	{
		protected static byte ADDRESS_I2C = 0x06;
		protected static byte ADDRESS_BEGIN = 0x00;
		protected static byte ADDRESS_BEGIN_TRANSMISSION = 0x01;
		protected static byte ADDRESS_WRITE = 0x02;
		protected static byte ADDRESS_END_TRANSMISSION = 0x03;


		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SerialI2C()
		{
			// Wire.begin();
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(ADDRESS_I2C, ADDRESS_BEGIN),
				PresetData = ModbusData.bytes2int(0x00, 0x00),	// 値は常に無効
			};
			Arduino.ModbusSerial.Write(query);
		}
		

		public void Write(byte address, List<byte> dataList)
		{
			// Wire.write(valueL);
			foreach (var data in dataList)
			{
				Query_x06 query = new Query_x06()
				{
					DeviceAddress = 0x00,
					FunctionCode = 0x06,
					RegisterAddress = ModbusData.bytes2int(ADDRESS_I2C, ADDRESS_WRITE),
					PresetData = ModbusData.bytes2int(0x00, data),
				};
				Arduino.ModbusSerial.Write(query);
			}
		}

		protected void beginTransmission(byte deviceAddress)
		{
			// Wire.beginTransmission(valueL);
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(ADDRESS_I2C, ADDRESS_BEGIN_TRANSMISSION),
				PresetData = ModbusData.bytes2int(0x00, deviceAddress),
			};
			Arduino.ModbusSerial.Write(query);
		}

		protected void endTransmission()
		{
			// Wire.endTransmission();
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(ADDRESS_I2C, ADDRESS_BEGIN_TRANSMISSION),
				PresetData = ModbusData.bytes2int(0x00, 0x00),	// 値は無効
			};
			Arduino.ModbusSerial.Write(query);
		}

	}
}