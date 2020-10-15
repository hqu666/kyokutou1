using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �V�X�e���ݒ�
	/// </summary>
	public partial class m_system_settings : NotificationObject
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
		///�_��ID :=�_��}�X�^.ID
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
		///�����^�u����1
		///</summary>
		private string _cost_tab_name1;
		public string cost_tab_name1
		{
			get => _cost_tab_name1;
			set
			{
				if (_cost_tab_name1 == value)
					return;
				_cost_tab_name1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����^�u����2
		///</summary>
		private string _cost_tab_name2;
		public string cost_tab_name2
		{
			get => _cost_tab_name2;
			set
			{
				if (_cost_tab_name2 == value)
					return;
				_cost_tab_name2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����^�u����3
		///</summary>
		private string _cost_tab_name3;
		public string cost_tab_name3
		{
			get => _cost_tab_name3;
			set
			{
				if (_cost_tab_name3 == value)
					return;
				_cost_tab_name3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�`�[�w�b�_�W�v�敪����1
		///</summary>
		private string _slip_header_aggregate_name1;
		public string slip_header_aggregate_name1
		{
			get => _slip_header_aggregate_name1;
			set
			{
				if (_slip_header_aggregate_name1 == value)
					return;
				_slip_header_aggregate_name1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�`�[�w�b�_�W�v�敪����2
		///</summary>
		private string _slip_header_aggregate_name2;
		public string slip_header_aggregate_name2
		{
			get => _slip_header_aggregate_name2;
			set
			{
				if (_slip_header_aggregate_name2 == value)
					return;
				_slip_header_aggregate_name2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�`�[�w�b�_�W�v�敪����3
		///</summary>
		private string _slip_header_aggregate_name3;
		public string slip_header_aggregate_name3
		{
			get => _slip_header_aggregate_name3;
			set
			{
				if (_slip_header_aggregate_name3 == value)
					return;
				_slip_header_aggregate_name3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�`�[�w�b�_�W�v�敪����4
		///</summary>
		private string _slip_header_aggregate_name4;
		public string slip_header_aggregate_name4
		{
			get => _slip_header_aggregate_name4;
			set
			{
				if (_slip_header_aggregate_name4 == value)
					return;
				_slip_header_aggregate_name4 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���i�}�X�^�W�v�敪����1
		///</summary>
		private string _product_aggregate_name1;
		public string product_aggregate_name1
		{
			get => _product_aggregate_name1;
			set
			{
				if (_product_aggregate_name1 == value)
					return;
				_product_aggregate_name1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���i�}�X�^�W�v�敪����2
		///</summary>
		private string _product_aggregate_name2;
		public string product_aggregate_name2
		{
			get => _product_aggregate_name2;
			set
			{
				if (_product_aggregate_name2 == value)
					return;
				_product_aggregate_name2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ڋq�}�X�^�W�v�敪����1
		///</summary>
		private string _client_aggregate_name1;
		public string client_aggregate_name1
		{
			get => _client_aggregate_name1;
			set
			{
				if (_client_aggregate_name1 == value)
					return;
				_client_aggregate_name1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ڋq�}�X�^�W�v�敪����2
		///</summary>
		private string _client_aggregate_name2;
		public string client_aggregate_name2
		{
			get => _client_aggregate_name2;
			set
			{
				if (_client_aggregate_name2 == value)
					return;
				_client_aggregate_name2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ڋq�}�X�^�W�v�敪����3
		///</summary>
		private string _client_aggregate_name3;
		public string client_aggregate_name3
		{
			get => _client_aggregate_name3;
			set
			{
				if (_client_aggregate_name3 == value)
					return;
				_client_aggregate_name3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ڋq�}�X�^�W�v�敪����4
		///</summary>
		private string _client_aggregate_name4;
		public string client_aggregate_name4
		{
			get => _client_aggregate_name4;
			set
			{
				if (_client_aggregate_name4 == value)
					return;
				_client_aggregate_name4 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ڋq�}�X�^�W�v�敪����5
		///</summary>
		private string _client_aggregate_name5;
		public string client_aggregate_name5
		{
			get => _client_aggregate_name5;
			set
			{
				if (_client_aggregate_name5 == value)
					return;
				_client_aggregate_name5 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����Ǘ��t���O :0�F�g�p���Ȃ��A1�F�g�p����
		///</summary>
		private int _property_management_flag;
		public int property_management_flag
		{
			get => _property_management_flag;
			set
			{
				if (_property_management_flag == value)
					return;
				_property_management_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����t���O :0�F�g�p���Ȃ��A1�F�g�p����
		///</summary>
		private int _cost_function_flag;
		public int cost_function_flag
		{
			get => _cost_function_flag;
			set
			{
				if (_cost_function_flag == value)
					return;
				_cost_function_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�v�ڋ@�\�t���O
		///</summary>
		private int _width_function_flag;
		public int width_function_flag
		{
			get => _width_function_flag;
			set
			{
				if (_width_function_flag == value)
					return;
				_width_function_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����t���O :0�F���喳���A1�F���傠��
		///</summary>
		private int _department_flag;
		public int department_flag
		{
			get => _department_flag;
			set
			{
				if (_department_flag == value)
					return;
				_department_flag = value;
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
		///���[�g�p�X :�Č���{���(ks009)��A�����}�X�^(ks022)�́u�t�@�C���Y�t�v��Google�A�g���Ă��Ȃ���
		///</summary>
		private string _root_path;
		public string root_path
		{
			get => _root_path;
			set
			{
				if (_root_path == value)
					return;
				_root_path = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ߏ蔭���A���[�g����
		///</summary>
		private int _over_order_alert_days;
		public int over_order_alert_days
		{
			get => _over_order_alert_days;
			set
			{
				if (_over_order_alert_days == value)
					return;
				_over_order_alert_days = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�@�蕟����Z�o�̎g�p�t���O :0�F�g�p���Ȃ��A1�F�g�p����
		///</summary>
		private int _legal_welfare_expenses_flag;
		public int legal_welfare_expenses_flag
		{
			get => _legal_welfare_expenses_flag;
			set
			{
				if (_legal_welfare_expenses_flag == value)
					return;
				_legal_welfare_expenses_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�@�蕟����Z�o�̃p�^�[�� :1�FA�p�^�[���A2�FB�p�^�[���A3�FC�p�^�[��
		///</summary>
		private int _legal_welfare_expenses_pattern;
		public int legal_welfare_expenses_pattern
		{
			get => _legal_welfare_expenses_pattern;
			set
			{
				if (_legal_welfare_expenses_pattern == value)
					return;
				_legal_welfare_expenses_pattern = value;
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


	public class m_system_settingsCollection : ObservableCollection<m_system_settings> {
		public m_system_settingsCollection(){
		}
	}
}
