using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ライセンスマスタ
	/// </summary>
	public partial class Licenses{
		///ID
		public int id { get; set; }
		///ライセンスキー
		public string license_key { get; set; }
		///停止フラグ
		public int stop_flag { get; set; }
		///有効期限（FROM)
		public DateTime effective_period_from { get; set; }
		///有効期限（TO）
		public DateTime effective_period_to { get; set; }
		///プランID :＝プランマスタ．ID
		public int m_plan_id { get; set; }
		///更新チェック間隔 :分単位で設定
		public int check_interval { get; set; }
		///バージョンアップ可能Ver :0：常に最新、以外：バージョンマスタ.ID
		public int m_version_id { get; set; }
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

	public class LicensesCollection : ObservableCollection<Licenses> {
		public LicensesCollection(){
		}
	}
}
