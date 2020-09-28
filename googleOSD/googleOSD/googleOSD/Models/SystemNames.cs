using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �V�X�e���֘A���̃}�X�^
	/// </summary>
	public partial class SystemNames{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�敪 :���Œ�l�F�V�X�e���֘A����
		public int name_type { get; set; }
		///����
		public string name_value { get; set; }
		///���я�
		public int order { get; set; }
		///�쐬��
		public int creater { get; set; }
		///�쐬����:
		public DateTime created_at { get; set; }
		///�X�V��
		public int modifier { get; set; }
		///�X�V����:
		public DateTime updated_at { get; set; }
		///�폜����:
		public DateTime deleted_at { get; set; }
	}

	public class SystemNamesCollection : ObservableCollection<SystemNames> {
		public SystemNamesCollection(){
		}
	}
}
