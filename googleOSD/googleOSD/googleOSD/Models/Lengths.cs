using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 要尺マスタ
	/// </summary>
	public partial class Lengths{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///クロス　有効巾(cm) :cr=Cross
		public int cr_effective_width { get; set; }
		///クロス　購入単位(cm)
		public int cr_buy_unit { get; set; }
		///クロス　リピート(cm)
		public int cr_repeat { get; set; }
		///クロス　切り代(cm)
		public int cr_cutting_allowance { get; set; }
		///クロス　販売
		public int cr_sale_type { get; set; }
		///クロス　販売(単位)
		public int cr_sale_unit { get; set; }
		///クロス　仕入
		public int cr_purchase_type { get; set; }
		///クロス　仕入（単位）
		public int cr_purchase_unit { get; set; }
		///クロス　施工
		public int cr_construction_type { get; set; }
		///クロス　施工（単位）
		public int cr_construction_unit { get; set; }
		///巾木　有効巾(cm) :bb=Baseboard
		public int bb_effective_width { get; set; }
		///巾木　切り代(cm)
		public int bb_cutting_allowance { get; set; }
		///巾木　ケース入り数(枚/ケース)
		public int bb_case_quantity { get; set; }
		///巾木　販売
		public int bb_sale_type { get; set; }
		///巾木　販売（単位）
		public int bb_sale_unit { get; set; }
		///巾木　仕入
		public int bb_purchase_type { get; set; }
		///巾木　仕入（単位）
		public int bb_purchase_unit { get; set; }
		///巾木　施工
		public int bb_construction_type { get; set; }
		///巾木　施工（単位）
		public int bb_construction_unit { get; set; }
		///Pタイル　巾(mm) :pt= P tile
		public int pt_width { get; set; }
		///Pタイル　長さ(mm)
		public int pt_length { get; set; }
		///Pタイル　最小カット巾(mm)
		public int pt_min_cut_width { get; set; }
		///Pタイル　ケース入り数
		public int pt_case_quantity { get; set; }
		///Pタイル　㎡当みなし枚数
		public int pt_deemed_quantity { get; set; }
		///Pタイル　販売
		public int pt_sale_type { get; set; }
		///Pタイル　販売（単位）
		public int pt_sale_unit { get; set; }
		///Pタイル　仕入
		public int pt_purchase_type { get; set; }
		///Pタイル　仕入（単位）
		public int pt_purchase_unit { get; set; }
		///Pタイル　施工
		public int pt_construction_type { get; set; }
		///Pタイル　施工（単位） :tc=Tile carpet
		public int pt_construction_unit { get; set; }
		///タイルカーペット　巾(mm)
		public int tc_width { get; set; }
		///タイルカーペット　長さ(mm)
		public int tc_length { get; set; }
		///タイルカーペット　最小カット巾(mm)
		public int tc_min_cut_width { get; set; }
		///タイルカーペット　ケース入り数
		public int tc_case_quantity { get; set; }
		///タイルカーペット　㎡当みなし枚数
		public int tc_deemed_quantity { get; set; }
		///タイルカーペット　販売
		public int tc_sale_type { get; set; }
		///タイルカーペット　販売（単位）
		public int tc_sale_unit { get; set; }
		///タイルカーペット　仕入
		public int tc_purchase_type { get; set; }
		///タイルカーペット　仕入（単位）
		public int tc_purchase_unit { get; set; }
		///タイルカーペット　施工
		public int tc_construction_type { get; set; }
		///タイルカーペット　施工（単位）
		public int tc_construction_unit { get; set; }
		///クッションフロア　有効巾(cm) :cf=Cushion floor
		public int cf_effective_width { get; set; }
		///クッションフロア　購入単位(cm)
		public int cf_buy_unit { get; set; }
		///クッションフロア　リピート(cm)
		public int cf_repeat { get; set; }
		///クッションフロア　切り代(cm)
		public int cf_cutting_allowance { get; set; }
		///クッションフロア　販売
		public int cf_sale_type { get; set; }
		///クッションフロア　販売（単位）
		public int cf_sale_unit { get; set; }
		///クッションフロア　仕入
		public int cf_purchase_type { get; set; }
		///クッションフロア　仕入（単位）
		public int cf_purchase_unit { get; set; }
		///クッションフロア　施工
		public int cf_construction_type { get; set; }
		///クッションフロア　施工（単位）
		public int cf_construction_unit { get; set; }
		///カーペット　販売 :ca=carpet
		public int ca_sale_type { get; set; }
		///カーペット　販売（単位）
		public int ca_sale_unit { get; set; }
		///カーペット　仕入
		public int ca_purchase_type { get; set; }
		///カーペット　仕入（単位）
		public int ca_purchase_unit { get; set; }
		///カーペット　施工
		public int ca_construction_type { get; set; }
		///カーペット　施工（単位）
		public int ca_construction_unit { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		DateTime updated_at { get; set; }
		///削除日時:
		DateTime deleted_at { get; set; }
	}

	public class LengthsCollection : ObservableCollection<Lengths> {
		public LengthsCollection(){
		}
	}
}
