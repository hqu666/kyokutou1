using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// ����Ń}�X�^
	/// </summary>
	public partial class Taxs
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
		///����ŃR�[�h
		///</summary>
		private string _tax_cd;
		public string tax_cd
		{
			get => _tax_cd;
			set
			{
				if (_tax_cd == value)
					return;
				_tax_cd = value;
			}
		}

		///<summary>
		///����Ŗ���
		///</summary>
		private string _tax_name;
		public string tax_name
		{
			get => _tax_name;
			set
			{
				if (_tax_name == value)
					return;
				_tax_name = value;
			}
		}

		///<summary>
		///�^�p�J�n��
		///</summary>
		private DateTime _operation_date_start;
		public DateTime operation_date_start
		{
			get => _operation_date_start;
			set
			{
				if (_operation_date_start == value)
					return;
				_operation_date_start = value;
			}
		}

		///<summary>
		///�^�p�I����
		///</summary>
		private DateTime _operation_date_end;
		public DateTime operation_date_end
		{
			get => _operation_date_end;
			set
			{
				if (_operation_date_end == value)
					return;
				_operation_date_end = value;
			}
		}

		///<summary>
		///�ŗ�
		///</summary>
		private decimal _tax_rate;
		public decimal tax_rate
		{
			get => _tax_rate;
			set
			{
				if (_tax_rate == value)
					return;
				_tax_rate = value;
			}
		}

		///<summary>
		///�o�ߑ[�u�K�p�J�n��
		///</summary>
		private DateTime _transitional_date_start;
		public DateTime transitional_date_start
		{
			get => _transitional_date_start;
			set
			{
				if (_transitional_date_start == value)
					return;
				_transitional_date_start = value;
			}
		}

		///<summary>
		///�o�ߑ[�u�K�p�I����
		///</summary>
		private DateTime _transitional_date_end;
		public DateTime transitional_date_end
		{
			get => _transitional_date_end;
			set
			{
				if (_transitional_date_end == value)
					return;
				_transitional_date_end = value;
			}
		}

		///<summary>
		///�����l�t���O
		///</summary>
		private int _default_flag;
		public int default_flag
		{
			get => _default_flag;
			set
			{
				if (_default_flag == value)
					return;
				_default_flag = value;
			}
		}

		///<summary>
		///�ɓ��Y�@�t���O :1�F�ɓ��Y�@�ݒ�A0�F���[�U�[�ݒ�
		///</summary>
		private int _ks_flag;
		public int ks_flag
		{
			get => _ks_flag;
			set
			{
				if (_ks_flag == value)
					return;
				_ks_flag = value;
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


	public class TaxsCollection : ObservableCollection<Taxs> {
		public TaxsCollection(){
		}
	}
}
