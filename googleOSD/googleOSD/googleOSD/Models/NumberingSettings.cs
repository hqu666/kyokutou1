using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �̔Ԑݒ�
	/// </summary>
	public partial class NumberingSettings{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�̔Ԏ�� :���Œ�l�F�̔Ԏ��
		public int numbering_type { get; set; }
		///�ړ����^�ڔ��� :���Œ�l�F�ړ����^�ڔ���
		public int prefix_suffix { get; set; }
		///���ʎq
		public string identifier { get; set; }
		///�̔ԃ��[�� :���Œ�l�F�̔ԃ��[��
		public int numbering_rule { get; set; }
		///����
		public int number_of_digits { get; set; }
		///�ŏI�ԍ�
		public int final_number { get; set; }
		///�쐬��
		public int created_user { get; set; }
		///�쐬����:
		DateTime created_at { get; set; }
		///�X�V��
		public int updated_user { get; set; }
		///�X�V����:
		DateTime updated_at { get; set; }
		///�폜����:
		DateTime deleted_at { get; set; }
	}

	public class NumberingSettingsCollection : ObservableCollection<NumberingSettings> {
		public NumberingSettingsCollection(){
		}
	}
}
