using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �X�֔ԍ��}�X�^
	/// </summary>
	public partial class PostalCodes{
		///ID
		public int id { get; set; }
		///�X�֔ԍ�
		public string postal_code { get; set; }
		///�s���{����
		public string prefectures_name { get; set; }
		///�s���{�����J�i
		public string prefectures_kana { get; set; }
		///�Z��
		public string address { get; set; }
		///�Z���J�i
		public string address_kana { get; set; }
		///�쐬��
		public int creater { get; set; }
		///�쐬����:
		public DateTime created_at { get; set; }
		///�X�V��
		public int modifier { get; set; }
		///�X�V����:
		public DateTime updated_at { get; set; }
		///�폜����:
		public DateTime deleted_at { get; set; }
	}

	public class PostalCodesCollection : ObservableCollection<PostalCodes> {
		public PostalCodesCollection(){
		}
	}
}
