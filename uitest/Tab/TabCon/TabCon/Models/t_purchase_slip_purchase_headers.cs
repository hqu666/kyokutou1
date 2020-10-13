using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �w�����`�[�i�d�����w�b�_�j
	/// </summary>
	public partial class t_purchase_slip_purchase_headers : NotificationObject
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
		///�X�e�[�^�X��
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
		///�x�����Ώۓ�
		///</summary>
		private DateTime _payment_closing_target_date;
		public DateTime payment_closing_target_date
		{
			get => _payment_closing_target_date;
			set
			{
				if (_payment_closing_target_date == value)
					return;
				_payment_closing_target_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�x�������s�t���O :0�F�����s�A1�F���s��
		///</summary>
		private int _payment_form_issuing_flag;
		public int payment_form_issuing_flag
		{
			get => _payment_form_issuing_flag;
			set
			{
				if (_payment_form_issuing_flag == value)
					return;
				_payment_form_issuing_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�x�������s��
		///</summary>
		private DateTime _payment_form_issuing_date;
		public DateTime payment_form_issuing_date
		{
			get => _payment_form_issuing_date;
			set
			{
				if (_payment_form_issuing_date == value)
					return;
				_payment_form_issuing_date = value;
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


	public class t_purchase_slip_purchase_headersCollection : ObservableCollection<t_purchase_slip_purchase_headers> {
		public t_purchase_slip_purchase_headersCollection(){
		}
	}
}
