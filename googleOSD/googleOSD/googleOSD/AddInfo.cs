using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleOSD {
	class AddInfo {
		/// <summary>
		/// 受注No　:　GoogleEventに無い追加項目
		/// </summary>
		public string orderNumber = "";
		/// <summary>
		/// 管理番号　:　GoogleEventに無い追加項目
		/// </summary>
		public string managementNumber = "";
		/// <summary>
		/// 得意先　:　GoogleEventに無い追加項目
		/// </summary>
		public string customerName = "";

		public IList<GAttachFile> sendFiles = null;             //送信元PCのファイルリスト

		public static IList<string> selectFiles = null;             //送信元PCのファイルリスト


		public AddInfo(string orderNumber, string managementNumber, string customerName, IList<GAttachFile> sendFiles)
		{
			this.orderNumber = orderNumber;
			this.managementNumber = managementNumber;
			this.customerName = customerName;
			this.sendFiles = sendFiles;
		}

	}
}
