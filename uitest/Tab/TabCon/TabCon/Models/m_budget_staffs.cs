using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// ���ВS���ҕʗ\�Z�}�X�^
	/// </summary>
	public partial class m_budget_staffs : NotificationObject
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���ВS����ID :=���ВS���҃}�X�^.ID
		///</summary>
		private int _m_own_company_staff_id;
		public int m_own_company_staff_id
		{
			get => _m_own_company_staff_id;
			set
			{
				if (_m_own_company_staff_id == value)
					return;
				_m_own_company_staff_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Ώ۔N�x
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{1��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{2��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{3��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{4��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{5��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{6��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{7��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{8��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{9��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{10��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{11��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{1���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{2���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{3���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{4���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{5���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{6���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{7���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{8���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{9���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{10���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{11���@�ڕW�\�Z�z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{1���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{2���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{3���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{4���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{5���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{6���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{7���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{8���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{9���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{10���@�ڕW�e���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///N�{11���@�ڕW�e���z
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}

	}


	public class m_budget_staffsCollection : ObservableCollection<m_budget_staffs> {
		public m_budget_staffsCollection(){
		}
	}
}
