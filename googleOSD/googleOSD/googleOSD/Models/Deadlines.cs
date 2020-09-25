using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 締日マスタ
	/// </summary>
	public partial class Deadlines{
		///ID
		public int id { get; set; }
		///取引先区分 :※取引先区分
		public int supplier_type { get; set; }
		///締日 :0：随時、日付（1～29）、99：末締め
		public DateTime closing_date { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		DateTime updated_at { get; set; }
		///削除日時:
		DateTime deleted_at { get; set; }
	}

	public class DeadlinesCollection : ObservableCollection<Deadlines> {
		public DeadlinesCollection(){
		}
	}
}
