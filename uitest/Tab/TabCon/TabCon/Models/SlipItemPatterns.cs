using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �`�[���׃p�^�[���}�X�^
	/// </summary>
	public partial class SlipItemPatterns
	{

		///<summary>
		///ID :��1�`8�܂�
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
		///�J������_1 :��jproduct_name
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
		///������_1 :��j3
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
		///��_1 :��j36                        �����\�L
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
		///�J������_2 :��jNULL
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
		///������_2 :��j0
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
		///��_2 :��j0                         �����\�L
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
		///�J������_3 :��jNULL
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
		///������_3 :��j0
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
		///��_3 :��j0                         �����\�L
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
		///�J������_4 :��jproduct_number|standard
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
		///������_4 :��j1
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
		///��_4 :��j12                        �����\�L
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
		///�J������_5 :��jquantity
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
		///������_5 :��j1
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
		///��_5 :��j12                        �����\�L
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
		///�J������_6 :��junit
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
		///������_6 :��j1
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
		///��_6 :��j12                        �����\�L
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
		///�J������_7 :��junit_price
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
		///������_7 :��j1
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
		///��_7 :��j12                        �����\�L
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
		///�J������_8 :��jamount
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
		///������_8 :��j1
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
		///��_8 :��j12                        �����\�L
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
		///�J������_9 :��jremark
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
		///������_9 :��j1
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
		///��_9 :��j12                        �����\�L
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
		///�J������_10 :��jNULL
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
		///������_10 :��j0
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
		///��_10 :��j0                          �����\�L
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


	public class SlipItemPatternsCollection : ObservableCollection<SlipItemPatterns> {
		public SlipItemPatternsCollection(){
		}
	}
}
