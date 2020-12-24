using System.Windows;
using System.Windows.Controls;

namespace TabCon.Controls {
	/// <summary>
	///締日用の日付け入力パレット（モダール）
	/// </summary>
	public partial class SuppliersClosingDatesWindow : Window {
		///　DependencyPropertyでのデータ送受信に参照エラーが出るのでコードビハインド間のクラス参照で対応
		/// <summary>
		/// 呼出し元クラス
		/// </summary>
		public SuppliersClosingDateControl OwnerControl;

		/// <summary>
		/// 表示文字
		/// </summary>
		public string DisplayStr { get; set; }

		/// <summary>
		///締日用の日付け入力パレット（モダール）
		/// </summary
		public SuppliersClosingDatesWindow()
		{
			InitializeComponent();
			this.Loaded += this_loaded;
		}

		/// <summary>
		/// リソースの読込み終了後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			//表示位置調整
			Point pt = OwnerControl.ShowPanelBT.PointToScreen(new Point(0.0d, 0.0d));
			this.Left = pt.X + 15;
			this.Top = pt.Y-2;
			DisplayStr = OwnerControl.SetValTB.Text;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//クリックされたボタン
			Button BT = sender as Button;
			//表示文字を読み
			DisplayStr = (string)BT.Content;
			//読み出し元へ返す
			OwnerControl.SetValTB.Text = DisplayStr;
			int SelectedInt = int.Parse(DisplayStr);
			OwnerControl.DisplaySet(SelectedInt);
			this.Close();
		}
	}
}
