using SharedLibrary.SerialPort.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualComponent
{
	/// <summary>
	/// SPI通信機能を処理する
	/// </summary>
	/// <typeparam name="TLatchPinName"></typeparam>
	public class LatchingSPI<TLatchPinName>
	{
		protected ISPI spi { get; set; }

		protected IGPIO<TLatchPinName> digitalOutput { get; set; }

		protected TLatchPinName latchPinName;

		public LatchingSPI(ISPI spi, IGPIO<TLatchPinName> digitalOutput, TLatchPinName latchPinName)
		{
			this.spi = spi;
			this.digitalOutput = digitalOutput;
			this.latchPinName = latchPinName;

			this.spi.begin();
			this.digitalOutput.SetDirection(this.latchPinName, true);
		}

		/// <summary>
		/// デストラクタ。SPI通信接続を切断する。
		/// </summary>
		~LatchingSPI()
		{
			this.spi.end();
		}

		/// <summary>
		/// 複数のデータをまとめて送信する
		/// </summary>
		/// <param name="dataList"></param>
		protected void Transfer(List<byte> dataList)
		{
			// スレーブ選択
			this.digitalOutput.SetLevel(this.latchPinName, VoltageLevel.LOW);

			// データ転送
			this.spi.transfer(dataList);

			// スレーブに適用
			this.digitalOutput.SetLevel(this.latchPinName, VoltageLevel.HIGH);
		}

		/// <summary>
		/// データを送信する
		/// </summary>
		/// <param name="data"></param>
		protected void Transfer(byte data)
		{
			// スレーブ選択
			this.digitalOutput.SetLevel(this.latchPinName, VoltageLevel.LOW);

			// データ転送
			this.spi.transfer(new List<byte>() { data });

			// スレーブに適用
			this.digitalOutput.SetLevel(this.latchPinName, VoltageLevel.HIGH);
		}
	}


}