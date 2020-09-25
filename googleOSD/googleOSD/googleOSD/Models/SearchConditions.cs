using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���������ۑ�
	/// </summary>
	public partial class SearchConditions{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///������� :���Œ�l�F�������
		public int search_type { get; set; }
		///���O�C�����[�U�[ID :=���O�C�����[�U�[�}�X�^.ID
		public int m_login_users_staff_id { get; set; }
		///������
		public string search_name { get; set; }
		///�����l1
		public string value1 { get; set; }
		///�����l2
		public string value2 { get; set; }
		///�����l3
		public string value3 { get; set; }
		///�����l4
		public string value4 { get; set; }
		///�����l5
		public string value5 { get; set; }
		///�����l6
		public string value6 { get; set; }
		///�����l7
		public string value7 { get; set; }
		///�����l8
		public string value8 { get; set; }
		///�����l9
		public string value9 { get; set; }
		///�����l10
		public string value10 { get; set; }
		///�����l11
		public string value11 { get; set; }
		///�����l12
		public string value12 { get; set; }
		///�����l13
		public string value13 { get; set; }
		///�����l14
		public string value14 { get; set; }
		///�����l15
		public string value15 { get; set; }
		///�����l16
		public string value16 { get; set; }
		///�����l17
		public string value17 { get; set; }
		///�����l18
		public string value18 { get; set; }
		///�����l19
		public string value19 { get; set; }
		///�����l20
		public string value20 { get; set; }
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

	public class SearchConditionsCollection : ObservableCollection<SearchConditions> {
		public SearchConditionsCollection(){
		}
	}
}
