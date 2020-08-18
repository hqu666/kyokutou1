using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleOSD {
	public class ProjectBase : INotifyPropertyChanged {

		int _ProjectBaseID;
		/// <summary>
		/// 案件基本ID
		/// </summary>
		public int ProjectBaseID {
			get { return _ProjectBaseID; }
			set { _ProjectBaseID = value; OnPropertyChanged("ProjectBaseID"); }
		}

		int _PropertyId;
		/// <summary>
		/// 物件ID
		/// </summary>
		public int PropertyId {
			get { return _PropertyId; }
			set { _PropertyId = value; OnPropertyChanged("PropertyId"); }
		}

		DateTime _DeliveryDate;
		/// <summary>
		/// 納期
		/// </summary>
		public DateTime DeliveryDate {
			get { return _DeliveryDate; }
			set { _DeliveryDate = value; OnPropertyChanged("DeliveryDate"); }
		}

		string _ManagementNumber;
		/// <summary>
		/// 管理番号
		/// </summary>
		public string ManagementNumber {
			get { return _ManagementNumber; }
			set { _ManagementNumber = value; OnPropertyChanged("ManagementNumber"); }
		}

		string _OrderNumber;
		/// <summary>
		/// 注文番号
		/// </summary>
		public string OrderNumber {
			get { return _OrderNumber; }
			set { _OrderNumber = value; OnPropertyChanged("OrderNumber"); }
		}

		string _ProjectNumber;
		/// <summary>
		/// 案件No.
		/// </summary>
		public string ProjectNumber {
			get { return _ProjectNumber; }
			set { _ProjectNumber = value; OnPropertyChanged("ProjectNumber"); }
		}

		string _ProjectName;
		/// <summary>
		/// 案件名
		/// </summary>
		public string ProjectName {
			get { return _ProjectName; }
			set { _ProjectName = value; OnPropertyChanged("ProjectName"); }
		}

		string _CustomerName;
		/// <summary>
		/// 得意先
		/// </summary>
		public string CustomerName {
			get { return _CustomerName; }
			set { _CustomerName = value; OnPropertyChanged("CustomerName"); }
		}

		string _OwnerName;
		/// <summary>
		/// 施主名
		/// </summary>
		public string OwnerName {
			get { return _OwnerName; }
			set { _OwnerName = value; OnPropertyChanged("OwnerName"); }
		}

		string _EventPlace;
		/// <summary>
		/// 場所
		/// </summary>
		public string EventPlace {
			get { return _EventPlace; }
			set { _EventPlace = value; OnPropertyChanged("EventPlace"); }
		}

		int _Status;
		/// <summary>
		/// ステータス
		/// </summary>
		public int Status {
			get { return _Status; }
			set { _Status = value; OnPropertyChanged("Status"); }
		}

		DateTime _Modify;
		/// <summary>
		/// 更新日
		/// </summary>
		public DateTime Modify {
			get { return _Modify; }
			set { _Modify = value; OnPropertyChanged("Modify"); }
		}
		//	[]            DATETIME DEFAULT(getdate()) NULL,
		//    [issueDate] DATETIME DEFAULT(getdate()) NULL,
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
		public class ProjectBaseCollection : ObservableCollection<ProjectBase> {
			public ProjectBaseCollection()
			{
				// 初期データ
				//this.Add(new AttachmentData() { Title = "1", Modifi = "202011/22", Size = "222KB" });
				//this.Add(new AttachmentData() { Title = "2", Modifi = "202011/22", Size = "22KB" });
				//this.Add(new AttachmentData() { Title = "3", Modifi = "202011/22", Size = "22KB" });
			}

		}
	}
