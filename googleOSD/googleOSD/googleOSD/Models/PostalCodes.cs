using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// —X•Ö”Ô†ƒ}ƒXƒ^
	/// </summary>
	public partial class PostalCodes{
		///ID
		public int id { get; set; }
		///—X•Ö”Ô†
		public string postal_code { get; set; }
		///“s“¹•{Œ§–¼
		public string prefectures_name { get; set; }
		///“s“¹•{Œ§–¼ƒJƒi
		public string prefectures_kana { get; set; }
		///ZŠ
		public string address { get; set; }
		///ZŠƒJƒi
		public string address_kana { get; set; }
		///ì¬Ò
		public int creater { get; set; }
		///ì¬“ú:
		public DateTime created_at { get; set; }
		///XVÒ
		public int modifier { get; set; }
		///XV“ú:
		public DateTime updated_at { get; set; }
		///íœ“ú:
		public DateTime deleted_at { get; set; }
	}

	public class PostalCodesCollection : ObservableCollection<PostalCodes> {
		public PostalCodesCollection(){
		}
	}
}
