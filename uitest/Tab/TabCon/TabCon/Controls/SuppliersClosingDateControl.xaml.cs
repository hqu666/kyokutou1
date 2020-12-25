using System.Windows;
using System.Windows.Controls;

namespace TabCon.Controls {
	/// <summary>
	///締日用のカスタムコントロール
	/// </summary>
	public partial class SuppliersClosingDateControl : UserControl
    {
		//ViewModelからBindingする場合はDependencyが必要
		/// <summary>
		/// 選択結果
		/// </summary>
		public int SuppliersClosingDate {
			get { return (int)GetValue(SCDProperty); }
			set { SetValue(SCDProperty, value); }
		}

		/// <summary>
		/// 選択結果の属性、イベント設定
		/// </summary>
		public static readonly DependencyProperty SCDProperty =
			DependencyProperty.Register(
				"SuppliersClosingDate", 
				typeof(int), 
				typeof(SuppliersClosingDateControl),
				new PropertyMetadata(
					0,
					new PropertyChangedCallback((sender, e) => {
						(sender as SuppliersClosingDateControl).OnSuppliersClosingDateChanged(sender, e);
					}))
				);

		/// <summary>
		///選択結果となる値の変更で発生するイベント
		/// </summary>
		private void OnSuppliersClosingDateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			DisplaySet(int.Parse(e.NewValue.ToString()));
		}

		/// <summary>
		/// 表示文字
		/// </summary>
		public string DisplayStr { get; set; }
		/// <summary>
		/// 月末
		/// </summary>

		public SuppliersClosingDateControl()
		{
			this.InitializeComponent();
		}

		private void MonthEnd_Checked(object sender, RoutedEventArgs e)
		{
			SuppliersClosingDate = 30;
		}
		private void AnyTime_Checked(object sender, RoutedEventArgs e)
		{
			SuppliersClosingDate = 0;
			//ここだけOnSuppliersClosingDateChangedが発生しない事が有った
			DisplaySet(SuppliersClosingDate);
		}

		public void DisplaySet(int suppliersClosingDate)
		{
			DisplayStr = "";
			if (suppliersClosingDate == 0) {
			} else if(29 < suppliersClosingDate) {
			} else {
				DisplayStr = suppliersClosingDate.ToString();
				//IsCheckedのBindingで変えられなかったのでエレメント操作
				AnyTime.IsChecked = false;
				MonthEnd.IsChecked = false;
			}
			this.SetValTB.Text = DisplayStr;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SuppliersClosingDatesWindow View = new SuppliersClosingDatesWindow();
			View.OwnerControl = this;
			View.ShowDialog();
		}

	}
}
