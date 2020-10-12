using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// ���l�}�X�^
	/// </summary>
	public partial class Numbers
	{

		///<summary>
		///�l :0�`9
		///</summary>
		private int _value;
		public int value
		{
			get => _value;
			set
			{
				if (_value == value)
					return;
				_value = value;
			}
		}

	}


	public class NumbersCollection : ObservableCollection<Numbers> {
		public NumbersCollection(){
		}
	}
}
