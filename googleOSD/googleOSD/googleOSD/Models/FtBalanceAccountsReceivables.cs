using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ����c�����|�z
	/// </summary>
	public partial class FtBalanceAccountsReceivables{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contracts_id { get; set; }
		///�����ID :=�����}�X�^.ID
		public int m_suppliers_id { get; set; }
		///�O�����|��
		public DateTime last_month_date { get; set; }
		///�O�����|�z
		public int last_month_amount { get; set; }
		///�폜�t���O
		public int is_deleted { get; set; }
		///�쐬��
		public int creater { get; set; }
		///�쐬����:
		public DateTime created_at { get; set; }
		///�X�V��
		public int modifier { get; set; }
		///�X�V����:
		public DateTime updated_at { get; set; }

	}

	public class FtBalanceAccountsReceivablesCollection : ObservableCollection<FtBalanceAccountsReceivables> {
		public FtBalanceAccountsReceivablesCollection(){
		}
	}
}
