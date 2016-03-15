using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.SerialPort.Modbus
{
	/// <summary>
	/// Modbus形式データの共通部分
	/// </summary>
	public class ModbusData
	{
		/// <summary>
		/// デバイスアドレス
		/// </summary>
		public byte DeviceAddress { get; set; }

		/// <summary>
		/// ファンクションコード
		/// </summary>
		public byte FunctionCode { get; set; }
		
		/// <summary>
		/// CRCコードを取得する
		/// </summary>
		/// <param name="bytes">データ</param>
		/// <param name="checkLength">要求データ長（CRCを除く）</param>
		/// <returns>CRCコード</returns>
		public static int GetCRC(byte[] bytes, int checkLength)
		{
			int CRC;
			int carry;
			int n;
			int k = 0;
			CRC = 0xFFFF;
			while (k < checkLength)
			{
				CRC ^= bytes[k];
				for (n = 0; n < 8; n++)
				{
					carry = CRC & 1;
					CRC >>= 1;
					if (carry == 1)
					{
						CRC ^= 0xA001;
					}
				}
				k++;
			}

			return CRC;
		}

		/// <summary>
		/// CRCコードをチェックする
		/// </summary>
		/// <param name="bytes">対象データ</param>
		/// <param name="checkLength">チェックするデータ長</param>
		/// <returns></returns>
		public static bool CheckCRC(byte[] bytes, int checkLength)
		{
			//throw new NotImplementedException();
			return true;
		}

	}

	/// <summary>
	/// 返信データ
	/// </summary>
	public class Response : ModbusData
	{
		/// <summary>
		/// 誤ったCRCコードで返答するかどうか
		/// </summary>
		public bool CRCErrorFlag = false;
	}


	/// <summary>
	/// ファンクションコード0x03の要求データ
	/// </summary>
	public class Query_x03 : ModbusData
	{
		/// <summary>
		/// データ要求する先頭アドレス
		/// </summary>
		public int StartingAddress;

		/// <summary>
		/// データ要求するアドレス数
		/// </summary>
		public int NumberOfPoints;
	}

	/// <summary>
	/// ファンクションコード03の返答データ
	/// </summary>
	public class Response_x03 : Response
	{
		/// <summary>
		/// 取得したデータのアドレス‐値リスト
		/// </summary>
		public Dictionary<int, short> DataList = new Dictionary<int, short>();

		/// <summary>
		/// 0x03返答データの「バイト数」部分の値
		/// </summary>
		public byte ByteCount;

		/// <summary>
		/// オブジェクトデータをModbusプロトコルのバイト配列にして返す
		/// </summary>
		/// <returns></returns>
		public byte[] GetBytes()
		{
			byte[] retBytes = new byte[this.ByteCount + 5];

			int index = 0;
			retBytes[index++] = this.DeviceAddress;
			retBytes[index++] = this.FunctionCode;
			retBytes[index++] = this.ByteCount;

			for (int address = this.DataList.Keys.Min(); address <= this.DataList.Keys.Max(); address++)
			{
				retBytes[index++] = (byte)((this.DataList[address] >> 8) & 255);
				retBytes[index++] = (byte)(this.DataList[address] & 255);
			}

			int CRC = ModbusData.GetCRC(retBytes, this.ByteCount + 3);
			retBytes[index++] = (byte)(CRC & 255);
			retBytes[index++] = (byte)((CRC >> 8) & 255);

			if (this.CRCErrorFlag) retBytes[index - 1] = (byte)~retBytes[index - 1];

			return retBytes;
		}

		/// <summary>
		/// 受信したデータをCRCチェックする
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static bool CheckCRC(byte[] bytes)
		{
			return (bytes.Length >= 8) ? ModbusData.CheckCRC(bytes, 6) : false;
		}
	}




	/// <summary>
	/// ファンクションコード0x06の要求データ
	/// </summary>
	public class Query_x06 : ModbusData
	{
		/// <summary>
		/// データ設定するアドレス
		/// </summary>
		public int RegisterAddress;

		/// <summary>
		/// データ設定する値
		/// </summary>
		public int PresetData;
	}
	
	/// <summary>
	/// ファンクションコード06の返答データ
	/// </summary>
	public class Response_x06 : Response
	{
		/// <summary>
		/// データ設定するアドレス
		/// </summary>
		public int RegisterAddress;

		/// <summary>
		/// データ設定する値
		/// </summary>
		public int PresetData;


		/// <summary>
		/// オブジェクトデータをModbusプロトコルのバイト配列にして返す
		/// </summary>
		/// <returns></returns>
		public byte[] GetBytes()
		{
			byte[] retBytes = new byte[8];

			int index = 0;
			retBytes[index++] = this.DeviceAddress;
			retBytes[index++] = this.FunctionCode;
			retBytes[index++] = (byte)((this.RegisterAddress >> 8) & 255);
			retBytes[index++] = (byte)(this.RegisterAddress & 255);
			retBytes[index++] = (byte)((this.PresetData >> 8) & 255);
			retBytes[index++] = (byte)(this.PresetData & 255);

			int CRC = ModbusData.GetCRC(retBytes, 6);
			retBytes[index++] = (byte)(CRC & 255);
			retBytes[index++] = (byte)((CRC >> 8) & 255);

			if (this.CRCErrorFlag) retBytes[index - 1] = (byte)~retBytes[index - 1];

			return retBytes;
		}
	}




	/// <summary>
	/// ファンクションコード0x08の要求データ
	/// </summary>
	public class Query_x08 : ModbusData
	{
		/// <summary>
		/// サブファンクションコード
		/// </summary>
		public int Subfunction;

		/// <summary>
		/// 要求データ
		/// </summary>
		public int Data;
	}

	/// <summary>
	/// ファンクションコード0x08の返答データ
	/// </summary>
	public class Response_x08 : Response
	{
		/// <summary>
		/// サブファンクションコード
		/// </summary>
		public int Subfunction;

		/// <summary>
		/// 要求データ
		/// </summary>
		public int Data;

		/// <summary>
		/// オブジェクトデータをModbusプロトコルのバイト配列にして返す
		/// </summary>
		/// <returns></returns>
		public byte[] GetBytes()
		{
			byte[] retBytes = new byte[8];

			int index = 0;
			retBytes[index++] = this.DeviceAddress;
			retBytes[index++] = this.FunctionCode;
			retBytes[index++] = (byte)((this.Subfunction >> 8) & 255);
			retBytes[index++] = (byte)(this.Subfunction & 255);
			retBytes[index++] = (byte)((this.Data >> 8) & 255);
			retBytes[index++] = (byte)(this.Data & 255);

			int CRC = ModbusData.GetCRC(retBytes, 6);
			retBytes[index++] = (byte)(CRC & 255);
			retBytes[index++] = (byte)((CRC >> 8) & 255);

			if (this.CRCErrorFlag) retBytes[index - 1] = (byte)~retBytes[index - 1];

			return retBytes;
		}
	}
	


	/// <summary>
	/// ファンクションコード0x10の要求データ
	/// </summary>
	public class Query_x10 : ModbusData
	{
		/// <summary>
		/// 設定するデータのアドレス‐値リスト
		/// </summary>
		public Dictionary<int, int> DataList = new Dictionary<int, int>();

		/// <summary>
		/// 設定するデータの開始アドレス（読込み専用）
		/// </summary>
		public int StartingAddress { get { return chk() ? DataList.Keys.Min() : -1; } }

		/// <summary>
		/// 設定するデータのアドレス数（読込み専用）
		/// </summary>
		public int NumberOfRegisters { get { return chk() ? DataList.Count : -1; } }

		/// <summary>
		/// 設定するバイト数（読込み専用）
		/// </summary>
		public int ByteCount { get { return chk() ? this.NumberOfRegisters * 2 : -1; } }

		private bool chk() { return (this.DataList != null && this.DataList.Count > 0); }
	}

	/// <summary>
	/// ファンクションコード0x10の返答データ
	/// </summary>
	public class Response_x10 : Response
	{
		/// <summary>
		/// 設定したデータのアドレス‐値リスト
		/// </summary>
		public Dictionary<int, int> DataList = new Dictionary<int, int>();

		/// <summary>
		/// 設定したデータの開始アドレス
		/// </summary>
		public int StartingAddress;

		/// <summary>
		/// 設定したデータのアドレス数
		/// </summary>
		public int NumberOfRegisters;

		/// <summary>
		/// オブジェクトデータをModbusプロトコルのバイト配列にして返す
		/// </summary>
		/// <returns></returns>
		public byte[] GetBytes()
		{
			byte[] retBytes = new byte[8];

			int index = 0;
			retBytes[index++] = this.DeviceAddress;
			retBytes[index++] = this.FunctionCode;
			retBytes[index++] = (byte)((this.StartingAddress >> 8) & 255);
			retBytes[index++] = (byte)(this.StartingAddress & 255);
			retBytes[index++] = (byte)((this.NumberOfRegisters >> 8) & 255);
			retBytes[index++] = (byte)(this.NumberOfRegisters & 255);

			int CRC = ModbusData.GetCRC(retBytes, 6);
			retBytes[index++] = (byte)(CRC & 255);
			retBytes[index++] = (byte)((CRC >> 8) & 255);

			if (this.CRCErrorFlag) retBytes[index - 1] = (byte)~retBytes[index - 1];

			return retBytes;
		}
	}

	public class ErrorResponse : Response
	{
		/// <summary>
		/// 例外コード、サブコード
		/// </summary>
		public byte ExceptionCode;

		/// <summary>
		/// オブジェクトデータをModbusプロトコルのバイト配列にして返す
		/// </summary>
		/// <returns></returns>
		public byte[] GetBytes()
		{
			byte[] retBytes = new byte[5];

			int index = 0;
			retBytes[index++] = this.DeviceAddress;
			retBytes[index++] = this.FunctionCode;
			retBytes[index++] = this.ExceptionCode;

			int CRC = ModbusData.GetCRC(retBytes, 3);
			retBytes[index++] = (byte)(CRC & 255);
			retBytes[index++] = (byte)((CRC >> 8) & 255);

			if (this.CRCErrorFlag) retBytes[index - 1] = (byte)~retBytes[index - 1];

			return retBytes;
		}
	}

}
