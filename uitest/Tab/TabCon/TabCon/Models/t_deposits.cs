using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// 入金情報
	/// </summary>
	public partial class t_deposits : NotificationObject
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
		///入金方法 :0：個別、1：一括
		///</summary>
		private int _deposit_method;
		public int deposit_method
		{
			get => _deposit_method;
			set
			{
				if (_deposit_method == value)
					return;
				_deposit_method = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金種類 :0：売上、1：前受金
		///</summary>
		private int _deposit_type;
		public int deposit_type
		{
			get => _deposit_type;
			set
			{
				if (_deposit_type == value)
					return;
				_deposit_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金No
		///</summary>
		private int _deposit_code;
		public int deposit_code
		{
			get => _deposit_code;
			set
			{
				if (_deposit_code == value)
					return;
				_deposit_code = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金日
		///</summary>
		private DateTime _deposit_date;
		public DateTime deposit_date
		{
			get => _deposit_date;
			set
			{
				if (_deposit_date == value)
					return;
				_deposit_date = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///得意先ID :=取引先マスタ.ID
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
		///入金額合計
		///</summary>
		private decimal _payment_sum;
		public decimal payment_sum
		{
			get => _payment_sum;
			set
			{
				if (_payment_sum == value)
					return;
				_payment_sum = value;
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
		///入金総額
		///</summary>
		private decimal _total_payment_sum;
		public decimal total_payment_sum
		{
			get => _total_payment_sum;
			set
			{
				if (_total_payment_sum == value)
					return;
				_total_payment_sum = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金1：区分 :※固定値：入金区分
		///</summary>
		private int _deposit_classification_1;
		public int deposit_classification_1
		{
			get => _deposit_classification_1;
			set
			{
				if (_deposit_classification_1 == value)
					return;
				_deposit_classification_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金1：入金額
		///</summary>
		private decimal _deposit_amount_1;
		public decimal deposit_amount_1
		{
			get => _deposit_amount_1;
			set
			{
				if (_deposit_amount_1 == value)
					return;
				_deposit_amount_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金1：振込手数料
		///</summary>
		private decimal _transfer_commission_1;
		public decimal transfer_commission_1
		{
			get => _transfer_commission_1;
			set
			{
				if (_transfer_commission_1 == value)
					return;
				_transfer_commission_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金1：調整額
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
		///入金1：取扱銀行ID
		///</summary>
		private int _m_bank_id_1;
		public int m_bank_id_1
		{
			get => _m_bank_id_1;
			set
			{
				if (_m_bank_id_1 == value)
					return;
				_m_bank_id_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金1：手形期日
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
		///入金1：備考
		///</summary>
		private string _note_1;
		public string note_1
		{
			get => _note_1;
			set
			{
				if (_note_1 == value)
					return;
				_note_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金1：入金合計
		///</summary>
		private decimal _total_payment_1;
		public decimal total_payment_1
		{
			get => _total_payment_1;
			set
			{
				if (_total_payment_1 == value)
					return;
				_total_payment_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金2：区分 :※固定値：入金区分
		///</summary>
		private int _deposit_classification_2;
		public int deposit_classification_2
		{
			get => _deposit_classification_2;
			set
			{
				if (_deposit_classification_2 == value)
					return;
				_deposit_classification_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金2：入金額
		///</summary>
		private decimal _deposit_amount_2;
		public decimal deposit_amount_2
		{
			get => _deposit_amount_2;
			set
			{
				if (_deposit_amount_2 == value)
					return;
				_deposit_amount_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金2：振込手数料
		///</summary>
		private decimal _transfer_commission_2;
		public decimal transfer_commission_2
		{
			get => _transfer_commission_2;
			set
			{
				if (_transfer_commission_2 == value)
					return;
				_transfer_commission_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金2：調整額
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
		///入金2：取扱銀行ID
		///</summary>
		private int _m_bank_id_2;
		public int m_bank_id_2
		{
			get => _m_bank_id_2;
			set
			{
				if (_m_bank_id_2 == value)
					return;
				_m_bank_id_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金2：手形期日
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
		///入金2：備考
		///</summary>
		private string _note_2;
		public string note_2
		{
			get => _note_2;
			set
			{
				if (_note_2 == value)
					return;
				_note_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金2：入金合計
		///</summary>
		private decimal _total_payment_2;
		public decimal total_payment_2
		{
			get => _total_payment_2;
			set
			{
				if (_total_payment_2 == value)
					return;
				_total_payment_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金3：区分 :※固定値：入金区分
		///</summary>
		private int _deposit_classification_3;
		public int deposit_classification_3
		{
			get => _deposit_classification_3;
			set
			{
				if (_deposit_classification_3 == value)
					return;
				_deposit_classification_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金3：入金額
		///</summary>
		private decimal _deposit_amount_3;
		public decimal deposit_amount_3
		{
			get => _deposit_amount_3;
			set
			{
				if (_deposit_amount_3 == value)
					return;
				_deposit_amount_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金3：振込手数料
		///</summary>
		private decimal _transfer_commission_3;
		public decimal transfer_commission_3
		{
			get => _transfer_commission_3;
			set
			{
				if (_transfer_commission_3 == value)
					return;
				_transfer_commission_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金3：調整額
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
		///入金3：取扱銀行ID
		///</summary>
		private int _m_bank_id_3;
		public int m_bank_id_3
		{
			get => _m_bank_id_3;
			set
			{
				if (_m_bank_id_3 == value)
					return;
				_m_bank_id_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金3：手形期日
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
		///入金3：備考
		///</summary>
		private string _note_3;
		public string note_3
		{
			get => _note_3;
			set
			{
				if (_note_3 == value)
					return;
				_note_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///入金3：入金合計
		///</summary>
		private decimal _total_payment_3;
		public decimal total_payment_3
		{
			get => _total_payment_3;
			set
			{
				if (_total_payment_3 == value)
					return;
				_total_payment_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///請求締対象日
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


	public class t_depositsCollection : ObservableCollection<t_deposits> {
		public t_depositsCollection(){
		}
	}
}
