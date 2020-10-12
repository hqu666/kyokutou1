using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// Äîñ`[iev[gwb_j
	/// </summary>
	public partial class ProjectSlipTemplateHeaders
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
		///ev[gR[h
		///</summary>
		private string _template_code;
		public string template_code
		{
			get => _template_code;
			set
			{
				if (_template_code == value)
					return;
				_template_code = value;
			}
		}

		///<summary>
		///ev[g¼
		///</summary>
		private string _template_name;
		public string template_name
		{
			get => _template_name;
			set
			{
				if (_template_name == value)
					return;
				_template_name = value;
			}
		}

		///<summary>
		///^uID
		///</summary>
		private int _tab_id;
		public int tab_id
		{
			get => _tab_id;
			set
			{
				if (_tab_id == value)
					return;
				_tab_id = value;
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
		///½ÏJ±ïz
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
			}
		}

		///<summary>
		///½Ïà|¦
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
			}
		}

		///<summary>
		///ÐïÛ¯¿¦
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
			}
		}

		///<summary>
		///@èïz
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
			}
		}

		///<summary>
		///¿Uæîñ
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


	public class ProjectSlipTemplateHeadersCollection : ObservableCollection<ProjectSlipTemplateHeaders> {
		public ProjectSlipTemplateHeadersCollection(){
		}
	}
}
