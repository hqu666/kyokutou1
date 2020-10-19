using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabCon.ViewModels {
	public class X_1_3ViewModel : ViewModel {
		public Views.X_1_3 MyView { get; set; }
		public ViewModels.MainViewModel RootViewModel { get; set; }
		public X_1_3ViewModel()
		{
			//		connectionString = "てきとうな初期値";
		}
	}
}
