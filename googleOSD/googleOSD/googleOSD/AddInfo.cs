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

		public AddInfo(string orderNumber, string managementNumber, string customerName)
		{
			this.orderNumber = orderNumber;
			this.managementNumber = managementNumber;
			this.customerName = customerName;
		}



	}
}
