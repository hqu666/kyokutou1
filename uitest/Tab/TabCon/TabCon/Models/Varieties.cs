using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �i��}�X�^
	/// </summary>
	public partial class Varieties
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
			}
		}

	}


	public class VarietiesCollection : ObservableCollection<Varieties> {
		public VarietiesCollection(){
		}
	}
}
