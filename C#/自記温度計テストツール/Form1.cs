﻿using System;
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
using System.Threading;

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
				this.pcal9555a.SetDirection(PCAL9555A.PinName.P0_5, true);	// P
				this.pcal9555a.SetDirection(PCAL9555A.PinName.P0_6, true);	// C
				this.pcal9555a.SetDirection(PCAL9555A.PinName.P0_7, true);	// A
			}

			// MAX335の初期化
			this.max335 = new MAX335(this.arduino.spi, pcal9555a, PCAL9555A.PinName.P1_0);

			// AD5206の初期化
			this.ad5206 = new AD5206(this.arduino.spi, pcal9555a, PCAL9555A.PinName.P1_1);

			// サーミスタの初期化
			initTH();

			// 充電状態の初期化
			initCharge();

			// リレーの初期化
			initRelay();

		}


		void initTH()
		{
			button5C_Click(null, null);
		}

		void initCharge()
		{
			pcal9555a.SetDirection(PCAL9555A.PinName.P0_0, false);
			button充電状態_Click(null, null);
		}

		void initRelay()
		{
			this.arduino.io.SetLevel(VirtualArduino.PinName.pin7, VoltageLevel.LOW);
			this.arduino.io.SetLevel(VirtualArduino.PinName.pin4, VoltageLevel.LOW);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}



		private void buttonDebug1_Click(object sender, EventArgs e)
		{
			this.arduino.io.SetLevel(VirtualArduino.PinName.pin7, VoltageLevel.HIGH);
			//this.arduino.io.SetLevel(VirtualArduino.PinName.pin4, VoltageLevel.LOW);
		}

		private void buttonDebug2_Click(object sender, EventArgs e)
		{
			this.arduino.io.SetLevel(VirtualArduino.PinName.pin7, VoltageLevel.LOW);
			//this.arduino.io.SetLevel(VirtualArduino.PinName.pin4, VoltageLevel.HIGH);
		}

		private void buttonDebug3_Click(object sender, EventArgs e)
		{
			pcal9555a.SetLevel(PCAL9555A.PinName.P0_7, VoltageLevel.HIGH);
			pcal9555a.SetLevel(PCAL9555A.PinName.P0_6, VoltageLevel.HIGH);
			pcal9555a.SetLevel(PCAL9555A.PinName.P0_5, VoltageLevel.LOW);
		}

		private void buttonDebug4_Click(object sender, EventArgs e)
		{
			ad5206[AD5206.PinName.BW4] = 0x80;
		}

		private void buttonDebug5_Click(object sender, EventArgs e)
		{
			ad5206[AD5206.PinName.BW4] = 0x00;
			
		}

		private void buttonDebug6_Click(object sender, EventArgs e)
		{
			var k = pcal9555a.ReadLevel(PCAL9555A.Command.InputPort_0);
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

		/// <summary>
		/// サーミスタのチェックボックス変化時（すべてのチェックボックス共通）
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkTH_CheckedChanged(object sender, EventArgs e)
		{
			if ((CheckBox)sender == this.checkCOM4)
			{
				max335[MAX335.PinName.COM4] = this.checkCOM4.Checked ? SwitchState.CLOSE : SwitchState.OPEN;
			}
			else if ((CheckBox)sender == this.checkCOM5)
			{
				max335[MAX335.PinName.COM5] = this.checkCOM5.Checked ? SwitchState.CLOSE : SwitchState.OPEN;
			}
			else if ((CheckBox)sender == this.checkCOM6)
			{
				max335[MAX335.PinName.COM6] = this.checkCOM6.Checked ? SwitchState.CLOSE : SwitchState.OPEN;
			}
			else if ((CheckBox)sender == this.checkCOM7)
			{
				max335[MAX335.PinName.COM7] = this.checkCOM7.Checked ? SwitchState.CLOSE : SwitchState.OPEN;
			}
		}

		private void buttonTH_Click(object sender, EventArgs e)
		{
			if ((Button)sender == this.buttonTH1)
			{
				ad5206[AD5206.PinName.BW5] = (byte)this.trackBarTH1.Value;
			}
			else if ((Button)sender == this.buttonTH2)
			{
				ad5206[AD5206.PinName.BW6] = (byte)this.trackBarTH2.Value;
			}
		}

		private void button集乳完了_Click(object sender, EventArgs e)
		{
			max335[MAX335.PinName.COM3] = SwitchState.CLOSE;
			Thread.Sleep(2500);
			max335[MAX335.PinName.COM3] = SwitchState.OPEN;
		}

		private void button積算乳温_Click(object sender, EventArgs e)
		{
			max335[MAX335.PinName.COM2] = SwitchState.CLOSE;
			max335[MAX335.PinName.COM2] = SwitchState.OPEN;
		}

		private void button外部警報_Click(object sender, EventArgs e)
		{
			max335[MAX335.PinName.COM1] = SwitchState.CLOSE;
			max335[MAX335.PinName.COM1] = SwitchState.OPEN;
		}

		private void button充電状態_Click(object sender, EventArgs e)
		{
			var k = pcal9555a.ReadLevel(PCAL9555A.Command.InputPort_0);

			this.label充電状態.Text = ((k[PCAL9555A.PinName.P0_0] == VoltageLevel.HIGH) ? "充電中" : "充電なし");
			this.label充電状態.BackColor = ((k[PCAL9555A.PinName.P0_0] == VoltageLevel.HIGH) ? Color.Red : Color.Blue);
		}

		private void button5C_Click(object sender, EventArgs e)
		{
			// サーミスタの初期化
			this.trackBarTH1.Value = 115;
			this.trackBarTH2.Value = 255;
			ad5206[AD5206.PinName.BW5] = 115;
			ad5206[AD5206.PinName.BW6] = 255;

			this.checkCOM4.Checked = false;
			this.checkCOM5.Checked = true;
			this.checkCOM6.Checked = false;
			this.checkCOM7.Checked = false;
			//max335[MAX335.PinName.COM4] = SwitchState.OPEN;
			//max335[MAX335.PinName.COM5] = SwitchState.CLOSE;
			//max335[MAX335.PinName.COM6] = SwitchState.OPEN;
			//max335[MAX335.PinName.COM7] = SwitchState.OPEN;

			Dictionary<int, Dictionary<int, int>> dic = new Dictionary<int, Dictionary<int, int>>();

			Dictionary<int, int> dic2 = new Dictionary<int,int>();
			dic2.Add(2, 3);

			dic.Add(2, dic2);


		}

		private void button電源リセット_Click(object sender, EventArgs e)
		{
			this.arduino.io.SetLevel(VirtualArduino.PinName.pin7, VoltageLevel.HIGH);
			Thread.Sleep(1000);
			this.arduino.io.SetLevel(VirtualArduino.PinName.pin7, VoltageLevel.LOW);
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
