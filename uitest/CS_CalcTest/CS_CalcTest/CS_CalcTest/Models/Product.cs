using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_CalcTest.Models
{
	/// <summary>
	/// テスト用：製品
	/// </summary>
	public class Product : NotificationObject {
		///<summary>
		///製品名
		///</summary>
		private string _Name;
		public string Name {
			get => _Name;
			set {
				if (_Name == value)
					return;
				_Name = value;
			}
		}

		private int _Price;
		/// <summary>
		/// 価格
		/// </summary>
		public int Price {
			get => _Price;
			set {
				if (_Price == value)
					return;
				_Price = value;
			}
		}

		private int _Tax;
		/// <summary>
		/// 外税
		/// </summary>
		public int Tax {
			get => _Tax;
			set {
				if (_Tax == value)
					return;
				_Tax = value;
			}
		}


	}
}
