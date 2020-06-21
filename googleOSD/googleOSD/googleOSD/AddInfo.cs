using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace googleOSD {
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

		/// <summary>
		/// PCのファイル管理
		/// </summary>
		public struct LocalFile {
			public string fullPass;
			public string name;
			public string parent;
			public bool isFolder;

			public LocalFile(string fullPass, string name, string parent, bool isFolder)
			{
				this.fullPass = fullPass;
				this.name = name;
				this.parent = parent;
				this.isFolder = isFolder;
			}
		}
		public IList<LocalFile> sendFiles = null;             //送信元PCのファイルリスト

		public static IList<string> selectFiles = null;             //送信元PCのファイルリスト


		public AddInfo(string orderNumber, string managementNumber, string customerName, IList<LocalFile> sendFiles)
		{
			this.orderNumber = orderNumber;
			this.managementNumber = managementNumber;
			this.customerName = customerName;
			this.sendFiles = sendFiles;
		}

	}
}
