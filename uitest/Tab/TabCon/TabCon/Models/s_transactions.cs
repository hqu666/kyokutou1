using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// îrëºÉeÅ[ÉuÉã
	/// </summary>
	public partial class s_transactions : NotificationObject
	{

		///<summary>
		///å_ñÒID
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
				RaisePropertyChanged();
			}
		}

	}


	public class s_transactionsCollection : ObservableCollection<s_transactions> {
		public s_transactionsCollection(){
		}
	}
}
