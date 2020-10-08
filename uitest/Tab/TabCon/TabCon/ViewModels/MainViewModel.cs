using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Livet;
using Livet.Commands;
using Livet.Messaging;

using TabCon.Models;

namespace TabCon.ViewModels {
	//.ViewModel
	public class MainViewModel : ViewModel {

		public List<Models.MyMenu> _MyMenu { get; set; }

		//	public TabControl MainTab { get; set; }

		public System.Collections.IEnumerable TabItems { get; set; }

		public Label InfoLavel { get; set; }
		public TreeView MenuTree { get; set; }

		//public bool NeedHideOwner { get; set; }

		//		int AddCount;

		public MainViewModel()
		{
			//			AddCount = 0;
			//			MainTab = FindName("MainTab") as TabControl;
			////閉じるコマンドを生成
			//var Closing = new Livet.Commands.ListenerCommand<Window>((w) => {
			//	if (NeedHideOwner && w.Owner != null) {
			//		w.Owner.Show();
			//	}
			//});

			Initialize();
		}

	//	Authorizer authorizer = new Authorizer();
		public void Initialize()
		{
		//	if (!authorizer.IsAuthorized) {
				var message = new InteractionMessage();
				Messenger.Raise(message);
			//	}

			_MyMenu = new List<MyMenu>()
			   {
				new MyMenu()
				{
					Name = "test1",
					Child = new List<MyMenu>()
					{
						new MyMenu() { Name = "test1-1" },
						new MyMenu() { Name = "test1-2" },
						new MyMenu() { Name = "test1-3" },
					}
				},
				new MyMenu()
				{
					Name = "簡易テスト",
					Child = new List<Models.MyMenu>()
					{
						new MyMenu() { Name = "TabConから操作" },
						new MyMenu()
						{
							Name = "このViewから操作",
							Child = new List<Models.MyMenu>()
							{
								new MyMenu() { Name = "ViewをWindowで開く",Value="GotoCommand2" },
								new MyMenu() { Name = "閉じる",Value="CloseCommand" },
							}
						}
					}
				}
			};
		}

		/// <summary>
		/// Treeの選択動作
		/// </summary>



		public ViewModelCommand MenuSelectedItemChanged {
			get { return new Livet.Commands.ViewModelCommand(MenuSelected); }
		}
		public void MenuSelected()
		{
			string selectedValue = (string)MenuTree.SelectedValue;
			if (selectedValue == "CloseCommand") {
				Close();
			}else if(selectedValue == "GotoCommand2") {
				Goto2();
			}
		}



		public ViewModelCommand GotoCommand2 {
			get { return new Livet.Commands.ViewModelCommand(Goto2); }
		}

		/// <summary>
		/// Windowクラスを別ウインドウで開く
		/// </summary>
		public void Goto2()
		{
			string dbMsg = "";
			Views.ChildView rContent = new Views.ChildView();
			dbMsg += "WindowクラスのViewを\r\n";
			ViewModels.ChildViewModel VM = new ViewModels.ChildViewModel();
			VM.MW  = (Views.MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
			VM.CInfo_lb = dbMsg + "表示";
			rContent.DataContext = VM;
			//TransitionMessage message = new TransitionMessage(rContent.GetType(), VM, TransitionMode.Modal);
			//Messenger.Raise(message);
			rContent.Show();
		}


		private ViewModelCommand _CloseCommand;
		public ViewModelCommand CloseCommand {
			get {
				if (_CloseCommand == null) {
					_CloseCommand = new ViewModelCommand(Close);
				}
				return _CloseCommand;
			}
		}

		/// <summary>
		/// このウィンドウを閉じる
		/// </summary>
		public void Close()
		{
			var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) =>
			w.IsActive);
		}
	}
}
