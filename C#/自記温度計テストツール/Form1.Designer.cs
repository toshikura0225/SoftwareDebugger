namespace 自記温度計テストツール
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
			this.label1 = new System.Windows.Forms.Label();
			this.trackBarTH1 = new System.Windows.Forms.TrackBar();
			this.trackBarTH2 = new System.Windows.Forms.TrackBar();
			this.labelTH1 = new System.Windows.Forms.Label();
			this.labelTH2 = new System.Windows.Forms.Label();
			this.comboCOM = new System.Windows.Forms.ComboBox();
			this.button開始 = new System.Windows.Forms.Button();
			this.buttonDebug1 = new System.Windows.Forms.Button();
			this.buttonDebug2 = new System.Windows.Forms.Button();
			this.buttonDebug3 = new System.Windows.Forms.Button();
			this.buttonDebug4 = new System.Windows.Forms.Button();
			this.buttonDebug5 = new System.Windows.Forms.Button();
			this.buttonDebug6 = new System.Windows.Forms.Button();
			this.checkCOM4 = new System.Windows.Forms.CheckBox();
			this.checkCOM5 = new System.Windows.Forms.CheckBox();
			this.checkCOM6 = new System.Windows.Forms.CheckBox();
			this.checkCOM7 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonTH1 = new System.Windows.Forms.Button();
			this.buttonTH2 = new System.Windows.Forms.Button();
			this.button集乳完了 = new System.Windows.Forms.Button();
			this.button積算乳温 = new System.Windows.Forms.Button();
			this.button外部警報 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label充電状態 = new System.Windows.Forms.Label();
			this.button充電状態 = new System.Windows.Forms.Button();
			this.button5C = new System.Windows.Forms.Button();
			this.button電源リセット = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTH1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTH2)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(120, 95);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "サーミスタ";
			// 
			// trackBarTH1
			// 
			this.trackBarTH1.Location = new System.Drawing.Point(137, 110);
			this.trackBarTH1.Maximum = 255;
			this.trackBarTH1.Name = "trackBarTH1";
			this.trackBarTH1.Size = new System.Drawing.Size(384, 45);
			this.trackBarTH1.TabIndex = 1;
			this.trackBarTH1.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarTH1.ValueChanged += new System.EventHandler(this.trackBarTH1_ValueChanged);
			// 
			// trackBarTH2
			// 
			this.trackBarTH2.Location = new System.Drawing.Point(137, 143);
			this.trackBarTH2.Maximum = 255;
			this.trackBarTH2.Name = "trackBarTH2";
			this.trackBarTH2.Size = new System.Drawing.Size(384, 45);
			this.trackBarTH2.TabIndex = 2;
			this.trackBarTH2.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarTH2.ValueChanged += new System.EventHandler(this.trackBarTH2_ValueChanged);
			// 
			// labelTH1
			// 
			this.labelTH1.AutoSize = true;
			this.labelTH1.Location = new System.Drawing.Point(120, 114);
			this.labelTH1.Name = "labelTH1";
			this.labelTH1.Size = new System.Drawing.Size(11, 12);
			this.labelTH1.TabIndex = 3;
			this.labelTH1.Text = "0";
			// 
			// labelTH2
			// 
			this.labelTH2.AutoSize = true;
			this.labelTH2.Location = new System.Drawing.Point(120, 149);
			this.labelTH2.Name = "labelTH2";
			this.labelTH2.Size = new System.Drawing.Size(11, 12);
			this.labelTH2.TabIndex = 3;
			this.labelTH2.Text = "0";
			// 
			// comboCOM
			// 
			this.comboCOM.FormattingEnabled = true;
			this.comboCOM.Location = new System.Drawing.Point(134, 51);
			this.comboCOM.Name = "comboCOM";
			this.comboCOM.Size = new System.Drawing.Size(121, 20);
			this.comboCOM.TabIndex = 4;
			this.comboCOM.Text = "COM20";
			// 
			// button開始
			// 
			this.button開始.Location = new System.Drawing.Point(283, 47);
			this.button開始.Name = "button開始";
			this.button開始.Size = new System.Drawing.Size(75, 23);
			this.button開始.TabIndex = 5;
			this.button開始.Text = "開始";
			this.button開始.UseVisualStyleBackColor = true;
			this.button開始.Click += new System.EventHandler(this.button開始_Click);
			// 
			// buttonDebug1
			// 
			this.buttonDebug1.Location = new System.Drawing.Point(12, 51);
			this.buttonDebug1.Name = "buttonDebug1";
			this.buttonDebug1.Size = new System.Drawing.Size(75, 23);
			this.buttonDebug1.TabIndex = 6;
			this.buttonDebug1.Text = "button1";
			this.buttonDebug1.UseVisualStyleBackColor = true;
			this.buttonDebug1.Click += new System.EventHandler(this.buttonDebug1_Click);
			// 
			// buttonDebug2
			// 
			this.buttonDebug2.Location = new System.Drawing.Point(12, 80);
			this.buttonDebug2.Name = "buttonDebug2";
			this.buttonDebug2.Size = new System.Drawing.Size(75, 23);
			this.buttonDebug2.TabIndex = 7;
			this.buttonDebug2.Text = "button2";
			this.buttonDebug2.UseVisualStyleBackColor = true;
			this.buttonDebug2.Click += new System.EventHandler(this.buttonDebug2_Click);
			// 
			// buttonDebug3
			// 
			this.buttonDebug3.Location = new System.Drawing.Point(12, 109);
			this.buttonDebug3.Name = "buttonDebug3";
			this.buttonDebug3.Size = new System.Drawing.Size(75, 23);
			this.buttonDebug3.TabIndex = 8;
			this.buttonDebug3.Text = "button3";
			this.buttonDebug3.UseVisualStyleBackColor = true;
			this.buttonDebug3.Click += new System.EventHandler(this.buttonDebug3_Click);
			// 
			// buttonDebug4
			// 
			this.buttonDebug4.Location = new System.Drawing.Point(12, 138);
			this.buttonDebug4.Name = "buttonDebug4";
			this.buttonDebug4.Size = new System.Drawing.Size(75, 23);
			this.buttonDebug4.TabIndex = 9;
			this.buttonDebug4.Text = "button4";
			this.buttonDebug4.UseVisualStyleBackColor = true;
			this.buttonDebug4.Click += new System.EventHandler(this.buttonDebug4_Click);
			// 
			// buttonDebug5
			// 
			this.buttonDebug5.Location = new System.Drawing.Point(12, 167);
			this.buttonDebug5.Name = "buttonDebug5";
			this.buttonDebug5.Size = new System.Drawing.Size(75, 23);
			this.buttonDebug5.TabIndex = 10;
			this.buttonDebug5.Text = "button5";
			this.buttonDebug5.UseVisualStyleBackColor = true;
			this.buttonDebug5.Click += new System.EventHandler(this.buttonDebug5_Click);
			// 
			// buttonDebug6
			// 
			this.buttonDebug6.Location = new System.Drawing.Point(12, 196);
			this.buttonDebug6.Name = "buttonDebug6";
			this.buttonDebug6.Size = new System.Drawing.Size(75, 23);
			this.buttonDebug6.TabIndex = 11;
			this.buttonDebug6.Text = "button6";
			this.buttonDebug6.UseVisualStyleBackColor = true;
			this.buttonDebug6.Click += new System.EventHandler(this.buttonDebug6_Click);
			// 
			// checkCOM4
			// 
			this.checkCOM4.AutoSize = true;
			this.checkCOM4.Location = new System.Drawing.Point(152, 185);
			this.checkCOM4.Name = "checkCOM4";
			this.checkCOM4.Size = new System.Drawing.Size(54, 16);
			this.checkCOM4.TabIndex = 12;
			this.checkCOM4.Text = "10kΩ";
			this.checkCOM4.UseVisualStyleBackColor = true;
			this.checkCOM4.CheckedChanged += new System.EventHandler(this.checkTH_CheckedChanged);
			// 
			// checkCOM5
			// 
			this.checkCOM5.AutoSize = true;
			this.checkCOM5.Location = new System.Drawing.Point(212, 185);
			this.checkCOM5.Name = "checkCOM5";
			this.checkCOM5.Size = new System.Drawing.Size(54, 16);
			this.checkCOM5.TabIndex = 12;
			this.checkCOM5.Text = "47kΩ";
			this.checkCOM5.UseVisualStyleBackColor = true;
			this.checkCOM5.CheckedChanged += new System.EventHandler(this.checkTH_CheckedChanged);
			// 
			// checkCOM6
			// 
			this.checkCOM6.AutoSize = true;
			this.checkCOM6.Location = new System.Drawing.Point(272, 185);
			this.checkCOM6.Name = "checkCOM6";
			this.checkCOM6.Size = new System.Drawing.Size(60, 16);
			this.checkCOM6.TabIndex = 12;
			this.checkCOM6.Text = "100kΩ";
			this.checkCOM6.UseVisualStyleBackColor = true;
			this.checkCOM6.CheckedChanged += new System.EventHandler(this.checkTH_CheckedChanged);
			// 
			// checkCOM7
			// 
			this.checkCOM7.AutoSize = true;
			this.checkCOM7.Location = new System.Drawing.Point(338, 185);
			this.checkCOM7.Name = "checkCOM7";
			this.checkCOM7.Size = new System.Drawing.Size(60, 16);
			this.checkCOM7.TabIndex = 12;
			this.checkCOM7.Text = "130kΩ";
			this.checkCOM7.UseVisualStyleBackColor = true;
			this.checkCOM7.CheckedChanged += new System.EventHandler(this.checkTH_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(650, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 60);
			this.label2.TabIndex = 13;
			this.label2.Text = " 13kΩ→40℃\r\n 30kΩ→20℃\r\n 60kΩ→5℃\r\n 80kΩ→0℃\r\n146kΩ→-9.9℃";
			// 
			// buttonTH1
			// 
			this.buttonTH1.Location = new System.Drawing.Point(541, 110);
			this.buttonTH1.Name = "buttonTH1";
			this.buttonTH1.Size = new System.Drawing.Size(83, 23);
			this.buttonTH1.TabIndex = 14;
			this.buttonTH1.Text = "AD5セット";
			this.buttonTH1.UseVisualStyleBackColor = true;
			this.buttonTH1.Click += new System.EventHandler(this.buttonTH_Click);
			// 
			// buttonTH2
			// 
			this.buttonTH2.Location = new System.Drawing.Point(541, 139);
			this.buttonTH2.Name = "buttonTH2";
			this.buttonTH2.Size = new System.Drawing.Size(83, 23);
			this.buttonTH2.TabIndex = 15;
			this.buttonTH2.Text = "AD6セット";
			this.buttonTH2.UseVisualStyleBackColor = true;
			this.buttonTH2.Click += new System.EventHandler(this.buttonTH_Click);
			// 
			// button集乳完了
			// 
			this.button集乳完了.Location = new System.Drawing.Point(775, 36);
			this.button集乳完了.Name = "button集乳完了";
			this.button集乳完了.Size = new System.Drawing.Size(70, 51);
			this.button集乳完了.TabIndex = 16;
			this.button集乳完了.Text = "集乳\r\n完了";
			this.button集乳完了.UseVisualStyleBackColor = true;
			this.button集乳完了.Click += new System.EventHandler(this.button集乳完了_Click);
			// 
			// button積算乳温
			// 
			this.button積算乳温.Location = new System.Drawing.Point(861, 36);
			this.button積算乳温.Name = "button積算乳温";
			this.button積算乳温.Size = new System.Drawing.Size(69, 51);
			this.button積算乳温.TabIndex = 17;
			this.button積算乳温.Text = "積算\r\n乳温";
			this.button積算乳温.UseVisualStyleBackColor = true;
			this.button積算乳温.Click += new System.EventHandler(this.button積算乳温_Click);
			// 
			// button外部警報
			// 
			this.button外部警報.Location = new System.Drawing.Point(952, 36);
			this.button外部警報.Name = "button外部警報";
			this.button外部警報.Size = new System.Drawing.Size(65, 51);
			this.button外部警報.TabIndex = 18;
			this.button外部警報.Text = "外部\r\n警報";
			this.button外部警報.UseVisualStyleBackColor = true;
			this.button外部警報.Click += new System.EventHandler(this.button外部警報_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(81, 356);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 19;
			this.label3.Text = "充電状態";
			// 
			// label充電状態
			// 
			this.label充電状態.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label充電状態.Location = new System.Drawing.Point(141, 356);
			this.label充電状態.Name = "label充電状態";
			this.label充電状態.Size = new System.Drawing.Size(80, 23);
			this.label充電状態.TabIndex = 20;
			this.label充電状態.Text = "label4";
			this.label充電状態.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button充電状態
			// 
			this.button充電状態.Location = new System.Drawing.Point(248, 356);
			this.button充電状態.Name = "button充電状態";
			this.button充電状態.Size = new System.Drawing.Size(100, 23);
			this.button充電状態.TabIndex = 21;
			this.button充電状態.Text = "充電状態更新";
			this.button充電状態.UseVisualStyleBackColor = true;
			this.button充電状態.Click += new System.EventHandler(this.button充電状態_Click);
			// 
			// button5C
			// 
			this.button5C.Location = new System.Drawing.Point(431, 181);
			this.button5C.Name = "button5C";
			this.button5C.Size = new System.Drawing.Size(46, 23);
			this.button5C.TabIndex = 22;
			this.button5C.Text = "5℃";
			this.button5C.UseVisualStyleBackColor = true;
			this.button5C.Click += new System.EventHandler(this.button5C_Click);
			// 
			// button電源リセット
			// 
			this.button電源リセット.Location = new System.Drawing.Point(414, 51);
			this.button電源リセット.Name = "button電源リセット";
			this.button電源リセット.Size = new System.Drawing.Size(95, 23);
			this.button電源リセット.TabIndex = 23;
			this.button電源リセット.Text = "電源リセット";
			this.button電源リセット.UseVisualStyleBackColor = true;
			this.button電源リセット.Click += new System.EventHandler(this.button電源リセット_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1052, 844);
			this.Controls.Add(this.button電源リセット);
			this.Controls.Add(this.button5C);
			this.Controls.Add(this.button充電状態);
			this.Controls.Add(this.label充電状態);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button外部警報);
			this.Controls.Add(this.button積算乳温);
			this.Controls.Add(this.button集乳完了);
			this.Controls.Add(this.buttonTH2);
			this.Controls.Add(this.buttonTH1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.checkCOM7);
			this.Controls.Add(this.checkCOM6);
			this.Controls.Add(this.checkCOM5);
			this.Controls.Add(this.checkCOM4);
			this.Controls.Add(this.buttonDebug6);
			this.Controls.Add(this.buttonDebug5);
			this.Controls.Add(this.buttonDebug4);
			this.Controls.Add(this.buttonDebug3);
			this.Controls.Add(this.buttonDebug2);
			this.Controls.Add(this.buttonDebug1);
			this.Controls.Add(this.button開始);
			this.Controls.Add(this.comboCOM);
			this.Controls.Add(this.labelTH2);
			this.Controls.Add(this.labelTH1);
			this.Controls.Add(this.trackBarTH2);
			this.Controls.Add(this.trackBarTH1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.trackBarTH1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTH2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar trackBarTH1;
		private System.Windows.Forms.TrackBar trackBarTH2;
		private System.Windows.Forms.Label labelTH1;
		private System.Windows.Forms.Label labelTH2;
		private System.Windows.Forms.ComboBox comboCOM;
		private System.Windows.Forms.Button button開始;
		private System.Windows.Forms.Button buttonDebug1;
		private System.Windows.Forms.Button buttonDebug2;
		private System.Windows.Forms.Button buttonDebug3;
		private System.Windows.Forms.Button buttonDebug4;
		private System.Windows.Forms.Button buttonDebug5;
		private System.Windows.Forms.Button buttonDebug6;
		private System.Windows.Forms.CheckBox checkCOM4;
		private System.Windows.Forms.CheckBox checkCOM5;
		private System.Windows.Forms.CheckBox checkCOM6;
		private System.Windows.Forms.CheckBox checkCOM7;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonTH1;
		private System.Windows.Forms.Button buttonTH2;
		private System.Windows.Forms.Button button集乳完了;
		private System.Windows.Forms.Button button積算乳温;
		private System.Windows.Forms.Button button外部警報;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label充電状態;
		private System.Windows.Forms.Button button充電状態;
		private System.Windows.Forms.Button button5C;
		private System.Windows.Forms.Button button電源リセット;
	}
}

