using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public interface II2C
	{
		/// <summary>
		/// Wireライブラリを初期化し、I2Cバスにマスタとして接続します
		/// </summary>
		void begin();
		/// <summary>
		/// 指定したアドレスのI2Cスレーブに対して送信処理を始めます。この関数の実行後、write()でデータをキューへ送り、endTransmission()で送信を実行します。
		/// </summary>
		void beginTransmission(byte i2cAddress);
		/// <summary>
		/// マスタがスレーブに送信するデータをキューに入れるときに使用します
		/// </summary>
		void write(List<byte> data);
		/// <summary>
		/// スレーブデバイスに対する送信を完了します。
		/// </summary>
		/// <returns>
		/// true：成功 false：失敗
		/// </returns>
		bool endTransmission();
	}
}