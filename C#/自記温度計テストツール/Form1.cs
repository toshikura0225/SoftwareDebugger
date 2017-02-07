using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VirtualComponent.Arduino;
using VirtualComponent.IC;
using VirtualComponent;
using System.IO.Ports;

namespace 自記温度計テストツール
{
	public partial class Form1 : Form
	{
		VirtualArduino arduino;

		MAX335 max335;
		AD5206 ad5206;
		PCAL9555A pcal9555a;

		public Form1()
		{
			InitializeComponent();
			this.comboCOM.Items.AddRange(SerialPort.GetPortNames());
		}

		/// <summary>
		/// 「開始」ボタンのクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button開始_Click(object sender, EventArgs e)
		{
			// VirtualArduinoの初期化
			{
				this.arduino = new VirtualArduino(this.comboCOM.Text);

				// ピンの方向
				this.arduino.io.SetDirection(VirtualArduino.PinName.pin7, true);	// バッテリーのON/OFF
				this.arduino.io.SetDirection(VirtualArduino.PinName.pin4, true);	// AC電源のON/OFF
			}

			// PCAL955Aの初期化
			{
				this.pcal9555a = new PCAL9555A(this.arduino.i2c, 0x21);

				// ピンの方向
				this.pcal9555a.SetDirection(PCAL9555A.PinName.P0_7, true);	// AD5206のCS用
				this.pcal9555a.SetDirection(PCAL9555A.PinName.P1_0, true);	// MAX335のCS用
				this.pcal9555a.SetDirection(PCAL9555A.PinName.P0_0, false);	// 充電のON/OFF信号検出
				this.pcal9555a.SetDirection(PCAL9555A.PinName.P0_1, false);	// 外部接点①の出力検出
				this.pcal9555a.SetDirection(PCAL9555A.PinName.P0_2, false);	// 外部接点②の出力検出
			}

			// MAX335の初期化
			this.max335 = new MAX335(this.arduino.spi, pcal9555a, PCAL9555A.PinName.P1_0);

			// AD5206の初期化
			this.ad5206 = new AD5206(this.arduino.spi, pcal9555a, PCAL9555A.PinName.P1_1);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}



		private void buttonDebug1_Click(object sender, EventArgs e)
		{
			ad5206[AD5206.PinName.BW4] = 0x00;
		}

		private void buttonDebug2_Click(object sender, EventArgs e)
		{
			ad5206[AD5206.PinName.BW4] = 0x80;
		}

		private void buttonDebug3_Click(object sender, EventArgs e)
		{
			ad5206[AD5206.PinName.BW4] = 0xFF;
		}

		private void buttonDebug4_Click(object sender, EventArgs e)
		{
			this.arduino.io.SetDirection(VirtualArduino.PinName.pin7, true);
			this.arduino.io.SetDirection(VirtualArduino.PinName.pin4, true);
			this.arduino.io.SetLevel(VirtualArduino.PinName.pin7, VoltageLevel.HIGH);
			this.arduino.io.SetLevel(VirtualArduino.PinName.pin4, VoltageLevel.HIGH);
		}

		private void buttonDebug5_Click(object sender, EventArgs e)
		{
			this.arduino.io.SetLevel(VirtualArduino.PinName.pin7, VoltageLevel.LOW);
			this.arduino.io.SetLevel(VirtualArduino.PinName.pin4, VoltageLevel.LOW);
		}

		private void buttonDebug6_Click(object sender, EventArgs e)
		{

		}




		/// <summary>
		/// サーミスタのツマミ①を変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trackBarTH1_ValueChanged(object sender, EventArgs e)
		{
			labelTH1.Text = this.trackBarTH1.Value.ToString();
		}

		/// <summary>
		/// サーミスタのツマミ②を変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trackBarTH2_ValueChanged(object sender, EventArgs e)
		{
			labelTH2.Text = this.trackBarTH2.Value.ToString();
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
