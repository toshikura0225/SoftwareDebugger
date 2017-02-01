using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualComponent.IC
{
	/// <summary>
	/// GPIOモジュール「PCAL9555A」の機能を処理する。入出力機能はすべて出力。
	/// </summary>
	public class PCAL9555A : AddressingI2C, IGPIO<PCAL9555A.PinName>
	{
		/// <summary>
		/// PCAL9555Aのコマンドコード（データシート参照）
		/// </summary>
		public enum Command
		{
			InputPort_0 = 0x00,
			InputPort_1,
			OutputPort_0 = 0x02,
			OutputPort_1,
			ConfigurationPort_0 = 0x06,
			ConfigurationPort_1,
		}

		enum IODirectionType
		{
			OutputPort = 0x00,
			InputPort = 0x01,
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="i2c">I2Cオブジェクト</param>
		/// <param name="address">I2Cスレーブのデバイスアドレス</param>
		public PCAL9555A(II2C i2c, byte address) : base(i2c, address)
		{
			// 入出力ポートをすべて出力に設定

			Console.WriteLine(string.Format("PCAL9555A 各ピンを出力＆LOWにセット"));
			/*
			this.write(new List<byte>()
			{
				(byte)Command.ConfigurationPort_0,
				0,	// すべて出力
			});

			this.write(new List<byte>()
			{
				(byte)Command.ConfigurationPort_1,
				0,	// すべて出力
			});

			// デフォルト値としてLOWをセット
			foreach (PinName P in Enum.GetValues(typeof(PinName)))
			{
				outputTable[P] = VoltageLevel.LOW;
			}
			*/
		}

		public enum PinName
		{
			P0_0,
			P0_1,
			P0_2,
			P0_3,
			P0_4,
			P0_5,
			P0_6,
			P0_7,
			P1_0,
			P1_1,
			P1_2,
			P1_3,
			P1_4,
			P1_5,
			P1_6,
			P1_7,
		}



		protected Dictionary<PinName, VoltageLevel> outputTable = new Dictionary<PinName, VoltageLevel>();

		/// <summary>
		/// 出力状態をセットする
		/// </summary>
		/// <param name="pinName"></param>
		/// <returns></returns>
		public VoltageLevel this[PinName pinName]
		{
			set
			{
				this.SetLevel(pinName, value);
			}
		}



		/// <summary>
		/// 各ポートの出力値をセットする。
		/// </summary>
		/// <param name="argTable"></param>
		public void SetLevel(Dictionary<PinName, VoltageLevel> argTable)
		{
			// 指定値を変数に代入
			foreach (var key_pair in argTable)
			{
				this.outputTable[key_pair.Key] = key_pair.Value;
			}


			byte data_P0 = this.getOutputValue_p0();
			byte data_P1 = this.getOutputValue_p1();

			Console.WriteLine(string.Format("PCAL9555A 出力値セット：P0 = {0}, P1 = {1}", data_P0, data_P1));

			// P0_0～P0_7とP1_0～P1_7をまとめてセット
			this.write(new List<byte>()
			{
				(byte)Command.OutputPort_0,	// 送信するコマンド
				data_P0,					// 送信するデータ（P0_0～P0_7）
				data_P1,					// 送信するデータ（P1_0～P1_7）
			});
		}

		protected byte getOutputValue_p0()
		{
			byte outputValue_0 = 0;
			outputValue_0 |= (this.outputTable[PinName.P0_0] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00000001;     // P0_0
			outputValue_0 |= (this.outputTable[PinName.P0_1] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00000010;     // P0_1
			outputValue_0 |= (this.outputTable[PinName.P0_2] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00000100;     // P0_2
			outputValue_0 |= (this.outputTable[PinName.P0_3] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00001000;     // P0_3
			outputValue_0 |= (this.outputTable[PinName.P0_4] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00010000;     // P0_4
			outputValue_0 |= (this.outputTable[PinName.P0_5] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00100000;     // P0_5
			outputValue_0 |= (this.outputTable[PinName.P0_6] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b01000000;     // P0_6
			outputValue_0 |= (this.outputTable[PinName.P0_7] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b10000000;    // P0_7
			return outputValue_0;
		}

		protected byte getOutputValue_p1()
		{
			byte outputValue_1 = 0;
			outputValue_1 |= (this.outputTable[PinName.P1_0] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00000001;     // P1_0
			outputValue_1 |= (this.outputTable[PinName.P1_1] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00000010;     // P1_1
			outputValue_1 |= (this.outputTable[PinName.P1_2] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00000100;     // P1_2
			outputValue_1 |= (this.outputTable[PinName.P1_3] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00001000;     // P1_3
			outputValue_1 |= (this.outputTable[PinName.P1_4] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00010000;     // P1_4
			outputValue_1 |= (this.outputTable[PinName.P1_5] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b00100000;    // P1_5
			outputValue_1 |= (this.outputTable[PinName.P1_6] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b01000000;    // P1_6
			outputValue_1 |= (this.outputTable[PinName.P1_7] == VoltageLevel.LOW) ? (byte)0 : (byte)Bin.b10000000;    // P1_7
			return outputValue_1;
		}

		/// <summary>
		/// 出力方向をセットする（未対応機能）
		/// </summary>
		/// <param name="pinName"></param>
		/// <param name="direction"></param>
		public void SetDirection(PinName p, bool b)
		{
			byte directionP0, directionP1;


			// 未対応機能→すべて出力ピンとする
			//Console.WriteLine(string.Format("PCAL9555A 出力方向：{0}を{1}に", Enum.GetName(typeof(PinName),pinName), direction));

			this.write(new List<byte>()
			{
				(byte)Command.ConfigurationPort_0,
				0,	// 出力
			});

			this.write(new List<byte>()
			{
				(byte)Command.ConfigurationPort_1,
				0,	// 出力
			});

		}

		public void SetLevel(PinName pinName, VoltageLevel level)
		{
			this.outputTable[pinName] = level;

			switch (pinName)
			{
				case PinName.P0_0:
				case PinName.P0_1:
				case PinName.P0_2:
				case PinName.P0_3:
				case PinName.P0_4:
				case PinName.P0_5:
				case PinName.P0_6:
				case PinName.P0_7:

					byte data_p0 = this.getOutputValue_p0();
					Console.WriteLine(string.Format("PCAL9555A 出力値セット：P0 = {0}", data_p0));

					this.write(new List<byte>()
						{
							(byte)Command.OutputPort_0,	// 送信するコマンド
							data_p0,	// 送信するデータ（P0_0～P0_7）
						});

					break;

				case PinName.P1_0:
				case PinName.P1_1:
				case PinName.P1_2:
				case PinName.P1_3:
				case PinName.P1_4:
				case PinName.P1_5:
				case PinName.P1_6:
				case PinName.P1_7:

					byte data_p1 = this.getOutputValue_p1();
					Console.WriteLine(string.Format("PCAL9555A 出力値セット：P1 = {0}", data_p1));

					this.write(new List<byte>()
						{
							(byte)Command.OutputPort_1,	// 送信するコマンド
							data_p1,	// 送信するデータ（P0_0～P0_7）
						});
					break;
			}
		}

		public Dictionary<PinName, VoltageLevel> ReadLevel(Command command)
		{
			// 入力するポートを指定（P0_* or P1_*）
			this.write(new List<byte>() { (byte)command });

			// PCAL9555Aからデータを読む（非同期処理）
			byte recvData = this.i2c.read(this.deviceAddress);

			// 受信したデータから戻り値の変数にセット
			Dictionary<PinName, VoltageLevel> retCollection = new Dictionary<PinName, VoltageLevel>();
			switch(command)
			{
				case Command.InputPort_0:
					retCollection[PinName.P0_7] = ((recvData & (byte)Bin.b00000001) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P0_6] = ((recvData & (byte)Bin.b00000010) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P0_5] = ((recvData & (byte)Bin.b00000100) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P0_4] = ((recvData & (byte)Bin.b00001000) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P0_3] = ((recvData & (byte)Bin.b00010000) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P0_2] = ((recvData & (byte)Bin.b00100000) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P0_1] = ((recvData & (byte)Bin.b01000000) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P0_0] = ((recvData & (byte)Bin.b10000000) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);

					break;

				case Command.InputPort_1:
					retCollection[PinName.P1_7] = ((recvData & (byte)Bin.b00000001) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P1_6] = ((recvData & (byte)Bin.b00000010) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P1_5] = ((recvData & (byte)Bin.b00000100) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P1_4] = ((recvData & (byte)Bin.b00001000) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P1_3] = ((recvData & (byte)Bin.b00010000) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P1_2] = ((recvData & (byte)Bin.b00100000) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P1_1] = ((recvData & (byte)Bin.b01000000) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
					retCollection[PinName.P1_0] = ((recvData & (byte)Bin.b10000000) > 0 ? VoltageLevel.HIGH : VoltageLevel.LOW);
	
					break;
			}

			return retCollection;
		}
	}
}