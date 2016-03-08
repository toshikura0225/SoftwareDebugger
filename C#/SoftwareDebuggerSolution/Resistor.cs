using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public class Resistor
	{
		
		/// <summary>
		/// デジタルポテンショメータピン
		/// </summary>
		public enum ResistorPinType
		{
			pinR1,
			pinR2,
			pinR3,
			pinR4,
			pinR5,
			pinR6,
			pinR7,
			pinR8,
			pinR9,
			pinR10,
			pinR11,
			pinR12,
		}

		private List<VirtualResistorIC> registorICList = new List<VirtualResistorIC>();

		public Resistor()
		{
			registorICList.Add(new VirtualResistorIC(Arduino.PinType.pin10));
			registorICList.Add(new VirtualResistorIC(Arduino.PinType.pin8));
		}

		/// <summary>
		/// 抵抗値をセットする
		/// </summary>
		/// <param name="pinType">ピン</param>
		/// <param name="outputValue">出力値（０～２５５）</param>
		public void SetResistor(ResistorPinType pinType, byte outputValue)
		{
			
		}
		


	}
}
