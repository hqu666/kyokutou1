using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// r¼e[u
	/// </summary>
	public partial class Transactions{
		///_ñID
		public int m_contract_id { get; set; }

	}

	public class TransactionsCollection : ObservableCollection<Transactions> {
		public TransactionsCollection(){
		}
	}
}
