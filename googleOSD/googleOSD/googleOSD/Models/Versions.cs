using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// バージョンマスタ
	/// </summary>
	public partial class Versions{
		///ID
		public int id { get; set; }
		///バージョン名
		public string version_name { get; set; }
		///前バージョンID :=バージョン情報.ID
		public int pre_m_version_id { get; set; }
		///バージョン系統
		public decimal version_lineage { get; set; }
		///アプリケーション名 :EXE名
		public string application_name { get; set; }
		///アプリケーションパス :ダウンロード用のパス
		public string application_path { get; set; }
		///配信開始日
		public DateTime delivery_date_start { get; set; }
		///配信終了日
		public DateTime delivery_date_end { get; set; }
		///バージョンアップ期限
		public DateTime version_upgrade_deadline { get; set; }
		///配信停止フラグ
		public int undelivered_flag { get; set; }
		///バージョン概要 :バージョンアップ内容
		public string overview { get; set; }
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

	public class VersionsCollection : ObservableCollection<Versions> {
		public VersionsCollection(){
		}
	}
}
