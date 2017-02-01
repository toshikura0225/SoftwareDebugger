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


		public static byte SPI_CLOCK_DIV4 = 0x00;
		public static byte SPI_CLOCK_DIV16 = 0x01;
		public static byte SPI_CLOCK_DIV64 = 0x02;
		public static byte SPI_CLOCK_DIV128 = 0x03;
		public static byte SPI_CLOCK_DIV2 = 0x04;
		public static byte SPI_CLOCK_DIV8 = 0x05;
		public static byte SPI_CLOCK_DIV32 = 0x06;

		// I2C関連
		public static byte I2C = 0x06;
		public static byte I2C_BEGIN = 0x00;
		public static byte I2C_BEGIN_TRANSMISSION = 0x01;
		public static byte I2C_WRITE = 0x02;
		public static byte I2C_END_TRANSMISSION = 0x03;
		public static byte I2C_READ = 0x04;
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
		public IGPIO<PinName> io;

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
		ModbusSerialPort modbusSerialPort;
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="portName">COMポート名</param>
		public VirtualArduino(string portName)
		{
			this.modbusSerialPort = new ModbusSerialPort()
			{
				//BaudRate = 9600,
				BaudRate = 57600,
				Handshake = System.IO.Ports.Handshake.None,
			};

			this.modbusSerialPort.PortName = portName;


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

			this.modbusSerialPort.Open();

			this.i2c = (II2C)new VirtualI2C(this.modbusSerialPort);
			this.spi = (ISPI)new VirtualSPI(this.modbusSerialPort);
			this.io = (IGPIO<PinName>)new VirtualGPIO(this.modbusSerialPort);
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
			Console.WriteLine("Wire.begin();");
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
			Console.WriteLine(string.Format("Wire.beginTransmission({0});", i2cAddress));
			this.modbusSerialPort.Write(query);
		}
		/// <summary>
		/// マスタがスレーブに送信するデータをキューに入れるときに使用します
		/// </summary>
		public void write(List<byte> dataList)
		{
			// Wire.write(0x**);
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(0x06, 0x02),
				//PresetData = ModbusData.bytes2int(0x00, 0x06),
			};
			foreach (var data in dataList)
			{
				query.PresetData = data;
				Console.WriteLine(string.Format("Wire.write({0})", data));
				this.modbusSerialPort.Write(query);
			}
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
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.I2C, VirtualArduinoAddress.I2C_END_TRANSMISSION),
				PresetData = ModbusData.bytes2int(0x00, 0x00),  // 値は無効
			};
			Console.WriteLine("Wire.endTransmission();");
			this.modbusSerialPort.Write(query);

		}

		/// <summary>
		/// マスターがスレーブから受信する（同期処理）
		/// </summary>
		/// <returns></returns>
		public byte read(byte i2cAddress)
		{
			// Wire.requestForm(アドレス,受信バイト数);
			Query_x03 query = new Query_x03()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x03,
				StartingAddress = ModbusData.bytes2int(VirtualArduinoAddress.I2C, VirtualArduinoAddress.I2C_READ),
				NumberOfPoints = ModbusData.bytes2int(0x00, i2cAddress),  // データ長部分にI2Cのアドレスを指定
			};
			Console.WriteLine(string.Format("Wire.requestForm({0},1);", i2cAddress));

			this.modbusSerialPort.DiscardOutBuffer();
			this.modbusSerialPort.DiscardInBuffer();
			this.modbusSerialPort.Write(query);

			this.modbusSerialPort.ReadTimeout = 1000;
			//this.modbusSerialPort.
			List<byte> retData = new List<byte>();
			while (retData.Count <= 6)
			{
				retData.Add(this.modbusSerialPort.ReadByte());
			}
			Console.WriteLine(string.Format("Wire.read() => {0}", retData[4]));

			return retData[4];
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
			Console.WriteLine("SPI.begin();");
			this.modbusSerialPort.Write(query);

			//SPI.setDataMode(SPI_MODE0);
			//SPI.setClockDivider(SPI_CLOCK_DIV32);
			//this.modbusSerial.PortName.Write(new byte[] { 0x00, 0x06, 0x05, 0x01, 0x00, 0x06, 0xAA, 0xAA });
			query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.SPI, VirtualArduinoAddress.SPI_MODE),
				PresetData = ModbusData.bytes2int(0x00, VirtualArduinoAddress.SPI_CLOCK_DIV32),
			};
			Console.WriteLine("SPI.setDataMode(SPI_MODE0); SPI.setClockDivider(SPI_CLOCK_DIV32);");
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
				Console.WriteLine(string.Format("SPI.transfer({0});", data));
				this.modbusSerialPort.Write(query);
			}

		}
		/// <summary>
		/// SPIバスを無効にします。各ピンの設定は変更されません。
		/// </summary>
		public void end()
		{
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.SPI, VirtualArduinoAddress.SPI_END),
				PresetData = ModbusData.bytes2int(0x00, 0x00),
			};
			Console.WriteLine(string.Format("SPI.end();"));
			this.modbusSerialPort.Write(query);
		}

	}

	/// <summary>
	/// Arduinoの入出力機能の実装
	/// </summary>
	internal class VirtualGPIO : IGPIO<VirtualArduino.PinName>
	{
		protected ModbusSerialPort modbusSerialPort;

		protected Dictionary<VirtualArduino.PinName, VoltageLevel> outputTable = new Dictionary<VirtualArduino.PinName, VoltageLevel>();


		public VirtualGPIO(ModbusSerialPort modbusSerialPort)
		{
			this.modbusSerialPort = modbusSerialPort;
		}

		/// <summary>
		/// 出力状態をセットする
		/// </summary>
		/// <param name="pinName"></param>
		/// <returns></returns>
		public VoltageLevel this[VirtualArduino.PinName pinName]
		{
			set
			{
				this.outputTable[pinName] = value;
			}
		}

		/// <summary>
		/// デジタル入出力方向をセットする
		/// </summary>
		/// <param name="direction"></param>
		public void SetDirection(VirtualArduino.PinName pinName, bool direction)
		{
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.DIO_MODE, (byte)pinName),
				PresetData = ModbusData.bytes2int((direction ? (byte)0x01 : (byte)0x00), VirtualArduinoAddress.DIO_MODE_DIGITAL),
			};
			Console.WriteLine(string.Format("pinMode({0}, {1});", pinName, direction));
			this.modbusSerialPort.Write(query);
		}

		/// <summary>
		/// デジタル入出力の出力方向をセットする
		/// </summary>
		/// <param name="argTable"></param>
		public void SetLevel(Dictionary<VirtualArduino.PinName, VoltageLevel> argTable)
		{
			foreach(var pair in argTable)
			{
				this.SetLevel(pair.Key, pair.Value);
			}
		}

		/// <summary>
		/// デジタル出力値をセットする
		/// </summary>
		/// <param name="level"></param>
		public void SetLevel(VirtualArduino.PinName pinName, VoltageLevel level)
		{
			Query_x06 query = new Query_x06()
			{
				DeviceAddress = 0x00,
				FunctionCode = 0x06,
				RegisterAddress = ModbusData.bytes2int(VirtualArduinoAddress.DIO_VALUE, (byte)pinName),
				PresetData = ModbusData.bytes2int(0x00, (level == VoltageLevel.HIGH ? (byte)1 : (byte)0)),
			};
			Console.WriteLine(string.Format("digitalOut({0}, {1});", pinName, level));
			this.modbusSerialPort.Write(query);
		}
	}
}
