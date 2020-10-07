using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Livet;
using Livet.Commands;
using Livet.Messaging;

namespace TabCon.ViewModels {
	//.ViewModel
	public class MainViewModel : ViewModel {

	//	public TabControl MainTab { get; set; }

		public System.Collections.IEnumerable TabItems { get; set; }

		public string InfoLavel { get; set; }
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
		}

		public ViewModelCommand GotoCommand2 {
			get { return new Livet.Commands.ViewModelCommand(Goto2); }
		}
		public void Goto2()
		{
			//using (var vm = new ViewModel2()) {
			//	TransitionMessage message = new TransitionMessage(typeof(Views.Window2), vm, TransitionMode.Modal);
			//	Messenger.Raise(message);

			//}
			//Messenger.Raise(new TransitionMessage(new ViewModel2() { NeedHideOwner = true }, "MessageKey2"));
			//using (var vm = new ChildViewModel()) {
			//	TransitionMessage message = new TransitionMessage(typeof(Views.ChildView), vm, TransitionMode.Modal);
			//	Messenger.Raise(message);

			//}
			Messenger.Raise(new TransitionMessage(new ChildViewModel() { NeedHideOwner = true }, "MessageKey2"));
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
		public void Close()
		{
			var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) =>
			w.IsActive);
		}
	}
}
