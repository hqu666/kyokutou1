using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �Č����`�[�i�󒍐����w�b�_�j
	/// </summary>
	public partial class t_project_slip_sale_headers : NotificationObject
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
		///�Č�����{ID :=�Č�����{.ID
		///</summary>
		private int _t_project_base_id;
		public int t_project_base_id
		{
			get => _t_project_base_id;
			set
			{
				if (_t_project_base_id == value)
					return;
				_t_project_base_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�󒍓�
		///</summary>
		private DateTime _order_date;
		public DateTime order_date
		{
			get => _order_date;
			set
			{
				if (_order_date == value)
					return;
				_order_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�������
		///</summary>
		private string _trading_condition;
		public string trading_condition
		{
			get => _trading_condition;
			set
			{
				if (_trading_condition == value)
					return;
				_trading_condition = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�E�v
		///</summary>
		private string _summary;
		public string summary
		{
			get => _summary;
			set
			{
				if (_summary == value)
					return;
				_summary = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���v���z�i�Ŕ��j
		///</summary>
		private decimal _total_amount;
		public decimal total_amount
		{
			get => _total_amount;
			set
			{
				if (_total_amount == value)
					return;
				_total_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����ŋ��z
		///</summary>
		private decimal _tax_amount;
		public decimal tax_amount
		{
			get => _tax_amount;
			set
			{
				if (_tax_amount == value)
					return;
				_tax_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����ŋ��z(�y���ŗ��Ώ�)
		///</summary>
		private decimal _reduction_tax_amount;
		public decimal reduction_tax_amount
		{
			get => _reduction_tax_amount;
			set
			{
				if (_reduction_tax_amount == value)
					return;
				_reduction_tax_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���v���z�i�ō��j
		///</summary>
		private decimal _total_amount_tax_included;
		public decimal total_amount_tax_included
		{
			get => _total_amount_tax_included;
			set
			{
				if (_total_amount_tax_included == value)
					return;
				_total_amount_tax_included = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����^�u�@���z
		///</summary>
		private int _cost_tab_1_amount;
		public int cost_tab_1_amount
		{
			get => _cost_tab_1_amount;
			set
			{
				if (_cost_tab_1_amount == value)
					return;
				_cost_tab_1_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����^�u�A���z
		///</summary>
		private int _cost_tab_2_amount;
		public int cost_tab_2_amount
		{
			get => _cost_tab_2_amount;
			set
			{
				if (_cost_tab_2_amount == value)
					return;
				_cost_tab_2_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����^�u�B���z
		///</summary>
		private int _cost_tab_3_amount;
		public int cost_tab_3_amount
		{
			get => _cost_tab_3_amount;
			set
			{
				if (_cost_tab_3_amount == value)
					return;
				_cost_tab_3_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�������v���z
		///</summary>
		private int _cost_total_amount;
		public int cost_total_amount
		{
			get => _cost_total_amount;
			set
			{
				if (_cost_total_amount == value)
					return;
				_cost_total_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�l�����z
		///</summary>
		private int _discount_amount;
		public int discount_amount
		{
			get => _discount_amount;
			set
			{
				if (_discount_amount == value)
					return;
				_discount_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Č��e����
		///</summary>
		private decimal _project_gross_profit_rate;
		public decimal project_gross_profit_rate
		{
			get => _project_gross_profit_rate;
			set
			{
				if (_project_gross_profit_rate == value)
					return;
				_project_gross_profit_rate = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Č��e�����z
		///</summary>
		private int _project_gross_profit_amount;
		public int project_gross_profit_amount
		{
			get => _project_gross_profit_amount;
			set
			{
				if (_project_gross_profit_amount == value)
					return;
				_project_gross_profit_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���ϘJ����z
		///</summary>
		private decimal _average_labor_cost_amount;
		public decimal average_labor_cost_amount
		{
			get => _average_labor_cost_amount;
			set
			{
				if (_average_labor_cost_amount == value)
					return;
				_average_labor_cost_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���ϕ��|��
		///</summary>
		private decimal _average_productivity_rate;
		public decimal average_productivity_rate
		{
			get => _average_productivity_rate;
			set
			{
				if (_average_productivity_rate == value)
					return;
				_average_productivity_rate = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Љ�ی�����
		///</summary>
		private decimal _social_insurance_charge_rate;
		public decimal social_insurance_charge_rate
		{
			get => _social_insurance_charge_rate;
			set
			{
				if (_social_insurance_charge_rate == value)
					return;
				_social_insurance_charge_rate = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�@�蕟����z
		///</summary>
		private decimal _legal_welfare_expenses_amount;
		public decimal legal_welfare_expenses_amount
		{
			get => _legal_welfare_expenses_amount;
			set
			{
				if (_legal_welfare_expenses_amount == value)
					return;
				_legal_welfare_expenses_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����U������
		///</summary>
		private int _billing_transfer_target_information;
		public int billing_transfer_target_information
		{
			get => _billing_transfer_target_information;
			set
			{
				if (_billing_transfer_target_information == value)
					return;
				_billing_transfer_target_information = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���b�N�t���O :0�F�����b�N�A1�F���b�N��
		///</summary>
		private bool _lock_flag;
		public bool lock_flag
		{
			get => _lock_flag;
			set
			{
				if (_lock_flag == value)
					return;
				_lock_flag = value;
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


	public class t_project_slip_sale_headersCollection : ObservableCollection<t_project_slip_sale_headers> {
		public t_project_slip_sale_headersCollection(){
		}
	}
}