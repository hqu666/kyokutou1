using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �T�[�r�X�ݒ�
	/// </summary>
	public partial class ServiceSettings{
		///ID
		public int id { get; set; }
		///���p�X���[�h�L������ :��
		public int temporary_password_limit { get; set; }
		///�f�[�^�捞�������s�� :�l
		public int concurrent_executions_limit { get; set; }
		///�f�[�^�捞�ő�t�@�C���T�C�Y :KB�P��
		public int data_import_max_file_size { get; set; }
		///�P���|���ݒ蓾�Ӑ�ő匏��
		public int supplier_price_rates_max_count { get; set; }
		///�P���|���ݒ菤�i�ő匏��
		public int product_price_rates_max_count { get; set; }
		///�V�X�e�������e�i���X���[�h�t���O :0�FOff�A1�FOn
		public int is_maintenance { get; set; }
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

	public class ServiceSettingsCollection : ObservableCollection<ServiceSettings> {
		public ServiceSettingsCollection(){
		}
	}
}
