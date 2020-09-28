using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �o�����
	/// </summary>
	public partial class PaymentLumps{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�o��No
		public int withdrawal_no { get; set; }
		///�o����
		public DateTime withdrawal_date { get; set; }
		///�d����ID :=�����}�X�^.ID
		public int m_suppliers_id { get; set; }
		///���ВS����ID :=���ВS���҃}�X�^.ID
		public int m_own_company_staff_id { get; set; }
		///�o���z���v
		public decimal withdrawal_amount_sum { get; set; }
		///�����z���v
		public decimal adjustment_amount_sum { get; set; }
		///�o�����z
		public decimal withdrawal_total_amount { get; set; }
		///�o��1�F�敪 :���Œ�l�F�o���敪
		public int kubun_1 { get; set; }
		///�o��1�F�o���z
		public decimal withdrawal_amount_1 { get; set; }
		///�o��1�F�U���萔��
		public decimal transfer_fee_1 { get; set; }
		///�o��1�F�����z
		public decimal adjustment_amount_1 { get; set; }
		///�o��1�F�戵��sID
		public int handling_bank_id1 { get; set; }
		///�o��1�F��`����
		public DateTime bill_deadline_1 { get; set; }
		///�o��1�F���l
		public string recital_1 { get; set; }
		///�o��1�F�o�����v
		public decimal withdrawal_total_1 { get; set; }
		///�o��2�F�敪 :���Œ�l�F�o���敪
		public int kubun_2 { get; set; }
		///�o��2�F�o���z
		public decimal withdrawal_amount_2 { get; set; }
		///�o��2�F�U���萔��
		public decimal transfer_fee_2 { get; set; }
		///�o��2�F�����z
		public decimal adjustment_amount_2 { get; set; }
		///�o��2�F�戵��sID
		public int handling_bank_id2 { get; set; }
		///�o��2�F��`����
		public DateTime bill_deadline_2 { get; set; }
		///�o��2�F���l
		public string recital_2 { get; set; }
		///�o��2�F�o�����v
		public decimal withdrawal_total_2 { get; set; }
		///�o��3�F�敪 :���Œ�l�F�o���敪
		public int kubun_3 { get; set; }
		///�o��3�F�o���z
		public decimal withdrawal_amount_3 { get; set; }
		///�o��3�F�U���萔��
		public decimal transfer_fee_3 { get; set; }
		///�o��3�F�����z
		public decimal adjustment_amount_3 { get; set; }
		///�o��3�F�戵��sID
		public int handling_bank_id3 { get; set; }
		///�o��3�F��`����
		public DateTime bill_deadline_3 { get; set; }
		///�o��3�F���l
		public string recital_3 { get; set; }
		///�o��3�F�o�����v
		public decimal withdrawal_total_3 { get; set; }
		///�x�����Ώۓ�
		public DateTime payment_closing_target_date { get; set; }
		///�m��� :�m�菈�����s��ꂽ��
		public DateTime confirmed_date { get; set; }
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

	public class PaymentLumpsCollection : ObservableCollection<PaymentLumps> {
		public PaymentLumpsCollection(){
		}
	}
}
