using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �Č����`�[�i�����㐿�������ׁj
	/// </summary>
	public partial class ProjectSlipTemporaryDetails{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�����㐿�����w�b�_ID :=�Č����`�[�i�����㐿�����w�b�_�j.ID
		public int t_project_slip_temporary_headers_id { get; set; }
		///�s�ԍ�
		public int col_number { get; set; }
		///���o�� :0�F���o���ȊO�A1�F���o��
		public bool heading_flag { get; set; }
		///�敪 :���Œ�l��`���FA-5.���ׂ̋敪
		public int name_type { get; set; }
		///�ꏊ
		public string event_place { get; set; }
		///�ӏ�
		public string place { get; set; }
		///���Еi��
		public string product_cd { get; set; }
		///���[�J�[�i��
		public string maker_cd { get; set; }
		///���[�J�[��
		public string maker_name { get; set; }
		///���iID :=���i�}�X�^�DID
		public int m_product_id { get; set; }
		///�i��
		public string product_name { get; set; }
		///�K�i
		public string standard { get; set; }
		///�i��ID :=�i��}�X�^�DID
		public int m_varietie_id { get; set; }
		///�i�햼
		public string variety_name { get; set; }
		///����
		public decimal quantity { get; set; }
		///�P�ʖ� :=�V�X�e���֘A���̃}�X�^.ID�@�i�敪=2)
		public string unit_name { get; set; }
		///�P��
		public decimal price { get; set; }
		///���z
		public decimal amount { get; set; }
		///���l
		public string remark { get; set; }
		///�̔����i�Ŕ��j
		public decimal sales_retail_price_tax_excluded { get; set; }
		///�|��
		public decimal rate { get; set; }
		///�����ID :=����Ń}�X�^�DID
		public int m_tax_id { get; set; }
		///�ŗ�
		public decimal tax_rate { get; set; }
		///�@����|��
		public decimal court_productivity_rate { get; set; }
		///�����
		public decimal tax_amount { get; set; }
		///�\���t���O :0�F��\���A1�F�\��
		public bool display_flag { get; set; }
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

	public class ProjectSlipTemporaryDetailsCollection : ObservableCollection<ProjectSlipTemporaryDetails> {
		public ProjectSlipTemporaryDetailsCollection(){
		}
	}
}