using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ����Ń}�X�^
	/// </summary>
	public partial class Taxs{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///����ŃR�[�h
		public string tax_cd { get; set; }
		///����Ŗ���
		public string tax_name { get; set; }
		///�^�p�J�n��
		public DateTime operation_date_start { get; set; }
		///�^�p�I����
		public DateTime operation_date_end { get; set; }
		///�ŗ�
		public decimal tax_rate { get; set; }
		///�o�ߑ[�u�K�p�J�n��
		public DateTime transitional_date_start { get; set; }
		///�o�ߑ[�u�K�p�I����
		public DateTime transitional_date_end { get; set; }
		///�����l�t���O
		public int default_flag { get; set; }
		///�ɓ��Y�@�t���O :1�F�ɓ��Y�@�ݒ�A0�F���[�U�[�ݒ�
		public int ks_flag { get; set; }
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

	public class TaxsCollection : ObservableCollection<Taxs> {
		public TaxsCollection(){
		}
	}
}
