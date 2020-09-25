using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �������U���
	/// </summary>
	public partial class DepositAllocations{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�������ID :=�������i�ꊇ�j.ID
		public int t_deposit_id { get; set; }
		///�Č�ID :=�Č�����{.ID
		public int t_project_base_id { get; set; }
		///�������׃w�b�_ID :=�Č���񐿋����׃w�b�_.ID
		public int t_project_slip_invoice_header_id { get; set; }
		///���U�z
		public decimal allocations_amount { get; set; }
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

	public class DepositAllocationsCollection : ObservableCollection<DepositAllocations> {
		public DepositAllocationsCollection(){
		}
	}
}
