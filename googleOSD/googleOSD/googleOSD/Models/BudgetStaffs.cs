using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ©ÐSÒÊ\Z}X^
	/// </summary>
	public partial class BudgetStaffs{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///©ÐSÒID :=©ÐSÒ}X^.ID
		public int m_own_company_staff_id { get; set; }
		///ÎÛNx
		public int target_year { get; set; }
		///N
		public int buget_month_1 { get; set; }
		///N{1
		public int buget_month_2 { get; set; }
		///N{2
		public int buget_month_3 { get; set; }
		///N{3
		public int buget_month_4 { get; set; }
		///N{4
		public int buget_month_5 { get; set; }
		///N{5
		public int buget_month_6 { get; set; }
		///N{6
		public int buget_month_7 { get; set; }
		///N{7
		public int buget_month_8 { get; set; }
		///N{8
		public int buget_month_9 { get; set; }
		///N{9
		public int buget_month_10 { get; set; }
		///N{10
		public int buget_month_11 { get; set; }
		///N{11
		public int buget_month_12 { get; set; }
		///N@ÚW\Zz
		public int buget_amount_1 { get; set; }
		///N{1@ÚW\Zz
		public int buget_amount_2 { get; set; }
		///N{2@ÚW\Zz
		public int buget_amount_3 { get; set; }
		///N{3@ÚW\Zz
		public int buget_amount_4 { get; set; }
		///N{4@ÚW\Zz
		public int buget_amount_5 { get; set; }
		///N{5@ÚW\Zz
		public int buget_amount_6 { get; set; }
		///N{6@ÚW\Zz
		public int buget_amount_7 { get; set; }
		///N{7@ÚW\Zz
		public int buget_amount_8 { get; set; }
		///N{8@ÚW\Zz
		public int buget_amount_9 { get; set; }
		///N{9@ÚW\Zz
		public int buget_amount_10 { get; set; }
		///N{10@ÚW\Zz
		public int buget_amount_11 { get; set; }
		///N{11@ÚW\Zz
		public int buget_amount_12 { get; set; }
		///N@ÚWez
		public int gross_profit_amount_1 { get; set; }
		///N{1@ÚWez
		public int gross_profit_amount_2 { get; set; }
		///N{2@ÚWez
		public int gross_profit_amount_3 { get; set; }
		///N{3@ÚWez
		public int gross_profit_amount_4 { get; set; }
		///N{4@ÚWez
		public int gross_profit_amount_5 { get; set; }
		///N{5@ÚWez
		public int gross_profit_amount_6 { get; set; }
		///N{6@ÚWez
		public int gross_profit_amount_7 { get; set; }
		///N{7@ÚWez
		public int gross_profit_amount_8 { get; set; }
		///N{8@ÚWez
		public int gross_profit_amount_9 { get; set; }
		///N{9@ÚWez
		public int gross_profit_amount_10 { get; set; }
		///N{10@ÚWez
		public int gross_profit_amount_11 { get; set; }
		///N{11@ÚWez
		public int gross_profit_amount_12 { get; set; }
		///ì¬Ò
		public int created_user { get; set; }
		///ì¬ú:
		public DateTime created_at { get; set; }
		///XVÒ
		public int updated_user { get; set; }
		///XVú:
		public DateTime updated_at { get; set; }
		///íú:
		public DateTime deleted_at { get; set; }
	}

	public class BudgetStaffsCollection : ObservableCollection<BudgetStaffs> {
		public BudgetStaffsCollection(){
		}
	}
}
