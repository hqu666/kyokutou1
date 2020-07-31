using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GoogleOSD {
	public class AttachmentData : INotifyPropertyChanged {
		// Titleプロパティ
		string _title;
		public string Title {
			get { return _title; }
			set { _title = value; OnPropertyChanged("Title"); }
		}

		//Modifiプロパティ
		string _modifi;
		public string Modifi {
			get { return _modifi; }
			set { _modifi = value; OnPropertyChanged("Modifi"); }
		}

		//Sizeプロパティ
		string _size;
		public string Size {
			get { return _modifi; }
			set { _modifi = value; OnPropertyChanged("Size"); }
		}

		// FileIdプロパティ
		string _fileId;
		public string FileId {
			get { return _fileId; }
			set { _fileId = value; OnPropertyChanged("FileId"); }
		}

		// FileUrlプロパティ
		string _fileUrl;
		public string FileUrl {
			get { return _fileUrl; }
			set { _fileUrl = value; OnPropertyChanged("FileUrl"); }
		}

		//IconLinkプロパティ
		string _iconLink;
		public string IconLink {
			get { return _fileUrl; }
			set { _fileUrl = value; OnPropertyChanged("IconLink"); }
		}

		//MimeTypeプロパティ
		string _mimeType;
		public string MimeType {
			get { return _mimeType; }
			set { _mimeType = value; OnPropertyChanged("MimeType"); }
		}

		//ETagプロパティ
		string _eTag;
		public string ETag {
			get { return _eTag; }
			set { _eTag = value; OnPropertyChanged("ETag"); }
		}

		// INotifyPropertyChangedインターフェースの実装
		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged(string pName)
		{
			var handler = this.PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(pName));
		}
	}

	// 表示するデータのコレクション（データバインド可能）
	public class AttachmentDataCollection : ObservableCollection<AttachmentData> {
		public AttachmentDataCollection()
		{
			// 初期データ
			//this.Add(new AttachmentData() { Title = "1", Modifi = "202011/22", Size = "222KB" });
			//this.Add(new AttachmentData() { Title = "2", Modifi = "202011/22", Size = "22KB" });
			//this.Add(new AttachmentData() { Title = "3", Modifi = "202011/22", Size = "22KB" });
		}
	}
}