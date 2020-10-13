using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// 商品単価マトリクス
	/// </summary>
	public partial class m_product_price_matrixes : NotificationObject
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///縦軸名
		///</summary>
		private string _col_name;
		public string col_name
		{
			get => _col_name;
			set
			{
				if (_col_name == value)
					return;
				_col_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///横軸名
		///</summary>
		private string _row_name;
		public string row_name
		{
			get => _row_name;
			set
			{
				if (_row_name == value)
					return;
				_row_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///行1 :カンマ区切りで列の情報を格納
		///</summary>
		private string _row1;
		public string row1
		{
			get => _row1;
			set
			{
				if (_row1 == value)
					return;
				_row1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///行2 :例）100,100,100,100,100,,,
		///</summary>
		private string _row2;
		public string row2
		{
			get => _row2;
			set
			{
				if (_row2 == value)
					return;
				_row2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///行3 :例）,,,,,,,
		///</summary>
		private string _row3;
		public string row3
		{
			get => _row3;
			set
			{
				if (_row3 == value)
					return;
				_row3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///行4
		///</summary>
		private string _row4;
		public string row4
		{
			get => _row4;
			set
			{
				if (_row4 == value)
					return;
				_row4 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///行5
		///</summary>
		private string _row5;
		public string row5
		{
			get => _row5;
			set
			{
				if (_row5 == value)
					return;
				_row5 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///行6
		///</summary>
		private string _row6;
		public string row6
		{
			get => _row6;
			set
			{
				if (_row6 == value)
					return;
				_row6 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///行7
		///</summary>
		private string _row7;
		public string row7
		{
			get => _row7;
			set
			{
				if (_row7 == value)
					return;
				_row7 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///行8
		///</summary>
		private string _row8;
		public string row8
		{
			get => _row8;
			set
			{
				if (_row8 == value)
					return;
				_row8 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///縦軸項目名1
		///</summary>
		private string _col_item_name1;
		public string col_item_name1
		{
			get => _col_item_name1;
			set
			{
				if (_col_item_name1 == value)
					return;
				_col_item_name1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///縦軸項目名2
		///</summary>
		private string _col_item_name2;
		public string col_item_name2
		{
			get => _col_item_name2;
			set
			{
				if (_col_item_name2 == value)
					return;
				_col_item_name2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///縦軸項目名3
		///</summary>
		private string _col_item_name3;
		public string col_item_name3
		{
			get => _col_item_name3;
			set
			{
				if (_col_item_name3 == value)
					return;
				_col_item_name3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///縦軸項目名4
		///</summary>
		private string _col_item_name4;
		public string col_item_name4
		{
			get => _col_item_name4;
			set
			{
				if (_col_item_name4 == value)
					return;
				_col_item_name4 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///縦軸項目名5
		///</summary>
		private string _col_item_name5;
		public string col_item_name5
		{
			get => _col_item_name5;
			set
			{
				if (_col_item_name5 == value)
					return;
				_col_item_name5 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///縦軸項目名6
		///</summary>
		private string _col_item_name6;
		public string col_item_name6
		{
			get => _col_item_name6;
			set
			{
				if (_col_item_name6 == value)
					return;
				_col_item_name6 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///縦軸項目名7
		///</summary>
		private string _col_item_name7;
		public string col_item_name7
		{
			get => _col_item_name7;
			set
			{
				if (_col_item_name7 == value)
					return;
				_col_item_name7 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///縦軸項目名8
		///</summary>
		private string _col_item_name8;
		public string col_item_name8
		{
			get => _col_item_name8;
			set
			{
				if (_col_item_name8 == value)
					return;
				_col_item_name8 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///横軸項目名1
		///</summary>
		private string _row_item_name1;
		public string row_item_name1
		{
			get => _row_item_name1;
			set
			{
				if (_row_item_name1 == value)
					return;
				_row_item_name1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///横軸項目名2
		///</summary>
		private string _row_item_name2;
		public string row_item_name2
		{
			get => _row_item_name2;
			set
			{
				if (_row_item_name2 == value)
					return;
				_row_item_name2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///横軸項目名3
		///</summary>
		private string _row_item_name3;
		public string row_item_name3
		{
			get => _row_item_name3;
			set
			{
				if (_row_item_name3 == value)
					return;
				_row_item_name3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///横軸項目名4
		///</summary>
		private string _row_item_name4;
		public string row_item_name4
		{
			get => _row_item_name4;
			set
			{
				if (_row_item_name4 == value)
					return;
				_row_item_name4 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///横軸項目名5
		///</summary>
		private string _row_item_name5;
		public string row_item_name5
		{
			get => _row_item_name5;
			set
			{
				if (_row_item_name5 == value)
					return;
				_row_item_name5 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///横軸項目名6
		///</summary>
		private string _row_item_name6;
		public string row_item_name6
		{
			get => _row_item_name6;
			set
			{
				if (_row_item_name6 == value)
					return;
				_row_item_name6 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///横軸項目名7
		///</summary>
		private string _row_item_name7;
		public string row_item_name7
		{
			get => _row_item_name7;
			set
			{
				if (_row_item_name7 == value)
					return;
				_row_item_name7 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///横軸項目名8
		///</summary>
		private string _row_item_name8;
		public string row_item_name8
		{
			get => _row_item_name8;
			set
			{
				if (_row_item_name8 == value)
					return;
				_row_item_name8 = value;
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}

	}


	public class m_product_price_matrixesCollection : ObservableCollection<m_product_price_matrixes> {
		public m_product_price_matrixesCollection(){
		}
	}
}
