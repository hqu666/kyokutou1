using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using TabCon.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Infragistics.Windows.Controls;
using TabCon.ViewModels;
using System.Windows.Input;
//using TabCon.Enums;

namespace TabCon.Infrastructures {
	public class ViewModelBase : Livet.ViewModel, INotifyPropertyChanged {
		/* コマンド、プロパティの定義にはそれぞれ 
         * 
         *  lvcom   : ViewModelCommand
         *  lvcomn  : ViewModelCommand(CanExecute無)
         *  llcom   : ListenerCommand(パラメータ有のコマンド)
         *  llcomn  : ListenerCommand(パラメータ有のコマンド・CanExecute無)
         *  lprop   : 変更通知プロパティ(.NET4.5ではlpropn)
         *  
         * を使用してください。
         * 
         * Modelが十分にリッチであるならコマンドにこだわる必要はありません。
         * View側のコードビハインドを使用しないMVVMパターンの実装を行う場合でも、ViewModelにメソッドを定義し、
         * LivetCallMethodActionなどから直接メソッドを呼び出してください。
         * 
         * ViewModelのコマンドを呼び出せるLivetのすべてのビヘイビア・トリガー・アクションは
         * 同様に直接ViewModelのメソッドを呼び出し可能です。
         */

		/* ViewModelからViewを操作したい場合は、View側のコードビハインド無で処理を行いたい場合は
         * Messengerプロパティからメッセージ(各種InteractionMessage)を発信する事を検討してください。
         */

		/* Modelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedEventListenerや
         * CollectionChangedEventListenerを使うと便利です。各種ListenerはViewModelに定義されている
         * CompositeDisposableプロパティ(LivetCompositeDisposable型)に格納しておく事でイベント解放を容易に行えます。
         * 
         * ReactiveExtensionsなどを併用する場合は、ReactiveExtensionsのCompositeDisposableを
         * ViewModelのCompositeDisposableプロパティに格納しておくのを推奨します。
         * 
         * LivetのWindowテンプレートではViewのウィンドウが閉じる際にDataContextDisposeActionが動作するようになっており、
         * ViewModelのDisposeが呼ばれCompositeDisposableプロパティに格納されたすべてのIDisposable型のインスタンスが解放されます。
         * 
         * ViewModelを使いまわしたい時などは、ViewからDataContextDisposeActionを取り除くか、発動のタイミングをずらす事で対応可能です。
         */

		/* UIDispatcherを操作する場合は、DispatcherHelperのメソッドを操作してください。
         * UIDispatcher自体はApp.xaml.csでインスタンスを確保してあります。
         * 
         * LivetのViewModelではプロパティ変更通知(RaisePropertyChanged)やDispatcherCollectionを使ったコレクション変更通知は
         * 自動的にUIDispatcher上での通知に変換されます。変更通知に際してUIDispatcherを操作する必要はありません。
         */

		//public NLog.Logger Logger {
		//	get {
		//		return NLog.LogManager.GetCurrentClassLogger();
		//	}
		//}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ViewModelBase()
		{
			//this.Logger.Trace(this.ToString() + " " +"Constructor");
		}
		//public ViewModelBase(ITabController controller)
		//{
		//	this.TabController = controller;
		//}
		public virtual void Initialize()
		{
		}

		public virtual void AnyChecked()
		{
		}

		//#region KickScroll変更通知プロパティ
		//private Behaviors.Scroll _KickScroll;

		//public Behaviors.Scroll KickScroll
		//{
		//    get
		//    { return _KickScroll; }
		//    set
		//    {
		//        //if (_KickScroll == value)
		//        //    return;
		//        _KickScroll = value;
		//        RaisePropertyChanged();
		//    }
		//}
		//#endregion
		//タブコントローラ
		//public ITabController TabController { get; set; }

		private static ObservableCollection<TabItemEx> _Tabs;
		public static ObservableCollection<TabItemEx> Tabs {
			get => _Tabs;
			set {
				if (_Tabs == value)
					return;
				_Tabs = value;
			}
		}
		//ボタンからのタブ追加 string=ScreenTypes
		private ICommand _OpenTabCommand;

		//public ICommand OpenTabCommand {
		//	get {
		//		if (_OpenTabCommand == null) {
		//			_OpenTabCommand = new RelayCommand<string>(OpenClick2);
		//		}
		//		return _OpenTabCommand;
		//	}
		//}

		//メニューからのタブ追加
		//public void OpenClick2(string windowname)
		//{
		//	//ユーザーコントロール取得
		//	Type type = Type.GetType("KsCloudBrowser.Views." + windowname + "Window");
		//	var tc1 = Activator.CreateInstance(type);
		//	string dispName = "";
		//	foreach (var t in Enum.GetValues(typeof(Enums.ScreenTypes))) {
		//		if (t.ToString() == windowname) {
		//			dispName = new EnumDisplayNameConverter(typeof(Enums.ScreenTypes)).ConvertToString(Convert.ToInt16(t));
		//		}

		//	}

		//	ViewModelBase.Tabs.Add(new TabItemEx() {
		//		Header = dispName,
		//		Content = tc1,
		//		IsSelected = true,
		//		CloseButtonVisibility = TabItemCloseButtonVisibility.Visible,
		//	});
		//	this.TabController = new TabController(ViewModelBase.Tabs);
		//}

		//メニューからのタブ追加
		//public void OpenClick(MenuTreeSource tocItem)
		//{
		//	//ユーザーコントロール取得
		//	Type type = Type.GetType("KsCloudBrowser.Views." + tocItem.windowname + "Window");
		//	var tc1 = Activator.CreateInstance(type);

		//	//タブ追加
		//	ViewModelBase.Tabs.Add(new TabItemEx() {
		//		Header = tocItem.name,
		//		Content = tc1,
		//		IsSelected = true,
		//		CloseButtonVisibility = TabItemCloseButtonVisibility.Visible,
		//	});
		//}

		//private List<MenuTreeSource> _ItemsSource;
		//public List<MenuTreeSource> ItemsSource {
		//	get => _ItemsSource;
		//	set {
		//		if (_ItemsSource == value)
		//			return;
		//		_ItemsSource = value;
		//	}
		//}


		//private MenuTreeSource _SelectedItemsSource;
		//public MenuTreeSource SelectedItemsSource {
		//	get => _SelectedItemsSource;
		//	set {
		//		if (_SelectedItemsSource == value)
		//			return;
		//		_SelectedItemsSource = value;
		//		this.OpenClick(SelectedItemsSource);
		//	}
		//}



	}


	//Commandに引数を追加
	public class RelayCommand : ICommand {
		#region fields

		private readonly Action<object> _executeOld;
		private readonly Action _execute;
		private readonly Predicate<object> _canExecute;

		#endregion // Fields

		#region Constructor

		/// <summary>
		/// 実行可否判定のないコマンドを作成
		/// </summary>
		/// <param name="execute"></param>
		[Obsolete("RelayCommand(Action execute) または RelayCommand(Action<T> execute) を使用してください。")]
		public RelayCommand(Action<object> execute) : this(execute, null) { }

		/// <summary>
		/// 実行可否判定のないコマンドを作成
		/// </summary>
		/// <param name="execute"></param>
		public RelayCommand(Action execute) : this(execute, null) { }

		/// <summary>
		/// コマンドを作成
		/// </summary>
		/// <param name="execute"></param>
		/// <param name="canExecute"></param>
		[Obsolete("RelayCommand(Action execute, Predicate<object> canExecute) または RelayCommand(Action<T> execute, Predicate<object> canExecute) を使用してください。")]
		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("param: execute");

			_executeOld = execute;
			_canExecute = canExecute;
		}

		/// <summary>
		/// コマンドを作成
		/// </summary>
		/// <param name="execute"></param>
		/// <param name="canExecute"></param>
		public RelayCommand(Action execute, Predicate<object> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("param: execute");

			_execute = execute;
			_canExecute = canExecute;
		}

		#endregion // Constructor

		#region ICommand Members

		/// <summary>
		/// 現在の状態でこのコマンドを実行できるかどうかを判断します。
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}

		/// <summary>
		/// コマンドを実行するかどうかに影響するような変更があった場合に発生するイベントです。
		/// </summary>
		public event EventHandler CanExecuteChanged {
			add {
				if (_canExecute != null)
					CommandManager.RequerySuggested += value;
			}
			remove {
				if (_canExecute != null)
					CommandManager.RequerySuggested -= value;
			}
		}

		/// <summary>
		/// コマンドの起動時に呼び出されるメソッドです。
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			if (_execute != null)
				_execute();
			else
				_executeOld(parameter);
		}

		#endregion // ICommand Members
	}

	/// <summary>
	/// デリゲートを呼び出すことによって、コマンドを他のオブジェクトに中継する。CanExecute メソッドの既定値は 'true'。
	/// </summary>
	public class RelayCommand<T> : ICommand {
		#region fields

		private readonly Action<T> _execute;
		private readonly Predicate<object> _canExecute;

		#endregion // Fields

		#region Constructor

		/// <summary>
		/// 実行可否判定のないコマンドを作成
		/// </summary>
		/// <param name="execute"></param>
		public RelayCommand(Action<T> execute)
			: this(execute, null)
		{
		}

		/// <summary>
		/// コマンドを作成
		/// </summary>
		/// <param name="execute"></param>
		/// <param name="canExecute"></param>
		public RelayCommand(Action<T> execute, Predicate<object> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("param: execute");

			_execute = execute;
			_canExecute = canExecute;
		}

		#endregion // Constructor

		#region ICommand Members

		/// <summary>
		/// 現在の状態でこのコマンドを実行できるかどうかを判断します。
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}

		/// <summary>
		/// コマンドを実行するかどうかに影響するような変更があった場合に発生するイベントです。
		/// </summary>
		public event EventHandler CanExecuteChanged {
			add {
				if (_canExecute != null)
					CommandManager.RequerySuggested += value;
			}
			remove {
				if (_canExecute != null)
					CommandManager.RequerySuggested -= value;
			}
		}

		/// <summary>
		/// コマンドの起動時に呼び出されるメソッドです。
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			_execute((T)parameter);
		}

		#endregion // ICommand Members
	}
}
