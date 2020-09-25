using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// îrëºÉeÅ[ÉuÉã
	/// </summary>
	public partial class Transactions{
		///å_ñÒID
		public int m_contract_id { get; set; }

	}

	public class TransactionsCollection : ObservableCollection<Transactions> {
		public TransactionsCollection(){
		}
	}
}
