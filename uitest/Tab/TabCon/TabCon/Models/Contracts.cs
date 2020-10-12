using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 契約マスタ
	/// </summary>
	public partial class Contracts
	{

		///<summary>
		///契約ID
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
		///契約番号
		///</summary>
		private string _contract_number;
		public string contract_number
		{
			get => _contract_number;
			set
			{
				if (_contract_number == value)
					return;
				_contract_number = value;
			}
		}

		///<summary>
		///会社名
		///</summary>
		private string _company_name;
		public string company_name
		{
			get => _company_name;
			set
			{
				if (_company_name == value)
					return;
				_company_name = value;
			}
		}

		///<summary>
		///部署名
		///</summary>
		private string _department_name;
		public string department_name
		{
			get => _department_name;
			set
			{
				if (_department_name == value)
					return;
				_department_name = value;
			}
		}

		///<summary>
		///契約期間（開始）
		///</summary>
		private DateTime _contract_period_start;
		public DateTime contract_period_start
		{
			get => _contract_period_start;
			set
			{
				if (_contract_period_start == value)
					return;
				_contract_period_start = value;
			}
		}

		///<summary>
		///契約期間（終了）
		///</summary>
		private DateTime _contract_period_end;
		public DateTime contract_period_end
		{
			get => _contract_period_end;
			set
			{
				if (_contract_period_end == value)
					return;
				_contract_period_end = value;
			}
		}

		///<summary>
		///代理店コード
		///</summary>
		private string _shop_code;
		public string shop_code
		{
			get => _shop_code;
			set
			{
				if (_shop_code == value)
					return;
				_shop_code = value;
			}
		}

		///<summary>
		///代理店名
		///</summary>
		private string _shop_name;
		public string shop_name
		{
			get => _shop_name;
			set
			{
				if (_shop_name == value)
					return;
				_shop_name = value;
			}
		}

		///<summary>
		///サイドバーカテゴリID :＝カテゴリマスタ．ID
		///</summary>
		private int _m_sidebar_category_id;
		public int m_sidebar_category_id
		{
			get => _m_sidebar_category_id;
			set
			{
				if (_m_sidebar_category_id == value)
					return;
				_m_sidebar_category_id = value;
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


	public class ContractsCollection : ObservableCollection<Contracts> {
		public ContractsCollection(){
		}
	}
}
