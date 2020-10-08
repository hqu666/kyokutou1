using System.Windows;
// ObservableCollection
using System.Linq;
using Livet.Commands;
using Livet;
//CloseCommand

namespace TabCon.ViewModels {
	public class ChildViewModel : ViewModel {

		public Views.MainWindow MW { get; set; }
		public ViewTabControl TC { get; set; }
		public string CInfo_lb { get; set; }

		public ChildViewModel()
		{
			var Loaded = new Livet.Commands.ListenerCommand<Window>((w) => {
				if (NeedHideOwner && w.Owner != null && w.Owner.Visibility ==
								Visibility.Visible) {
					w.Owner.Hide();
				}
			});
			//閉じるコマンドを生成
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
	//		XCloseButtonManager.Disable();
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
			//呼出し元：ｗ　と　自分:windowを取得
			var window = Application.Current.Windows.OfType<Window>().
								SingleOrDefault((w) => w.IsActive);
			window.Close();
		}
		#endregion

		private void CPageCloss()
		{
			if(TC != null) {
				TC.DrelTabItem();
			}else{
				this.Close();
			}
		}
	}
}
