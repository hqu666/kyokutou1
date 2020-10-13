using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// 購買情報伝票（仕入書ヘッダ）
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
		///購買情報基本ID :=購買情報基本.ID
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
		///ステータス日
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
		///摘要
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
		///合計金額（税抜）
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
		///消費税金額
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
		///消費税金額(軽減税率対象)
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
		///合計金額（税込）
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
		///値引金額
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
		///支払書発行フラグ :0：未発行、1：発行済
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
		///支払書発行日
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


	public class t_purchase_slip_purchase_headersCollection : ObservableCollection<t_purchase_slip_purchase_headers> {
		public t_purchase_slip_purchase_headersCollection(){
		}
	}
}
