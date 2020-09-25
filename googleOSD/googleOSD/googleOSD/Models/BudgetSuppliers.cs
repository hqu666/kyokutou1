using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// “¾ˆÓæ•Ê—\Zƒ}ƒXƒ^
	/// </summary>
	public partial class BudgetSuppliers{
		///ID
		public int id { get; set; }
		///Œ_–ñID :=Œ_–ñƒ}ƒXƒ^.ID
		public int m_contract_id { get; set; }
		///æˆøæID :=æˆøæƒ}ƒXƒ^.ID
		public int m_supplier_id { get; set; }
		///‘ÎÛ”N“x
		public int target_year { get; set; }
		///NŒ
		public int buget_month_1 { get; set; }
		///N{1Œ
		public int buget_month_2 { get; set; }
		///N{2Œ
		public int buget_month_3 { get; set; }
		///N{3Œ
		public int buget_month_4 { get; set; }
		///N{4Œ
		public int buget_month_5 { get; set; }
		///N{5Œ
		public int buget_month_6 { get; set; }
		///N{6Œ
		public int buget_month_7 { get; set; }
		///N{7Œ
		public int buget_month_8 { get; set; }
		///N{8Œ
		public int buget_month_9 { get; set; }
		///N{9Œ
		public int buget_month_10 { get; set; }
		///N{10Œ
		public int buget_month_11 { get; set; }
		///N{11Œ
		public int buget_month_12 { get; set; }
		///NŒ@–Ú•W—\ZŠz
		public int buget_amount_1 { get; set; }
		///N{1Œ@–Ú•W—\ZŠz
		public int buget_amount_2 { get; set; }
		///N{2Œ@–Ú•W—\ZŠz
		public int buget_amount_3 { get; set; }
		///N{3Œ@–Ú•W—\ZŠz
		public int buget_amount_4 { get; set; }
		///N{4Œ@–Ú•W—\ZŠz
		public int buget_amount_5 { get; set; }
		///N{5Œ@–Ú•W—\ZŠz
		public int buget_amount_6 { get; set; }
		///N{6Œ@–Ú•W—\ZŠz
		public int buget_amount_7 { get; set; }
		///N{7Œ@–Ú•W—\ZŠz
		public int buget_amount_8 { get; set; }
		///N{8Œ@–Ú•W—\ZŠz
		public int buget_amount_9 { get; set; }
		///N{9Œ@–Ú•W—\ZŠz
		public int buget_amount_10 { get; set; }
		///N{10Œ@–Ú•W—\ZŠz
		public int buget_amount_11 { get; set; }
		///N{11Œ@–Ú•W—\ZŠz
		public int buget_amount_12 { get; set; }
		///NŒ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_1 { get; set; }
		///N{1Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_2 { get; set; }
		///N{2Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_3 { get; set; }
		///N{3Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_4 { get; set; }
		///N{4Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_5 { get; set; }
		///N{5Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_6 { get; set; }
		///N{6Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_7 { get; set; }
		///N{7Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_8 { get; set; }
		///N{8Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_9 { get; set; }
		///N{9Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_10 { get; set; }
		///N{10Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_11 { get; set; }
		///N{11Œ@–Ú•W‘e—˜Šz
		public int gross_profit_amount_12 { get; set; }
		///ì¬Ò
		public int created_user { get; set; }
		///ì¬“ú:
		DateTime created_at { get; set; }
		///XVÒ
		public int updated_user { get; set; }
		///XV“ú:
		DateTime updated_at { get; set; }
		///íœ“ú:
		DateTime deleted_at { get; set; }
	}

	public class BudgetSuppliersCollection : ObservableCollection<BudgetSuppliers> {
		public BudgetSuppliersCollection(){
		}
	}
}
