using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���В����
	/// </summary>
	public partial class ConfirmationProcesses{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///���В��敪 :�Œ�l�F���В��敪
		public bool confirmation_processes_type { get; set; }
		///����
		public DateTime closing_date { get; set; }
		///�쐬��
		public int created_user { get; set; }
		///�쐬����:
		public DateTime created_at { get; set; }
		///�X�V��
		public int updated_user { get; set; }
		///�X�V����:
		public DateTime updated_at { get; set; }
		///�폜����:
		public DateTime deleted_at { get; set; }
	}

	public class ConfirmationProcessesCollection : ObservableCollection<ConfirmationProcesses> {
		public ConfirmationProcessesCollection(){
		}
	}
}
