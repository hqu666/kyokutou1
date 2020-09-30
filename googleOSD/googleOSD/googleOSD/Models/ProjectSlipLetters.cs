using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �Č����`�[�i���t��j
	/// </summary>
	public partial class ProjectSlipLetters{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�Č�����{ID :=�Č�����{.ID
		public int t_project_base_id { get; set; }
		///�X�e�[�^�X��
		public DateTime status_date { get; set; }
		///�E�v
		public string summary { get; set; }
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

	public class ProjectSlipLettersCollection : ObservableCollection<ProjectSlipLetters> {
		public ProjectSlipLettersCollection(){
		}
	}
}