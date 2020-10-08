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

		private int AddCount;


		public ViewTabControl()
        {
            InitializeComponent();
			AddCount = 0;

		}

		public bool IsPage = false;
		public bool IsWindow = false;
		public bool IsVM = false;
		public bool IsVP = false;

		private void TabAdd_Click(object sender, RoutedEventArgs e)
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
				rContent.CInfo_lb.Content = dbMsg+ (MainTab.Items.Count + 1) + "番目に追加したTabItemです";
				//		rContent.CwindowCloss_lb.Content = (MainTab.Items.Count + 1) + "番目に追加したページです";
				////frame.Navigate(rContent);
				tabContent.TabContent.Navigate(rContent);
			} else if (IsWindow) {
				dbMsg += "WindowクラスのXAMLを\r\n";
				Views.Child_Window rContent = new Views.Child_Window();
				Window rWindow = Window.GetWindow(rContent);
				rContent.MW = this;
				rContent.CInfo_lb.Content = dbMsg + (MainTab.Items.Count + 1) + "番目に追加したTabItemです";
				tabContent.TabContent.Navigate(rContent);
			} else if (IsVM) {
				dbMsg += "WindowクラスのViewを\r\n";
				//System.InvalidOperationException: ''TabCon.Views.ChildView' ルート要素は、ナビゲーションに対して無効です。'
				Views.ChildView rContent = new Views.ChildView();
				Type gType = rContent.GetType();
				rContent.CInfo_lb.Content = dbMsg + (MainTab.Items.Count + 1) + "番目に追加したTabItemです";
				//		ViewModels.ChildViewModel rContent = new ViewModels.ChildViewModel();
				rContent.MW = this;
			//	rContent.CInfo_lb = (MainTab.Items.Count + 1) + "番目に追加したViewです";
				tabContent.TabContent.Navigate(rContent);
			} else if (IsVP) {
				dbMsg += "PageクラスのViewを\r\n";
				Views.ChildPageView rContent = new Views.ChildPageView();
				//読込んだページを操作；ViewModelをタブ生成時時に生成してパラメータを渡す
				ViewModels.ChildPageViewModel VM = new ViewModels.ChildPageViewModel();
				VM.MW = this;
				rContent.DataContext = VM; 
				rContent.CInfo_lb.Content = dbMsg + (MainTab.Items.Count + 1) + "番目に追加したTabItemです";
				tabContent.TabContent.Navigate(rContent);
			}

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

		private void ReadType_Checked(object sender, RoutedEventArgs e)
		{
			var radioButton = sender as RadioButton;

			IsPage = false;
			IsWindow = false;
			IsVM = false;
			IsVP = false;

			//			foreach (RadioButton rb in RTyps.Controls.OfType<RadioButton>()) {
			if (radioButton == Page_rb) {
				IsPage = true;
			} else if (radioButton == Window_rb) {
				IsWindow = true;
			} else if (radioButton == VM_rb) {
				IsVM = true;
			} else if (radioButton == VP_rb) {
				IsVP = true;
			}
			//		}
		}


		//Windowクラスを読み込む方法


		private void OpenVM_Click(object sender, RoutedEventArgs e)
		{
			ViewModels.ChildViewModel rContent = new ViewModels.ChildViewModel();
			rContent.MW = this;
			rContent.CInfo_lb = "呼び出されたViewModelです";
			//Messenger	が使えない
			//		Messenger.Raise(new TransitionMessage(new ViewModels.ChildViewModel() { NeedHideOwner = true }, "MessageKey2"));

		}

		public Views.NaviWindow naviWindow;
		private void NaniWindow_Click(object sender, RoutedEventArgs e)
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
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OpenWindow_Click(object sender, RoutedEventArgs e)
		{
			string dbMsg = "";
			Views.ChildView rContent = new Views.ChildView();
			dbMsg += "WindowクラスのViewを\r\n";
			//	Views.Child_Window rContent = new Views.Child_Window();
			//	rContent.MW = this;
			AddCount++;
			rContent.CInfo_lb.Content = dbMsg +  AddCount + "番目に表示したWindowです";
			rContent.Show();
		}

		/// <summary>
		///  Windowクラスをダイアログ表示する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OpenDialog_Click(object sender, RoutedEventArgs e)
		{
			string dbMsg = "";
			Views.ChildView rContent = new Views.ChildView();
			dbMsg += "WindowクラスのViewを\r\n";
			//		Views.Child_Window rContent = new Views.Child_Window();
			//		rContent.Owner = MainWindow;
			rContent.MW = this;
			AddCount++;
			rContent.CInfo_lb.Content = AddCount + "番目に表示したダイアログです\r\nダイアログは複数表示されません";
			rContent.ShowDialog();
		}


	}
}
