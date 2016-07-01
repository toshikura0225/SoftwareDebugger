using SharedLibrary.SerialPort.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	/// <summary>
	/// SPI通信機能を処理する
	/// </summary>
	/// <typeparam name="TLatchPinName"></typeparam>
	public class LatchingSPI<TLatchPinName>
	{
		protected ISPI spi { get; set; }

		protected IDigitalOutput<TLatchPinName> digitalOutput { get; set; }
		
		public LatchingSPI(ISPI spi, IDigitalOutput<TLatchPinName> digitalouput)
		{
			this.spi = spi;

			this.digitalOutput = digitalOutput;

			this.spi.begin();
			this.digitalOutput.SetDirection(true);
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
			this.digitalOutput.SetLevel(false);

			// データ転送
			this.spi.transfer(dataList);

			// スレーブに適用
			this.digitalOutput.SetLevel(true);
		}

		/// <summary>
		/// データを送信する
		/// </summary>
		/// <param name="data"></param>
		protected void Transfer(byte data)
		{
			// スレーブ選択
			this.digitalOutput.SetLevel(false);

			// データ転送
			this.spi.transfer(new List<byte>() { data });

			// スレーブに適用
			this.digitalOutput.SetLevel(true);
		}
	}


}