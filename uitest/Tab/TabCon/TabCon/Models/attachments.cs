using System;
using System.Collections.ObjectModel;
using Livet;

namespace TabCon.Models {
	/// <summary>
	/// 添付ファイル情報
	/// </summary>
	public partial class attachments : NotificationObject, ICloneable {

		private string _local_file_pass;
		///<summary>
		///PCやサーバ上のフルパス名
		///</summary>
		public string local_file_pass {
			get => _local_file_pass;
			set
			{
				if (_local_file_pass == value)
					return;
				_local_file_pass = value;
				RaisePropertyChanged();
			}
		}

		private bool _IsEnabled;
		///<summary>
		///活性化指定
		///</summary>
		public bool IsEnabled {
			get => _IsEnabled;
			set {
				if (_IsEnabled == value)
					return;
				_IsEnabled = value;
				RaisePropertyChanged();
			}
		}

		private string _summary;
		/// <summary>
		/// 表示用の文字列
		/// </summary>
		public string summary {
			get => _summary;
			set {
				if (_summary == value)
					return;
				_summary = value;
				RaisePropertyChanged();
			}
		}

		object ICloneable.Clone()
		{
			return new attachments() {
				local_file_pass = this.local_file_pass,
				IsEnabled = this.IsEnabled,
				summary = this.summary
			};
		}
		/////////////////////////////////////////////////////////////生成以降の追記///
	}

	public class attachmentsCollection : ObservableCollection<t_events> {
		public attachmentsCollection(){
		}
	}
}
