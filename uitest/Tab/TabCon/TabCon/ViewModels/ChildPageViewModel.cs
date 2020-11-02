using Livet.Commands;
using System.Linq;
using System.Windows;
using Livet;

namespace TabCon.ViewModels {
	class ChildPageViewModel : ViewModel {
		public ViewTabControl MW { get; set; }
		public string CInfo_lb { get; set; }

		public ChildPageViewModel()
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
			if(MW == null) {
				//呼出し元：ｗ　と　自分:windowを取得
				var window = Application.Current.Windows.OfType<Window>().
									SingleOrDefault((w) => w.IsActive);
				//ダブに読み込むとMainを拾って閉じる
				window.Close();
			}else{
			//呼出し元からTabItem削除
				MW.DrelTabItem();
			}
		}
		#endregion
	}

}
