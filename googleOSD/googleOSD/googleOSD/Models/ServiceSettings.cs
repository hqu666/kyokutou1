using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// サービス設定
	/// </summary>
	public partial class ServiceSettings{
		///ID
		public int id { get; set; }
		///仮パスワード有効時間 :分
		public int temporary_password_limit { get; set; }
		///データ取込同時実行数 :人
		public int concurrent_executions_limit { get; set; }
		///データ取込最大ファイルサイズ :KB単位
		public int data_import_max_file_size { get; set; }
		///単価掛率設定得意先最大件数
		public int supplier_price_rates_max_count { get; set; }
		///単価掛率設定商品最大件数
		public int product_price_rates_max_count { get; set; }
		///システムメンテナンスモードフラグ :0：Off、1：On
		public int is_maintenance { get; set; }
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

	public class ServiceSettingsCollection : ObservableCollection<ServiceSettings> {
		public ServiceSettingsCollection(){
		}
	}
}
