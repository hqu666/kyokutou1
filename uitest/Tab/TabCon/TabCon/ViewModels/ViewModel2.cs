
using System;
 
// ObservableCollection
using System.Collections.Generic;
using System.Linq;
 
//INotifyPropertyChanged
//PropertyChanged
using System.ComponentModel;
 
//参照設定が必要
//using System.Configuration;
 
using Livet;
using Livet.Commands;
using Livet.Messaging;
//CloseCommand
using Livet.Messaging.Windows;
 
//ICommand
//using System.Windows.Input;
 
using System.Windows;
 
 
namespace TabCon.ViewModels {
	class ViewModel2 : ViewModel {
		public ViewModel2()
		{
			var Loaded = new Livet.Commands.ListenerCommand<Window>((w) => {
				if (NeedHideOwner && w.Owner != null && w.Owner.Visibility ==
								Visibility.Visible) {
					w.Owner.Hide();
				}
			});

			var Closing = new Livet.Commands.ListenerCommand<Window>((w) => {
				if (NeedHideOwner && w.Owner != null) {
					w.Owner.Show();
				}
			});
		}

		public bool NeedHideOwner { get; set; }
		//public ICommand Loaded { get; private set; }
		//public ICommand Closing { get; private set; }

		public void Initialize()
		{
			//XCloseButtonManager.Disable();
		}

		#region CloseCommand
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
			var window = Application.Current.Windows.OfType<Window>().
								SingleOrDefault((w) => w.IsActive);
			window.Close();
		}
		#endregion
	}
}