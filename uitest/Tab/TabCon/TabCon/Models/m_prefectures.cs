using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// “s“¹•{Œ§ƒ}ƒXƒ^
	/// </summary>
	public partial class m_prefectures : NotificationObject
	{

		///<summary>
		///ID
		///</summary>
		private int _id;
		public int id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;
				_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///“s“¹•{Œ§–¼
		///</summary>
		private string _prefectures_name;
		public string prefectures_name
		{
			get => _prefectures_name;
			set
			{
				if (_prefectures_name == value)
					return;
				_prefectures_name = value;
				RaisePropertyChanged();
			}
		}

	}


	public class m_prefecturesCollection : ObservableCollection<m_prefectures> {
		public m_prefecturesCollection(){
		}
	}
}
