using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �T�[�r�X�ݒ�
	/// </summary>
	public partial class m_service_settings : NotificationObject
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
		///���p�X���[�h�L������ :��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�f�[�^�捞�������s�� :�l
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�f�[�^�捞�ő�t�@�C���T�C�Y :KB�P��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�P���|���ݒ蓾�Ӑ�ő匏��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�P���|���ݒ菤�i�ő匏��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�V�X�e�������e�i���X���[�h�t���O :0�FOff�A1�FOn
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�쐬��
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
		///�쐬����
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
		///�X�V��
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
		///�X�V����
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
		///�폜����
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


	public class m_service_settingsCollection : ObservableCollection<m_service_settings> {
		public m_service_settingsCollection(){
		}
	}
}
