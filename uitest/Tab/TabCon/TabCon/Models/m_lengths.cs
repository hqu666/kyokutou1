using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// 要尺マスタ
	/// </summary>
	public partial class m_lengths : NotificationObject
	{

		///<summary>
		///ID
		///</summary>
		private int _id;
		public int id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;
				_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///契約ID :=契約マスタ.ID
		///</summary>
		private int _m_contract_id;
		public int m_contract_id
		{
			get => _m_contract_id;
			set
			{
				if (_m_contract_id == value)
					return;
				_m_contract_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クロス　有効巾(cm) :cr=Cross
		///</summary>
		private int _cr_effective_width;
		public int cr_effective_width
		{
			get => _cr_effective_width;
			set
			{
				if (_cr_effective_width == value)
					return;
				_cr_effective_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クロス　購入単位(cm)
		///</summary>
		private int _cr_buy_unit;
		public int cr_buy_unit
		{
			get => _cr_buy_unit;
			set
			{
				if (_cr_buy_unit == value)
					return;
				_cr_buy_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クロス　リピート(cm)
		///</summary>
		private int _cr_repeat;
		public int cr_repeat
		{
			get => _cr_repeat;
			set
			{
				if (_cr_repeat == value)
					return;
				_cr_repeat = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クロス　切り代(cm)
		///</summary>
		private int _cr_cutting_allowance;
		public int cr_cutting_allowance
		{
			get => _cr_cutting_allowance;
			set
			{
				if (_cr_cutting_allowance == value)
					return;
				_cr_cutting_allowance = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クロス　販売
		///</summary>
		private int _cr_sale_type;
		public int cr_sale_type
		{
			get => _cr_sale_type;
			set
			{
				if (_cr_sale_type == value)
					return;
				_cr_sale_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クロス　販売(単位)
		///</summary>
		private int _cr_sale_unit;
		public int cr_sale_unit
		{
			get => _cr_sale_unit;
			set
			{
				if (_cr_sale_unit == value)
					return;
				_cr_sale_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クロス　仕入
		///</summary>
		private int _cr_purchase_type;
		public int cr_purchase_type
		{
			get => _cr_purchase_type;
			set
			{
				if (_cr_purchase_type == value)
					return;
				_cr_purchase_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クロス　仕入（単位）
		///</summary>
		private int _cr_purchase_unit;
		public int cr_purchase_unit
		{
			get => _cr_purchase_unit;
			set
			{
				if (_cr_purchase_unit == value)
					return;
				_cr_purchase_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クロス　施工
		///</summary>
		private int _cr_construction_type;
		public int cr_construction_type
		{
			get => _cr_construction_type;
			set
			{
				if (_cr_construction_type == value)
					return;
				_cr_construction_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クロス　施工（単位）
		///</summary>
		private int _cr_construction_unit;
		public int cr_construction_unit
		{
			get => _cr_construction_unit;
			set
			{
				if (_cr_construction_unit == value)
					return;
				_cr_construction_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///巾木　有効巾(cm) :bb=Baseboard
		///</summary>
		private int _bb_effective_width;
		public int bb_effective_width
		{
			get => _bb_effective_width;
			set
			{
				if (_bb_effective_width == value)
					return;
				_bb_effective_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///巾木　切り代(cm)
		///</summary>
		private int _bb_cutting_allowance;
		public int bb_cutting_allowance
		{
			get => _bb_cutting_allowance;
			set
			{
				if (_bb_cutting_allowance == value)
					return;
				_bb_cutting_allowance = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///巾木　ケース入り数(枚/ケース)
		///</summary>
		private int _bb_case_quantity;
		public int bb_case_quantity
		{
			get => _bb_case_quantity;
			set
			{
				if (_bb_case_quantity == value)
					return;
				_bb_case_quantity = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///巾木　販売
		///</summary>
		private int _bb_sale_type;
		public int bb_sale_type
		{
			get => _bb_sale_type;
			set
			{
				if (_bb_sale_type == value)
					return;
				_bb_sale_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///巾木　販売（単位）
		///</summary>
		private int _bb_sale_unit;
		public int bb_sale_unit
		{
			get => _bb_sale_unit;
			set
			{
				if (_bb_sale_unit == value)
					return;
				_bb_sale_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///巾木　仕入
		///</summary>
		private int _bb_purchase_type;
		public int bb_purchase_type
		{
			get => _bb_purchase_type;
			set
			{
				if (_bb_purchase_type == value)
					return;
				_bb_purchase_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///巾木　仕入（単位）
		///</summary>
		private int _bb_purchase_unit;
		public int bb_purchase_unit
		{
			get => _bb_purchase_unit;
			set
			{
				if (_bb_purchase_unit == value)
					return;
				_bb_purchase_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///巾木　施工
		///</summary>
		private int _bb_construction_type;
		public int bb_construction_type
		{
			get => _bb_construction_type;
			set
			{
				if (_bb_construction_type == value)
					return;
				_bb_construction_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///巾木　施工（単位）
		///</summary>
		private int _bb_construction_unit;
		public int bb_construction_unit
		{
			get => _bb_construction_unit;
			set
			{
				if (_bb_construction_unit == value)
					return;
				_bb_construction_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　巾(mm) :pt= P tile
		///</summary>
		private int _pt_width;
		public int pt_width
		{
			get => _pt_width;
			set
			{
				if (_pt_width == value)
					return;
				_pt_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　長さ(mm)
		///</summary>
		private int _pt_length;
		public int pt_length
		{
			get => _pt_length;
			set
			{
				if (_pt_length == value)
					return;
				_pt_length = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　最小カット巾(mm)
		///</summary>
		private int _pt_min_cut_width;
		public int pt_min_cut_width
		{
			get => _pt_min_cut_width;
			set
			{
				if (_pt_min_cut_width == value)
					return;
				_pt_min_cut_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　ケース入り数
		///</summary>
		private int _pt_case_quantity;
		public int pt_case_quantity
		{
			get => _pt_case_quantity;
			set
			{
				if (_pt_case_quantity == value)
					return;
				_pt_case_quantity = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　㎡当みなし枚数
		///</summary>
		private int _pt_deemed_quantity;
		public int pt_deemed_quantity
		{
			get => _pt_deemed_quantity;
			set
			{
				if (_pt_deemed_quantity == value)
					return;
				_pt_deemed_quantity = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　販売
		///</summary>
		private int _pt_sale_type;
		public int pt_sale_type
		{
			get => _pt_sale_type;
			set
			{
				if (_pt_sale_type == value)
					return;
				_pt_sale_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　販売（単位）
		///</summary>
		private int _pt_sale_unit;
		public int pt_sale_unit
		{
			get => _pt_sale_unit;
			set
			{
				if (_pt_sale_unit == value)
					return;
				_pt_sale_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　仕入
		///</summary>
		private int _pt_purchase_type;
		public int pt_purchase_type
		{
			get => _pt_purchase_type;
			set
			{
				if (_pt_purchase_type == value)
					return;
				_pt_purchase_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　仕入（単位）
		///</summary>
		private int _pt_purchase_unit;
		public int pt_purchase_unit
		{
			get => _pt_purchase_unit;
			set
			{
				if (_pt_purchase_unit == value)
					return;
				_pt_purchase_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　施工
		///</summary>
		private int _pt_construction_type;
		public int pt_construction_type
		{
			get => _pt_construction_type;
			set
			{
				if (_pt_construction_type == value)
					return;
				_pt_construction_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Pタイル　施工（単位） :tc=Tile carpet
		///</summary>
		private int _pt_construction_unit;
		public int pt_construction_unit
		{
			get => _pt_construction_unit;
			set
			{
				if (_pt_construction_unit == value)
					return;
				_pt_construction_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　巾(mm)
		///</summary>
		private int _tc_width;
		public int tc_width
		{
			get => _tc_width;
			set
			{
				if (_tc_width == value)
					return;
				_tc_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　長さ(mm)
		///</summary>
		private int _tc_length;
		public int tc_length
		{
			get => _tc_length;
			set
			{
				if (_tc_length == value)
					return;
				_tc_length = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　最小カット巾(mm)
		///</summary>
		private int _tc_min_cut_width;
		public int tc_min_cut_width
		{
			get => _tc_min_cut_width;
			set
			{
				if (_tc_min_cut_width == value)
					return;
				_tc_min_cut_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　ケース入り数
		///</summary>
		private int _tc_case_quantity;
		public int tc_case_quantity
		{
			get => _tc_case_quantity;
			set
			{
				if (_tc_case_quantity == value)
					return;
				_tc_case_quantity = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　㎡当みなし枚数
		///</summary>
		private int _tc_deemed_quantity;
		public int tc_deemed_quantity
		{
			get => _tc_deemed_quantity;
			set
			{
				if (_tc_deemed_quantity == value)
					return;
				_tc_deemed_quantity = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　販売
		///</summary>
		private int _tc_sale_type;
		public int tc_sale_type
		{
			get => _tc_sale_type;
			set
			{
				if (_tc_sale_type == value)
					return;
				_tc_sale_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　販売（単位）
		///</summary>
		private int _tc_sale_unit;
		public int tc_sale_unit
		{
			get => _tc_sale_unit;
			set
			{
				if (_tc_sale_unit == value)
					return;
				_tc_sale_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　仕入
		///</summary>
		private int _tc_purchase_type;
		public int tc_purchase_type
		{
			get => _tc_purchase_type;
			set
			{
				if (_tc_purchase_type == value)
					return;
				_tc_purchase_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　仕入（単位）
		///</summary>
		private int _tc_purchase_unit;
		public int tc_purchase_unit
		{
			get => _tc_purchase_unit;
			set
			{
				if (_tc_purchase_unit == value)
					return;
				_tc_purchase_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　施工
		///</summary>
		private int _tc_construction_type;
		public int tc_construction_type
		{
			get => _tc_construction_type;
			set
			{
				if (_tc_construction_type == value)
					return;
				_tc_construction_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///タイルカーペット　施工（単位）
		///</summary>
		private int _tc_construction_unit;
		public int tc_construction_unit
		{
			get => _tc_construction_unit;
			set
			{
				if (_tc_construction_unit == value)
					return;
				_tc_construction_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クッションフロア　有効巾(cm) :cf=Cushion floor
		///</summary>
		private int _cf_effective_width;
		public int cf_effective_width
		{
			get => _cf_effective_width;
			set
			{
				if (_cf_effective_width == value)
					return;
				_cf_effective_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クッションフロア　購入単位(cm)
		///</summary>
		private int _cf_buy_unit;
		public int cf_buy_unit
		{
			get => _cf_buy_unit;
			set
			{
				if (_cf_buy_unit == value)
					return;
				_cf_buy_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クッションフロア　リピート(cm)
		///</summary>
		private int _cf_repeat;
		public int cf_repeat
		{
			get => _cf_repeat;
			set
			{
				if (_cf_repeat == value)
					return;
				_cf_repeat = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クッションフロア　切り代(cm)
		///</summary>
		private int _cf_cutting_allowance;
		public int cf_cutting_allowance
		{
			get => _cf_cutting_allowance;
			set
			{
				if (_cf_cutting_allowance == value)
					return;
				_cf_cutting_allowance = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クッションフロア　販売
		///</summary>
		private int _cf_sale_type;
		public int cf_sale_type
		{
			get => _cf_sale_type;
			set
			{
				if (_cf_sale_type == value)
					return;
				_cf_sale_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クッションフロア　販売（単位）
		///</summary>
		private int _cf_sale_unit;
		public int cf_sale_unit
		{
			get => _cf_sale_unit;
			set
			{
				if (_cf_sale_unit == value)
					return;
				_cf_sale_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クッションフロア　仕入
		///</summary>
		private int _cf_purchase_type;
		public int cf_purchase_type
		{
			get => _cf_purchase_type;
			set
			{
				if (_cf_purchase_type == value)
					return;
				_cf_purchase_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クッションフロア　仕入（単位）
		///</summary>
		private int _cf_purchase_unit;
		public int cf_purchase_unit
		{
			get => _cf_purchase_unit;
			set
			{
				if (_cf_purchase_unit == value)
					return;
				_cf_purchase_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クッションフロア　施工
		///</summary>
		private int _cf_construction_type;
		public int cf_construction_type
		{
			get => _cf_construction_type;
			set
			{
				if (_cf_construction_type == value)
					return;
				_cf_construction_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///クッションフロア　施工（単位）
		///</summary>
		private int _cf_construction_unit;
		public int cf_construction_unit
		{
			get => _cf_construction_unit;
			set
			{
				if (_cf_construction_unit == value)
					return;
				_cf_construction_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///カーペット　販売 :ca=carpet
		///</summary>
		private int _ca_sale_type;
		public int ca_sale_type
		{
			get => _ca_sale_type;
			set
			{
				if (_ca_sale_type == value)
					return;
				_ca_sale_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///カーペット　販売（単位）
		///</summary>
		private int _ca_sale_unit;
		public int ca_sale_unit
		{
			get => _ca_sale_unit;
			set
			{
				if (_ca_sale_unit == value)
					return;
				_ca_sale_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///カーペット　仕入
		///</summary>
		private int _ca_purchase_type;
		public int ca_purchase_type
		{
			get => _ca_purchase_type;
			set
			{
				if (_ca_purchase_type == value)
					return;
				_ca_purchase_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///カーペット　仕入（単位）
		///</summary>
		private int _ca_purchase_unit;
		public int ca_purchase_unit
		{
			get => _ca_purchase_unit;
			set
			{
				if (_ca_purchase_unit == value)
					return;
				_ca_purchase_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///カーペット　施工
		///</summary>
		private int _ca_construction_type;
		public int ca_construction_type
		{
			get => _ca_construction_type;
			set
			{
				if (_ca_construction_type == value)
					return;
				_ca_construction_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///カーペット　施工（単位）
		///</summary>
		private int _ca_construction_unit;
		public int ca_construction_unit
		{
			get => _ca_construction_unit;
			set
			{
				if (_ca_construction_unit == value)
					return;
				_ca_construction_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///作成者
		///</summary>
		private int _created_user;
		public int created_user
		{
			get => _created_user;
			set
			{
				if (_created_user == value)
					return;
				_created_user = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///作成日時
		///</summary>
		private DateTime _created_at;
		public DateTime created_at
		{
			get => _created_at;
			set
			{
				if (_created_at == value)
					return;
				_created_at = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///更新者
		///</summary>
		private int _updated_user;
		public int updated_user
		{
			get => _updated_user;
			set
			{
				if (_updated_user == value)
					return;
				_updated_user = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///更新日時
		///</summary>
		private DateTime _updated_at;
		public DateTime updated_at
		{
			get => _updated_at;
			set
			{
				if (_updated_at == value)
					return;
				_updated_at = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///削除日時
		///</summary>
		private DateTime _deleted_at;
		public DateTime deleted_at
		{
			get => _deleted_at;
			set
			{
				if (_deleted_at == value)
					return;
				_deleted_at = value;
				RaisePropertyChanged();
			}
		}

	}


	public class m_lengthsCollection : ObservableCollection<m_lengths> {
		public m_lengthsCollection(){
		}
	}
}
