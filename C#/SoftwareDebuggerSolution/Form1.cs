using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using VirtualComponent.Arduino;
using VirtualComponent.IC;
using VirtualComponent;

namespace SoftwareDebuggerSolution
{
	public partial class Form1 : Form
	{
		VirtualArduino arduino;

		public MAX335 max335;
		public AD5206 ad5206;
		public PCAL9555A pcal9555a;

		public Form1()
		{
			InitializeComponent();
			this.comboBox1.Items.AddRange(SerialPort.GetPortNames());
		}


		private void button1_Click(object sender, EventArgs e)
		{
			max335 = new MAX335(this.arduino.spi, pcal9555a, PCAL9555A.PinName.P1_0);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			pcal9555a.SetLevel(PCAL9555A.PinName.P0_0, VoltageLevel.HIGH);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ad5206 = new AD5206(this.arduino.spi, pcal9555a, PCAL9555A.PinName.P0_7);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ad5206[AD5206.PinName.BW1] = 0x80;
		}


		private void button6_Click(object sender, EventArgs e)
		{
			pcal9555a = new PCAL9555A(this.arduino.i2c, 0x20);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			max335[MAX335.PinName.COM2] = SwitchState.OPEN;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			max335[MAX335.PinName.COM2] = SwitchState.CLOSE;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			ad5206[AD5206.PinName.BW1] = 0x00;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			ad5206[AD5206.PinName.BW1] = 0xFF;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.arduino = new VirtualArduino(this.comboBox1.Text);
		}

		private void button11_Click(object sender, EventArgs e)
		{
			pcal9555a.SetLevel(PCAL9555A.PinName.P0_0, VoltageLevel.LOW);
		}

		private void button12_Click(object sender, EventArgs e)
		{
			var k = pcal9555a.ReadLevel(PCAL9555A.Command.InputPort_1);
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
