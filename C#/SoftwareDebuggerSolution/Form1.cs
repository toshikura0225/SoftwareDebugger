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
			max335 = new MAX335(this.arduino.spi, this.arduino.io, VirtualArduino.PinName.pin7);
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			max335.SetSwitch(new Dictionary<MAX335.PinName, SwitchState>()
			{
				{ MAX335.PinName.COM4, SwitchState.CLOSE }
			});
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ad5206 = new AD5206(this.arduino.spi, this.arduino.io, VirtualArduino.PinName.pin8);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ad5206.SetRegister(new Dictionary<AD5206<VirtualArduino.PinName>.PinName, byte>()
			{
				{  AD5206.PinName.BW4, 0x30 }
			});
		}


		private void button6_Click(object sender, EventArgs e)
		{
			pcal9555a = new PCAL9555A(this.arduino.i2c, 0x20);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			pcal9555a.SetLevel(new Dictionary<PCAL9555A.PinName, VoltageLevel>()
			{
				{PCAL9555A.PinName.P0_7, VoltageLevel.HIGH},
				{PCAL9555A.PinName.P1_1, VoltageLevel.HIGH},
			});
		}

		private void button8_Click(object sender, EventArgs e)
		{
			max335[MAX335.PinName.COM4] = SwitchState.OPEN;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			ad5206[AD5206.PinName.BW4] = 0xF0;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			pcal9555a[PCAL9555A.PinName.P1_0] = VoltageLevel.HIGH;
		}

		private void COM_Click(object sender, EventArgs e)
		{
			this.arduino = new VirtualArduino(this.comboBox1.Text);
		}

	}


	public class MAX335 : MAX335<VirtualArduino.PinName>
	{
		public MAX335(ISPI spi, IGPIO<VirtualArduino.PinName> digitalouput, VirtualArduino.PinName latchPinName) : base(spi, digitalouput, latchPinName) { }
	}

	public class AD5206 : AD5206<VirtualArduino.PinName>
	{
		public AD5206(ISPI spi, IGPIO<VirtualArduino.PinName> digitalouput, VirtualArduino.PinName latchPinName) : base(spi, digitalouput, latchPinName) { }
	}
}
