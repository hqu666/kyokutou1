using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// ¿T}[îñ
	/// </summary>
	public partial class BillingSummaries
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
		///¿No
		///</summary>
		private string _billing_no;
		public string billing_no
		{
			get => _billing_no;
			set
			{
				if (_billing_no == value)
					return;
				_billing_no = value;
			}
		}

		///<summary>
		///¾ÓæID :=æøæ}X^.ID
		///</summary>
		private int _m_supplier_id;
		public int m_supplier_id
		{
			get => _m_supplier_id;
			set
			{
				if (_m_supplier_id == value)
					return;
				_m_supplier_id = value;
			}
		}

		///<summary>
		///ÄID :=Äîñî{.ID
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
		///÷æª :¦ÅèlF÷æª
		///</summary>
		private int _closing_kubun;
		public int closing_kubun
		{
			get => _closing_kubun;
			set
			{
				if (_closing_kubun == value)
					return;
				_closing_kubun = value;
			}
		}

		///<summary>
		///Oñ¿z
		///</summary>
		private decimal _last_billing_amount;
		public decimal last_billing_amount
		{
			get => _last_billing_amount;
			set
			{
				if (_last_billing_amount == value)
					return;
				_last_billing_amount = value;
			}
		}

		///<summary>
		///¡ñüàz
		///</summary>
		private decimal _payment_amount;
		public decimal payment_amount
		{
			get => _payment_amount;
			set
			{
				if (_payment_amount == value)
					return;
				_payment_amount = value;
			}
		}

		///<summary>
		///Jzz
		///</summary>
		private int _brought_forward_amount;
		public int brought_forward_amount
		{
			get => _brought_forward_amount;
			set
			{
				if (_brought_forward_amount == value)
					return;
				_brought_forward_amount = value;
			}
		}

		///<summary>
		///¡ñãz
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
		///ÁïÅ
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
		///ãv
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
		///¡ñ¿z
		///</summary>
		private decimal _billing_amount;
		public decimal billing_amount
		{
			get => _billing_amount;
			set
			{
				if (_billing_amount == value)
					return;
				_billing_amount = value;
			}
		}

		///<summary>
		///¿÷ú
		///</summary>
		private DateTime _billing_closing_date;
		public DateTime billing_closing_date
		{
			get => _billing_closing_date;
			set
			{
				if (_billing_closing_date == value)
					return;
				_billing_closing_date = value;
			}
		}

		///<summary>
		///ñcÝètO :0F÷ß©çì¬A1FcÝè©çì¬
		///</summary>
		private int _first_balance_setting_flag;
		public int first_balance_setting_flag
		{
			get => _first_balance_setting_flag;
			set
			{
				if (_first_balance_setting_flag == value)
					return;
				_first_balance_setting_flag = value;
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


	public class BillingSummariesCollection : ObservableCollection<BillingSummaries> {
		public BillingSummariesCollection(){
		}
	}
}
