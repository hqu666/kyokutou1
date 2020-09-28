using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ÚqÖA¼Ì}X^
	/// </summary>
	public partial class ClientNames{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///æª :¦ÅèlFÚqÖA¼Ì
		public int name_type { get; set; }
		///¼Ì
		public string name_value { get; set; }
		///ÀÑ
		public int order { get; set; }
		///ì¬Ò
		public int creater { get; set; }
		///ì¬ú:
		public DateTime created_at { get; set; }
		///XVÒ
		public int modifier { get; set; }
		///XVú:
		public DateTime updated_at { get; set; }
		///íú:
		public DateTime deleted_at { get; set; }
	}

	public class ClientNamesCollection : ObservableCollection<ClientNames> {
		public ClientNamesCollection(){
		}
	}
}
