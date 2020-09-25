using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���Ӑ�ʗ\�Z�}�X�^
	/// </summary>
	public partial class BudgetSuppliers{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�����ID :=�����}�X�^.ID
		public int m_supplier_id { get; set; }
		///�Ώ۔N�x
		public int target_year { get; set; }
		///N��
		public int buget_month_1 { get; set; }
		///N�{1��
		public int buget_month_2 { get; set; }
		///N�{2��
		public int buget_month_3 { get; set; }
		///N�{3��
		public int buget_month_4 { get; set; }
		///N�{4��
		public int buget_month_5 { get; set; }
		///N�{5��
		public int buget_month_6 { get; set; }
		///N�{6��
		public int buget_month_7 { get; set; }
		///N�{7��
		public int buget_month_8 { get; set; }
		///N�{8��
		public int buget_month_9 { get; set; }
		///N�{9��
		public int buget_month_10 { get; set; }
		///N�{10��
		public int buget_month_11 { get; set; }
		///N�{11��
		public int buget_month_12 { get; set; }
		///N���@�ڕW�\�Z�z
		public int buget_amount_1 { get; set; }
		///N�{1���@�ڕW�\�Z�z
		public int buget_amount_2 { get; set; }
		///N�{2���@�ڕW�\�Z�z
		public int buget_amount_3 { get; set; }
		///N�{3���@�ڕW�\�Z�z
		public int buget_amount_4 { get; set; }
		///N�{4���@�ڕW�\�Z�z
		public int buget_amount_5 { get; set; }
		///N�{5���@�ڕW�\�Z�z
		public int buget_amount_6 { get; set; }
		///N�{6���@�ڕW�\�Z�z
		public int buget_amount_7 { get; set; }
		///N�{7���@�ڕW�\�Z�z
		public int buget_amount_8 { get; set; }
		///N�{8���@�ڕW�\�Z�z
		public int buget_amount_9 { get; set; }
		///N�{9���@�ڕW�\�Z�z
		public int buget_amount_10 { get; set; }
		///N�{10���@�ڕW�\�Z�z
		public int buget_amount_11 { get; set; }
		///N�{11���@�ڕW�\�Z�z
		public int buget_amount_12 { get; set; }
		///N���@�ڕW�e���z
		public int gross_profit_amount_1 { get; set; }
		///N�{1���@�ڕW�e���z
		public int gross_profit_amount_2 { get; set; }
		///N�{2���@�ڕW�e���z
		public int gross_profit_amount_3 { get; set; }
		///N�{3���@�ڕW�e���z
		public int gross_profit_amount_4 { get; set; }
		///N�{4���@�ڕW�e���z
		public int gross_profit_amount_5 { get; set; }
		///N�{5���@�ڕW�e���z
		public int gross_profit_amount_6 { get; set; }
		///N�{6���@�ڕW�e���z
		public int gross_profit_amount_7 { get; set; }
		///N�{7���@�ڕW�e���z
		public int gross_profit_amount_8 { get; set; }
		///N�{8���@�ڕW�e���z
		public int gross_profit_amount_9 { get; set; }
		///N�{9���@�ڕW�e���z
		public int gross_profit_amount_10 { get; set; }
		///N�{10���@�ڕW�e���z
		public int gross_profit_amount_11 { get; set; }
		///N�{11���@�ڕW�e���z
		public int gross_profit_amount_12 { get; set; }
		///�쐬��
		public int created_user { get; set; }
		///�쐬����:
		DateTime created_at { get; set; }
		///�X�V��
		public int updated_user { get; set; }
		///�X�V����:
		DateTime updated_at { get; set; }
		///�폜����:
		DateTime deleted_at { get; set; }
	}

	public class BudgetSuppliersCollection : ObservableCollection<BudgetSuppliers> {
		public BudgetSuppliersCollection(){
		}
	}
}
