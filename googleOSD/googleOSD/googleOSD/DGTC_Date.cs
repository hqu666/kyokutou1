using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GoogleOSD {
	public class DGTC_Date : DataGridTextColumn {
		#region Methods

		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			var textBlock = new TextBlock();
			textBlock.SetValue(FrameworkElement.StyleProperty, ElementStyle);

			Dispatcher.BeginInvoke(
				DispatcherPriority.Loaded,
				new Action<TextBlock>(x => x.SetBinding(TextBlock.TextProperty, Binding)),
			textBlock);
			return textBlock;
		}

		#endregion Methods
	}
}