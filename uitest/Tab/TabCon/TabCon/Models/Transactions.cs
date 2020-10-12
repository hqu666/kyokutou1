using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// r¼e[u
	/// </summary>
	public partial class Transactions
	{

		///<summary>
		///_ñID
		///</summary>
		private int _m_contract_id;
		public int m_contract_id
		{
			get => _m_contract_id;
			set
			{
				if (_m_contract_id == value)
					return;
				_m_contract_id = value;
			}
		}

	}


	public class TransactionsCollection : ObservableCollection<Transactions> {
		public TransactionsCollection(){
		}
	}
}
