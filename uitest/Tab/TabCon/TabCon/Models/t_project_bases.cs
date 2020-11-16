using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// ˆÄŒî•ñŠî–{
	/// </summary>
	public partial class t_project_bases : NotificationObject
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
		///Œ_–ñID :=Œ_–ñƒ}ƒXƒ^.ID
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
		///ˆÄŒ”Ô†
		///</summary>
		private string _project_code;
		public string project_code
		{
			get => _project_code;
			set
			{
				if (_project_code == value)
					return;
				_project_code = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ˆÄŒŠÇ—”Ô†
		///</summary>
		private string _project_manage_code;
		public string project_manage_code
		{
			get => _project_manage_code;
			set
			{
				if (_project_manage_code == value)
					return;
				_project_manage_code = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ˆÄŒ–¼
		///</summary>
		private string _project_name;
		public string project_name
		{
			get => _project_name;
			set
			{
				if (_project_name == value)
					return;
				_project_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///•¨ŒID :=•¨Œƒ}ƒXƒ^.ID
		///</summary>
		private int _m_property_id;
		public int m_property_id
		{
			get => _m_property_id;
			set
			{
				if (_m_property_id == value)
					return;
				_m_property_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///”[Šú
		///</summary>
		private DateTime _delivery_date;
		public DateTime delivery_date
		{
			get => _delivery_date;
			set
			{
				if (_delivery_date == value)
					return;
				_delivery_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///—\’èHŠúiFROMj
		///</summary>
		private DateTime _plan_construction_period_from;
		public DateTime plan_construction_period_from
		{
			get => _plan_construction_period_from;
			set
			{
				if (_plan_construction_period_from == value)
					return;
				_plan_construction_period_from = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///—\’èHŠúiTO)
		///</summary>
		private DateTime _plan_construction_period_to;
		public DateTime plan_construction_period_to
		{
			get => _plan_construction_period_to;
			set
			{
				if (_plan_construction_period_to == value)
					return;
				_plan_construction_period_to = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///“¾ˆÓæID :=æˆøæƒ}ƒXƒ^.ID@i“¾ˆÓæj
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///“¾ˆÓæ’S“–ÒID :=æˆøæ•”–å’S“–Òƒ}ƒXƒ^.ID
		///</summary>
		private int _m_supplier_staff_id;
		public int m_supplier_staff_id
		{
			get => _m_supplier_staff_id;
			set
			{
				if (_m_supplier_staff_id == value)
					return;
				_m_supplier_staff_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///{å–¼
		///</summary>
		private string _owner_name;
		public string owner_name
		{
			get => _owner_name;
			set
			{
				if (_owner_name == value)
					return;
				_owner_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///”[“üæID :=æˆøæƒ}ƒXƒ^.ID@i“¾ˆÓæj
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///”[“üæF—X•Ö”Ô†
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///”[“üæF“s“¹•{Œ§‚h‚c
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///”[“üæFZŠ‚P
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///”[“üæFZŠ‚Q
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///”[“üæFŒŸõ—pZŠ
		///</summary>
		private string _d_search_address;
		public string d_search_address
		{
			get => _d_search_address;
			set
			{
				if (_d_search_address == value)
					return;
				_d_search_address = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///•”–åID :=•”–åƒ}ƒXƒ^.ID
		///</summary>
		private int _m_department_id;
		public int m_department_id
		{
			get => _m_department_id;
			set
			{
				if (_m_department_id == value)
					return;
				_m_department_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///©Ğ’S“–ÒID :=©Ğ’S“–Òƒ}ƒXƒ^.ID
		///</summary>
		private int _m_own_company_staff_id;
		public int m_own_company_staff_id
		{
			get => _m_own_company_staff_id;
			set
			{
				if (_m_own_company_staff_id == value)
					return;
				_m_own_company_staff_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///—LŒøŠúŒÀ“ú
		///</summary>
		private DateTime _expiration_date;
		public DateTime expiration_date
		{
			get => _expiration_date;
			set
			{
				if (_expiration_date == value)
					return;
				_expiration_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¿‹—\’è“ú
		///</summary>
		private DateTime _billing_expected_date;
		public DateTime billing_expected_date
		{
			get => _billing_expected_date;
			set
			{
				if (_billing_expected_date == value)
					return;
				_billing_expected_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///‰ÛÅ‹æ•ª
		///</summary>
		private int _tax_classification;
		public int tax_classification
		{
			get => _tax_classification;
			set
			{
				if (_tax_classification == value)
					return;
				_tax_classification = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Å’[”ˆ—
		///</summary>
		private int _tax_fraction_processing;
		public int tax_fraction_processing
		{
			get => _tax_fraction_processing;
			set
			{
				if (_tax_fraction_processing == value)
					return;
				_tax_fraction_processing = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///WŒv‹æ•ª1
		///</summary>
		private int _aggregate_type_1;
		public int aggregate_type_1
		{
			get => _aggregate_type_1;
			set
			{
				if (_aggregate_type_1 == value)
					return;
				_aggregate_type_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///WŒv‹æ•ª2
		///</summary>
		private int _aggregate_type_2;
		public int aggregate_type_2
		{
			get => _aggregate_type_2;
			set
			{
				if (_aggregate_type_2 == value)
					return;
				_aggregate_type_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///WŒv‹æ•ª3
		///</summary>
		private int _aggregate_type_3;
		public int aggregate_type_3
		{
			get => _aggregate_type_3;
			set
			{
				if (_aggregate_type_3 == value)
					return;
				_aggregate_type_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///WŒv‹æ•ª4
		///</summary>
		private int _aggregate_type_4;
		public int aggregate_type_4
		{
			get => _aggregate_type_4;
			set
			{
				if (_aggregate_type_4 == value)
					return;
				_aggregate_type_4 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ƒƒ‚
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///“E—v
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
		///Œ©Ï”jŠü“ú
		///</summary>
		private DateTime _quotation_discard_date;
		public DateTime quotation_discard_date
		{
			get => _quotation_discard_date;
			set
			{
				if (_quotation_discard_date == value)
					return;
				_quotation_discard_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¸’“ú
		///</summary>
		private DateTime _failure_date;
		public DateTime failure_date
		{
			get => _failure_date;
			set
			{
				if (_failure_date == value)
					return;
				_failure_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¸’——RID
		///</summary>
		private string _failure_cause_id;
		public string failure_cause_id
		{
			get => _failure_cause_id;
			set
			{
				if (_failure_cause_id == value)
					return;
				_failure_cause_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///‘Oó‹à
		///</summary>
		private int _advance_payment;
		public int advance_payment
		{
			get => _advance_payment;
			set
			{
				if (_advance_payment == value)
					return;
				_advance_payment = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///‰¼”„ã‹à
		///</summary>
		private int _temporary_sales_money;
		public int temporary_sales_money
		{
			get => _temporary_sales_money;
			set
			{
				if (_temporary_sales_money == value)
					return;
				_temporary_sales_money = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///”„ãŠz
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
		///Á”ïÅ
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
		///”„ã‡Œv :”„ãŠz{Á”ïÅ
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
		///Š„UÏŠz :‚±‚ÌˆÄŒ‚É•R‚Ã‚¯‚ç‚ê‚Ä‚¢‚éŠ„Uƒf[ƒ^‚ÌŠ„UŠz‚Ì‘Šz
		///</summary>
		private decimal _total_allocations_amount;
		public decimal total_allocations_amount
		{
			get => _total_allocations_amount;
			set
			{
				if (_total_allocations_amount == value)
					return;
				_total_allocations_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Š„UcŠz :”„ã‡Œv-Š„UÏŠz
		///</summary>
		private decimal _allocation_remains;
		public decimal allocation_remains
		{
			get => _allocation_remains;
			set
			{
				if (_allocation_remains == value)
					return;
				_allocation_remains = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ˆóüİ’è
		///</summary>
		private int _print_setting;
		public int print_setting
		{
			get => _print_setting;
			set
			{
				if (_print_setting == value)
					return;
				_print_setting = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Šm’è“ú :Šm’èˆ—‚ªs‚í‚ê‚½“ú
		///</summary>
		private DateTime _confirmed_date;
		public DateTime confirmed_date
		{
			get => _confirmed_date;
			set
			{
				if (_confirmed_date == value)
					return;
				_confirmed_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ƒXƒe[ƒ^ƒX :¦ŒÅ’è’lFˆÄŒƒXƒe[ƒ^ƒX
		///</summary>
		private int _status;
		public int status
		{
			get => _status;
			set
			{
				if (_status == value)
					return;
				_status = value;
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ì¬“ú
		///</summary>
		private DateTime? _created_at;
		public DateTime? created_at
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///XV“ú
		///</summary>
		private DateTime? _updated_at;
		public DateTime? updated_at
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
		///íœ“ú
		///</summary>
		private DateTime? _deleted_at;
		public DateTime? deleted_at
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


	public class t_project_basesCollection : ObservableCollection<t_project_bases> {
		public t_project_basesCollection(){
		}
	}
}
