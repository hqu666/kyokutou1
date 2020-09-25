using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �w�����`�[�i�d�����w�b�_�j
	/// </summary>
	public partial class PurchaseSlipPurchaseHeaders{
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
		public int lock_flag { get; set; }
		///�x�����Ώۓ�
		public DateTime payment_closing_target_date { get; set; }
		///�x�������s�t���O :0�F�����s�A1�F���s��
		public int payment_form_issuing_flag { get; set; }
		///�x�������s��
		public DateTime payment_form_issuing_date { get; set; }
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

	public class PurchaseSlipPurchaseHeadersCollection : ObservableCollection<PurchaseSlipPurchaseHeaders> {
		public PurchaseSlipPurchaseHeadersCollection(){
		}
	}
}
