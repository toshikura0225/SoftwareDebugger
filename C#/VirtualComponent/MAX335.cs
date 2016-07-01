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
		public MAX335(ISPI spi, IGPIO<TLatchPinName> digitalouput, TLatchPinName latchPinName) : base(spi, digitalouput, latchPinName)
		{
			// コンストラクタ

			// スイッチ状態のデフォルト値をセット
			foreach (PinName COM in Enum.GetValues(typeof(PinName)))
			{
				switchTable[COM] = SwitchState.OPEN;
			}
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


		protected Dictionary<PinName, SwitchState> switchTable = new Dictionary<PinName, SwitchState>();

		/// <summary>
		/// スイッチ状態をセットする
		/// </summary>
		/// <param name="pinName"></param>
		/// <returns></returns>
		public SwitchState this[PinName pinName]
		{
			set
			{
				this.switchTable[pinName] = value;
				this.Transfer(this.getOutputValue());
			}
		}
		
				
		/// <summary>
		/// MAX335の各ポートのスイッチをセットする
		/// </summary>
		/// <param name="argTable">各ポートのスイッチ状態</param>
		public void SetSwitch(Dictionary<PinName, SwitchState> argTable)
		{
			// 指定値を変数に代入
			foreach(var key_pair in argTable)
			{
				this.switchTable[key_pair.Key] = key_pair.Value;
			}

			// 代入された変数の設定値を適用
			this.Transfer(this.getOutputValue());
		}

		protected byte getOutputValue()
		{
			// 送信するデータ
			byte outputValue = 0;

			outputValue |= (this.switchTable[PinName.COM0] == SwitchState.OPEN) ? (byte)0 : (byte)1;      // COM0
			outputValue |= (this.switchTable[PinName.COM1] == SwitchState.OPEN) ? (byte)0 : (byte)2;      // COM1
			outputValue |= (this.switchTable[PinName.COM2] == SwitchState.OPEN) ? (byte)0 : (byte)4;      // COM2
			outputValue |= (this.switchTable[PinName.COM3] == SwitchState.OPEN) ? (byte)0 : (byte)8;      // COM3
			outputValue |= (this.switchTable[PinName.COM4] == SwitchState.OPEN) ? (byte)0 : (byte)16;     // COM4
			outputValue |= (this.switchTable[PinName.COM5] == SwitchState.OPEN) ? (byte)0 : (byte)32;     // COM5
			outputValue |= (this.switchTable[PinName.COM6] == SwitchState.OPEN) ? (byte)0 : (byte)64;     // COM6
			outputValue |= (this.switchTable[PinName.COM7] == SwitchState.OPEN) ? (byte)0 : (byte)128;    // COM7

			return outputValue;
		}

	}
}