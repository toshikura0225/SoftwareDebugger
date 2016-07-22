using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualComponent
{
	/// <summary>
	/// GPIOのインターフェース
	/// </summary>
	/// <typeparam name="TPinName"></typeparam>
	public interface IGPIO<TPinName>
	{
		/// <summary>
		/// 出力テーブル
		/// </summary>
		/// <param name="pinName"></param>
		/// <returns></returns>
		VoltageLevel this[TPinName pinName] { set; }
		
		/// <summary>
		/// 出力方向を設定する
		/// </summary>
		/// <param name="pinName"></param>
		/// <param name="direction"></param>
		void SetDirection(TPinName pinName, bool direction);

		/// <summary>
		/// 一つの出力を設定する
		/// </summary>
		/// <param name="pinName"></param>
		/// <param name="level"></param>
		void SetLevel(TPinName pinName, VoltageLevel level);
	}
}