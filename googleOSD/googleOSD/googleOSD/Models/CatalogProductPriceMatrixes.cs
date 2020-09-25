using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �J�^���O���i�P���}�g���N�X
	/// </summary>
	public partial class CatalogProductPriceMatrixes{
		///ID
		public int id { get; set; }
		///�쐬��
		public int creater { get; set; }
		///�쐬����:
		DateTime created_at { get; set; }
		///�X�V��
		public int modifier { get; set; }
		///�X�V����:
		DateTime updated_at { get; set; }
		///�폜����:
		DateTime deleted_at { get; set; }
	}

	public class CatalogProductPriceMatrixesCollection : ObservableCollection<CatalogProductPriceMatrixes> {
		public CatalogProductPriceMatrixesCollection(){
		}
	}
}
