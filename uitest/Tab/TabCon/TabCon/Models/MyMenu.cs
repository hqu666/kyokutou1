using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabCon.Models {
	public class MyMenu {
		/// <summary>
		/// 表示名称
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 使用するパラメータ
		/// </summary>
		public string Value { get; set; }
		/// <summary>
		/// サブメニュー配列
		/// </summary>
		public List<MyMenu> Child { get; set; }
	}
}
