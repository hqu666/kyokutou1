using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// ライセンスマスタ
	/// </summary>
	public partial class m_licenses : NotificationObject
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
		///ライセンスキー
		///</summary>
		private string _license_key;
		public string license_key
		{
			get => _license_key;
			set
			{
				if (_license_key == value)
					return;
				_license_key = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///停止フラグ
		///</summary>
		private bool _stop_flag;
		public bool stop_flag
		{
			get => _stop_flag;
			set
			{
				if (_stop_flag == value)
					return;
				_stop_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///有効期限（FROM)
		///</summary>
		private DateTime _effective_period_from;
		public DateTime effective_period_from
		{
			get => _effective_period_from;
			set
			{
				if (_effective_period_from == value)
					return;
				_effective_period_from = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///有効期限（TO）
		///</summary>
		private DateTime _effective_period_to;
		public DateTime effective_period_to
		{
			get => _effective_period_to;
			set
			{
				if (_effective_period_to == value)
					return;
				_effective_period_to = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///プランID :＝プランマスタ．ID
		///</summary>
		private int _m_plan_id;
		public int m_plan_id
		{
			get => _m_plan_id;
			set
			{
				if (_m_plan_id == value)
					return;
				_m_plan_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///更新チェック間隔 :分単位で設定
		///</summary>
		private int _check_interval;
		public int check_interval
		{
			get => _check_interval;
			set
			{
				if (_check_interval == value)
					return;
				_check_interval = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///バージョンアップ可能Ver :0：常に最新、以外：バージョンマスタ.ID
		///</summary>
		private int _m_version_id;
		public int m_version_id
		{
			get => _m_version_id;
			set
			{
				if (_m_version_id == value)
					return;
				_m_version_id = value;
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


	public class m_licensesCollection : ObservableCollection<m_licenses> {
		public m_licensesCollection(){
		}
	}
}
