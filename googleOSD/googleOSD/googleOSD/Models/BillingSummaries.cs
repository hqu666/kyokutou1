using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �����T�}���[���
	/// </summary>
	public partial class BillingSummaries{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///����No
		public string billing_no { get; set; }
		///���Ӑ�ID :=�����}�X�^.ID
		public int m_supplier_id { get; set; }
		///�Č�ID :=�Č�����{.ID
		public int t_project_base_id { get; set; }
		///���敪 :���Œ�l�F���敪
		public int closing_kubun { get; set; }
		///�O�񐿋��z
		public decimal last_billing_amount { get; set; }
		///��������z
		public decimal payment_amount { get; set; }
		///�J�z�z
		public int brought_forward_amount { get; set; }
		///���񔄏�z
		public decimal total_amount { get; set; }
		///�����
		public decimal tax_amount { get; set; }
		///���㍇�v
		public decimal total_amount_tax_included { get; set; }
		///���񐿋��z
		public decimal billing_amount { get; set; }
		///��������
		public DateTime billing_closing_date { get; set; }
		///����c���ݒ�t���O :0�F���ߏ�������쐬�A1�F�c���ݒ肩��쐬
		public int first_balance_setting_flag { get; set; }
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

	public class BillingSummariesCollection : ObservableCollection<BillingSummaries> {
		public BillingSummariesCollection(){
		}
	}
}
