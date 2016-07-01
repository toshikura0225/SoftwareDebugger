using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace VirtualComponent.IC
{
	/// <summary>
	/// スイッチIC「MAX335」の機能を処理する
	/// </summary>
	/// <typeparam name="TLatchPinName"></typeparam>
	public class MAX335<TLatchPinName> : LatchingSPI<TLatchPinName>
	{
		public MAX335(ISPI spi, IDigitalOutput<TLatchPinName> digitalouput) : base(spi, digitalouput)
		{
			// コンストラクタ
		}

		public enum PinName
		{
			COM0,
			COM1,
			COM2,
			COM3,
			COM4,
			COM5,
			COM6,
			COM7,
		}

		public enum SwitchType
		{
			OPEN,
			CLOSE,
		}

		/// <summary>
		/// MAX335の各ポートのスイッチをセットする
		/// </summary>
		/// <param name="outputTable">各ポートのスイッチ状態（デフォルトはOPEN）</param>
		public void SetSwitch(Dictionary<MAX335<TLatchPinName>.PinName, SwitchType> outputTable)
		{
			// デフォルト値をセット
			foreach (PinName COM in Enum.GetValues(typeof(PinName)))
			{
				if (outputTable.ContainsKey(COM) == false)
				{
					outputTable[COM] = SwitchType.OPEN;
				}
			}

			// 送信するデータ
			byte outputValue = 0;

			outputValue |= (outputTable[PinName.COM0] == SwitchType.OPEN) ? (byte)0 : (byte)1;		// COM0
			outputValue |= (outputTable[PinName.COM1] == SwitchType.OPEN) ? (byte)0 : (byte)2;		// COM1
			outputValue |= (outputTable[PinName.COM2] == SwitchType.OPEN) ? (byte)0 : (byte)4;		// COM2
			outputValue |= (outputTable[PinName.COM3] == SwitchType.OPEN) ? (byte)0 : (byte)8;		// COM3
			outputValue |= (outputTable[PinName.COM4] == SwitchType.OPEN) ? (byte)0 : (byte)16;		// COM4
			outputValue |= (outputTable[PinName.COM5] == SwitchType.OPEN) ? (byte)0 : (byte)32;		// COM5
			outputValue |= (outputTable[PinName.COM6] == SwitchType.OPEN) ? (byte)0 : (byte)64;		// COM6
			outputValue |= (outputTable[PinName.COM7] == SwitchType.OPEN) ? (byte)0 : (byte)128;	// COM7

			// SPI通信で転送
			this.Transfer(outputValue);
		}
	}
}