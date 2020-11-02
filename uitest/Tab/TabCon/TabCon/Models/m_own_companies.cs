using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// ���Џ��}�X�^
	/// </summary>
	public partial class m_own_companies : NotificationObject
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
		///�Ж�������1
		///</summary>
		private string _company_name_1;
		public string company_name_1
		{
			get => _company_name_1;
			set
			{
				if (_company_name_1 == value)
					return;
				_company_name_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Ж�������2
		///</summary>
		private string _company_name_2;
		public string company_name_2
		{
			get => _company_name_2;
			set
			{
				if (_company_name_2 == value)
					return;
				_company_name_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Ж��ȗ���
		///</summary>
		private string _company_short_name;
		public string company_short_name
		{
			get => _company_short_name;
			set
			{
				if (_company_short_name == value)
					return;
				_company_short_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�X�֔ԍ�
		///</summary>
		private string _postal_code;
		public string postal_code
		{
			get => _postal_code;
			set
			{
				if (_postal_code == value)
					return;
				_postal_code = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�s���{�� :=�s���{���}�X�^.ID
		///</summary>
		private int _m_prefecture_id;
		public int m_prefecture_id
		{
			get => _m_prefecture_id;
			set
			{
				if (_m_prefecture_id == value)
					return;
				_m_prefecture_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Z��1
		///</summary>
		private string _address_1;
		public string address_1
		{
			get => _address_1;
			set
			{
				if (_address_1 == value)
					return;
				_address_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Z��2
		///</summary>
		private string _address_2;
		public string address_2
		{
			get => _address_2;
			set
			{
				if (_address_2 == value)
					return;
				_address_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///��\�Җ�
		///</summary>
		private string _representative_name;
		public string representative_name
		{
			get => _representative_name;
			set
			{
				if (_representative_name == value)
					return;
				_representative_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///TEL
		///</summary>
		private string _tell_number;
		public string tell_number
		{
			get => _tell_number;
			set
			{
				if (_tell_number == value)
					return;
				_tell_number = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///FAX
		///</summary>
		private string _fax_number;
		public string fax_number
		{
			get => _fax_number;
			set
			{
				if (_fax_number == value)
					return;
				_fax_number = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Email
		///</summary>
		private string _email;
		public string email
		{
			get => _email;
			set
			{
				if (_email == value)
					return;
				_email = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///URL
		///</summary>
		private string _url_address;
		public string url_address
		{
			get => _url_address;
			set
			{
				if (_url_address == value)
					return;
				_url_address = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���Z��
		///</summary>
		private int _receivable_cclosing_month;
		public int receivable_cclosing_month
		{
			get => _receivable_cclosing_month;
			set
			{
				if (_receivable_cclosing_month == value)
					return;
				_receivable_cclosing_month = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����敪 :���Œ�l�F�����敪
		///</summary>
		private int _closing_date_kubun;
		public int closing_date_kubun
		{
			get => _closing_date_kubun;
			set
			{
				if (_closing_date_kubun == value)
					return;
				_closing_date_kubun = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�x���� :���Œ�l�F�x����
		///</summary>
		private int _payment_month;
		public int payment_month
		{
			get => _payment_month;
			set
			{
				if (_payment_month == value)
					return;
				_payment_month = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�x���� :���Œ�l�F�x����
		///</summary>
		private int _payment_day;
		public int payment_day
		{
			get => _payment_day;
			set
			{
				if (_payment_day == value)
					return;
				_payment_day = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�W���̔��e����
		///</summary>
		private decimal _sales_gross_profit_rate;
		public decimal sales_gross_profit_rate
		{
			get => _sales_gross_profit_rate;
			set
			{
				if (_sales_gross_profit_rate == value)
					return;
				_sales_gross_profit_rate = value;
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
		///���ϓ��z
		///</summary>
		private decimal _average_daily_price;
		public decimal average_daily_price
		{
			get => _average_daily_price;
			set
			{
				if (_average_daily_price == value)
					return;
				_average_daily_price = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���ϘJ���
		///</summary>
		private decimal _average_labor_cost_rate;
		public decimal average_labor_cost_rate
		{
			get => _average_labor_cost_rate;
			set
			{
				if (_average_labor_cost_rate == value)
					return;
				_average_labor_cost_rate = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�^�p�J�n��
		///</summary>
		private DateTime _operation_date_start;
		public DateTime operation_date_start
		{
			get => _operation_date_start;
			set
			{
				if (_operation_date_start == value)
					return;
				_operation_date_start = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o�^�ԍ�
		///</summary>
		private string _registration_number;
		public string registration_number
		{
			get => _registration_number;
			set
			{
				if (_registration_number == value)
					return;
				_registration_number = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���S�C���[�W
		///</summary>
		private string _logo_image;
		public string logo_image
		{
			get => _logo_image;
			set
			{
				if (_logo_image == value)
					return;
				_logo_image = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Google�J�����_�[�ŏI���f����
		///</summary>
		private DateTime _last_application_time;
		public DateTime last_application_time
		{
			get => _last_application_time;
			set
			{
				if (_last_application_time == value)
					return;
				_last_application_time = value;
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


	public class m_own_companiesCollection : ObservableCollection<m_own_companies> {
		public m_own_companiesCollection(){
		}
	}
}
