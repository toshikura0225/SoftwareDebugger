namespace SoftwareDebuggerSolution
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 140);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(117, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "1 ③new MAX335";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(24, 388);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(380, 23);
			this.button2.TabIndex = 0;
			this.button2.Text = "2 pcal9555a.SetLevel(PCAL9555A.PinName.P0_0, VoltageLevel.HIGH);";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(176, 140);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(137, 23);
			this.button3.TabIndex = 0;
			this.button3.Text = "3 ③new AD5206";
			this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(24, 312);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(344, 23);
			this.button4.TabIndex = 0;
			this.button4.Text = "ad5206[AD5206.PinName.BW4] = 0x80;";
			this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(24, 60);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(137, 23);
			this.button5.TabIndex = 0;
			this.button5.Text = "5 ①new VirtualArduino";
			this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(24, 102);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(135, 23);
			this.button6.TabIndex = 1;
			this.button6.Text = "6 ②new PCAL9555A";
			this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(24, 209);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(344, 23);
			this.button7.TabIndex = 2;
			this.button7.Text = "7 max335[MAX335.PinName.COM3] = SwitchState.OPEN;";
			this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(24, 238);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(344, 23);
			this.button8.TabIndex = 4;
			this.button8.Text = "8 max335[MAX335.PinName.COM3] = SwitchState.CLOSE;";
			this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(24, 283);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(344, 23);
			this.button9.TabIndex = 5;
			this.button9.Text = "ad5206[AD5206.PinName.BW4] = 0xA0;\r\n";
			this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(24, 20);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 20);
			this.comboBox1.TabIndex = 6;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(24, 341);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(344, 23);
			this.button10.TabIndex = 7;
			this.button10.Text = "ad5206[AD5206.PinName.BW4] = 0xC0;";
			this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(24, 417);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(380, 23);
			this.button11.TabIndex = 8;
			this.button11.Text = "11 pcal9555a.SetLevel(PCAL9555A.PinName.P0_0, VoltageLevel.LOW);";
			this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(24, 463);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(75, 23);
			this.button12.TabIndex = 9;
			this.button12.Text = "12 I2C受信";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(24, 492);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(380, 23);
			this.button13.TabIndex = 10;
			this.button13.Text = "pcal9555a.SetLevel(PCAL9555A.PinName.P0_6, VoltageLevel.HIGH);";
			this.button13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(567, 524);
			this.Controls.Add(this.button13);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
	}
}

