using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �x���T�}���[���
	/// </summary>
	public partial class t_payment_summaries : NotificationObject
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
		///�x��No
		///</summary>
		private string _payment_no;
		public string payment_no
		{
			get => _payment_no;
			set
			{
				if (_payment_no == value)
					return;
				_payment_no = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�d����ID :=�����}�X�^.ID
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
		///�w������{ID :=�w������{.ID
		///</summary>
		private int _t_purchase_base_id;
		public int t_purchase_base_id
		{
			get => _t_purchase_base_id;
			set
			{
				if (_t_purchase_base_id == value)
					return;
				_t_purchase_base_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���敪 :���Œ�l�F���敪
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�O��x���z
		///</summary>
		private decimal _last_payment_amount;
		public decimal last_payment_amount
		{
			get => _last_payment_amount;
			set
			{
				if (_last_payment_amount == value)
					return;
				_last_payment_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����o���z
		///</summary>
		private decimal _currenct_withdrawal_amount;
		public decimal currenct_withdrawal_amount
		{
			get => _currenct_withdrawal_amount;
			set
			{
				if (_currenct_withdrawal_amount == value)
					return;
				_currenct_withdrawal_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�J�z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����d���z
		///</summary>
		private decimal _currenct_stocking_amount;
		public decimal currenct_stocking_amount
		{
			get => _currenct_stocking_amount;
			set
			{
				if (_currenct_stocking_amount == value)
					return;
				_currenct_stocking_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����
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
		///�d�����v
		///</summary>
		private int _purchase_sum;
		public int purchase_sum
		{
			get => _purchase_sum;
			set
			{
				if (_purchase_sum == value)
					return;
				_purchase_sum = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����x���z
		///</summary>
		private decimal _currenct_payment_amount;
		public decimal currenct_payment_amount
		{
			get => _currenct_payment_amount;
			set
			{
				if (_currenct_payment_amount == value)
					return;
				_currenct_payment_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�x������
		///</summary>
		private DateTime _payment_closing_date;
		public DateTime payment_closing_date
		{
			get => _payment_closing_date;
			set
			{
				if (_payment_closing_date == value)
					return;
				_payment_closing_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����c���ݒ�t���O :0�F���ߏ�������쐬�A1�F�c���ݒ肩��쐬
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


	public class t_payment_summariesCollection : ObservableCollection<t_payment_summaries> {
		public t_payment_summariesCollection(){
		}
	}
}
