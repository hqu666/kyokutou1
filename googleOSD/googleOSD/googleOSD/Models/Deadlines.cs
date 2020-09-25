using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �����}�X�^
	/// </summary>
	public partial class Deadlines{
		///ID
		public int id { get; set; }
		///�����敪 :�������敪
		public int supplier_type { get; set; }
		///���� :0�F�����A���t�i1�`29�j�A99�F������
		public DateTime closing_date { get; set; }
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

	public class DeadlinesCollection : ObservableCollection<Deadlines> {
		public DeadlinesCollection(){
		}
	}
}
