using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleOSD {
	public class AriadneData {
	/// <summary>
	/// 案件番号
	/// </summary>
		public string ItemNumber { set; get; }
		/// <summary>
		/// 案件名　:
		/// </summary>
		public string ItenName { set; get; }

		/// <summary>
		/// 受注No　:
		/// </summary>
		public string OrderNumber { set; get; }
		/// <summary>
		/// 管理番号　:
		/// </summary>
		public string ManagementNumber { set; get; }
		/// <summary>
		/// 得意先　:
		/// </summary>
		public string CustomerName { set; get; }
		/// <summary>
		/// メモ
		/// </summary>
		public string Memo { set; get; }

		/// <summary>
		/// 見積ファイルのPC保存位置
		/// </summary>
		public string EstimationPCPass { set; get; }

		/// <summary>
		/// 見積ファイルのGoogleDriveID
		/// </summary>
		public string EstimationGoogleFileID { set; get; }

		/// <summary>
		/// 受注ファイルのPC保存位置
		/// </summary>
		public string OrderPCPass { set; get; }

		/// <summary>
		/// 受注ファイルのGoogleDriveID
		/// </summary>
		public string OrderGoogleFileID { set; get; }

		/// <summary>
		/// 売上ファイルのPC保存位置
		/// </summary>
		public string SalesPCPass { set; get; }

		/// <summary>
		/// 売上ファイルのGoogleDriveID
		/// </summary>
		public string SalesGoogleFileID { set; get; }

		/// <summary>
		/// 請求ファイルのPC保存位置
		/// </summary>
		public string RequestPCPass { set; get; }

		/// <summary>
		/// 請求ファイルのGoogleDriveID
		/// </summary>
		public string RequestGoogleFileID { set; get; }

		/// <summary>
		/// 入金ファイルのPC保存位置
		/// </summary>
		public string ReceiptPCPass { set; get; }

		/// <summary>
		/// 入金ファイルのGoogleDriveID
		/// </summary>
		public string ReceipttGoogleFileID { set; get; }

		/// <summary>
		/// 発注ファイルのPC保存位置
		/// </summary>
		public string ToOrderPCPass { set; get; }

		/// <summary>
		/// 発注ファイルのGoogleDriveID
		/// </summary>
		public string ToOrderGoogleFileID { set; get; }

		/// <summary>
		/// 入荷・工事消込ファイルのPC保存位置
		/// </summary>
		public string StockPCPass { set; get; }

		/// <summary>
		/// 入荷・工事消込ファイルのGoogleDriveID
		/// </summary>
		public string StockGoogleFileID { set; get; }

		public IList<GAttachFile> sendFiles = null;             //送信元PCのファイルリスト
		public static IList<string> selectFiles = null;             //送信元PCのファイルリスト


		/// <summary>
		/// TreeViewの階層化配列
		/// </summary>
		public List<AriadneData> Children { get; set; } = new List<AriadneData>();
		/// <summary>
		/// 添付などの選択
		/// </summary>
		public bool IsSerect { set; get; }
	}
}
