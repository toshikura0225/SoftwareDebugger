using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualComponent
{
	/// <summary>
	/// I2C通信の機能を処理する
	/// </summary>
	public class AddressingI2C
	{
		protected II2C i2c;
		protected byte deviceAddress;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="i2c">I2Cのオブジェクト</param>
		/// <param name="address">スレーブのデバイスアドレス</param>
		public AddressingI2C(II2C i2c, byte address)
		{
			this.deviceAddress = address;
			this.i2c = i2c;
			this.i2c.begin();

			// 入出力ポートを出力にセット
		}

		protected void write(List<byte> dataList)
		{
			this.i2c.beginTransmission(this.deviceAddress);
			this.i2c.write(dataList);
			this.i2c.endTransmission();
		}
	}
}