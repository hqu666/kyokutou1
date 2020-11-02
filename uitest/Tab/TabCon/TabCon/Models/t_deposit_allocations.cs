using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �������U���
	/// </summary>
	public partial class t_deposit_allocations : NotificationObject
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
		///�������ID :=�������i�ꊇ�j.ID
		///</summary>
		private int _t_deposit_id;
		public int t_deposit_id
		{
			get => _t_deposit_id;
			set
			{
				if (_t_deposit_id == value)
					return;
				_t_deposit_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Č�ID :=�Č�����{.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�������׃w�b�_ID :=�Č���񐿋����׃w�b�_.ID
		///</summary>
		private int _t_project_slip_invoice_header_id;
		public int t_project_slip_invoice_header_id
		{
			get => _t_project_slip_invoice_header_id;
			set
			{
				if (_t_project_slip_invoice_header_id == value)
					return;
				_t_project_slip_invoice_header_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���U�z
		///</summary>
		private decimal _allocations_amount;
		public decimal allocations_amount
		{
			get => _allocations_amount;
			set
			{
				if (_allocations_amount == value)
					return;
				_allocations_amount = value;
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


	public class t_deposit_allocationsCollection : ObservableCollection<t_deposit_allocations> {
		public t_deposit_allocationsCollection(){
		}
	}
}
