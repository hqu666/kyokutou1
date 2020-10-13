using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using TabCon.Models;

namespace TabCon.ViewModels {
	public class SQLTablesViewModel : ViewModel {
		public void Initialize()
		{
		}

		#region テーブル名
		private string _key;
		public string key {
			get { return _key; }
			set {
				if (_key == value)
					return;
				_key = value;
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}
		#endregion
	}
}
