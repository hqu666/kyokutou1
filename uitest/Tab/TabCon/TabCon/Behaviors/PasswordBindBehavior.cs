using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows;

namespace TabCon.Behaviors {
	public class PasswordBindBehavior : Behavior<PasswordBox> {
		//<TextBox local:SelectAllOnFocusTextBoxBehavior.SelectAllOnFocus="True" Text="ABCDEFG" />
		//Bahaviorを使ってPasswordBoxでDataBindしてみる

		static bool initialized = false;
		public string Password {
			get {
				return (string)GetValue(PasswordProperty);
			}
			set {
				SetValue(PasswordProperty, value);
			}
		}
		public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
			"Password"
			, typeof(string)
			, typeof(PasswordBindBehavior)
			, new UIPropertyMetadata(null));
		private void Init()
		{
			if (this.AssociatedObject is PasswordBox) {
				this.AssociatedObject.Password = (string)GetValue(PasswordProperty);
			}
		}
		protected override void OnAttached()
		{
			base.OnAttached();
			if (!initialized) {
				this.Init(); initialized = true;
			}
			this.AssociatedObject.PasswordChanged += PasswordChanged;
		}

		void PasswordChanged(object sender, RoutedEventArgs e)
		{
			SetValue(PasswordProperty, ((PasswordBox)sender).Password);
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.AssociatedObject.PasswordChanged -= PasswordChanged;
		}
	}
}
