using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 取引先別商品別単価掛率マスタ
	/// </summary>
	public partial class SupplierProductPriceRates
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
		///種別 :※固定値：取引先区分
		///</summary>
		private int _type_id;
		public int type_id
		{
			get => _type_id;
			set
			{
				if (_type_id == value)
					return;
				_type_id = value;
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
		///商品ID :=商品マスタ.ID
		///</summary>
		private int _m_product_id;
		public int m_product_id
		{
			get => _m_product_id;
			set
			{
				if (_m_product_id == value)
					return;
				_m_product_id = value;
			}
		}

		///<summary>
		///単価
		///</summary>
		private decimal _price;
		public decimal price
		{
			get => _price;
			set
			{
				if (_price == value)
					return;
				_price = value;
			}
		}

		///<summary>
		///掛率
		///</summary>
		private decimal _rate;
		public decimal rate
		{
			get => _rate;
			set
			{
				if (_rate == value)
					return;
				_rate = value;
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


	public class SupplierProductPriceRatesCollection : ObservableCollection<SupplierProductPriceRates> {
		public SupplierProductPriceRatesCollection(){
		}
	}
}
