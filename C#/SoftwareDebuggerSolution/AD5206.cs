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
		public AD5206(ISPI spi, IDigitalOutput<TLatchPinName> digitalouput) : base(spi, digitalouput)
		{
			// コンストラクタ
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

		/// <summary>
		/// AD値をセットする
		/// </summary>
		/// <param name="pin"></param>
		/// <param name="adValue"></param>
		public void SetRegister(AD5206<TLatchPinName>.PinName pin, byte outputValue)
		{
			// データ転送
			this.Transfer(new List<byte>() { (byte)pin, outputValue });
		}

	}


}