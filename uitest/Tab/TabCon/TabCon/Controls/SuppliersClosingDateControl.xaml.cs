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
		public static readonly DependencyProperty SCDProperty =
			DependencyProperty.Register(
				"SuppliersClosingDate", 
				typeof(int), 
				typeof(SuppliersClosingDateControl),
				new PropertyMetadata(
					0,
					new PropertyChangedCallback((sender, e) => {
						(sender as SuppliersClosingDateControl).OnMyPropertyChanged(sender, e);
					}))
				);
		private void OnMyPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
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
		//public bool MonthEndBool { get; set; }
		///// <summary>
		///// 随時
		///// </summary>
		//public bool AnyTimeBool { get; set; }

		public SuppliersClosingDateControl()
		{
			this.InitializeComponent();
			DisplaySet(SuppliersClosingDate);
		}

		private void MonthEnd_Checked(object sender, RoutedEventArgs e)
		{
			SuppliersClosingDate = 30;
			DisplaySet(SuppliersClosingDate);
		}
		private void AnyTime_Checked(object sender, RoutedEventArgs e)
		{
			SuppliersClosingDate = 0;
			DisplaySet(SuppliersClosingDate);
		}

		public void DisplaySet(int suppliersClosingDate)
		{
			DisplayStr = "";
			//AnyTimeBool = false;
			//MonthEndBool = false;
			if (suppliersClosingDate == 0) {
				//AnyTimeBool = true;
			} else if(29 < suppliersClosingDate) {
				//MonthEndBool = true;
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
