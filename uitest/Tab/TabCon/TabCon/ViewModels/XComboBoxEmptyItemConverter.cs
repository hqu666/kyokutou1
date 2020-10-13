using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//IValueConverter 
using System.Globalization;
using System.Windows.Data;

//DynamicObject
using System.ComponentModel;
using System.Dynamic;

//IEnumerable
using System.Collections;


namespace TabCon.ViewModels {
	/// <summary>
	/// http://www.aa.cyberhome.ne.jp/~bel/WPFCSharpUsingLivet/basic11.html
	/// </summary>
	public class XComboBoxEmptyItemConverter {
		private class EmptyItem : DynamicObject {
			public override bool TryGetMember(GetMemberBinder binder,
					out object result)
			{
				result = null;
				return true;
			}
		}

		public object Convert(object value, Type targetType, object parameter,
			CultureInfo culture)
		{
			IEnumerable container = value as IEnumerable;

			if (container != null) {
				IEnumerable<object> genericContainer = container.OfType<object>();
				IEnumerable<object> emptyItem = new object[] { new EmptyItem() };
				return emptyItem.Concat(genericContainer);
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter,
			CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}