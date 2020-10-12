using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �`�[��ʐݒ�
	/// </summary>
	public partial class SlipSettings
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
		///���O�C�����[�U�[ID :=���O�C�����[�U�[�}�X�^.ID
		///</summary>
		private int _m_login_users_staff_id;
		public int m_login_users_staff_id
		{
			get => _m_login_users_staff_id;
			set
			{
				if (_m_login_users_staff_id == value)
					return;
				_m_login_users_staff_id = value;
			}
		}

		///<summary>
		///�ꏊ�F�\���t���O :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _location_display_flag;
		public int location_display_flag
		{
			get => _location_display_flag;
			set
			{
				if (_location_display_flag == value)
					return;
				_location_display_flag = value;
			}
		}

		///<summary>
		///�ꏊ�F��������
		///</summary>
		private int _location_union_item;
		public int location_union_item
		{
			get => _location_union_item;
			set
			{
				if (_location_union_item == value)
					return;
				_location_union_item = value;
			}
		}

		///<summary>
		///�ꏊ�F���я�
		///</summary>
		private int _location_order;
		public int location_order
		{
			get => _location_order;
			set
			{
				if (_location_order == value)
					return;
				_location_order = value;
			}
		}

		///<summary>
		///�ӏ��F�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _place_display_flag;
		public int place_display_flag
		{
			get => _place_display_flag;
			set
			{
				if (_place_display_flag == value)
					return;
				_place_display_flag = value;
			}
		}

		///<summary>
		///�ӏ��F��������
		///</summary>
		private int _place_union_item;
		public int place_union_item
		{
			get => _place_union_item;
			set
			{
				if (_place_union_item == value)
					return;
				_place_union_item = value;
			}
		}

		///<summary>
		///�ӏ��F���я�
		///</summary>
		private int _place_order;
		public int place_order
		{
			get => _place_order;
			set
			{
				if (_place_order == value)
					return;
				_place_order = value;
			}
		}

		///<summary>
		///���Еi�ԁF�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _product_display_flag;
		public int product_display_flag
		{
			get => _product_display_flag;
			set
			{
				if (_product_display_flag == value)
					return;
				_product_display_flag = value;
			}
		}

		///<summary>
		///���Еi�ԁF��������
		///</summary>
		private int _product_union_item;
		public int product_union_item
		{
			get => _product_union_item;
			set
			{
				if (_product_union_item == value)
					return;
				_product_union_item = value;
			}
		}

		///<summary>
		///���Еi�ԁF���я�
		///</summary>
		private int _product_order;
		public int product_order
		{
			get => _product_order;
			set
			{
				if (_product_order == value)
					return;
				_product_order = value;
			}
		}

		///<summary>
		///���[�J�[�i�ԁF�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _maker_display_flag;
		public int maker_display_flag
		{
			get => _maker_display_flag;
			set
			{
				if (_maker_display_flag == value)
					return;
				_maker_display_flag = value;
			}
		}

		///<summary>
		///���[�J�[�i�ԁF��������
		///</summary>
		private int _maker_union_item;
		public int maker_union_item
		{
			get => _maker_union_item;
			set
			{
				if (_maker_union_item == value)
					return;
				_maker_union_item = value;
			}
		}

		///<summary>
		///���[�J�[�i�ԁF���я�
		///</summary>
		private int _maker_order;
		public int maker_order
		{
			get => _maker_order;
			set
			{
				if (_maker_order == value)
					return;
				_maker_order = value;
			}
		}

		///<summary>
		///���[�J�[���F�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _maker_name_display_flag;
		public int maker_name_display_flag
		{
			get => _maker_name_display_flag;
			set
			{
				if (_maker_name_display_flag == value)
					return;
				_maker_name_display_flag = value;
			}
		}

		///<summary>
		///���[�J�[���F��������
		///</summary>
		private int _maker_name_union_item;
		public int maker_name_union_item
		{
			get => _maker_name_union_item;
			set
			{
				if (_maker_name_union_item == value)
					return;
				_maker_name_union_item = value;
			}
		}

		///<summary>
		///���[�J�[���F���я�
		///</summary>
		private int _maker_name_order;
		public int maker_name_order
		{
			get => _maker_name_order;
			set
			{
				if (_maker_name_order == value)
					return;
				_maker_name_order = value;
			}
		}

		///<summary>
		///�i���F�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _product_name_display_flag;
		public int product_name_display_flag
		{
			get => _product_name_display_flag;
			set
			{
				if (_product_name_display_flag == value)
					return;
				_product_name_display_flag = value;
			}
		}

		///<summary>
		///�i���F��������
		///</summary>
		private int _product_name_union_item;
		public int product_name_union_item
		{
			get => _product_name_union_item;
			set
			{
				if (_product_name_union_item == value)
					return;
				_product_name_union_item = value;
			}
		}

		///<summary>
		///�i���F���я�
		///</summary>
		private int _product_name_order;
		public int product_name_order
		{
			get => _product_name_order;
			set
			{
				if (_product_name_order == value)
					return;
				_product_name_order = value;
			}
		}

		///<summary>
		///�K�i�F�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _standard_display_flag;
		public int standard_display_flag
		{
			get => _standard_display_flag;
			set
			{
				if (_standard_display_flag == value)
					return;
				_standard_display_flag = value;
			}
		}

		///<summary>
		///�K�i�F��������
		///</summary>
		private int _standard_union_item;
		public int standard_union_item
		{
			get => _standard_union_item;
			set
			{
				if (_standard_union_item == value)
					return;
				_standard_union_item = value;
			}
		}

		///<summary>
		///�K�i�F���я�
		///</summary>
		private int _standard_order;
		public int standard_order
		{
			get => _standard_order;
			set
			{
				if (_standard_order == value)
					return;
				_standard_order = value;
			}
		}

		///<summary>
		///�i��F�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _variety_display_flag;
		public int variety_display_flag
		{
			get => _variety_display_flag;
			set
			{
				if (_variety_display_flag == value)
					return;
				_variety_display_flag = value;
			}
		}

		///<summary>
		///�i��F��������
		///</summary>
		private int _variety_union_item;
		public int variety_union_item
		{
			get => _variety_union_item;
			set
			{
				if (_variety_union_item == value)
					return;
				_variety_union_item = value;
			}
		}

		///<summary>
		///�i��F���я�
		///</summary>
		private int _variety_order;
		public int variety_order
		{
			get => _variety_order;
			set
			{
				if (_variety_order == value)
					return;
				_variety_order = value;
			}
		}

		///<summary>
		///���ʁF�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _quantity_display_flag;
		public int quantity_display_flag
		{
			get => _quantity_display_flag;
			set
			{
				if (_quantity_display_flag == value)
					return;
				_quantity_display_flag = value;
			}
		}

		///<summary>
		///���ʁF��������
		///</summary>
		private int _quantity_union_item;
		public int quantity_union_item
		{
			get => _quantity_union_item;
			set
			{
				if (_quantity_union_item == value)
					return;
				_quantity_union_item = value;
			}
		}

		///<summary>
		///���ʁF���я�
		///</summary>
		private int _quantity_order;
		public int quantity_order
		{
			get => _quantity_order;
			set
			{
				if (_quantity_order == value)
					return;
				_quantity_order = value;
			}
		}

		///<summary>
		///�P�ʁF�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _unit_display_flag;
		public int unit_display_flag
		{
			get => _unit_display_flag;
			set
			{
				if (_unit_display_flag == value)
					return;
				_unit_display_flag = value;
			}
		}

		///<summary>
		///�P�ʁF��������
		///</summary>
		private int _unit_union_item;
		public int unit_union_item
		{
			get => _unit_union_item;
			set
			{
				if (_unit_union_item == value)
					return;
				_unit_union_item = value;
			}
		}

		///<summary>
		///�P�ʁF���я�
		///</summary>
		private int _unit_order;
		public int unit_order
		{
			get => _unit_order;
			set
			{
				if (_unit_order == value)
					return;
				_unit_order = value;
			}
		}

		///<summary>
		///�P���F�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _price_display_flag;
		public int price_display_flag
		{
			get => _price_display_flag;
			set
			{
				if (_price_display_flag == value)
					return;
				_price_display_flag = value;
			}
		}

		///<summary>
		///�P���F��������
		///</summary>
		private int _price_union_item;
		public int price_union_item
		{
			get => _price_union_item;
			set
			{
				if (_price_union_item == value)
					return;
				_price_union_item = value;
			}
		}

		///<summary>
		///�P���F���я�
		///</summary>
		private int _price_order;
		public int price_order
		{
			get => _price_order;
			set
			{
				if (_price_order == value)
					return;
				_price_order = value;
			}
		}

		///<summary>
		///���z�F�\�� :am=Amount of money
		///</summary>
		private int _am_display_flag;
		public int am_display_flag
		{
			get => _am_display_flag;
			set
			{
				if (_am_display_flag == value)
					return;
				_am_display_flag = value;
			}
		}

		///<summary>
		///���z�F��������
		///</summary>
		private int _am_union_item;
		public int am_union_item
		{
			get => _am_union_item;
			set
			{
				if (_am_union_item == value)
					return;
				_am_union_item = value;
			}
		}

		///<summary>
		///���z�F���я�
		///</summary>
		private int _am_order;
		public int am_order
		{
			get => _am_order;
			set
			{
				if (_am_order == value)
					return;
				_am_order = value;
			}
		}

		///<summary>
		///���l�F�\�� :0�F�\�����Ȃ��A1�F�\������
		///</summary>
		private int _remarks_display_flag;
		public int remarks_display_flag
		{
			get => _remarks_display_flag;
			set
			{
				if (_remarks_display_flag == value)
					return;
				_remarks_display_flag = value;
			}
		}

		///<summary>
		///���l�F��������
		///</summary>
		private int _remarks_union_item;
		public int remarks_union_item
		{
			get => _remarks_union_item;
			set
			{
				if (_remarks_union_item == value)
					return;
				_remarks_union_item = value;
			}
		}

		///<summary>
		///���l�F���я�
		///</summary>
		private int _remarks_order;
		public int remarks_order
		{
			get => _remarks_order;
			set
			{
				if (_remarks_order == value)
					return;
				_remarks_order = value;
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


	public class SlipSettingsCollection : ObservableCollection<SlipSettings> {
		public SlipSettingsCollection(){
		}
	}
}
