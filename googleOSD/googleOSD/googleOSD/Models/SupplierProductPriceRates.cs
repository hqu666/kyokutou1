using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �����ʏ��i�ʒP���|���}�X�^
	/// </summary>
	public partial class SupplierProductPriceRates{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///��� :���Œ�l�F�����敪
		public int type_id { get; set; }
		///�����ID :=�����}�X�^.ID
		public int m_supplier_id { get; set; }
		///���iID :=���i�}�X�^.ID
		public int m_product_id { get; set; }
		///�P��
		public decimal price { get; set; }
		///�|��
		public decimal rate { get; set; }
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

	public class SupplierProductPriceRatesCollection : ObservableCollection<SupplierProductPriceRates> {
		public SupplierProductPriceRatesCollection(){
		}
	}
}
