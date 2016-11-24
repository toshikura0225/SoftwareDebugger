using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualComponent.Arduino;
using VirtualComponent.IC;


namespace Blink
{
	public partial class Form1 : Form
	{
		VirtualArduino arduino;
		PCAL9555A pcal9555a;
		MAX335<PCAL9555A.PinName> max335;
		AD5206<PCAL9555A.PinName> ad5206;

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
		}

		/// <summary>
		/// 各オブジェクトを初期化する
		/// </summary>
		private void initGlobalObject()
		{
			this.arduino = new VirtualArduino(this.comboBox1.Text);
			this.pcal9555a = new PCAL9555A(this.arduino.i2c, 0x20);
			this.max335 = new MAX335<PCAL9555A.PinName>(this.arduino.spi, pcal9555a, PCAL9555A.PinName.P1_0);
			this.ad5206 = new AD5206<PCAL9555A.PinName>(this.arduino.spi, pcal9555a, PCAL9555A.PinName.P0_7);
		}
	}
}
