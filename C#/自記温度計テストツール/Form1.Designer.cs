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
			((System.ComponentModel.ISupportInitialize)(this.trackBarTH1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTH2)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(132, 124);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "サーミスタ";
			// 
			// trackBarTH1
			// 
			this.trackBarTH1.Location = new System.Drawing.Point(283, 110);
			this.trackBarTH1.Maximum = 255;
			this.trackBarTH1.Name = "trackBarTH1";
			this.trackBarTH1.Size = new System.Drawing.Size(245, 45);
			this.trackBarTH1.TabIndex = 1;
			this.trackBarTH1.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarTH1.ValueChanged += new System.EventHandler(this.trackBarTH1_ValueChanged);
			// 
			// trackBarTH2
			// 
			this.trackBarTH2.Location = new System.Drawing.Point(283, 171);
			this.trackBarTH2.Maximum = 255;
			this.trackBarTH2.Name = "trackBarTH2";
			this.trackBarTH2.Size = new System.Drawing.Size(245, 45);
			this.trackBarTH2.TabIndex = 2;
			this.trackBarTH2.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarTH2.ValueChanged += new System.EventHandler(this.trackBarTH2_ValueChanged);
			// 
			// labelTH1
			// 
			this.labelTH1.AutoSize = true;
			this.labelTH1.Location = new System.Drawing.Point(242, 123);
			this.labelTH1.Name = "labelTH1";
			this.labelTH1.Size = new System.Drawing.Size(11, 12);
			this.labelTH1.TabIndex = 3;
			this.labelTH1.Text = "0";
			// 
			// labelTH2
			// 
			this.labelTH2.AutoSize = true;
			this.labelTH2.Location = new System.Drawing.Point(242, 171);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1052, 844);
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
	}
}

