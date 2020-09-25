using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �ڋq���������ڍ�
	/// </summary>
	public partial class CustomerConditionDetails{
		///ID
		public int id { get; set; }
		///�_��ID :=�_����.ID
		public int m_contract_id { get; set; }
		///�ڋq����������{ID
		public int search_criteria_base_id { get; set; }
		///�����ԍ� :���������̍s�ԍ�
		public int condition_number { get; set; }
		///And/Or
		public string conjunction { get; set; }
		///�O������
		public string previous_parenthesis { get; set; }
		///���� :���Œ�l�F�ڋq���������F���ځi�\���p�j�A�ڋq���������F���ځi�����p�j
		public int item { get; set; }
		///��r������� :���Œ�l�F�ڋq���������F��r��������i���Z�q�j
		public int comparing_value_3 { get; set; }
		///��r����l�P
		public string comparing_value_1 { get; set; }
		///��r����l�Q
		public string comparing_value_2 { get; set; }
		///�ォ����
		public string after_parenthesis { get; set; }
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

	public class CustomerConditionDetailsCollection : ObservableCollection<CustomerConditionDetails> {
		public CustomerConditionDetailsCollection(){
		}
	}
}
