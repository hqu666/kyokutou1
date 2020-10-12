using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabCon.ViewModels {
	public class SQLTablesViewModel {
		#region テーブル名
		private string _key;
		public string key {
			get { return _key; }
			set {
				if (_key == value)
					return;
				_key = value;
					//		RaisePropertyChanged();
			}
		}
		#endregion

		#region 表示名
		private string _name;
		public string name {
			get { return _name; }
			set {
				if (_name == value)
					return;
				_name = value;
				//		RaisePropertyChanged();
			}
		}
		#endregion
	}
}
