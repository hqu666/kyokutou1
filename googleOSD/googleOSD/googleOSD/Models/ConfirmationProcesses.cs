using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ©Ð÷îñ
	/// </summary>
	public partial class ConfirmationProcesses{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///©Ð÷æª :ÅèlF©Ð÷æª
		public int confirmation_processes_type { get; set; }
		///÷ú
		public DateTime closing_date { get; set; }
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

	public class ConfirmationProcessesCollection : ObservableCollection<ConfirmationProcesses> {
		public ConfirmationProcessesCollection(){
		}
	}
}
