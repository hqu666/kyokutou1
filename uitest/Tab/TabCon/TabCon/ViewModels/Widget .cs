using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabCon.ViewModels {
	/// <summary>
	/// IBindingListで使用されるWidget クラス。
	/// </summary>
	public class Widget {
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="marketValue">Market 値</param>
		/// <param name="magnitude">Magnitude</param>
		public Widget(string name, double marketValue, long magnitude)
		{
			this.Name = name;
			this.MarketValue = marketValue;
			this.Magnitude = magnitude;
		}
		private string name;
		private double marketValue;
		private long magnitude;
		/// <summary>
		/// Public プロパティ名
		/// </summary>
		public string Name {
			get {
				return this.name;
			}
			set {
				this.name = value;
			}
		}
		/// <summary>
		/// Public プロパティ Market 値
		/// </summary>
		public double MarketValue {
			get {
				return this.marketValue;
			}
			set {
				this.marketValue = value;
			}
		}
		/// <summary>
		/// Public プロパティ Magnitude
		/// </summary>
		public long Magnitude {
			get {
				return this.magnitude;
			}
			set {
				this.magnitude = value;
			}
		}
	}
}
