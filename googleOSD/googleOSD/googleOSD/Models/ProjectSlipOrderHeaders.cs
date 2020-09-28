using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �Č����`�[�i�������w�b�_�j
	/// </summary>
	public partial class ProjectSlipOrderHeaders{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�Č�����{ID :=�Č�����{.ID
		public int t_project_base_id { get; set; }
		///�X�e�[�^�X��
		public DateTime status_date { get; set; }
		///�[����ID :=�����}�X�^.ID�@�i���Ӑ�j
		public int d_m_supplier_id { get; set; }
		///�[����F�X�֔ԍ�
		public string d_postal_code { get; set; }
		///�[����F�s���{���h�c :=�s���{���}�X�^.ID
		public int d_m_prefecture_id { get; set; }
		///�[����F�Z���P
		public string d_address_1 { get; set; }
		///�[����F�Z���Q
		public string d_address_2 { get; set; }
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
		///���b�N�t���O :0�F�����b�N�A1�F���b�N��
		public int lock_flag { get; set; }
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

	public class ProjectSlipOrderHeadersCollection : ObservableCollection<ProjectSlipOrderHeaders> {
		public ProjectSlipOrderHeadersCollection(){
		}
	}
}
