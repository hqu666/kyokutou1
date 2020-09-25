using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �x���T�}���[���
	/// </summary>
	public partial class PaymentSummaries{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�x��No
		public string payment_no { get; set; }
		///�d����ID :=�����}�X�^.ID
		public int m_suppliers_id { get; set; }
		///�w������{ID :=�w������{.ID
		public int t_purchase_base_id { get; set; }
		///���敪 :���Œ�l�F���敪
		public int closing_kubun { get; set; }
		///�O��x���z
		public decimal last_payment_amount { get; set; }
		///����o���z
		public decimal currenct_withdrawal_amount { get; set; }
		///�J�z�z
		public int brought_forward_amount { get; set; }
		///����d���z
		public decimal currenct_stocking_amount { get; set; }
		///�����
		public decimal tax_amount { get; set; }
		///�d�����v
		public int purchase_sum { get; set; }
		///����x���z
		public decimal currenct_payment_amount { get; set; }
		///�x������
		public DateTime payment_closing_date { get; set; }
		///����c���ݒ�t���O :0�F���ߏ�������쐬�A1�F�c���ݒ肩��쐬
		public int first_balance_setting_flag { get; set; }
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

	public class PaymentSummariesCollection : ObservableCollection<PaymentSummaries> {
		public PaymentSummariesCollection(){
		}
	}
}
