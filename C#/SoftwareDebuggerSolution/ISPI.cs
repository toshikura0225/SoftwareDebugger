using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	/// <summary>
	/// SPI通信のインターフェース
	/// </summary>
	public interface ISPI
	{
		/// <summary>
		/// SPIバスを初期化します。SCK、MOSI、SSの各ピンは出力に設定され、SCKとMOSIはlowに、SSはhighとなります。
		/// </summary>
		void begin();
		/// <summary>
		/// SPIバスを通じて1バイトを転送します。
		/// </summary>
		void transfer(List<byte> dataList);
		/// <summary>
		/// SPIバスを無効にします。各ピンの設定は変更されません。
		/// </summary>
		void end();
	}
	
}