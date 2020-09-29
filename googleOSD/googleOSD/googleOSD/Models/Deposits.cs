using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �������
	/// </summary>
	public partial class Deposits{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�������@ :0�F�ʁA1�F�ꊇ
		public int deposit_method { get; set; }
		///������� :0�F����A1�F�O���
		public int deposit_type { get; set; }
		///����No
		public int deposit_code { get; set; }
		///������
		public DateTime deposit_date { get; set; }
		///���Ӑ�ID :=�����}�X�^.ID
		public int m_supplier_id { get; set; }
		///���ВS����ID :=���ВS���҃}�X�^.ID
		public int m_own_company_staff_id { get; set; }
		///�����z���v
		public decimal payment_sum { get; set; }
		///�����z���v
		public decimal adjustment_amount_sum { get; set; }
		///�������z
		public decimal total_payment_sum { get; set; }
		///����1�F�敪 :���Œ�l�F�����敪
		public int deposit_classification_1 { get; set; }
		///����1�F�����z
		public decimal deposit_amount_1 { get; set; }
		///����1�F�U���萔��
		public decimal transfer_commission_1 { get; set; }
		///����1�F�����z
		public decimal adjustment_amount_1 { get; set; }
		///����1�F�戵��sID
		public int m_bank_id_1 { get; set; }
		///����1�F��`����
		public DateTime bill_deadline_1 { get; set; }
		///����1�F���l
		public string note_1 { get; set; }
		///����1�F�������v
		public decimal total_payment_1 { get; set; }
		///����2�F�敪 :���Œ�l�F�����敪
		public int deposit_classification_2 { get; set; }
		///����2�F�����z
		public decimal deposit_amount_2 { get; set; }
		///����2�F�U���萔��
		public decimal transfer_commission_2 { get; set; }
		///����2�F�����z
		public decimal adjustment_amount_2 { get; set; }
		///����2�F�戵��sID
		public int m_bank_id_2 { get; set; }
		///����2�F��`����
		public DateTime bill_deadline_2 { get; set; }
		///����2�F���l
		public string note_2 { get; set; }
		///����2�F�������v
		public decimal total_payment_2 { get; set; }
		///����3�F�敪 :���Œ�l�F�����敪
		public int deposit_classification_3 { get; set; }
		///����3�F�����z
		public decimal deposit_amount_3 { get; set; }
		///����3�F�U���萔��
		public decimal transfer_commission_3 { get; set; }
		///����3�F�����z
		public decimal adjustment_amount_3 { get; set; }
		///����3�F�戵��sID
		public int m_bank_id_3 { get; set; }
		///����3�F��`����
		public DateTime bill_deadline_3 { get; set; }
		///����3�F���l
		public string note_3 { get; set; }
		///����3�F�������v
		public decimal total_payment_3 { get; set; }
		///�������Ώۓ�
		public DateTime billing_closing_target_date { get; set; }
		///�m��� :�m�菈�����s��ꂽ��
		public DateTime confirmed_date { get; set; }
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

	public class DepositsCollection : ObservableCollection<Deposits> {
		public DepositsCollection(){
		}
	}
}
