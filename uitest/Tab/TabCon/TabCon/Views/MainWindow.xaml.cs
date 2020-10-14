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
using System.Windows.Shapes;
using TabCon.ViewModels;
using TabCon.Properties;

namespace TabCon.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
		ViewModels.MainViewModel VM;
		public MainWindow()
		{
			InitializeComponent();
			// ウィンドウのサイズを復元
			RecoverWindowBounds();
			//ViewとViewModelの紐付け
			VM = new ViewModels.MainViewModel();
			//VM.MenuTree = this.MenuTree;
			//VM.InfoLavel = InfoLavel;
			// Window_Loaded, Window_Activated,Window_Initialized,Window_GotFocusなどどのタイミングでも割り付ける事ができなかった
			this.DataContext = VM;
			this.Loaded += this_loaded;
		}
		//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			VM.MyView = this;
			//	((ViewModels.MainViewModel)this.DataContext).MyView =this;

		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
		}


		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// ウィンドウのサイズを保存
			SaveWindowBounds();
		}


		/// <summary>
		/// ウィンドウの位置・サイズを保存します。
		/// </summary>
		void SaveWindowBounds()
		{
			var settings = Settings.Default;
			settings.WindowMaximized = WindowState == WindowState.Maximized;
			WindowState = WindowState.Normal; // 最大化解除
			settings.WindowLeft = Left;
			settings.WindowTop = Top;
			settings.WindowWidth = Width;
			settings.WindowHeight = Height;
			settings.Save();
		}

		/// <summary>
		/// ウィンドウの位置・サイズを復元します。
		/// </summary>
		void RecoverWindowBounds()
		{
			var settings = Settings.Default;
			// 左
			if (settings.WindowLeft >= 0 &&
				(settings.WindowLeft + settings.WindowWidth) < SystemParameters.VirtualScreenWidth) {
					Left = settings.WindowLeft; 
				}
			// 上
			if (settings.WindowTop >= 0 &&
				(settings.WindowTop + settings.WindowHeight) < SystemParameters.VirtualScreenHeight) { Top = settings.WindowTop; }
			// 幅
			if (settings.WindowWidth > 0 &&
				settings.WindowWidth <= SystemParameters.WorkArea.Width) { Width = settings.WindowWidth; }
			// 高さ
			if (settings.WindowHeight > 0 &&
				settings.WindowHeight <= SystemParameters.WorkArea.Height) { Height = settings.WindowHeight; }
			// 最大化
			if (settings.WindowMaximized) {
				// ロード後に最大化
				Loaded += (o, e) => WindowState = WindowState.Maximized;
			}
		}
	}
}
