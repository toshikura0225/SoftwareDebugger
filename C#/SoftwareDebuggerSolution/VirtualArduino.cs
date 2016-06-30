using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLibrary.SerialPort.Modbus;
using System.IO.Ports;
using System.ComponentModel;

namespace SoftwareDebuggerSolution
{
	public static class VirtualArduinoAddress
	{
		public static byte ADDRESS_I2C = 0x06;
		public static byte ADDRESS_BEGIN = 0x00;
		public static byte ADDRESS_BEGIN_TRANSMISSION = 0x01;
		public static byte ADDRESS_WRITE = 0x02;
		public static byte ADDRESS_END_TRANSMISSION = 0x03;
	}

	public class VirtualArduino
	{

		ModbusSerialPort modbusSerialPort = new ModbusSerialPort();

		public string PortName { get; set; }


		public II2C i2c;
		public ISPI spi;
		public IDigitalOutput<PinName> io;


		public enum PinName
		{
			pin0 = 0,   // RX
			pin1,       // TX
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
		public VirtualArduino()
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
					for (int i = 0; i < buf.Length; i++)
					{
						Console.Write(buf[i] + ",");
					}
					Console.WriteLine();
					Console.WriteLine();
				};


			this.i2c = (II2C)new VirtualI2C(this.modbusSerialPort);
			this.spi = (ISPI)new VirtualSPI(this.modbusSerialPort);
			this.io = (IDigitalOutput<PinName>)new VirtualGPIO(this.modbusSerialPort);
		}
		
	}

	public class VirtualI2C : II2C
	{
		ModbusSerialPort modbusSerialPort;
		public VirtualI2C(ModbusSerialPort modbusSerialPort)
		{
			this.modbusSerialPort = modbusSerialPort;
		}

		/// <summary>
		/// Wireライブラリを初期化し、I2Cバスにマスタとして接続します
		/// </summary>
		public void begin()
		{
			// Wire.begin();
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.ADDRESS_I2C, VirtualArduinoAddress.ADDRESS_BEGIN),
				PresetData = ModbusData.bytes2int(0x00, 0x00),  // 値は常に無効
			};
			VirtualArduino.ModbusSerial.Write(query);
		}

		/// <summary>
		/// 指定したアドレスのI2Cスレーブに対して送信処理を始めます。この関数の実行後、write()でデータをキューへ送り、endTransmission()で送信を実行します。
		/// </summary>
		public void beginTransmission(byte i2cAddress)
		{
			// Wire.beginTransmission(valueL);
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.ADDRESS_I2C, VirtualArduinoAddress.ADDRESS_BEGIN_TRANSMISSION),
				PresetData = ModbusData.bytes2int(0x00, i2cAddress),
			};
			VirtualArduino.ModbusSerial.Write(query);
		}
		/// <summary>
		/// マスタがスレーブに送信するデータをキューに入れるときに使用します
		/// </summary>
		public void write(List<byte> dataList)
		{
			// Wire.write(0x06);
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x02),
				PresetData = ModbusData.bytes2int(0x00, 0x06),
			};
			VirtualArduino.ModbusSerial.Write(query);
		}
		/// <summary>
		/// スレーブデバイスに対する送信を完了します。
		/// </summary>
		/// <returns>
		/// true：成功 false：失敗
		/// </returns>
		public void endTransmission()
		{
			// Wire.endTransmission();
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.ADDRESS_I2C, VirtualArduinoAddress.ADDRESS_BEGIN_TRANSMISSION),
				PresetData = ModbusData.bytes2int(0x00, 0x00),  // 値は無効
			};
			VirtualArduino.ModbusSerial.Write(query);

		}

	}


	public class VirtualSPI : ISPI
	{
		ModbusSerialPort modbusSerialPort;

		public VirtualSPI(ModbusSerialPort modbusSerialPort)
		{
			this.modbusSerialPort = modbusSerialPort;
		}

		/// <summary>
		/// SPIバスを初期化します。SCK、MOSI、SSの各ピンは出力に設定され、SCKとMOSIはlowに、SSはhighとなります。
		/// </summary>
		public void begin()
		{
			////pinMode(slaveSelectPin, OUTPUT);
			////VirtualArduino.ModbusSerial.Write(new byte[] { 0x00, 0x06, 0x00, (byte)this.latchPin, 0x01, 0x00, 0xAA, 0xAA});
			//Query_x06 query = new Query_x06()
			//{
			//	DeviceAddress = 0x00,
			//	FunctionCode = 0x06,
			//	RegisterAddress = ModbusData.bytes2int(0x00, latchPin),
			//	PresetData = ModbusData.bytes2int(0x01, 0x00),
			//};
			//VirtualArduino.ModbusSerial.Write(query);

			//// initialize SPI:
			//SPI.begin();
			//VirtualArduino.ModbusSerial.Write(new byte[] { 0x00, 0x06, 0x05, 0x00, 0x00, 0x00, 0xAA, 0xAA });
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x05, 0x00),
				PresetData = ModbusData.bytes2int(0x00, 0x00),
			};
			VirtualArduino.ModbusSerial.Write(query);

			//SPI.setDataMode(SPI_MODE0);
			//SPI.setClockDivider(SPI_CLOCK_DIV32);
			//VirtualArduino.ModbusSerial.Write(new byte[] { 0x00, 0x06, 0x05, 0x01, 0x00, 0x06, 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x05, 0x01),
				PresetData = ModbusData.bytes2int(0x00, 0x06),
			};
			VirtualArduino.ModbusSerial.Write(query);
		}
		/// <summary>
		/// SPIバスを通じて1バイトを転送します。
		/// </summary>
		public void transfer(List<byte> dataList)
		{

		}
		/// <summary>
		/// SPIバスを無効にします。各ピンの設定は変更されません。
		/// </summary>
		public void end()
		{

		}

	}

	public class VirtualGPIO : IDigitalOutput<VirtualArduino.PinName>
	{
		public VirtualArduino.PinName PinName { get; set; }

		ModbusSerialPort modbusSerialPort = new ModbusSerialPort();

		public VirtualGPIO(ModbusSerialPort modbusSerialPort)
		{
			this.modbusSerialPort = modbusSerialPort;
		}


		public void SetDirection(bool direction)
		{
			throw new NotImplementedException();
		}

		public void SetLevel(bool level)
		{
			throw new NotImplementedException();
		}
	}
}
