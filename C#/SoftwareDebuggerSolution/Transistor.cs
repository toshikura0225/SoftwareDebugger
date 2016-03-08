using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class Transistor
	{
		
		/// <summary>
		/// トランジスタ出力ピン
		/// </summary>
		public enum PinType
		{
			pinT1,
			pinT2,
			pinT3,
			pinT4,
			pinT5,
			pinT6,
			pinT7,
			pinT8,
			pinT9,
			pinT10,
			pinT11,
			pinT12,
			pinT13,
			pinT14,
			pinT15,
			pinT16,
		}

		private List<VirtualTransistorIC> transistorICList = new List<VirtualTransistorIC>();
		/// <summary>
		/// トランジスタ出力値をセットする
		/// </summary>
		/// <param name="pinType">ピン</param>
		/// <param name="level">High：1  Low：0</param>
		public void SetLevel(PinType pinType, bool level)
		{
			
		}
		
	}
}
