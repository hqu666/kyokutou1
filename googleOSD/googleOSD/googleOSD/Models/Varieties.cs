using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �i��}�X�^
	/// </summary>
	public partial class Varieties{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�i��敪 :���Œ�l�F�i��敪
		public int variety_type { get; set; }
		///�i��R�[�h
		public int variety_code { get; set; }
		///�i�햼
		public string variety_name { get; set; }
		///���я�
		public int order { get; set; }
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

	public class VarietiesCollection : ObservableCollection<Varieties> {
		public VarietiesCollection(){
		}
	}
}
