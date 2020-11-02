using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// Googleアカウント認証テーブル
	/// </summary>
	public partial class m_google_account : NotificationObject
	{

		///<summary>
		///ID
		///</summary>
		private int _id;
		public int id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;
				_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///契約ID
		///</summary>
		private int _m_contract_id;
		public int m_contract_id
		{
			get => _m_contract_id;
			set
			{
				if (_m_contract_id == value)
					return;
				_m_contract_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Googleアカウント :@gmail.comのアカウント
		///</summary>
		private string _google_account;
		public string google_account
		{
			get => _google_account;
			set
			{
				if (_google_account == value)
					return;
				_google_account = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///GoogleクライアントID :GoogleAPIが使用するアカウント相当情報
		///</summary>
		private string _client_id;
		public string client_id
		{
			get => _client_id;
			set
			{
				if (_client_id == value)
					return;
				_client_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Googleクライアントシークレット :上記のパスワード相当相当
		///</summary>
		private string _client_secret;
		public string client_secret
		{
			get => _client_secret;
			set
			{
				if (_client_secret == value)
					return;
				_client_secret = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///GoogleプロジェクトID :GoogleAPIの登録先名
		///</summary>
		private string _project_id;
		public string project_id
		{
			get => _project_id;
			set
			{
				if (_project_id == value)
					return;
				_project_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///カレンダID
		///</summary>
		private string _calender_id;
		public string calender_id
		{
			get => _calender_id;
			set
			{
				if (_calender_id == value)
					return;
				_calender_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ドライブID
		///</summary>
		private string _drive_id;
		public string drive_id
		{
			get => _drive_id;
			set
			{
				if (_drive_id == value)
					return;
				_drive_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///作成者
		///</summary>
		private int _created_user;
		public int created_user
		{
			get => _created_user;
			set
			{
				if (_created_user == value)
					return;
				_created_user = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///作成日時
		///</summary>
		private DateTime _created_at;
		public DateTime created_at
		{
			get => _created_at;
			set
			{
				if (_created_at == value)
					return;
				_created_at = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///更新者
		///</summary>
		private int _updated_user;
		public int updated_user
		{
			get => _updated_user;
			set
			{
				if (_updated_user == value)
					return;
				_updated_user = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///更新日時
		///</summary>
		private DateTime _updated_at;
		public DateTime updated_at
		{
			get => _updated_at;
			set
			{
				if (_updated_at == value)
					return;
				_updated_at = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///削除日時
		///</summary>
		private DateTime _deleted_at;
		public DateTime deleted_at
		{
			get => _deleted_at;
			set
			{
				if (_deleted_at == value)
					return;
				_deleted_at = value;
				RaisePropertyChanged();
			}
		}

	}


	public class m_google_accountCollection : ObservableCollection<m_google_account> {
		public m_google_accountCollection(){
		}
	}
}
