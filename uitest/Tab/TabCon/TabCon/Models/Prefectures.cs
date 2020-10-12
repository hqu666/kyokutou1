using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// “s“¹•{Œ§ƒ}ƒXƒ^
	/// </summary>
	public partial class Prefectures
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
			}
		}

	}


	public class PrefecturesCollection : ObservableCollection<Prefectures> {
		public PrefecturesCollection(){
		}
	}
}
