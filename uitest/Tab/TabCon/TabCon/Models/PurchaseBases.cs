using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �w������{
	/// </summary>
	public partial class PurchaseBases
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
		///�w���ԍ�
		///</summary>
		private string _purchase_code;
		public string purchase_code
		{
			get => _purchase_code;
			set
			{
				if (_purchase_code == value)
					return;
				_purchase_code = value;
			}
		}

		///<summary>
		///�w���Ǘ��ԍ�
		///</summary>
		private string _purchase_manage_code;
		public string purchase_manage_code
		{
			get => _purchase_manage_code;
			set
			{
				if (_purchase_manage_code == value)
					return;
				_purchase_manage_code = value;
			}
		}

		///<summary>
		///�w���Č���
		///</summary>
		private string _purchase_name;
		public string purchase_name
		{
			get => _purchase_name;
			set
			{
				if (_purchase_name == value)
					return;
				_purchase_name = value;
			}
		}

		///<summary>
		///��]�[��
		///</summary>
		private DateTime _desired_delivery_date;
		public DateTime desired_delivery_date
		{
			get => _desired_delivery_date;
			set
			{
				if (_desired_delivery_date == value)
					return;
				_desired_delivery_date = value;
			}
		}

		///<summary>
		///����ID :=�����}�X�^.ID
		///</summary>
		private int _m_property_id;
		public int m_property_id
		{
			get => _m_property_id;
			set
			{
				if (_m_property_id == value)
					return;
				_m_property_id = value;
			}
		}

		///<summary>
		///�����ID :=�����}�X�^.ID�@�i�d����j
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
			}
		}

		///<summary>
		///�d����S����ID :=����敔��S���҃}�X�^.ID
		///</summary>
		private int _m_supplier_staff_id;
		public int m_supplier_staff_id
		{
			get => _m_supplier_staff_id;
			set
			{
				if (_m_supplier_staff_id == value)
					return;
				_m_supplier_staff_id = value;
			}
		}

		///<summary>
		///�[����ID :=�����}�X�^.ID�@�i���Ӑ�j
		///</summary>
		private int _d_m_supplier_id;
		public int d_m_supplier_id
		{
			get => _d_m_supplier_id;
			set
			{
				if (_d_m_supplier_id == value)
					return;
				_d_m_supplier_id = value;
			}
		}

		///<summary>
		///�[����F�X�֔ԍ� :=�s���{���}�X�^.ID
		///</summary>
		private string _d_postal_code;
		public string d_postal_code
		{
			get => _d_postal_code;
			set
			{
				if (_d_postal_code == value)
					return;
				_d_postal_code = value;
			}
		}

		///<summary>
		///�[����F�s���{���h�c
		///</summary>
		private int _d_m_prefecture_id;
		public int d_m_prefecture_id
		{
			get => _d_m_prefecture_id;
			set
			{
				if (_d_m_prefecture_id == value)
					return;
				_d_m_prefecture_id = value;
			}
		}

		///<summary>
		///�[����F�Z���P
		///</summary>
		private string _d_address_1;
		public string d_address_1
		{
			get => _d_address_1;
			set
			{
				if (_d_address_1 == value)
					return;
				_d_address_1 = value;
			}
		}

		///<summary>
		///�[����F�Z���Q
		///</summary>
		private string _d_address_2;
		public string d_address_2
		{
			get => _d_address_2;
			set
			{
				if (_d_address_2 == value)
					return;
				_d_address_2 = value;
			}
		}

		///<summary>
		///�[����F�����p�Z�� :�X�֔ԍ��{�s���{�����{�Z���P�{�Z���Q
		///</summary>
		private string _d_search_address;
		public string d_search_address
		{
			get => _d_search_address;
			set
			{
				if (_d_search_address == value)
					return;
				_d_search_address = value;
			}
		}

		///<summary>
		///����ID :=����}�X�^.ID
		///</summary>
		private int _m_department_id;
		public int m_department_id
		{
			get => _m_department_id;
			set
			{
				if (_m_department_id == value)
					return;
				_m_department_id = value;
			}
		}

		///<summary>
		///�����S����ID :=���ВS���҃}�X�^.ID
		///</summary>
		private int _h_m_own_company_staff_id;
		public int h_m_own_company_staff_id
		{
			get => _h_m_own_company_staff_id;
			set
			{
				if (_h_m_own_company_staff_id == value)
					return;
				_h_m_own_company_staff_id = value;
			}
		}

		///<summary>
		///�[�i���ԍ�
		///</summary>
		private DateTime _delivery_slip_code;
		public DateTime delivery_slip_code
		{
			get => _delivery_slip_code;
			set
			{
				if (_delivery_slip_code == value)
					return;
				_delivery_slip_code = value;
			}
		}

		///<summary>
		///�x���\���
		///</summary>
		private DateTime _payment_expected_date;
		public DateTime payment_expected_date
		{
			get => _payment_expected_date;
			set
			{
				if (_payment_expected_date == value)
					return;
				_payment_expected_date = value;
			}
		}

		///<summary>
		///����
		///</summary>
		private string _memo;
		public string memo
		{
			get => _memo;
			set
			{
				if (_memo == value)
					return;
				_memo = value;
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
			}
		}

		///<summary>
		///�X�e�[�^�X :���Œ�l�F�w���X�e�[�^�X
		///</summary>
		private int _status;
		public int status
		{
			get => _status;
			set
			{
				if (_status == value)
					return;
				_status = value;
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


	public class PurchaseBasesCollection : ObservableCollection<PurchaseBases> {
		public PurchaseBasesCollection(){
		}
	}
}
