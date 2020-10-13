using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// 出金情報
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
		///契約ID :=契約マスタ.ID
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
		///出金No
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
		///出金日
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
		///仕入先ID :=取引先マスタ.ID
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
		///自社担当者ID :=自社担当者マスタ.ID
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
		///出金額合計
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
		///調整額合計
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
		///出金総額
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
		///出金1：区分 :※固定値：出金区分
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
		///出金1：出金額
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
		///出金1：振込手数料
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
		///出金1：調整額
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
		///出金1：取扱銀行ID
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
		///出金1：手形期日
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
		///出金1：備考
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
		///出金1：出金合計
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
		///出金2：区分 :※固定値：出金区分
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
		///出金2：出金額
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
		///出金2：振込手数料
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
		///出金2：調整額
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
		///出金2：取扱銀行ID
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
		///出金2：手形期日
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
		///出金2：備考
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
		///出金2：出金合計
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
		///出金3：区分 :※固定値：出金区分
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
		///出金3：出金額
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
		///出金3：振込手数料
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
		///出金3：調整額
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
		///出金3：取扱銀行ID
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
		///出金3：手形期日
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
		///出金3：備考
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
		///出金3：出金合計
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
		///支払締対象日
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
		///確定日 :確定処理が行われた日
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
		///ロックフラグ :0：未ロック、1：ロック中
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
		///作成者
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
		///作成日時
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
		///更新者
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
		///更新日時
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
		///削除日時
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
