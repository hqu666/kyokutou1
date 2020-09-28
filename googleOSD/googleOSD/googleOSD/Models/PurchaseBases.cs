using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �w������{
	/// </summary>
	public partial class PurchaseBases{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�w���ԍ�
		public string purchase_code { get; set; }
		///�w���Ǘ��ԍ�
		public string purchase_manage_code { get; set; }
		///�w���Č���
		public string purchase_name { get; set; }
		///��]�[��
		public DateTime desired_delivery_date { get; set; }
		///����ID :=�����}�X�^.ID
		public int m_property_id { get; set; }
		///�����ID :=�����}�X�^.ID�@�i�d����j
		public int m_supplier_id { get; set; }
		///�d����S����ID :=����敔��S���҃}�X�^.ID
		public int m_supplier_staff_id { get; set; }
		///�[����ID :=�����}�X�^.ID�@�i���Ӑ�j
		public int d_m_supplier_id { get; set; }
		///�[����F�X�֔ԍ� :=�s���{���}�X�^.ID
		public string d_postal_code { get; set; }
		///�[����F�s���{���h�c
		public int d_m_prefecture_id { get; set; }
		///�[����F�Z���P
		public string d_address_1 { get; set; }
		///�[����F�Z���Q
		public string d_address_2 { get; set; }
		///�[����F�����p�Z�� :�X�֔ԍ��{�s���{�����{�Z���P�{�Z���Q
		public string d_search_address { get; set; }
		///����ID :=����}�X�^.ID
		public int m_department_id { get; set; }
		///�����S����ID :=���ВS���҃}�X�^.ID
		public int h_m_own_company_staff_id { get; set; }
		///�[�i���ԍ�
		public DateTime delivery_slip_code { get; set; }
		///�x���\���
		public DateTime payment_expected_date { get; set; }
		///����
		public string memo { get; set; }
		///�E�v
		public string summary { get; set; }
		///�m��� :�m�菈�����s��ꂽ��
		public DateTime confirmed_date { get; set; }
		///�X�e�[�^�X :���Œ�l�F�w���X�e�[�^�X
		public int status { get; set; }
		///�쐬��
		public int created_user { get; set; }
		///�쐬����:
		public DateTime created_at { get; set; }
		///�X�V��
		public int updated_user { get; set; }
		///�X�V����:
		public DateTime updated_at { get; set; }
		///�폜����:
		public DateTime deleted_at { get; set; }
	}

	public class PurchaseBasesCollection : ObservableCollection<PurchaseBases> {
		public PurchaseBasesCollection(){
		}
	}
}
