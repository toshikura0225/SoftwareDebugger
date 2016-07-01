using SharedLibrary.SerialPort.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualComponent.IC
{
	/// <summary>
	/// デジタルポテンショメータIC「AD5206」の機能を実装する
	/// </summary>
	/// <typeparam name="TLatchPinName"></typeparam>
	public class AD5206<TLatchPinName> : LatchingSPI<TLatchPinName>
	{
		public AD5206(ISPI spi, IGPIO<TLatchPinName> digitalouput, TLatchPinName latchPinName) : base(spi, digitalouput, latchPinName)
		{
			// コンストラクタ

			// デフォルト値として128をセット
			//foreach (PinName AW in Enum.GetValues(typeof(PinName)))
			//{
			//	adTable[AW] = 128;
			//}
		}

		public enum PinName
		{
			AW1 = 0,
			AW2,
			AW3,
			AW4,
			AW5,
			AW6,
		}


		//protected Dictionary<PinName, byte> adTable = new Dictionary<PinName, byte>();

		/// <summary>
		/// スイッチ状態をセットする
		/// </summary>
		/// <param name="pinName"></param>
		/// <returns></returns>
		public byte this[PinName pinName]
		{
			set
			{
				//this.adTable[pinName] = value;
				this.Transfer(new List<byte>() { (byte)pinName, value });
			}
		}

		/// <summary>
		/// AD値をセットする
		/// </summary>
		/// <param name="pin"></param>
		/// <param name="adValue"></param>
		public void SetRegister(Dictionary<AD5206<TLatchPinName>.PinName, byte> argTable)
		{
			// 変数に保持
			//foreach (var key_pair in argTable)
			//{
			//	this.adTable[key_pair.Key] = key_pair.Value;
			//}

			// スレーブ選択
			this.digitalOutput.SetLevel(this.latchPinName, false);

			// 送信
			this.spi.transfer(argTable.Select(s => s.Value).ToList());

			// スレーブに適用
			this.digitalOutput.SetLevel(this.latchPinName, true);

		}

	}


}