using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// オプション設定
	/// </summary>
	public partial class OptionSettings
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
		///ログインユーザーID :=ログインユーザーマスタ.ID
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
		///明細行削除時メッセージ
		///</summary>
		private int _statement_delete_message;
		public int statement_delete_message
		{
			get => _statement_delete_message;
			set
			{
				if (_statement_delete_message == value)
					return;
				_statement_delete_message = value;
			}
		}

		///<summary>
		///テーマ :※固定値定義書：Z-5.テーマ名
		///</summary>
		private int _theme;
		public int theme
		{
			get => _theme;
			set
			{
				if (_theme == value)
					return;
				_theme = value;
			}
		}

		///<summary>
		///伝票明細パターンID :=伝票明細パターンマスタ.ID
		///</summary>
		private int _m_slip_item_patterns_id;
		public int m_slip_item_patterns_id
		{
			get => _m_slip_item_patterns_id;
			set
			{
				if (_m_slip_item_patterns_id == value)
					return;
				_m_slip_item_patterns_id = value;
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


	public class OptionSettingsCollection : ObservableCollection<OptionSettings> {
		public OptionSettingsCollection(){
		}
	}
}
