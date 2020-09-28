using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �W�v�敪���̃}�X�^
	/// </summary>
	public partial class CategoryNames{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�敪 :���Œ�l�F�W�v�敪����
		public int name_type { get; set; }
		///�R�[�h
		public int name_code { get; set; }
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

	public class CategoryNamesCollection : ObservableCollection<CategoryNames> {
		public CategoryNamesCollection(){
		}
	}
}
