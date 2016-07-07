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
		enum Command
		{
			OutputPort_0 = 0x02,
			OutputPort_1,
			ConfigurationPort_0 = 0x06,
			ConfigurationPort_1,
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="i2c">I2Cオブジェクト</param>
		/// <param name="address">I2Cスレーブのデバイスアドレス</param>
		public PCAL9555A(II2C i2c, byte address) : base(i2c, address)
		{
			// 入出力ポートをすべて出力に設定

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

			// デフォルト値としてLOWをセット
			foreach (PinName P in Enum.GetValues(typeof(PinName)))
			{
				outputTable[P] = VoltageLevel.LOW;
			}
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

			// P0_0～P0_7とP1_0～P1_7をまとめてセット
			this.write(new List<byte>()
			{
				(byte)Command.OutputPort_0,	// 送信するコマンド
				this.getOutputValue_p0(),	// 送信するデータ（P0_0～P0_7）
				this.getOutputValue_p1(),	// 送信するデータ（P1_0～P1_7）
			});
		}

		protected byte getOutputValue_p0()
		{
			byte outputValue_0 = 0;
			outputValue_0 |= (this.outputTable[PinName.P0_0] == VoltageLevel.LOW) ? (byte)0 : (byte)1;      // P0_0
			outputValue_0 |= (this.outputTable[PinName.P0_1] == VoltageLevel.LOW) ? (byte)0 : (byte)2;      // P0_1
			outputValue_0 |= (this.outputTable[PinName.P0_2] == VoltageLevel.LOW) ? (byte)0 : (byte)4;      // P0_2
			outputValue_0 |= (this.outputTable[PinName.P0_3] == VoltageLevel.LOW) ? (byte)0 : (byte)8;      // P0_3
			outputValue_0 |= (this.outputTable[PinName.P0_4] == VoltageLevel.LOW) ? (byte)0 : (byte)16;     // P0_4
			outputValue_0 |= (this.outputTable[PinName.P0_5] == VoltageLevel.LOW) ? (byte)0 : (byte)32;     // P0_5
			outputValue_0 |= (this.outputTable[PinName.P0_6] == VoltageLevel.LOW) ? (byte)0 : (byte)64;     // P0_6
			outputValue_0 |= (this.outputTable[PinName.P0_7] == VoltageLevel.LOW) ? (byte)0 : (byte)128;    // P0_7
			return outputValue_0;
		}

		protected byte getOutputValue_p1()
		{
			byte outputValue_1 = 0;
			outputValue_1 |= (this.outputTable[PinName.P1_0] == VoltageLevel.LOW) ? (byte)0 : (byte)1;      // P1_0
			outputValue_1 |= (this.outputTable[PinName.P1_1] == VoltageLevel.LOW) ? (byte)0 : (byte)2;      // P1_1
			outputValue_1 |= (this.outputTable[PinName.P1_2] == VoltageLevel.LOW) ? (byte)0 : (byte)4;      // P1_2
			outputValue_1 |= (this.outputTable[PinName.P1_3] == VoltageLevel.LOW) ? (byte)0 : (byte)8;      // P1_3
			outputValue_1 |= (this.outputTable[PinName.P1_4] == VoltageLevel.LOW) ? (byte)0 : (byte)16;     // P1_4
			outputValue_1 |= (this.outputTable[PinName.P1_5] == VoltageLevel.LOW) ? (byte)0 : (byte)32;     // P1_5
			outputValue_1 |= (this.outputTable[PinName.P1_6] == VoltageLevel.LOW) ? (byte)0 : (byte)64;     // P1_6
			outputValue_1 |= (this.outputTable[PinName.P1_7] == VoltageLevel.LOW) ? (byte)0 : (byte)128;    // P1_7
			return outputValue_1;
		}

		/// <summary>
		/// 出力方向をセットする（未対応機能）
		/// </summary>
		/// <param name="pinName"></param>
		/// <param name="direction"></param>
		public void SetDirection(PinName pinName, bool direction)
		{
			// 未対応機能→すべて出力ピンとする

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
					this.write(new List<byte>()
						{
							(byte)Command.OutputPort_0,	// 送信するコマンド
							this.getOutputValue_p0(),	// 送信するデータ（P0_0～P0_7）
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
					this.write(new List<byte>()
						{
							(byte)Command.OutputPort_1,	// 送信するコマンド
							this.getOutputValue_p1(),	// 送信するデータ（P0_0～P0_7）
						});
					break;
			}
		}
	}
}