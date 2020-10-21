using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �i��}�X�^
	/// </summary>
	public partial class m_varieties : NotificationObject
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
		///�i��敪 :���Œ�l�F�i��敪
		///</summary>
		private int _variety_type;
		public int variety_type
		{
			get => _variety_type;
			set
			{
				if (_variety_type == value)
					return;
				_variety_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�i��R�[�h
		///</summary>
		private int _variety_code;
		public int variety_code
		{
			get => _variety_code;
			set
			{
				if (_variety_code == value)
					return;
				_variety_code = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�i�햼
		///</summary>
		private string _variety_name;
		public string variety_name
		{
			get => _variety_name;
			set
			{
				if (_variety_name == value)
					return;
				_variety_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���я�
		///</summary>
		private int _order;
		public int order
		{
			get => _order;
			set
			{
				if (_order == value)
					return;
				_order = value;
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


	public class m_varietiesCollection : ObservableCollection<m_varieties> {
		public m_varietiesCollection(){
		}
	}
}