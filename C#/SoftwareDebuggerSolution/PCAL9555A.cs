using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualComponent.IC
{
	/// <summary>
	/// GPIOモジュール「PCAL9555A」の機能を処理する。入出力機能はすべて出力。
	/// </summary>
	public class PCAL9555A : AddressingI2C
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
				(byte)Command.OutputPort_0,
				0,	// 出力
			});

			this.write(new List<byte>()
			{
				(byte)Command.OutputPort_1,
				0,	// 出力
			});

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

		/// <summary>
		/// 各ポートの出力値をセットする。（デフォルトは0V出力）
		/// </summary>
		/// <param name="outputTable"></param>
		public void SetLevel(Dictionary<PinName, bool> outputTable)
		{
			// デフォルト値をセット
			foreach (PinName COM in Enum.GetValues(typeof(PinName)))
			{
				if (outputTable.ContainsKey(COM) == false)
				{
					outputTable[COM] = false;
				}
			}

			// 送信するデータ（P0_0～P0_7）
			byte outputValue_0 = 0;   
			outputValue_0 |= (!outputTable[PinName.P0_0]) ? (byte)0 : (byte)1;      // P0_0
			outputValue_0 |= (!outputTable[PinName.P0_1]) ? (byte)0 : (byte)2;      // P0_1
			outputValue_0 |= (!outputTable[PinName.P0_2]) ? (byte)0 : (byte)4;      // P0_2
			outputValue_0 |= (!outputTable[PinName.P0_3]) ? (byte)0 : (byte)8;      // P0_3
			outputValue_0 |= (!outputTable[PinName.P0_4]) ? (byte)0 : (byte)16;     // P0_4
			outputValue_0 |= (!outputTable[PinName.P0_5]) ? (byte)0 : (byte)32;     // P0_5
			outputValue_0 |= (!outputTable[PinName.P0_6]) ? (byte)0 : (byte)64;     // P0_6
			outputValue_0 |= (!outputTable[PinName.P0_7]) ? (byte)0 : (byte)128;    // P0_7

			// 送信するデータ（P1_0～P1_7）
			byte outputValue_1 = 0;   
			outputValue_1 |= (!outputTable[PinName.P1_0]) ? (byte)0 : (byte)1;      // P1_0
			outputValue_1 |= (!outputTable[PinName.P1_1]) ? (byte)0 : (byte)2;      // P1_1
			outputValue_1 |= (!outputTable[PinName.P1_2]) ? (byte)0 : (byte)4;      // P1_2
			outputValue_1 |= (!outputTable[PinName.P1_3]) ? (byte)0 : (byte)8;      // P1_3
			outputValue_1 |= (!outputTable[PinName.P1_4]) ? (byte)0 : (byte)16;     // P1_4
			outputValue_1 |= (!outputTable[PinName.P1_5]) ? (byte)0 : (byte)32;     // P1_5
			outputValue_1 |= (!outputTable[PinName.P1_6]) ? (byte)0 : (byte)64;     // P1_6
			outputValue_1 |= (!outputTable[PinName.P1_7]) ? (byte)0 : (byte)128;    // P1_7

			// P0_0～P0_7とP1_0～P1_7をまとめてセット
			this.write(new List<byte>()
			{
				(byte)Command.OutputPort_0,
				outputValue_0,
				outputValue_1,
			});
		}
	}
}