using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// Äîñ`[i¿¾×wb_j
	/// </summary>
	public partial class ProjectSlipInvoiceHeaders
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
		///_ñID :=_ñ}X^.ID
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
			}
		}

		///<summary>
		///Äîñî{ID :=Äîñî{.ID
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
			}
		}

		///<summary>
		///Xe[^Xú
		///</summary>
		private DateTime _status_date;
		public DateTime status_date
		{
			get => _status_date;
			set
			{
				if (_status_date == value)
					return;
				_status_date = value;
			}
		}

		///<summary>
		///[üæID :=æøæ}X^.ID@i¾Óæj
		///</summary>
		private int _d_m_supplier_id;
		public int d_m_supplier_id
		{
			get => _d_m_supplier_id;
			set
			{
				if (_d_m_supplier_id == value)
					return;
				_d_m_supplier_id = value;
			}
		}

		///<summary>
		///[üæFXÖÔ
		///</summary>
		private string _d_postal_code;
		public string d_postal_code
		{
			get => _d_postal_code;
			set
			{
				if (_d_postal_code == value)
					return;
				_d_postal_code = value;
			}
		}

		///<summary>
		///[üæFs¹{§hc :=s¹{§}X^.ID
		///</summary>
		private int _d_m_prefecture_id;
		public int d_m_prefecture_id
		{
			get => _d_m_prefecture_id;
			set
			{
				if (_d_m_prefecture_id == value)
					return;
				_d_m_prefecture_id = value;
			}
		}

		///<summary>
		///[üæFZP
		///</summary>
		private string _d_address_1;
		public string d_address_1
		{
			get => _d_address_1;
			set
			{
				if (_d_address_1 == value)
					return;
				_d_address_1 = value;
			}
		}

		///<summary>
		///[üæFZQ
		///</summary>
		private string _d_address_2;
		public string d_address_2
		{
			get => _d_address_2;
			set
			{
				if (_d_address_2 == value)
					return;
				_d_address_2 = value;
			}
		}

		///<summary>
		///æøð
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
			}
		}

		///<summary>
		///Ev
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
			}
		}

		///<summary>
		///vàziÅ²j
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
			}
		}

		///<summary>
		///ÁïÅàz
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
			}
		}

		///<summary>
		///vàziÅj
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
			}
		}

		///<summary>
		///løàz
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
			}
		}

		///<summary>
		///Äe¦
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
			}
		}

		///<summary>
		///Äeàz
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
			}
		}

		///<summary>
		///¿Uæîñ :=Uæ}X^DID
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
			}
		}

		///<summary>
		///üà®¹tO :0F¢®¹A1F®¹
		///</summary>
		private bool _payment_complete_flag;
		public bool payment_complete_flag
		{
			get => _payment_complete_flag;
			set
			{
				if (_payment_complete_flag == value)
					return;
				_payment_complete_flag = value;
			}
		}

		///<summary>
		///bNtO :0F¢bNA1FbN
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
			}
		}

		///<summary>
		///¿÷ÎÛú
		///</summary>
		private DateTime _billing_closing_target_date;
		public DateTime billing_closing_target_date
		{
			get => _billing_closing_target_date;
			set
			{
				if (_billing_closing_target_date == value)
					return;
				_billing_closing_target_date = value;
			}
		}

		///<summary>
		///¿­stO :0F¢­sA1F­sÏ
		///</summary>
		private int _billing_issue_flag;
		public int billing_issue_flag
		{
			get => _billing_issue_flag;
			set
			{
				if (_billing_issue_flag == value)
					return;
				_billing_issue_flag = value;
			}
		}

		///<summary>
		///¿­sú
		///</summary>
		private DateTime _billing_issue_date;
		public DateTime billing_issue_date
		{
			get => _billing_issue_date;
			set
			{
				if (_billing_issue_date == value)
					return;
				_billing_issue_date = value;
			}
		}

		///<summary>
		///ì¬Ò
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
		///ì¬ú
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
		///XVÒ
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
		///XVú
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
		///íú
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


	public class ProjectSlipInvoiceHeadersCollection : ObservableCollection<ProjectSlipInvoiceHeaders> {
		public ProjectSlipInvoiceHeadersCollection(){
		}
	}
}
