using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualComponent;
using VirtualComponent.Arduino;
using VirtualComponent.IC;


namespace Blink
{
	public partial class Form1 : Form
	{
		const int stepInterval = 500;

		VirtualArduino arduino;
		PCAL9555A pcal9555a;
		MAX335 max335;
		AD5206 ad5206;

		public Form1()
		{
			InitializeComponent();
			this.comboBox1.Items.AddRange(SerialPort.GetPortNames());
			if(this.comboBox1.Items.Count > 0)	this.comboBox1.SelectedIndex = 0;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// 各オブジェクトを初期化する
			this.initGlobalObject();

			// MAX335の確認：各ピン毎にOPEN-CLSEを二回ずつ繰り返す
			var max335Task = Task.Run(() =>
			{
				Console.WriteLine("MAX335の確認開始");
				Action<MAX335.PinName> oneCycle = (pin) =>
				{
					max335[pin] = SwitchState.OPEN;
					Thread.Sleep(stepInterval);
					max335[pin] = SwitchState.CLOSE;
					Thread.Sleep(stepInterval);

					max335[pin] = SwitchState.OPEN;
					Thread.Sleep(stepInterval);
					max335[pin] = SwitchState.CLOSE;
					Thread.Sleep(stepInterval);
				};

				foreach (MAX335.PinName pin in Enum.GetValues(typeof(MAX335.PinName)))
				{
					Console.WriteLine(string.Format("MAX335[{0}]", Enum.GetName(typeof(MAX335.PinName), pin)));
					oneCycle(pin);
				}
			});

			// AD5206の確認（各ピン毎に0kΩ→5kΩ→10kΩを２回ずつ繰り返す）
			var ad5206Task = max335Task.ContinueWith((t) =>
			{
				Action<AD5206.PinName> oneCycle = (pin) =>
				{
					ad5206[pin] = 0x00;
					Thread.Sleep(stepInterval);
					ad5206[pin] = 0x80;
					Thread.Sleep(stepInterval);
					ad5206[pin] = 0xFF;
					Thread.Sleep(stepInterval);

					ad5206[pin] = 0x00;
					Thread.Sleep(stepInterval);
					ad5206[pin] = 0x80;
					Thread.Sleep(stepInterval);
					ad5206[pin] = 0xFF;
					Thread.Sleep(stepInterval);
				};

				foreach (AD5206.PinName pin in Enum.GetValues(typeof(AD5206.PinName)))
				{
					Console.WriteLine(string.Format("AD5206[{0}]", Enum.GetName(typeof(AD5206.PinName), pin)));
					oneCycle(pin);
				}
			});

			ad5206Task.Wait();

			Console.WriteLine("done");
		}

		/// <summary>
		/// 各オブジェクトを初期化する
		/// </summary>
		private void initGlobalObject()
		{
			this.arduino = new VirtualArduino(this.comboBox1.Text);
			this.pcal9555a = new PCAL9555A(this.arduino.i2c, 0x20);
			this.max335 = new MAX335(this.arduino.spi, pcal9555a, PCAL9555A.PinName.P1_0);
			this.ad5206 = new AD5206(this.arduino.spi, pcal9555a, PCAL9555A.PinName.P0_7);
		}
	}

	public class MAX335 : MAX335<PCAL9555A.PinName>
	{
		public MAX335(ISPI spi, IGPIO<PCAL9555A.PinName> digitalouput, PCAL9555A.PinName latchPinName) : base(spi, digitalouput, latchPinName) { }
	}

	public class AD5206 : AD5206<PCAL9555A.PinName>
	{
		public AD5206(ISPI spi, IGPIO<PCAL9555A.PinName> digitalouput, PCAL9555A.PinName latchPinName) : base(spi, digitalouput, latchPinName) { }
	}
}
