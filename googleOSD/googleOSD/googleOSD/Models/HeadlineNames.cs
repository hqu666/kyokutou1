using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���o���̃}�X�^
	/// </summary>
	public partial class HeadlineNames{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///��� :���Œ�l�F���o����
		public string name_type { get; set; }
		///�R�[�h
		public string name_code { get; set; }
		///����
		public string name_value { get; set; }
		///���я�
		public int order { get; set; }
		///�쐬��
		public int creater { get; set; }
		///�쐬����:
		DateTime created_at { get; set; }
		///�X�V��
		public int modifier { get; set; }
		///�X�V����:
		DateTime updated_at { get; set; }
		///�폜����:
		DateTime deleted_at { get; set; }
	}

	public class HeadlineNamesCollection : ObservableCollection<HeadlineNames> {
		public HeadlineNamesCollection(){
		}
	}
}
