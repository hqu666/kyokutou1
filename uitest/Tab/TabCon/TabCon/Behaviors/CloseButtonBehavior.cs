using System;

//[DllImport("user32.dll")]
using System.Runtime.InteropServices;

using System.Windows;

//WindowInteropHelper
using System.Windows.Interactivity;

using System.Windows.Interop;

namespace TabCon.Behaviors {
	public class CloseButtonBehavior : Behavior<Window> {

		// http://b.amberfrog.net/post/88379654924/window%E3%81%AE%E9%96%89%E3%81%98%E3%82%8B%E3%83%9C%E3%82%BF%E3%83%B3%E3%82%92%E7%84%A1%E5%8A%B9%E3%81%AB%E3%81%99%E3%82%8Bbehavior

		[DllImport("user32.dll")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("user32.dll")]
		private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

		private const uint SC_CLOSE = 0xF060;

		private const uint MF_BYCOMMAND = 0x00000000;
		private const uint MF_GRAYED = 0x00000001;
		private const uint MF_ENABLED = 0x00000000;

		public static readonly DependencyProperty IsWindowCloseProperty
			= DependencyProperty.Register(
				"IsWindowCloseEnable", typeof(bool),
				typeof(CloseButtonBehavior),
				new PropertyMetadata(true, new PropertyChangedCallback(OnPropertyChanged)));

		public bool IsWindowCloseEnable {
			get { return (bool)this.GetValue(IsWindowCloseProperty); }
			set { this.SetValue(IsWindowCloseProperty, value); }
		}

		private static void OnPropertyChanged(DependencyObject obj,
			DependencyPropertyChangedEventArgs e)
		{
			var self = obj as CloseButtonBehavior;
			if (self != null) {
				self.Apply();
			}
		}

		private void Apply()
		{
			if (AssociatedObject == null) {
				return;
			}
			var hwnd = new WindowInteropHelper(AssociatedObject).Handle;
			IntPtr hMenu = GetSystemMenu(hwnd, false);
			if (hMenu != IntPtr.Zero) {
				if (IsWindowCloseEnable) {
					EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_ENABLED);
				} else {
					EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
				}
			}
		}
	}
}