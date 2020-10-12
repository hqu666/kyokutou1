using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �V�X�e���֘A���̃}�X�^
	/// </summary>
	public partial class SystemNames
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
		///�敪 :���Œ�l�F�V�X�e���֘A����
		///</summary>
		private int _name_type;
		public int name_type
		{
			get => _name_type;
			set
			{
				if (_name_type == value)
					return;
				_name_type = value;
			}
		}

		///<summary>
		///����
		///</summary>
		private string _name_value;
		public string name_value
		{
			get => _name_value;
			set
			{
				if (_name_value == value)
					return;
				_name_value = value;
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
		private int _creater;
		public int creater
		{
			get => _creater;
			set
			{
				if (_creater == value)
					return;
				_creater = value;
			}
		}

		///<summary>
		///�쐬����
		///</summary>
		private DateTime _created_on;
		public DateTime created_on
		{
			get => _created_on;
			set
			{
				if (_created_on == value)
					return;
				_created_on = value;
			}
		}

		///<summary>
		///�X�V��
		///</summary>
		private int _modifier;
		public int modifier
		{
			get => _modifier;
			set
			{
				if (_modifier == value)
					return;
				_modifier = value;
			}
		}

		///<summary>
		///�X�V����
		///</summary>
		private DateTime _modifier_on;
		public DateTime modifier_on
		{
			get => _modifier_on;
			set
			{
				if (_modifier_on == value)
					return;
				_modifier_on = value;
			}
		}

		///<summary>
		///�폜����
		///</summary>
		private DateTime _deleted_on;
		public DateTime deleted_on
		{
			get => _deleted_on;
			set
			{
				if (_deleted_on == value)
					return;
				_deleted_on = value;
			}
		}

	}


	public class SystemNamesCollection : ObservableCollection<SystemNames> {
		public SystemNamesCollection(){
		}
	}
}
