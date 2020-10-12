using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using TabCon.Views;
using Livet;
using Livet.Commands;
using Livet.Messaging;

namespace TabCon
{
    /// <summary>
    /// ViewTabControl.xaml の相互作用ロジック
    /// </summary>
    public partial class ViewTabControl : UserControl
    {
		/// <summary>
		/// 読込対象
		/// </summary>
		public Dictionary<string, string> RTyps { get; set; }

		/// <summary>
		/// 別ウインドウ
		/// </summary>
		public Dictionary<string, string> WindowTyps { get; set; }
		public string WindowSelected;

		private int AddCount;

		public bool IsPage = false;
		public bool IsWindow = false;
		public bool IsVM = false;
		public bool IsVP = false;


		public ViewTabControl()
        {
            InitializeComponent();
			AddCount = 0;
			RTyps = new Dictionary<string, string>()
			{
				{ "VM_rb", "WindowクラスのView" },
				{ "VP_rb", "PageクラスのView" },
				{ "Page_rb","PageクラスのXAML" },
				{ "Window_rb","WindowクラスのXAML" },
			};
			TypeSerect.ItemsSource = RTyps;
			TypeSerect.SelectedValue = "VP_rb";

			WindowTyps = new Dictionary<string, string>()
			{
				{ "OpenVM", "ViewModel遷移" },
				{ "OpenWindow", "Window遷移" },
				{ "OpenDialog","ダイアログで表示" },
				{ "NaniWindow","NavigationWindow" },
			};
			WindowSerect.ItemsSource = WindowTyps;
	//		WindowSerect.SelectedValue = "OpenVM";
			AddWindow.Visibility = Visibility.Hidden;
		}

		private void TabAdd_Click(object sender, RoutedEventArgs e)
		{
			AddTab();
		}

		public void AddTab()
		{
			string dbMsg = "";
			MainTab.Visibility = Visibility.Visible;

			//	AddCount++;
			TabItem tab = new TabItem();
			tab.Header = "Tab" + (MainTab.Items.Count + 1);
			////フレームを生成して設置したタブコントロールのContentにする場合
			////var frame = new Frame();
			//②Viewの読込ができるTabContentを生成する
			WindowTabContentUC tabContent = new WindowTabContentUC();
			if (IsPage) {
				dbMsg += "PageクラスのXAMLを\r\n";
				Views.Child_Page rContent = new Views.Child_Page();
				//読込んだページを操作
				rContent.MW = this;
				rContent.CInfo_lb.Content = dbMsg + (MainTab.Items.Count + 1) + "番目に追加したTabItemです";
				//		rContent.CwindowCloss_lb.Content = (MainTab.Items.Count + 1) + "番目に追加したページです";
				////frame.Navigate(rContent);
				tabContent.TabContent.Navigate(rContent);
			} else if (IsWindow) {
				dbMsg += "WindowクラスのXAMLを\r\n";
				Views.Child_Window rContent = new Views.Child_Window();
				Window rWindow = Window.GetWindow(rContent);
				rContent.TC = this;
				rContent.CInfo_lb.Content = dbMsg + (MainTab.Items.Count + 1) + "番目に追加したTabItemです";
				tabContent.TabContent.Navigate(rContent);
			} else if (IsVM) {
				dbMsg += "WindowクラスのViewを\r\n";
				Views.ChildView rContent = new Views.ChildView();
				Window rWindow = Window.GetWindow(rContent);
				Type gType = rContent.GetType();
				rContent.CInfo_lb.Content = dbMsg + (MainTab.Items.Count + 1) + "番目に追加したTabItemです";
				ViewModels.ChildViewModel VM = new ViewModels.ChildViewModel();
				VM.TC = this;
				rContent.DataContext = VM;
				//System.InvalidOperationException: ''TabCon.Views.ChildView' ルート要素は、ナビゲーションに対して無効です。'
				tabContent.TabContent.Navigate(rContent);
			} else if (IsVP) {
				dbMsg += "PageクラスのViewを\r\n";
				Views.ChildPageView rContent = new Views.ChildPageView();
				//読込んだページを操作；ViewModelをタブ生成時時に生成してパラメータを渡す
				ViewModels.ChildPageViewModel VM = new ViewModels.ChildPageViewModel();
				VM.MW = this;
				rContent.DataContext = VM;
				rContent.CInfo_lb.Content = dbMsg + (MainTab.Items.Count + 1) + "番目に追加したTabItemです";
				tab.Header = rContent.Title + "(" + (MainTab.Items.Count + 1) + ")";
				tabContent.TabContent.Navigate(rContent);
			}

			tab.Content = tabContent;
			//追加した物を選択状態にしてタブコントロールに追加
			tab.IsSelected = true;
			this.MainTab.Items.Add(tab);
		}

		/// <summary>
		/// View名で指定した画面をタブに読込む
		/// </summary>
		/// <param name="ViewName"></param>
		public void Add2Tab(string ViewName)
		{
			string dbMsg = "";
			TabItem tab = new TabItem();
			tab.Header = "Tab" + (MainTab.Items.Count + 1);
			////フレームを生成して設置したタブコントロールのContentにする場合
			////var frame = new Frame();
			//②Viewの読込ができるTabContentを生成する
			WindowTabContentUC tabContent = new WindowTabContentUC();
			dbMsg += "PageクラスのXAMLを\r\n";
			Views.Child_Page rContent = new Views.Child_Page();
			//読込んだページを操作
			rContent.MW = this;
			rContent.CInfo_lb.Content = dbMsg + (MainTab.Items.Count + 1) + "番目に追加したTabItemです";
			//		rContent.CwindowCloss_lb.Content = (MainTab.Items.Count + 1) + "番目に追加したページです";
			////frame.Navigate(rContent);
			tabContent.TabContent.Navigate(rContent);
			tab.Content = tabContent;
			//追加した物を選択状態にしてタブコントロールに追加
			tab.IsSelected = true;
			this.MainTab.Items.Add(tab);
		}


		private void TabDrel_Click(object sender, RoutedEventArgs e)
		{
			DrelTabItem();
		}

		public void DrelTabItem()
		{
			int SelectedIndex = MainTab.SelectedIndex;
			if (-1 < SelectedIndex) {
				MainTab.Items.Remove(MainTab.SelectedItem);
			} else {
				InfoLavel.Content = "タブは有りません";
			}
		}

		private void MainTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			String NowInfo = "(" + (MainTab.SelectedIndex + 1) + "/" + MainTab.Items.Count + ")" + MainTab.SelectedValue + "を選択";
			InfoLavel.Content = NowInfo;
		}


		private void TypeSerect_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			int serectIndex = cb.SelectedIndex;
			string selectedValue = (string)cb.SelectedValue;
			IsPage = false;
			IsWindow = false;
			IsVM = false;
			IsVP = false;

			if (selectedValue == "Page_rb") {
				IsPage = true;
			} else if (selectedValue == "Window_rb") {
				IsWindow = true;
			} else if (selectedValue == "VM_rb") {
				IsVM = true;
			} else if (selectedValue == "VP_rb") {
				IsVP = true;
			}
		}


		//Windowクラスを読み込む方法
	
		
		private void WindowSerect_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			int serectIndex = cb.SelectedIndex;
			WindowSelected = (string)cb.SelectedValue;
			AddWindow.Visibility = Visibility.Visible;
			if (WindowSelected == "OpenVM") {
				OpenVM();
			} else if (WindowSelected == "OpenWindow") {
				OpenWindow();
			} else if (WindowSelected == "OpenDialog") {
				AddWindow.Visibility = Visibility.Hidden;
				OpenDialog();
			} else if (WindowSelected == "NaniWindow") {
				ShowNaniWindow();
			}
		}

		/// <summary>
		/// Windowを追加
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddWindow_Click(object sender, RoutedEventArgs e)
		{
			if (WindowSelected == "OpenVM") {
				OpenVM();
			} else if (WindowSelected == "OpenWindow") {
				OpenWindow();
			} else if (WindowSelected == "OpenDialog") {
				OpenDialog();
			} else if (WindowSelected == "NaniWindow") {
				ShowNaniWindow();
			}

		}

		/// <summary>
		/// 		private void OpenVM_Click(object sender, RoutedEventArgs e)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OpenVM()
		{
			string dbMsg = "";
			Views.ChildView rContent = new Views.ChildView();
			dbMsg += "WindowクラスのViewを\r\n";
			ViewModels.ChildViewModel VM = new ViewModels.ChildViewModel();
			//	VM.MW = (Views.MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
			AddCount++;
			VM.CInfo_lb = dbMsg + AddCount + "番目に表示したWindowです";
			rContent.DataContext = VM;
			//TransitionMessage message = new TransitionMessage(rContent.GetType(), VM, TransitionMode.Modal);
			//Messenger.Raise(message);
			rContent.Show();
		}

		public Views.NaviWindow naviWindow;
		/// <summary>
		/// private void NaniWindow_Click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ShowNaniWindow()
		{
			string dbMsg = "";
			Views.ChildPageView rContent = new Views.ChildPageView();
			dbMsg += "PageクラスのViewを\r\n";
			//Views.Child_Page rContent = new Views.Child_Page();
			//	Uri tUri = new Uri("Child_Page.xaml", UriKind.Relative);

			Uri tUri = new Uri("ChildPageView.xaml", UriKind.Relative);
			if (naviWindow == null) {
				naviWindow = new Views.NaviWindow();
				//		IsNaviWindowOpen = true;
				//} else {
				//	IsNaviWindowOpen = true;
			}
			AddCount++;
			rContent.CInfo_lb.Content = dbMsg+ AddCount + "番目に呼び出したページです\r\nNaniWindowでは左上のボタンとドロップリストで読み出している画面を遷移して下さい";
			ViewModels.ChildPageViewModel VM = new ViewModels.ChildPageViewModel();
			VM.MW = this;
			rContent.DataContext = VM;
			naviWindow.Navigate(rContent);		//	.Source だと Uriしか指定できない
			//		if(! naviWindow.IsActive) {
			//ここで「System.IO.IOException: 'リソース 'views.childview.xaml' を検索できません。'」
			naviWindow.Show();
			//	}
		}

		public void NaviWindowClose()
		{
			naviWindow = null;
		}

		/// <summary>
		///   Windowクラスをそのまま表示する
		///   private void OpenWindow_Click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OpenWindow()
		{
			string dbMsg = "";
			Views.ChildView rContent = new Views.ChildView();
			dbMsg += "WindowクラスのViewを\r\n";
			ViewModels.ChildViewModel VM = new ViewModels.ChildViewModel();
			VM.TC = this;
			rContent.DataContext = VM;
			AddCount++;
			rContent.CInfo_lb.Content = dbMsg +  AddCount + "番目に表示したWindowです";
			rContent.Show();
		}

//		public static readonly DependencyProperty MyDoubleValue1Property = DependencyProperty.Register(nameof(MyDoubleValue1), typeof(double), typeof(SimpleUserControl), new PropertyMetadata(0.0));

		public ViewModelCommand OpDialog {
			get { return new Livet.Commands.ViewModelCommand(OpenDialog); }
		}
		/// <summary>
		///  Windowクラスをダイアログ表示する
		///  private void OpenDialog_Click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OpenDialog()
		{
			string dbMsg = "";
			Views.ChildView rContent = new Views.ChildView();
			dbMsg += "TabConからWindowクラスのViewを\r\n";
			ViewModels.ChildViewModel VM = new ViewModels.ChildViewModel();
			VM.TC = this;
			rContent.DataContext = VM;
			AddCount++;
			rContent.CInfo_lb.Content = AddCount + "番目に表示したダイアログです\r\nダイアログは複数表示されません";
			rContent.ShowDialog();
		}

	}
}
