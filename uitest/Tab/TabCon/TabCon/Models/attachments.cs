using System;
using System.Collections.ObjectModel;
using Livet;

namespace TabCon.Models {
	/// <summary>
	/// �Y�t�t�@�C�����
	/// </summary>
	public partial class attachments : NotificationObject, ICloneable {

		private int _index;
		public int index {
			get => _index;
			set {
				if (_index == value)
					return;
				_index = value;
				RaisePropertyChanged();
			}
		}

		private string _local_file_pass;
		///<summary>
		///PC��T�[�o��̃t���p�X��
		///</summary>
		public string local_file_pass {
			get => _local_file_pass;
			set {
				if (_local_file_pass == value)
					return;
				_local_file_pass = value;
				RaisePropertyChanged();
			}
		}

		private string _google_file_name;
		///<summary>
		///GoogleDrive��̕\����
		///</summary>
		public string google_file_name{
			get => _google_file_name;
			set {
				if (_google_file_name == value)
					return;
				_google_file_name = value;
				RaisePropertyChanged();
			}
		}

		private string _google_file_id;
		///<summary>
		///GoogleDrive��̎��ʖ�
		///</summary>
		public string google_file_id {
			get => _google_file_id;
			set {
				if (_google_file_id == value)
					return;
				_google_file_id = value;
				RaisePropertyChanged();
			}
		}



		private TabCon.ViewModels.X_2ViewModel _methodTarget;
		/// <summary>
		/// Context�ɂȂ�ViewModel
		/// </summary>
		public TabCon.ViewModels.X_2ViewModel methodTarget {
			get => _methodTarget;
			set {
				if (_methodTarget == value)
					return;
				_methodTarget = value;
				RaisePropertyChanged();
			}
		}

		private bool _IsEnabled;
		///<summary>
		///�������w��
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
		/// �\���p�̕�����
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
				index = this.index,
				local_file_pass = this.local_file_pass,
				google_file_id = this.google_file_id,
				google_file_name = this.google_file_name,
				methodTarget = this.methodTarget,
				IsEnabled = this.IsEnabled,
				summary = this.summary
			};
		}
		/////////////////////////////////////////////////////////////�����ȍ~�̒ǋL///
	}

	public class attachmentsCollection : ObservableCollection<t_events> {
		public attachmentsCollection(){
		}
	}
}
