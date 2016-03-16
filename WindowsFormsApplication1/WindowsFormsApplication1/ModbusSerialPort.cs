using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SharedLibrary.SerialPort.Modbus
{
	public partial class ModbusSerialPort : Component
	{

		/// <summary>
		/// 送信完了を検知するタイマー
		/// </summary>
		protected System.Timers.Timer timeoutTimer = new System.Timers.Timer();

		/// <summary>
		/// 受信してから受信イベントを発生させる時間（msec）
		/// 最後にデータを受信したタイミングから指定時間後に受信完了と判断して受信イベントが発生する
		/// </summary>
		public int DataReceivedDelay { get; set; }

		// 概要:
		//     ModbusSerialPort オブジェクトのデータ受信イベントを処理するメソッドを表します。
		public event ModbusDataReceivedEventHandler ModbusDataReceived;


		/// <summary>
		/// 受信済みデータ
		/// </summary>
		public List<byte> readDataList = new List<byte>();


		/// <summary>
		/// コンポーネントを初期化
		/// </summary>
		protected virtual void InitializeComponent2()
		{
			// データ受信完了イベント（データ受信してから○○経過して受信完了とする）
			this.timeoutTimer.Elapsed += timeoutTimer_Elapsed;

			// タイムアウト値がないとデータなしのDataReceivedイベントによりlock(this)でデッドロックする対策
			this.serialPort1.ReadTimeout = 1;
		}


		/// <summary>
		/// シリアルポートのデータ受信イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			lock (this)
			{
				try
				{
					// 受信データ数をチェック
					if (this.readDataList.Count < 10000)
					{
						// 受信完了タイマスタート
						this.timeoutTimer.AutoReset = false;
						this.timeoutTimer.Interval = this.DataReceivedDelay;
						this.timeoutTimer.Enabled = true;

						// 受信バッファ内のデータを受信済みデータとして追加
						byte[] buf1 = new byte[this.serialPort1.ReadBufferSize];
						int len = this.serialPort1.Read(buf1, 0, buf1.Length);
						byte[] buf2 = new byte[len];
						Buffer.BlockCopy(buf1, 0, buf2, 0, len);
						this.readDataList.AddRange(buf2);
						Console.WriteLine(string.Format("serialPort1_DataReceived:{0}", string.Join(",", buf2)));

					}
					else
					{
						Console.WriteLine("▲受信データ数オーバー");
						this.serialPort1.DiscardInBuffer();
					}
				}
				catch { }
			}

		}

		/// <summary>
		/// 受信イベントが発生して＊＊秒受信がないとデータ受信完了とする
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void timeoutTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			//Console.WriteLine(string.Format("timeoutTimer_Elapsed:{0}{1}{1}", string.Join(",", this.readDataList), Environment.NewLine));
			lock (this)
			{
				// 受信データ長をチェック
				if (this.CheckReadDataLength())
				{
					// ModbusDataReceivedイベントとして渡すイベント引数
					ModbusDataReceivedEventArgs modbusData = new ModbusDataReceivedEventArgs();

					// ファンクションコード別にチェック
					switch (this.readDataList[1])
					{
						case 0x03:
							modbusData.ReadData = this.GetQuery_x03();
							break;

						case 0x06:
							modbusData.ReadData = this.GetQuery_x06();
							break;

						case 0x08:
							modbusData.ReadData = this.GetQuery_x08();
							break;

						case 0x10:
							modbusData.ReadData = this.GetQuery_x10();
							break;

						default:

							modbusData.ReadData = new ModbusData()
							{
								DeviceAddress = this.readDataList[0],
								FunctionCode = (byte)(this.readDataList[1] + 0x80),
							};
							break;
					}

					// 受信イベントを発行
					if (this.ModbusDataReceived != null) this.ModbusDataReceived(sender, modbusData);

				}
				else
				{
					Console.WriteLine("▲受信データ長エラー");
				}


				this.readDataList = new List<byte>();	// 受信データを初期化
			}
		}

		/// <summary>
		/// 受信データからModbusデータ形式のデータを取得する
		/// </summary>
		/// <returns></returns>
		protected virtual Query_x03 GetQuery_x03()
		{
			return new Query_x03()
			{
				DeviceAddress = this.readDataList[0],
				FunctionCode = this.readDataList[1],
				StartingAddress = (this.readDataList[2] << 8) + this.readDataList[3],
				NumberOfPoints = (this.readDataList[4] << 8) + this.readDataList[5],
			};
		}

		/// <summary>
		/// 受信データからModbusデータ形式のデータを取得する
		/// </summary>
		/// <returns></returns>
		protected virtual Query_x06 GetQuery_x06()
		{
			return new Query_x06()
			{
				DeviceAddress = this.readDataList[0],
				FunctionCode = this.readDataList[1],
				RegisterAddress = (this.readDataList[2] << 8) + this.readDataList[3],
				PresetData = (this.readDataList[4] << 8) + this.readDataList[5],
			};
		}

		/// <summary>
		/// 受信データからModbusデータ形式のデータを取得する
		/// </summary>
		/// <returns></returns>
		protected virtual Query_x08 GetQuery_x08()
		{
			return new Query_x08()
			{
				DeviceAddress = this.readDataList[0],
				FunctionCode = this.readDataList[1],
				Subfunction = (this.readDataList[2] << 8) + this.readDataList[3],
				Data = (this.readDataList[4] << 8) + this.readDataList[5],
			};
		}

		/// <summary>
		/// 受信データからModbusデータ形式のデータを取得する
		/// </summary>
		/// <returns></returns>
		protected virtual Query_x10 GetQuery_x10()
		{
			Query_x10 retData = new Query_x10()
			{
				DeviceAddress = this.readDataList[0],
				FunctionCode = this.readDataList[1],
			};

			int address = (this.readDataList[2] << 8) + this.readDataList[3];
			for (var index = 7; index < this.readDataList.Count - 2; index += 2)
			{
				retData.DataList.Add(
					address++,
					(short)((this.readDataList[index] << 8) + this.readDataList[index + 1])
				);
			}

			return retData;
		}

		/// <summary>
		/// 受信データ長をチェック
		/// </summary>
		/// <returns></returns>
		protected virtual bool CheckReadDataLength()
		{
			bool retFlag;	// チェック結果

			// 8バイト以上であること
			if (this.readDataList.Count >= 8)
			{
				// ファンクションコード別にチェック
				switch (this.readDataList[1])
				{
					case 0x03:
					case 0x06:
					case 0x08:
						retFlag = (this.readDataList.Count >= 8);
						break;

					case 0x10:
						retFlag = (this.readDataList.Count >= this.readDataList[6] + 9);
						break;

					default:
						retFlag = false;
						break;
				}
			}
			else
			{
				retFlag = false;
			}
			return retFlag;
		}


		/// <summary>
		/// ファンクションコード0x03のデータを送信する
		/// </summary>
		/// <param name="response"></param>
		public virtual void Write(Response_x03 response)
		{
			byte[] buffer = response.GetBytes();
			this.Write(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// ファンクションコード0x06のデータを送信する
		/// </summary>
		/// <param name="response"></param>
		public virtual void Write(Response_x06 response)
		{
			byte[] buffer = response.GetBytes();
			this.Write(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// ファンクションコード0x06のデータを送信する
		/// </summary>
		/// <param name="response"></param>
		public virtual void Write(Response_x08 response)
		{
			byte[] buffer = response.GetBytes();
			this.Write(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// ファンクションコード0x10のデータを送信する
		/// </summary>
		/// <param name="response"></param>
		public virtual void Write(Response_x10 response)
		{
			byte[] buffer = response.GetBytes();
			this.Write(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="response"></param>
		public virtual void Write(ErrorResponse response)
		{
			byte[] buffer = response.GetBytes();
			this.Write(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// シリアルポートに出力する
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="offset"></param>
		/// <param name="count"></param>
		public virtual void Write(byte[] buffer, int offset, int count)
		{
			this.serialPort1.Write(buffer, offset, count);
		}



		public ModbusSerialPort()
		{
			InitializeComponent();
			this.InitializeComponent2();
		}

		public ModbusSerialPort(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
			this.InitializeComponent2();
		}

		#region ダミーSerialPort
		/// <summary>
		/// ボーレート設定
		/// </summary>
		public virtual int BaudRate
		{
			get { return this.serialPort1.BaudRate; }
			set { this.serialPort1.BaudRate = value; }
		}

		/// <summary>
		/// フロー制御方式
		/// </summary>
		public virtual Handshake Handshake
		{
			get { return this.serialPort1.Handshake; }
			set { this.serialPort1.Handshake = value; }
		}

		/// <summary>
		/// パリティ
		/// </summary>
		public virtual Parity Parity
		{
			get { return this.serialPort1.Parity; }
			set { this.serialPort1.Parity = value; }
		}

		/// <summary>
		/// ポート名
		/// </summary>
		public virtual string PortName
		{
			get { return this.serialPort1.PortName; }
			set { this.serialPort1.PortName = value; }
		}

		/// <summary>
		/// ストップビット
		/// </summary>
		public virtual StopBits StopBits
		{
			get { return this.serialPort1.StopBits; }
			set { this.serialPort1.StopBits = value; }
		}

		/// <summary>
		/// ポートが開いた状態か
		/// </summary>
		public virtual bool IsOpen
		{
			get { return this.serialPort1.IsOpen; }
		}


		/// <summary>
		/// シリアルポートを開く
		/// </summary>
		public virtual void Open()
		{
			this.serialPort1.Open();
		}

		/// <summary>
		/// シリアルポートを閉じる
		/// </summary>
		public virtual void Close()
		{
			this.serialPort1.Close();
		}
		#endregion
	}


	// 概要:
	//     DummyInv_FRENIC.ModbusSerialPort オブジェクトの DummyInv_FRENIC.ModbusDataReceived
	//     イベントを処理するメソッドを表します。
	//
	// パラメーター:
	//   sender:
	//     イベントの送信元。DummyInv_FRENIC.ModbusSerialPort派生元であるSystem.IO.Ports.SerialPort オブジェクトです。
	//
	//   e:
	//     イベント データを格納している DummyInv_FRENIC.ModbusSerialDataReceivedEventArgs オブジェクト。
	public delegate void ModbusDataReceivedEventHandler(object sender, ModbusDataReceivedEventArgs e);

	public class ModbusDataReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// 受信したModbusデータ
		/// </summary>
		public ModbusData ReadData { get; set; }
	}
}

