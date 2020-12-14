using Livet;
using System;
using System.Collections.ObjectModel;

namespace TabCon.Models
{
	public  class InputDialogModel : NotificationObject, ICloneable {


		#region TitolStr
		private string _TitolStr;
		public string TitolStr {
			get { return _TitolStr; }
			set {
				if (_TitolStr == value) return;
				_TitolStr = value;
				RaisePropertyChanged("TitolStr");
			}
		}
		#endregion

		#region MessegeStr
		private string _MessegeStr;
		public string MessegeStr {
			get { return _MessegeStr; }
			set {
				if (_MessegeStr == value) return;
				_MessegeStr = value;
				RaisePropertyChanged("MessegeStr");
			}
		}
		#endregion

		#region InputStr
		private string _InputStr;
		public string InputStr {
			get { return _InputStr; }
			set {
				if (_InputStr == value) return;
				_InputStr = value;
				RaisePropertyChanged("InputStr");
			}
		}
		#endregion

		/// <summary>
		/// 自身のコピーを生成します。
		/// </summary>
		public object Clone()
		{
			return new InputDialogModel() {
				TitolStr = this.TitolStr,
				MessegeStr = this.MessegeStr,
				InputStr = this.InputStr
			};
		}
	}

	//public static class Persons {
	//	/// <summary>
	//	/// Person のコレクションを生成します。
	//	/// </summary>
	//	public static ObservableCollection<Person> Create()
	//	{
	//		var ret = new ObservableCollection<Person>();
	//		ret.Add(new Person() { Id = 1, Name = "田中", Address = "渋谷区" });
	//		ret.Add(new Person() { Id = 2, Name = "山田", Address = "新宿区" });
	//		ret.Add(new Person() { Id = 3, Name = "鈴木", Address = "豊島区" });
	//		ret.Add(new Person() { Id = 4, Name = "佐藤", Address = "品川区" });
	//		ret.Add(new Person() { Id = 5, Name = "藤原", Address = "中央区" });

	//		return ret;
	//	}
	//}
}