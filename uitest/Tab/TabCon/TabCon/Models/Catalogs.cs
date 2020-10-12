using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// カタログマスタ
	/// </summary>
	public partial class Catalogs
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
			}
		}

		///<summary>
		///カタログID
		///</summary>
		private string _catalog_id;
		public string catalog_id
		{
			get => _catalog_id;
			set
			{
				if (_catalog_id == value)
					return;
				_catalog_id = value;
			}
		}

		///<summary>
		///カタログ名
		///</summary>
		private string _catalog_name;
		public string catalog_name
		{
			get => _catalog_name;
			set
			{
				if (_catalog_name == value)
					return;
				_catalog_name = value;
			}
		}

		///<summary>
		///有効期間(FROM)
		///</summary>
		private DateTime _rental_start;
		public DateTime rental_start
		{
			get => _rental_start;
			set
			{
				if (_rental_start == value)
					return;
				_rental_start = value;
			}
		}

		///<summary>
		///有効期間(TO)
		///</summary>
		private DateTime _rental_end;
		public DateTime rental_end
		{
			get => _rental_end;
			set
			{
				if (_rental_end == value)
					return;
				_rental_end = value;
			}
		}

		///<summary>
		///配信停止 :1:配信停止
		///</summary>
		private bool _is_unsubscribe;
		public bool is_unsubscribe
		{
			get => _is_unsubscribe;
			set
			{
				if (_is_unsubscribe == value)
					return;
				_is_unsubscribe = value;
			}
		}

		///<summary>
		///メモ
		///</summary>
		private string _memo;
		public string memo
		{
			get => _memo;
			set
			{
				if (_memo == value)
					return;
				_memo = value;
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
			}
		}

	}


	public class CatalogsCollection : ObservableCollection<Catalogs> {
		public CatalogsCollection(){
		}
	}
}
