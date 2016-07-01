using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLibrary.SerialPort.Modbus;
using System.IO.Ports;
using System.ComponentModel;
using VirtualComponent.IC;

namespace VirtualComponent.Arduino
{
	/// <summary>
	/// Arduinoの各種機能のアドレス
	/// </summary>
	public static class VirtualArduinoAddress
	{
		// デジタルIO関連
		public static byte DIO_MODE = 0x00;
		public static byte DIO_MODE_INPUT = 0x00;
		public static byte DIO_MODE_OUTPUT = 0x01;
		public static byte DIO_MODE_INPUT_PULLUP = 0x02;
		public static byte DIO_MODE_DIGITAL = 0x00;
		public static byte DIO_MODE_ANALOG = 0x01;
		public static byte DIO_VALUE = 0x01;

		// SPI関連
		public static byte SPI = 0x05;
		public static byte SPI_BEGIN = 0x00;
		public static byte SPI_MODE = 0x01;
		public static byte SPI_TRANSFER = 0x02;
		public static byte SPI_END = 0x03;

		// I2C関連
		public static byte I2C = 0x06;
		public static byte I2C_BEGIN = 0x00;
		public static byte I2C_BEGIN_TRANSMISSION = 0x01;
		public static byte I2C_WRITE = 0x02;
		public static byte I2C_END_TRANSMISSION = 0x03;
	}

	/// <summary>
	/// シリアル通信を使用してArduinoを制御する
	/// </summary>
	public class VirtualArduino
	{
		/// <summary>
		/// ArduinoのI2C機能
		/// </summary>
		public II2C i2c;
		
		/// <summary>
		/// ArduinoのSPI機能
		/// </summary>
		public ISPI spi;
		
		/// <summary>
		/// Arduinoの入出力機能
		/// </summary>
		public IDigitalOutput<PinName> io;

		/// <summary>
		/// ArduinoのCPU(ATMEGA328P)のピン名
		/// </summary>
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


		/// <summary>
		/// Arduinoと通信するためのModbus通信
		/// </summary>
		ModbusSerialPort modbusSerialPort = new ModbusSerialPort();
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="portName">COMポート名</param>
		public VirtualArduino(string portName)
		{
			this.modbusSerialPort.PortName = portName;

			this.modbusSerialPort = new ModbusSerialPort()
			{
				BaudRate = 9600,
				Handshake = System.IO.Ports.Handshake.None,
			};

			this.modbusSerialPort.ModbusDataReceived += (s, e) =>
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

	/// <summary>
	/// ArduinoのI2C通信機能の実装
	/// </summary>
	internal class VirtualI2C : II2C
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
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.I2C, VirtualArduinoAddress.I2C_BEGIN),
				PresetData = ModbusData.bytes2int(0x00, 0x00),  // 値は常に無効
			};
			this.modbusSerialPort.Write(query);
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
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.I2C, VirtualArduinoAddress.I2C_BEGIN_TRANSMISSION),
				PresetData = ModbusData.bytes2int(0x00, i2cAddress),
			};
			this.modbusSerialPort.Write(query);
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
			this.modbusSerialPort.Write(query);
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
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.I2C, VirtualArduinoAddress.I2C_BEGIN_TRANSMISSION),
				PresetData = ModbusData.bytes2int(0x00, 0x00),  // 値は無効
			};
			this.modbusSerialPort.Write(query);

		}

	}

	/// <summary>
	/// ArduinoのSPI通信機能の実装
	/// </summary>
	internal class VirtualSPI : ISPI
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
			//// initialize SPI:
			//SPI.begin();
			//this.modbusSerial.PortName.Write(new byte[] { 0x00, 0x06, 0x05, 0x00, 0x00, 0x00, 0xAA, 0xAA });
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.SPI, VirtualArduinoAddress.SPI_BEGIN),
				PresetData = ModbusData.bytes2int(0x00, 0x00),
			};
			this.modbusSerialPort.Write(query);

			//SPI.setDataMode(SPI_MODE0);
			//SPI.setClockDivider(SPI_CLOCK_DIV32);
			//this.modbusSerial.PortName.Write(new byte[] { 0x00, 0x06, 0x05, 0x01, 0x00, 0x06, 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.SPI, VirtualArduinoAddress.SPI_MODE),
				PresetData = ModbusData.bytes2int(0x00, 0x06),
			};
			this.modbusSerialPort.Write(query);
		}
		/// <summary>
		/// SPIバスを通じて1バイトを転送します。
		/// </summary>
		public void transfer(List<byte> dataList)
		{
			// SPI.transfer(valueL);
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.SPI, VirtualArduinoAddress.I2C_WRITE),
				//PresetData = ModbusData.bytes2int(0x00, 0x00),
			};

			foreach(var data in dataList)
			{
				query.PresetData = ModbusData.bytes2int(0x00, data);
				this.modbusSerialPort.Write(query);
			}

		}
		/// <summary>
		/// SPIバスを無効にします。各ピンの設定は変更されません。
		/// </summary>
		public void end()
		{
			// ▲Arduino側が未実装
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.SPI, VirtualArduinoAddress.SPI_END),
				PresetData = ModbusData.bytes2int(0x00, 0x00),
			};
			this.modbusSerialPort.Write(query);

			throw new NotImplementedException();
		}

	}

	/// <summary>
	/// Arduinoの入出力機能の実装
	/// </summary>
	internal class VirtualGPIO : IDigitalOutput<VirtualArduino.PinName>
	{
		public VirtualArduino.PinName PinName { get; set; }

		ModbusSerialPort modbusSerialPort = new ModbusSerialPort();

		public VirtualGPIO(ModbusSerialPort modbusSerialPort)
		{
			this.modbusSerialPort = modbusSerialPort;
		}
		
		/// <summary>
		/// デジタル入出力方向をセットする
		/// </summary>
		/// <param name="direction"></param>
		public void SetDirection(bool direction)
		{
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.DIO_MODE, (byte)this.PinName),
				PresetData = ModbusData.bytes2int(0x00, VirtualArduinoAddress.DIO_MODE_DIGITAL),
			};
			this.modbusSerialPort.Write(query);
		}

		/// <summary>
		/// デジタル出力値をセットする
		/// </summary>
		/// <param name="level"></param>
		public void SetLevel(bool level)
		{
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.DIO_MODE, (byte)this.PinName),
				PresetData = ModbusData.bytes2int(0x00, (level ? (byte)1 : (byte)0)),
			};
			this.modbusSerialPort.Write(query);
		}
	}
}
