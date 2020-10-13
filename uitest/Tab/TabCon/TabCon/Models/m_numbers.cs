using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// ���l�}�X�^
	/// </summary>
	public partial class m_numbers : NotificationObject
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
				RaisePropertyChanged();
			}
		}

	}


	public class m_numbersCollection : ObservableCollection<m_numbers> {
		public m_numbersCollection(){
		}
	}
}
