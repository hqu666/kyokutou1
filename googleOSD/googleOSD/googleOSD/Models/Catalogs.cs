using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �J�^���O�}�X�^
	/// </summary>
	public partial class Catalogs{
		///ID
		public int id { get; set; }
		///�J�^���OID
		public string catalog_id { get; set; }
		///�J�^���O��
		public string catalog_name { get; set; }
		///�L������(FROM)
		public DateTime rental_start { get; set; }
		///�L������(TO)
		public DateTime rental_end { get; set; }
		///�z�M��~ :1:�z�M��~
		public int is_unsubscribe { get; set; }
		///����
		public string memo { get; set; }
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

	public class CatalogsCollection : ObservableCollection<Catalogs> {
		public CatalogsCollection(){
		}
	}
}
