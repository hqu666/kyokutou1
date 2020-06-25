using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace GoogleOSD {
	class TreeViewModel {
		public TreeViewModel(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
		public IList<TreeViewModel> Children { get; set; } = new List<TreeViewModel>();
	}
}
