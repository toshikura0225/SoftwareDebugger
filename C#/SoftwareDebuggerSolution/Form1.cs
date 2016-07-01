using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SoftwareDebuggerSolution
{
	public partial class Form1 : Form
	{
		VirtualArduino arduino = new VirtualArduino();

		public MAX335 max335;
		public AD5206 ad5206;
		public PCAL9555A pcal9555a;

		public Form1()
		{
			InitializeComponent();
			this.comboBox1.Items.AddRange(SerialPort.GetPortNames());


			max335 = new MAX335(this.arduino.spi, this.arduino.io);
			max335.SetSwitch(new Dictionary<MAX335.PinName, MAX335.SwitchType>() { });

			ad5206 = new AD5206(this.arduino.spi, this.arduino.io);
			ad5206.SetRegister(AD5206.PinName.AW1, 125);

			pcal9555a = new PCAL9555A(this.arduino.i2c, 0x41);
			pcal9555a.SetLevel(new Dictionary<PCAL9555A.PinName, bool> () { });

		}


		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{

		}


		private void button6_Click(object sender, EventArgs e)
		{

		}

		private void button7_Click(object sender, EventArgs e)
		{

		}

		private void button8_Click(object sender, EventArgs e)
		{

		}

		private void button9_Click(object sender, EventArgs e)
		{

		}

		private void COM_Click(object sender, EventArgs e)
		{
			VirtualArduino.ModbusSerial.PortName = this.comboBox1.Text;
			VirtualArduino.ModbusSerial.Open();
		}


	}

	public class MAX335 : MAX335<VirtualArduino.PinName>
	{
		public MAX335(ISPI spi, IDigitalOutput<VirtualArduino.PinName> digitalouput) : base(spi, digitalouput) { }
	}

	public class AD5206 : AD5206<VirtualArduino.PinName>
	{
		public AD5206(ISPI spi, IDigitalOutput<VirtualArduino.PinName> digitalouput) : base(spi, digitalouput) { }
	}
	
}
