using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 伝票明細パターンマスタ
	/// </summary>
	public partial class SlipItemPatterns
	{

		///<summary>
		///ID :※1～8まで
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
		///カラム名_1 :例）product_name
		///</summary>
		private string _column_name_1;
		public string column_name_1
		{
			get => _column_name_1;
			set
			{
				if (_column_name_1 == value)
					return;
				_column_name_1 = value;
			}
		}

		///<summary>
		///結合数_1 :例）3
		///</summary>
		private int _colspan_1;
		public int colspan_1
		{
			get => _colspan_1;
			set
			{
				if (_colspan_1 == value)
					return;
				_colspan_1 = value;
			}
		}

		///<summary>
		///幅_1 :例）36                        ※％表記
		///</summary>
		private int _width_1;
		public int width_1
		{
			get => _width_1;
			set
			{
				if (_width_1 == value)
					return;
				_width_1 = value;
			}
		}

		///<summary>
		///カラム名_2 :例）NULL
		///</summary>
		private string _column_name_2;
		public string column_name_2
		{
			get => _column_name_2;
			set
			{
				if (_column_name_2 == value)
					return;
				_column_name_2 = value;
			}
		}

		///<summary>
		///結合数_2 :例）0
		///</summary>
		private int _colspan_2;
		public int colspan_2
		{
			get => _colspan_2;
			set
			{
				if (_colspan_2 == value)
					return;
				_colspan_2 = value;
			}
		}

		///<summary>
		///幅_2 :例）0                         ※％表記
		///</summary>
		private int _width_2;
		public int width_2
		{
			get => _width_2;
			set
			{
				if (_width_2 == value)
					return;
				_width_2 = value;
			}
		}

		///<summary>
		///カラム名_3 :例）NULL
		///</summary>
		private string _column_name_3;
		public string column_name_3
		{
			get => _column_name_3;
			set
			{
				if (_column_name_3 == value)
					return;
				_column_name_3 = value;
			}
		}

		///<summary>
		///結合数_3 :例）0
		///</summary>
		private int _colspan_3;
		public int colspan_3
		{
			get => _colspan_3;
			set
			{
				if (_colspan_3 == value)
					return;
				_colspan_3 = value;
			}
		}

		///<summary>
		///幅_3 :例）0                         ※％表記
		///</summary>
		private int _width_3;
		public int width_3
		{
			get => _width_3;
			set
			{
				if (_width_3 == value)
					return;
				_width_3 = value;
			}
		}

		///<summary>
		///カラム名_4 :例）product_number|standard
		///</summary>
		private string _column_name_4;
		public string column_name_4
		{
			get => _column_name_4;
			set
			{
				if (_column_name_4 == value)
					return;
				_column_name_4 = value;
			}
		}

		///<summary>
		///結合数_4 :例）1
		///</summary>
		private int _colspan_4;
		public int colspan_4
		{
			get => _colspan_4;
			set
			{
				if (_colspan_4 == value)
					return;
				_colspan_4 = value;
			}
		}

		///<summary>
		///幅_4 :例）12                        ※％表記
		///</summary>
		private int _width_4;
		public int width_4
		{
			get => _width_4;
			set
			{
				if (_width_4 == value)
					return;
				_width_4 = value;
			}
		}

		///<summary>
		///カラム名_5 :例）quantity
		///</summary>
		private string _column_name_5;
		public string column_name_5
		{
			get => _column_name_5;
			set
			{
				if (_column_name_5 == value)
					return;
				_column_name_5 = value;
			}
		}

		///<summary>
		///結合数_5 :例）1
		///</summary>
		private int _colspan_5;
		public int colspan_5
		{
			get => _colspan_5;
			set
			{
				if (_colspan_5 == value)
					return;
				_colspan_5 = value;
			}
		}

		///<summary>
		///幅_5 :例）12                        ※％表記
		///</summary>
		private int _width_5;
		public int width_5
		{
			get => _width_5;
			set
			{
				if (_width_5 == value)
					return;
				_width_5 = value;
			}
		}

		///<summary>
		///カラム名_6 :例）unit
		///</summary>
		private string _column_name_6;
		public string column_name_6
		{
			get => _column_name_6;
			set
			{
				if (_column_name_6 == value)
					return;
				_column_name_6 = value;
			}
		}

		///<summary>
		///結合数_6 :例）1
		///</summary>
		private int _colspan_6;
		public int colspan_6
		{
			get => _colspan_6;
			set
			{
				if (_colspan_6 == value)
					return;
				_colspan_6 = value;
			}
		}

		///<summary>
		///幅_6 :例）12                        ※％表記
		///</summary>
		private int _width_6;
		public int width_6
		{
			get => _width_6;
			set
			{
				if (_width_6 == value)
					return;
				_width_6 = value;
			}
		}

		///<summary>
		///カラム名_7 :例）unit_price
		///</summary>
		private string _column_name_7;
		public string column_name_7
		{
			get => _column_name_7;
			set
			{
				if (_column_name_7 == value)
					return;
				_column_name_7 = value;
			}
		}

		///<summary>
		///結合数_7 :例）1
		///</summary>
		private int _colspan_7;
		public int colspan_7
		{
			get => _colspan_7;
			set
			{
				if (_colspan_7 == value)
					return;
				_colspan_7 = value;
			}
		}

		///<summary>
		///幅_7 :例）12                        ※％表記
		///</summary>
		private int _width_7;
		public int width_7
		{
			get => _width_7;
			set
			{
				if (_width_7 == value)
					return;
				_width_7 = value;
			}
		}

		///<summary>
		///カラム名_8 :例）amount
		///</summary>
		private string _column_name_8;
		public string column_name_8
		{
			get => _column_name_8;
			set
			{
				if (_column_name_8 == value)
					return;
				_column_name_8 = value;
			}
		}

		///<summary>
		///結合数_8 :例）1
		///</summary>
		private int _colspan_8;
		public int colspan_8
		{
			get => _colspan_8;
			set
			{
				if (_colspan_8 == value)
					return;
				_colspan_8 = value;
			}
		}

		///<summary>
		///幅_8 :例）12                        ※％表記
		///</summary>
		private int _width_8;
		public int width_8
		{
			get => _width_8;
			set
			{
				if (_width_8 == value)
					return;
				_width_8 = value;
			}
		}

		///<summary>
		///カラム名_9 :例）remark
		///</summary>
		private string _column_name_9;
		public string column_name_9
		{
			get => _column_name_9;
			set
			{
				if (_column_name_9 == value)
					return;
				_column_name_9 = value;
			}
		}

		///<summary>
		///結合数_9 :例）1
		///</summary>
		private int _colspan_9;
		public int colspan_9
		{
			get => _colspan_9;
			set
			{
				if (_colspan_9 == value)
					return;
				_colspan_9 = value;
			}
		}

		///<summary>
		///幅_9 :例）12                        ※％表記
		///</summary>
		private int _width_9;
		public int width_9
		{
			get => _width_9;
			set
			{
				if (_width_9 == value)
					return;
				_width_9 = value;
			}
		}

		///<summary>
		///カラム名_10 :例）NULL
		///</summary>
		private string _column_name_10;
		public string column_name_10
		{
			get => _column_name_10;
			set
			{
				if (_column_name_10 == value)
					return;
				_column_name_10 = value;
			}
		}

		///<summary>
		///結合数_10 :例）0
		///</summary>
		private int _colspan_10;
		public int colspan_10
		{
			get => _colspan_10;
			set
			{
				if (_colspan_10 == value)
					return;
				_colspan_10 = value;
			}
		}

		///<summary>
		///幅_10 :例）0                          ※％表記
		///</summary>
		private int _width_10;
		public int width_10
		{
			get => _width_10;
			set
			{
				if (_width_10 == value)
					return;
				_width_10 = value;
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


	public class SlipItemPatternsCollection : ObservableCollection<SlipItemPatterns> {
		public SlipItemPatternsCollection(){
		}
	}
}
