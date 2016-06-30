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
		VirtualTransistorIC virtualTransistor = new VirtualTransistorIC(0x20);

		VirtualResistorIC virtualResistor_0 = new VirtualResistorIC(VirtualArduino.PinName.pin10);
		VirtualResistorIC virtualResistor_1 = new VirtualResistorIC(VirtualArduino.PinName.pin8);

		public MAX335<VirtualArduino.PinName> max;
		public AD5206<VirtualArduino.PinName> ad;
		public PCAL9555A io;

		public Form1()
		{
			InitializeComponent();
			this.comboBox1.Items.AddRange(SerialPort.GetPortNames());


			max = new MAX335<VirtualArduino.PinName>(this.arduino.spi, this.arduino.io);
			max.SetSwitch(MAX335<VirtualArduino.PinName>.PinName.pin0, MAX335<VirtualArduino.PinName>.SwitchType.OFF);

			ad = new AD5206<VirtualArduino.PinName>(this.arduino.spi, this.arduino.io);
			ad.SetRegister(AD5206<VirtualArduino.PinName>.PinName.pin1, 125);

			io = new PCAL9555A(this.arduino.i2c, 0x41);
			io.SetLevel(PCAL9555A.PinName.pin1, true);
			
		}


		private void button1_Click(object sender, EventArgs e)
		{
			virtualTransistor.Init();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Dictionary<VirtualTransistorIC.PortType, List<bool>> directionCollection = new Dictionary<VirtualTransistorIC.PortType, List<bool>>();
			directionCollection[VirtualTransistorIC.PortType.port0] = new List<bool>();
			directionCollection[VirtualTransistorIC.PortType.port1] = new List<bool>();

			virtualTransistor.WriteDirection(directionCollection);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Dictionary<VirtualTransistorIC.PortType, List<bool>> dataCollection = new Dictionary<VirtualTransistorIC.PortType, List<bool>>();
			dataCollection[VirtualTransistorIC.PortType.port0] = new List<bool>() { true, true, true, true, true, true, true, true };
			dataCollection[VirtualTransistorIC.PortType.port1] = new List<bool>() { false, false, false, false, false, false, false, false };
			virtualTransistor.WriteLevel(dataCollection);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Dictionary<VirtualTransistorIC.PortType, List<bool>> dataCollection = new Dictionary<VirtualTransistorIC.PortType, List<bool>>();
			dataCollection[VirtualTransistorIC.PortType.port0] = new List<bool>() { false, false, false, false, false, false, false, false };
			dataCollection[VirtualTransistorIC.PortType.port1] = new List<bool>() { true, true, true, true, true, true, true, true };
			virtualTransistor.WriteLevel(dataCollection);
		}


		private void button6_Click(object sender, EventArgs e)
		{
			virtualResistor_0.Init();
			virtualResistor_1.Init();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			virtualResistor_0.SetResistor(VirtualResistorIC.PinName.pin5, 100);
			virtualResistor_1.SetResistor(VirtualResistorIC.PinName.pin5, 200);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			virtualResistor_0.SetResistor(VirtualResistorIC.PinName.pin5, 200);
			virtualResistor_1.SetResistor(VirtualResistorIC.PinName.pin5, 100);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			virtualResistor_0.SetResistor(VirtualResistorIC.PinName.pin5, 255);
			virtualResistor_1.SetResistor(VirtualResistorIC.PinName.pin5, 255);
		}

		private void COM_Click(object sender, EventArgs e)
		{
			VirtualArduino.ModbusSerial.PortName = this.comboBox1.Text;
			VirtualArduino.ModbusSerial.Open();
		}


	}
}
