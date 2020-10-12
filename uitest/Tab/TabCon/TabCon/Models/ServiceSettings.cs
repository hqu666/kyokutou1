using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// サービス設定
	/// </summary>
	public partial class ServiceSettings
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
		///仮パスワード有効時間 :分
		///</summary>
		private int _temporary_password_limit;
		public int temporary_password_limit
		{
			get => _temporary_password_limit;
			set
			{
				if (_temporary_password_limit == value)
					return;
				_temporary_password_limit = value;
			}
		}

		///<summary>
		///データ取込同時実行数 :人
		///</summary>
		private int _concurrent_executions_limit;
		public int concurrent_executions_limit
		{
			get => _concurrent_executions_limit;
			set
			{
				if (_concurrent_executions_limit == value)
					return;
				_concurrent_executions_limit = value;
			}
		}

		///<summary>
		///データ取込最大ファイルサイズ :KB単位
		///</summary>
		private int _data_import_max_file_size;
		public int data_import_max_file_size
		{
			get => _data_import_max_file_size;
			set
			{
				if (_data_import_max_file_size == value)
					return;
				_data_import_max_file_size = value;
			}
		}

		///<summary>
		///単価掛率設定得意先最大件数
		///</summary>
		private int _supplier_price_rates_max_count;
		public int supplier_price_rates_max_count
		{
			get => _supplier_price_rates_max_count;
			set
			{
				if (_supplier_price_rates_max_count == value)
					return;
				_supplier_price_rates_max_count = value;
			}
		}

		///<summary>
		///単価掛率設定商品最大件数
		///</summary>
		private int _product_price_rates_max_count;
		public int product_price_rates_max_count
		{
			get => _product_price_rates_max_count;
			set
			{
				if (_product_price_rates_max_count == value)
					return;
				_product_price_rates_max_count = value;
			}
		}

		///<summary>
		///システムメンテナンスモードフラグ :0：Off、1：On
		///</summary>
		private int _is_maintenance;
		public int is_maintenance
		{
			get => _is_maintenance;
			set
			{
				if (_is_maintenance == value)
					return;
				_is_maintenance = value;
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


	public class ServiceSettingsCollection : ObservableCollection<ServiceSettings> {
		public ServiceSettingsCollection(){
		}
	}
}
