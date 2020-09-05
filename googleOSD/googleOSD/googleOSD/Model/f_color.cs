using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleOSD.Model {
	public partial class f_color {
		public int Id { get; set; }
		public string Color_var { get; set; }
		public string Color_name { get; set; }
		public string google_Color_id { get; set; }
		public DateTime modifier_on { get; set; }
		public DateTime deleted_on { get; set; }
	}

	public class FColorCollection : ObservableCollection<f_color> {
		public FColorCollection()
		{
		}
	}

}
