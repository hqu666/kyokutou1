using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���l�}�X�^
	/// </summary>
	public partial class Numbers{
		///�l :0�`9
		public int value { get; set; }

	}

	public class NumbersCollection : ObservableCollection<Numbers> {
		public NumbersCollection(){
		}
	}
}
