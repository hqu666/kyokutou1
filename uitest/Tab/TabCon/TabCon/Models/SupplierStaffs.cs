using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 取引先部門担当者マスタ
	/// </summary>
	public partial class SupplierStaffs
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
			}
		}

		///<summary>
		///取引先ID :=取引先マスタ.ID
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
		///担当者コード
		///</summary>
		private string _staff_cd;
		public string staff_cd
		{
			get => _staff_cd;
			set
			{
				if (_staff_cd == value)
					return;
				_staff_cd = value;
			}
		}

		///<summary>
		///担当者名
		///</summary>
		private string _staff_name;
		public string staff_name
		{
			get => _staff_name;
			set
			{
				if (_staff_name == value)
					return;
				_staff_name = value;
			}
		}

		///<summary>
		///役職
		///</summary>
		private string _position;
		public string position
		{
			get => _position;
			set
			{
				if (_position == value)
					return;
				_position = value;
			}
		}

		///<summary>
		///連絡先
		///</summary>
		private string _contact_number;
		public string contact_number
		{
			get => _contact_number;
			set
			{
				if (_contact_number == value)
					return;
				_contact_number = value;
			}
		}

		///<summary>
		///携帯電話
		///</summary>
		private string _mobile_number;
		public string mobile_number
		{
			get => _mobile_number;
			set
			{
				if (_mobile_number == value)
					return;
				_mobile_number = value;
			}
		}

		///<summary>
		///Email
		///</summary>
		private string _email;
		public string email
		{
			get => _email;
			set
			{
				if (_email == value)
					return;
				_email = value;
			}
		}

		///<summary>
		///備考
		///</summary>
		private string _remark;
		public string remark
		{
			get => _remark;
			set
			{
				if (_remark == value)
					return;
				_remark = value;
			}
		}

		///<summary>
		///無効フラグ
		///</summary>
		private int _invalid_flg;
		public int invalid_flg
		{
			get => _invalid_flg;
			set
			{
				if (_invalid_flg == value)
					return;
				_invalid_flg = value;
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
			}
		}

	}


	public class SupplierStaffsCollection : ObservableCollection<SupplierStaffs> {
		public SupplierStaffsCollection(){
		}
	}
}
