using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �o�����
	/// </summary>
	public partial class t_payment_lumps : NotificationObject
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
		///�o��No
		///</summary>
		private int _withdrawal_no;
		public int withdrawal_no
		{
			get => _withdrawal_no;
			set
			{
				if (_withdrawal_no == value)
					return;
				_withdrawal_no = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o����
		///</summary>
		private DateTime _withdrawal_date;
		public DateTime withdrawal_date
		{
			get => _withdrawal_date;
			set
			{
				if (_withdrawal_date == value)
					return;
				_withdrawal_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�d����ID :=�����}�X�^.ID
		///</summary>
		private int _m_suppliers_id;
		public int m_suppliers_id
		{
			get => _m_suppliers_id;
			set
			{
				if (_m_suppliers_id == value)
					return;
				_m_suppliers_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���ВS����ID :=���ВS���҃}�X�^.ID
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
		///�o���z���v
		///</summary>
		private decimal _withdrawal_amount_sum;
		public decimal withdrawal_amount_sum
		{
			get => _withdrawal_amount_sum;
			set
			{
				if (_withdrawal_amount_sum == value)
					return;
				_withdrawal_amount_sum = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����z���v
		///</summary>
		private decimal _adjustment_amount_sum;
		public decimal adjustment_amount_sum
		{
			get => _adjustment_amount_sum;
			set
			{
				if (_adjustment_amount_sum == value)
					return;
				_adjustment_amount_sum = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o�����z
		///</summary>
		private decimal _withdrawal_total_amount;
		public decimal withdrawal_total_amount
		{
			get => _withdrawal_total_amount;
			set
			{
				if (_withdrawal_total_amount == value)
					return;
				_withdrawal_total_amount = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��1�F�敪 :���Œ�l�F�o���敪
		///</summary>
		private int _kubun_1;
		public int kubun_1
		{
			get => _kubun_1;
			set
			{
				if (_kubun_1 == value)
					return;
				_kubun_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��1�F�o���z
		///</summary>
		private decimal _withdrawal_amount_1;
		public decimal withdrawal_amount_1
		{
			get => _withdrawal_amount_1;
			set
			{
				if (_withdrawal_amount_1 == value)
					return;
				_withdrawal_amount_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��1�F�U���萔��
		///</summary>
		private decimal _transfer_fee_1;
		public decimal transfer_fee_1
		{
			get => _transfer_fee_1;
			set
			{
				if (_transfer_fee_1 == value)
					return;
				_transfer_fee_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��1�F�����z
		///</summary>
		private decimal _adjustment_amount_1;
		public decimal adjustment_amount_1
		{
			get => _adjustment_amount_1;
			set
			{
				if (_adjustment_amount_1 == value)
					return;
				_adjustment_amount_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��1�F�戵��sID
		///</summary>
		private int _handling_bank_id1;
		public int handling_bank_id1
		{
			get => _handling_bank_id1;
			set
			{
				if (_handling_bank_id1 == value)
					return;
				_handling_bank_id1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��1�F��`����
		///</summary>
		private DateTime _bill_deadline_1;
		public DateTime bill_deadline_1
		{
			get => _bill_deadline_1;
			set
			{
				if (_bill_deadline_1 == value)
					return;
				_bill_deadline_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��1�F���l
		///</summary>
		private string _recital_1;
		public string recital_1
		{
			get => _recital_1;
			set
			{
				if (_recital_1 == value)
					return;
				_recital_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��1�F�o�����v
		///</summary>
		private decimal _withdrawal_total_1;
		public decimal withdrawal_total_1
		{
			get => _withdrawal_total_1;
			set
			{
				if (_withdrawal_total_1 == value)
					return;
				_withdrawal_total_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��2�F�敪 :���Œ�l�F�o���敪
		///</summary>
		private int _kubun_2;
		public int kubun_2
		{
			get => _kubun_2;
			set
			{
				if (_kubun_2 == value)
					return;
				_kubun_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��2�F�o���z
		///</summary>
		private decimal _withdrawal_amount_2;
		public decimal withdrawal_amount_2
		{
			get => _withdrawal_amount_2;
			set
			{
				if (_withdrawal_amount_2 == value)
					return;
				_withdrawal_amount_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��2�F�U���萔��
		///</summary>
		private decimal _transfer_fee_2;
		public decimal transfer_fee_2
		{
			get => _transfer_fee_2;
			set
			{
				if (_transfer_fee_2 == value)
					return;
				_transfer_fee_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��2�F�����z
		///</summary>
		private decimal _adjustment_amount_2;
		public decimal adjustment_amount_2
		{
			get => _adjustment_amount_2;
			set
			{
				if (_adjustment_amount_2 == value)
					return;
				_adjustment_amount_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��2�F�戵��sID
		///</summary>
		private int _handling_bank_id2;
		public int handling_bank_id2
		{
			get => _handling_bank_id2;
			set
			{
				if (_handling_bank_id2 == value)
					return;
				_handling_bank_id2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��2�F��`����
		///</summary>
		private DateTime _bill_deadline_2;
		public DateTime bill_deadline_2
		{
			get => _bill_deadline_2;
			set
			{
				if (_bill_deadline_2 == value)
					return;
				_bill_deadline_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��2�F���l
		///</summary>
		private string _recital_2;
		public string recital_2
		{
			get => _recital_2;
			set
			{
				if (_recital_2 == value)
					return;
				_recital_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��2�F�o�����v
		///</summary>
		private decimal _withdrawal_total_2;
		public decimal withdrawal_total_2
		{
			get => _withdrawal_total_2;
			set
			{
				if (_withdrawal_total_2 == value)
					return;
				_withdrawal_total_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��3�F�敪 :���Œ�l�F�o���敪
		///</summary>
		private int _kubun_3;
		public int kubun_3
		{
			get => _kubun_3;
			set
			{
				if (_kubun_3 == value)
					return;
				_kubun_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��3�F�o���z
		///</summary>
		private decimal _withdrawal_amount_3;
		public decimal withdrawal_amount_3
		{
			get => _withdrawal_amount_3;
			set
			{
				if (_withdrawal_amount_3 == value)
					return;
				_withdrawal_amount_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��3�F�U���萔��
		///</summary>
		private decimal _transfer_fee_3;
		public decimal transfer_fee_3
		{
			get => _transfer_fee_3;
			set
			{
				if (_transfer_fee_3 == value)
					return;
				_transfer_fee_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��3�F�����z
		///</summary>
		private decimal _adjustment_amount_3;
		public decimal adjustment_amount_3
		{
			get => _adjustment_amount_3;
			set
			{
				if (_adjustment_amount_3 == value)
					return;
				_adjustment_amount_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��3�F�戵��sID
		///</summary>
		private int _handling_bank_id3;
		public int handling_bank_id3
		{
			get => _handling_bank_id3;
			set
			{
				if (_handling_bank_id3 == value)
					return;
				_handling_bank_id3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��3�F��`����
		///</summary>
		private DateTime _bill_deadline_3;
		public DateTime bill_deadline_3
		{
			get => _bill_deadline_3;
			set
			{
				if (_bill_deadline_3 == value)
					return;
				_bill_deadline_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��3�F���l
		///</summary>
		private string _recital_3;
		public string recital_3
		{
			get => _recital_3;
			set
			{
				if (_recital_3 == value)
					return;
				_recital_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�o��3�F�o�����v
		///</summary>
		private decimal _withdrawal_total_3;
		public decimal withdrawal_total_3
		{
			get => _withdrawal_total_3;
			set
			{
				if (_withdrawal_total_3 == value)
					return;
				_withdrawal_total_3 = value;
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
		///�m��� :�m�菈�����s��ꂽ��
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


	public class t_payment_lumpsCollection : ObservableCollection<t_payment_lumps> {
		public t_payment_lumpsCollection(){
		}
	}
}
