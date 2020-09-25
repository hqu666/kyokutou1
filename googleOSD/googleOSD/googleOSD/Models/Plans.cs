using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �v�����}�X�^
	/// </summary>
	public partial class Plans{
		///ID
		public int id { get; set; }
		///�v������
		public string plan_name { get; set; }
		///���[�U�[�� :�����[�U�[���p�ł��邩
		public int number_users { get; set; }
		///���я�
		public int order { get; set; }
		///�Č��Ǘ� :0�F�����A1�F�L��
		public int project_management { get; set; }
		///�����Ǘ� :0�F�����A1�F�L��
		public int property_management { get; set; }
		///�`�[�쐬 :0�F�������A1�ȏ�F�w�薇��
		public int slip_creation { get; set; }
		///�ڋq�Ǘ� :0�F�����A1�F�L��
		public int customer_management { get; set; }
		///���|�Ǘ��i�������߁j :0�F�����A1�F�L��
		public int accounts_receivable_billing_closing { get; set; }
		///����W�v�\ :0�F�����A1�F�L��
		public int sales_aggregate_table { get; set; }
		///�����Ǘ� :0�F�����A1�F�L��
		public int cost_management { get; set; }
		///�X�P�W���[���Ǘ� :0�F�����A1�F�L��
		public int schedule_management { get; set; }
		///�@�蕟����@�\ :0�F�����A1�F�L��
		public int legal_welfare_expenses_feature { get; set; }
		///�\���Ǘ��@�\ :0�F�����A1�F�L��
		public int budget_control_feature { get; set; }
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

	public class PlansCollection : ObservableCollection<Plans> {
		public PlansCollection(){
		}
	}
}
