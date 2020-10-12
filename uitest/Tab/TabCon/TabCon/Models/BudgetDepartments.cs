using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// •”–å•Ê—\Zƒ}ƒXƒ^
	/// </summary>
	public partial class BudgetDepartments
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
		///Œ_–ñID :=Œ_–ñƒ}ƒXƒ^.ID
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
		///•”–åID :=•”–åƒ}ƒXƒ^.ID
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
		///‘ÎÛ”N“x
		///</summary>
		private int _target_year;
		public int target_year
		{
			get => _target_year;
			set
			{
				if (_target_year == value)
					return;
				_target_year = value;
			}
		}

		///<summary>
		///NŒ
		///</summary>
		private int _buget_month_1;
		public int buget_month_1
		{
			get => _buget_month_1;
			set
			{
				if (_buget_month_1 == value)
					return;
				_buget_month_1 = value;
			}
		}

		///<summary>
		///N{1Œ
		///</summary>
		private int _buget_month_2;
		public int buget_month_2
		{
			get => _buget_month_2;
			set
			{
				if (_buget_month_2 == value)
					return;
				_buget_month_2 = value;
			}
		}

		///<summary>
		///N{2Œ
		///</summary>
		private int _buget_month_3;
		public int buget_month_3
		{
			get => _buget_month_3;
			set
			{
				if (_buget_month_3 == value)
					return;
				_buget_month_3 = value;
			}
		}

		///<summary>
		///N{3Œ
		///</summary>
		private int _buget_month_4;
		public int buget_month_4
		{
			get => _buget_month_4;
			set
			{
				if (_buget_month_4 == value)
					return;
				_buget_month_4 = value;
			}
		}

		///<summary>
		///N{4Œ
		///</summary>
		private int _buget_month_5;
		public int buget_month_5
		{
			get => _buget_month_5;
			set
			{
				if (_buget_month_5 == value)
					return;
				_buget_month_5 = value;
			}
		}

		///<summary>
		///N{5Œ
		///</summary>
		private int _buget_month_6;
		public int buget_month_6
		{
			get => _buget_month_6;
			set
			{
				if (_buget_month_6 == value)
					return;
				_buget_month_6 = value;
			}
		}

		///<summary>
		///N{6Œ
		///</summary>
		private int _buget_month_7;
		public int buget_month_7
		{
			get => _buget_month_7;
			set
			{
				if (_buget_month_7 == value)
					return;
				_buget_month_7 = value;
			}
		}

		///<summary>
		///N{7Œ
		///</summary>
		private int _buget_month_8;
		public int buget_month_8
		{
			get => _buget_month_8;
			set
			{
				if (_buget_month_8 == value)
					return;
				_buget_month_8 = value;
			}
		}

		///<summary>
		///N{8Œ
		///</summary>
		private int _buget_month_9;
		public int buget_month_9
		{
			get => _buget_month_9;
			set
			{
				if (_buget_month_9 == value)
					return;
				_buget_month_9 = value;
			}
		}

		///<summary>
		///N{9Œ
		///</summary>
		private int _buget_month_10;
		public int buget_month_10
		{
			get => _buget_month_10;
			set
			{
				if (_buget_month_10 == value)
					return;
				_buget_month_10 = value;
			}
		}

		///<summary>
		///N{10Œ
		///</summary>
		private int _buget_month_11;
		public int buget_month_11
		{
			get => _buget_month_11;
			set
			{
				if (_buget_month_11 == value)
					return;
				_buget_month_11 = value;
			}
		}

		///<summary>
		///N{11Œ
		///</summary>
		private int _buget_month_12;
		public int buget_month_12
		{
			get => _buget_month_12;
			set
			{
				if (_buget_month_12 == value)
					return;
				_buget_month_12 = value;
			}
		}

		///<summary>
		///NŒ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_1;
		public int buget_amount_1
		{
			get => _buget_amount_1;
			set
			{
				if (_buget_amount_1 == value)
					return;
				_buget_amount_1 = value;
			}
		}

		///<summary>
		///N{1Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_2;
		public int buget_amount_2
		{
			get => _buget_amount_2;
			set
			{
				if (_buget_amount_2 == value)
					return;
				_buget_amount_2 = value;
			}
		}

		///<summary>
		///N{2Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_3;
		public int buget_amount_3
		{
			get => _buget_amount_3;
			set
			{
				if (_buget_amount_3 == value)
					return;
				_buget_amount_3 = value;
			}
		}

		///<summary>
		///N{3Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_4;
		public int buget_amount_4
		{
			get => _buget_amount_4;
			set
			{
				if (_buget_amount_4 == value)
					return;
				_buget_amount_4 = value;
			}
		}

		///<summary>
		///N{4Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_5;
		public int buget_amount_5
		{
			get => _buget_amount_5;
			set
			{
				if (_buget_amount_5 == value)
					return;
				_buget_amount_5 = value;
			}
		}

		///<summary>
		///N{5Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_6;
		public int buget_amount_6
		{
			get => _buget_amount_6;
			set
			{
				if (_buget_amount_6 == value)
					return;
				_buget_amount_6 = value;
			}
		}

		///<summary>
		///N{6Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_7;
		public int buget_amount_7
		{
			get => _buget_amount_7;
			set
			{
				if (_buget_amount_7 == value)
					return;
				_buget_amount_7 = value;
			}
		}

		///<summary>
		///N{7Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_8;
		public int buget_amount_8
		{
			get => _buget_amount_8;
			set
			{
				if (_buget_amount_8 == value)
					return;
				_buget_amount_8 = value;
			}
		}

		///<summary>
		///N{8Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_9;
		public int buget_amount_9
		{
			get => _buget_amount_9;
			set
			{
				if (_buget_amount_9 == value)
					return;
				_buget_amount_9 = value;
			}
		}

		///<summary>
		///N{9Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_10;
		public int buget_amount_10
		{
			get => _buget_amount_10;
			set
			{
				if (_buget_amount_10 == value)
					return;
				_buget_amount_10 = value;
			}
		}

		///<summary>
		///N{10Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_11;
		public int buget_amount_11
		{
			get => _buget_amount_11;
			set
			{
				if (_buget_amount_11 == value)
					return;
				_buget_amount_11 = value;
			}
		}

		///<summary>
		///N{11Œ@–Ú•W—\ZŠz
		///</summary>
		private int _buget_amount_12;
		public int buget_amount_12
		{
			get => _buget_amount_12;
			set
			{
				if (_buget_amount_12 == value)
					return;
				_buget_amount_12 = value;
			}
		}

		///<summary>
		///NŒ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_1;
		public int gross_profit_amount_1
		{
			get => _gross_profit_amount_1;
			set
			{
				if (_gross_profit_amount_1 == value)
					return;
				_gross_profit_amount_1 = value;
			}
		}

		///<summary>
		///N{1Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_2;
		public int gross_profit_amount_2
		{
			get => _gross_profit_amount_2;
			set
			{
				if (_gross_profit_amount_2 == value)
					return;
				_gross_profit_amount_2 = value;
			}
		}

		///<summary>
		///N{2Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_3;
		public int gross_profit_amount_3
		{
			get => _gross_profit_amount_3;
			set
			{
				if (_gross_profit_amount_3 == value)
					return;
				_gross_profit_amount_3 = value;
			}
		}

		///<summary>
		///N{3Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_4;
		public int gross_profit_amount_4
		{
			get => _gross_profit_amount_4;
			set
			{
				if (_gross_profit_amount_4 == value)
					return;
				_gross_profit_amount_4 = value;
			}
		}

		///<summary>
		///N{4Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_5;
		public int gross_profit_amount_5
		{
			get => _gross_profit_amount_5;
			set
			{
				if (_gross_profit_amount_5 == value)
					return;
				_gross_profit_amount_5 = value;
			}
		}

		///<summary>
		///N{5Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_6;
		public int gross_profit_amount_6
		{
			get => _gross_profit_amount_6;
			set
			{
				if (_gross_profit_amount_6 == value)
					return;
				_gross_profit_amount_6 = value;
			}
		}

		///<summary>
		///N{6Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_7;
		public int gross_profit_amount_7
		{
			get => _gross_profit_amount_7;
			set
			{
				if (_gross_profit_amount_7 == value)
					return;
				_gross_profit_amount_7 = value;
			}
		}

		///<summary>
		///N{7Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_8;
		public int gross_profit_amount_8
		{
			get => _gross_profit_amount_8;
			set
			{
				if (_gross_profit_amount_8 == value)
					return;
				_gross_profit_amount_8 = value;
			}
		}

		///<summary>
		///N{8Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_9;
		public int gross_profit_amount_9
		{
			get => _gross_profit_amount_9;
			set
			{
				if (_gross_profit_amount_9 == value)
					return;
				_gross_profit_amount_9 = value;
			}
		}

		///<summary>
		///N{9Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_10;
		public int gross_profit_amount_10
		{
			get => _gross_profit_amount_10;
			set
			{
				if (_gross_profit_amount_10 == value)
					return;
				_gross_profit_amount_10 = value;
			}
		}

		///<summary>
		///N{10Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_11;
		public int gross_profit_amount_11
		{
			get => _gross_profit_amount_11;
			set
			{
				if (_gross_profit_amount_11 == value)
					return;
				_gross_profit_amount_11 = value;
			}
		}

		///<summary>
		///N{11Œ@–Ú•W‘e—˜Šz
		///</summary>
		private int _gross_profit_amount_12;
		public int gross_profit_amount_12
		{
			get => _gross_profit_amount_12;
			set
			{
				if (_gross_profit_amount_12 == value)
					return;
				_gross_profit_amount_12 = value;
			}
		}

		///<summary>
		///ì¬Ò
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
		///ì¬“ú
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
		///XVÒ
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
		///XV“ú
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
		///íœ“ú
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


	public class BudgetDepartmentsCollection : ObservableCollection<BudgetDepartments> {
		public BudgetDepartmentsCollection(){
		}
	}
}
