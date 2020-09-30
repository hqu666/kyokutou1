using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �w�����`�[�i�������w�b�_�j
	/// </summary>
	public partial class PurchaseSlipOrderHeaders{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�w������{ID :=�w������{.ID
		public int t_purchase_base_id { get; set; }
		///�X�e�[�^�X��
		public DateTime status_date { get; set; }
		///�E�v
		public string summary { get; set; }
		///���v���z�i�Ŕ��j
		public decimal total_amount { get; set; }
		///����ŋ��z
		public decimal tax_amount { get; set; }
		///����ŋ��z(�y���ŗ��Ώ�)
		public decimal reduction_tax_amount { get; set; }
		///���v���z�i�ō��j
		public decimal total_amount_tax_included { get; set; }
		///�l�����z
		public int discount_amount { get; set; }
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

	public class PurchaseSlipOrderHeadersCollection : ObservableCollection<PurchaseSlipOrderHeaders> {
		public PurchaseSlipOrderHeadersCollection(){
		}
	}
}