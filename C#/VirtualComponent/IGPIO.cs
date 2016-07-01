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
		void SetDirection(TPinName pinName, bool direction);
		void SetLevel(TPinName pinName, bool level);
	}
}