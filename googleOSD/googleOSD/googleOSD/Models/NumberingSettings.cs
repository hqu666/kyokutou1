using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ÌÔÝè
	/// </summary>
	public partial class NumberingSettings{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///ÌÔíÊ :¦ÅèlFÌÔíÊ
		public int numbering_type { get; set; }
		///Úª«^Úö« :¦ÅèlFÚª«^Úö«
		public int prefix_suffix { get; set; }
		///¯Êq
		public string identifier { get; set; }
		///ÌÔ[ :¦ÅèlFÌÔ[
		public int numbering_rule { get; set; }
		///
		public int number_of_digits { get; set; }
		///ÅIÔ
		public int final_number { get; set; }
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

	public class NumberingSettingsCollection : ObservableCollection<NumberingSettings> {
		public NumberingSettingsCollection(){
		}
	}
}
