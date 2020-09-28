using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 伝票画面設定
	/// </summary>
	public partial class SlipSettings{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///ログインユーザーID :=ログインユーザーマスタ.ID
		public int m_login_users_staff_id { get; set; }
		///場所：表示フラグ :0：表示しない、1：表示する
		public int location_display_flag { get; set; }
		///場所：結合項目
		public int location_union_item { get; set; }
		///場所：並び順
		public int location_order { get; set; }
		///箇所：表示 :0：表示しない、1：表示する
		public int place_display_flag { get; set; }
		///箇所：結合項目
		public int place_union_item { get; set; }
		///箇所：並び順
		public int place_order { get; set; }
		///自社品番：表示 :0：表示しない、1：表示する
		public int product_display_flag { get; set; }
		///自社品番：結合項目
		public int product_union_item { get; set; }
		///自社品番：並び順
		public int product_order { get; set; }
		///メーカー品番：表示 :0：表示しない、1：表示する
		public int maker_display_flag { get; set; }
		///メーカー品番：結合項目
		public int maker_union_item { get; set; }
		///メーカー品番：並び順
		public int maker_order { get; set; }
		///メーカー名：表示 :0：表示しない、1：表示する
		public int maker_name_display_flag { get; set; }
		///メーカー名：結合項目
		public int maker_name_union_item { get; set; }
		///メーカー名：並び順
		public int maker_name_order { get; set; }
		///品名：表示 :0：表示しない、1：表示する
		public int product_name_display_flag { get; set; }
		///品名：結合項目
		public int product_name_union_item { get; set; }
		///品名：並び順
		public int product_name_order { get; set; }
		///規格：表示 :0：表示しない、1：表示する
		public int standard_display_flag { get; set; }
		///規格：結合項目
		public int standard_union_item { get; set; }
		///規格：並び順
		public int standard_order { get; set; }
		///品種：表示 :0：表示しない、1：表示する
		public int variety_display_flag { get; set; }
		///品種：結合項目
		public int variety_union_item { get; set; }
		///品種：並び順
		public int variety_order { get; set; }
		///数量：表示 :0：表示しない、1：表示する
		public int quantity_display_flag { get; set; }
		///数量：結合項目
		public int quantity_union_item { get; set; }
		///数量：並び順
		public int quantity_order { get; set; }
		///単位：表示 :0：表示しない、1：表示する
		public int unit_display_flag { get; set; }
		///単位：結合項目
		public int unit_union_item { get; set; }
		///単位：並び順
		public int unit_order { get; set; }
		///単価：表示 :0：表示しない、1：表示する
		public int price_display_flag { get; set; }
		///単価：結合項目
		public int price_union_item { get; set; }
		///単価：並び順
		public int price_order { get; set; }
		///金額：表示 :am=Amount of money
		public int am_display_flag { get; set; }
		///金額：結合項目
		public int am_union_item { get; set; }
		///金額：並び順
		public int am_order { get; set; }
		///備考：表示 :0：表示しない、1：表示する
		public int remarks_display_flag { get; set; }
		///備考：結合項目
		public int remarks_union_item { get; set; }
		///備考：並び順
		public int remarks_order { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		public DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		public DateTime updated_at { get; set; }
		///削除日時:
		public DateTime deleted_at { get; set; }
	}

	public class SlipSettingsCollection : ObservableCollection<SlipSettings> {
		public SlipSettingsCollection(){
		}
	}
}
