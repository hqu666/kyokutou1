using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �V�X�e���ݒ�
	/// </summary>
	public partial class SystemSettings{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�����^�u����1
		public string cost_tab_name1 { get; set; }
		///�����^�u����2
		public string cost_tab_name2 { get; set; }
		///�����^�u����3
		public string cost_tab_name3 { get; set; }
		///�`�[�w�b�_�W�v�敪����1
		public string slip_header_aggregate_name1 { get; set; }
		///�`�[�w�b�_�W�v�敪����2
		public string slip_header_aggregate_name2 { get; set; }
		///�`�[�w�b�_�W�v�敪����3
		public string slip_header_aggregate_name3 { get; set; }
		///�`�[�w�b�_�W�v�敪����4
		public string slip_header_aggregate_name4 { get; set; }
		///���i�}�X�^�W�v�敪����1
		public string product_aggregate_name1 { get; set; }
		///���i�}�X�^�W�v�敪����2
		public string product_aggregate_name2 { get; set; }
		///�ڋq�}�X�^�W�v�敪����1
		public string client_aggregate_name1 { get; set; }
		///�ڋq�}�X�^�W�v�敪����2
		public string client_aggregate_name2 { get; set; }
		///�ڋq�}�X�^�W�v�敪����3
		public string client_aggregate_name3 { get; set; }
		///�ڋq�}�X�^�W�v�敪����4
		public string client_aggregate_name4 { get; set; }
		///�ڋq�}�X�^�W�v�敪����5
		public string client_aggregate_name5 { get; set; }
		///�����Ǘ��t���O
		public int property_management_flag { get; set; }
		///�����t���O
		public int cost_function_flag { get; set; }
		///�v�ڋ@�\�t���O
		public int width_function_flag { get; set; }
		///����t���O :0�F���喳���A1�F���傠��
		public int department_flag { get; set; }
		///�P���|���ݒ蓾�Ӑ�ő匏��
		public int supplier_price_rates_max_count { get; set; }
		///�P���|���ݒ菤�i�ő匏��
		public int product_price_rates_max_count { get; set; }
		///���[�g�p�X :�Č���{���(ks009)��A�����}�X�^(ks022)�́u�t�@�C���Y�t�v��Google�A�g���Ă��Ȃ���
		public string root_path { get; set; }
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

	public class SystemSettingsCollection : ObservableCollection<SystemSettings> {
		public SystemSettingsCollection(){
		}
	}
}
