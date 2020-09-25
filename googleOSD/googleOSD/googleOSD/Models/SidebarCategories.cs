using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �T�C�h�o�[�J�e�S���}�X�^
	/// </summary>
	public partial class SidebarCategories{
		///ID
		public int id { get; set; }
		///�J�e�S���L�[
		public string category_key { get; set; }
		///URL
		public string url_address { get; set; }
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

	public class SidebarCategoriesCollection : ObservableCollection<SidebarCategories> {
		public SidebarCategoriesCollection(){
		}
	}
}
