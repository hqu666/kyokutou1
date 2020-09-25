using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �w�����`�[�i���t��j
	/// </summary>
	public partial class PurchaseSlipLetters{
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

	public class PurchaseSlipLettersCollection : ObservableCollection<PurchaseSlipLetters> {
		public PurchaseSlipLettersCollection(){
		}
	}
}
