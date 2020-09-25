using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// “s“¹•{Œ§ƒ}ƒXƒ^
	/// </summary>
	public partial class Prefectures{
		///ID
		public int id { get; set; }
		///“s“¹•{Œ§–¼
		public string prefectures_name { get; set; }

	}

	public class PrefecturesCollection : ObservableCollection<Prefectures> {
		public PrefecturesCollection(){
		}
	}
}
