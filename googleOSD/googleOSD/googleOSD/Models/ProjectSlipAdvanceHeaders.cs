using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �Č����`�[�i�O����������w�b�_�j
	/// </summary>
	public partial class ProjectSlipAdvanceHeaders{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�Č�����{ID :=�Č�����{.ID
		public int t_project_base_id { get; set; }
		///�󒍓�
		public DateTime order_date { get; set; }
		///�������
		public string trading_condition { get; set; }
		///�E�v
		public string summary { get; set; }
		///���v���z�i�Ŕ��j
		public decimal total_amount { get; set; }
		///����ŋ��z
		public decimal tax_amount { get; set; }
		///���v���z�i�ō��j
		public decimal total_amount_tax_included { get; set; }
		///�l�����z
		public int discount_amount { get; set; }
		///�Č��e����
		public decimal project_gross_profit_rate { get; set; }
		///�Č��e�����z
		public int project_gross_profit_amount { get; set; }
		///�����U������ :=�U����}�X�^�DID
		public int billing_transfer_target_information { get; set; }
		///���b�N�t���O :0�F�����b�N�A1�F���b�N��
		public bool lock_flag { get; set; }
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

	public class ProjectSlipAdvanceHeadersCollection : ObservableCollection<ProjectSlipAdvanceHeaders> {
		public ProjectSlipAdvanceHeadersCollection(){
		}
	}
}
