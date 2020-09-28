using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �����ʕi��ʊ|���}�X�^
	/// </summary>
	public partial class SupplierVarietyRates{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///��� :���Œ�l�F�����敪
		public int type_id { get; set; }
		///�����ID :=�����}�X�^.ID
		public int m_supplier_id { get; set; }
		///�i��ID :=�i��}�X�^.ID
		public int m_varietie_id { get; set; }
		///�|��
		public decimal rate { get; set; }
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

	public class SupplierVarietyRatesCollection : ObservableCollection<SupplierVarietyRates> {
		public SupplierVarietyRatesCollection(){
		}
	}
}
