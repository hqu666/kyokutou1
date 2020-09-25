using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���i�P���}�g���N�X
	/// </summary>
	public partial class ProductPriceMatrixes{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///���iID :=���i�}�X�^.ID
		public int m_product_id { get; set; }
		///�c����
		public string col_name { get; set; }
		///������
		public string row_name { get; set; }
		///�s1 :�J���}��؂�ŗ�̏����i�[
		public string row1 { get; set; }
		///�s2 :��j100,100,100,100,100,,,
		public string row2 { get; set; }
		///�s3 :��j,,,,,,,
		public string row3 { get; set; }
		///�s4
		public string row4 { get; set; }
		///�s5
		public string row5 { get; set; }
		///�s6
		public string row6 { get; set; }
		///�s7
		public string row7 { get; set; }
		///�s8
		public string row8 { get; set; }
		///�c�����ږ�1
		public string col_item_name1 { get; set; }
		///�c�����ږ�2
		public string col_item_name2 { get; set; }
		///�c�����ږ�3
		public string col_item_name3 { get; set; }
		///�c�����ږ�4
		public string col_item_name4 { get; set; }
		///�c�����ږ�5
		public string col_item_name5 { get; set; }
		///�c�����ږ�6
		public string col_item_name6 { get; set; }
		///�c�����ږ�7
		public string col_item_name7 { get; set; }
		///�c�����ږ�8
		public string col_item_name8 { get; set; }
		///�������ږ�1
		public string row_item_name1 { get; set; }
		///�������ږ�2
		public string row_item_name2 { get; set; }
		///�������ږ�3
		public string row_item_name3 { get; set; }
		///�������ږ�4
		public string row_item_name4 { get; set; }
		///�������ږ�5
		public string row_item_name5 { get; set; }
		///�������ږ�6
		public string row_item_name6 { get; set; }
		///�������ږ�7
		public string row_item_name7 { get; set; }
		///�������ږ�8
		public string row_item_name8 { get; set; }
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

	public class ProductPriceMatrixesCollection : ObservableCollection<ProductPriceMatrixes> {
		public ProductPriceMatrixesCollection(){
		}
	}
}
