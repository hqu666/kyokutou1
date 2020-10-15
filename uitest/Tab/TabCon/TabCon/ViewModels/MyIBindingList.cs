using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabCon.ViewModels {
	/// <summary>
	/// カスタム コレクション
	/// </summary>
	public class MyIBindingList : CollectionBase, IBindingList {
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MyIBindingList()
		{
		}
		/// <summary>
		/// 新しいインデックスを追加します。
		/// </summary>
		/// <param name="property">Provides an abstraction of a property on a class.</param>
		public void AddIndex(System.ComponentModel.PropertyDescriptor property)
		{
		}
		/// <summary>
		/// リストに新しい項目を追加します。
		/// </summary>
		/// <returns>新しい項目</returns>
		public object AddNew()
		{
			return this.AddNew("New Widget", 0, 0);
		}
		/// <summary>
		/// リストに新しい項目を追加します。
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="marketValue">Market 値</param>
		/// <param name="magnitude">Magnitude</param>
		/// <returns>Widget</returns>
		public Widget AddNew(string name, double marketValue, long magnitude)
		{
			Widget w = new Widget(name, marketValue, magnitude);
			this.List.Add(w);
			return w;
		}
		/// <summary>
		/// リスト内の項目を更新できるかどうかを取得します。
		/// </summary>
		public bool AllowEdit {
			get {
				return true;
			}
		}
		/// <summary>
		/// AddNew を使用して項目をリストに追加できるかどうかを取得します。
		/// </summary>
		public bool AllowNew {
			get {
				return true;
			}
		}
		/// <summary>
		/// Remove または RemoveAt を使用して、リストから項目を削除できるかどうかを取得します。
		/// </summary>
		public bool AllowRemove {
			get {
				return true;
			}
		}
		/// <summary>
		/// PropertyDescriptor または ListSortDirection に基づいてリストをソートします。
		/// </summary>
		/// <param name="property">ソートする PropertyDescriptor。</param>
		/// <param name="direction">ListSortDirection 値のひとつ。</param>
		public void ApplySort(System.ComponentModel.PropertyDescriptor property, System.ComponentModel.ListSortDirection direction)
		{
		}
		/// <summary>
		/// 特定の PropertyDescriptor を持っている行のインデックスを返します。
		/// </summary>
		/// <param name="property">検索する PropertyDescriptor。</param>
		/// <param name="key">検索するプロパティ パラメータの値。</param>
		/// <returns>特定の PropertyDescriptor を持っている行のインデックスを返します。</returns>
		public int Find(System.ComponentModel.PropertyDescriptor property, object key)
		{
			return 0;
		}
		/// <summary>
		/// リスト内の項目がソートされるかどうかを取得します。
		/// </summary>
		public bool IsSorted {
			get {
				return true;
			}
		}
		/// <summary>
		/// IBindingList クラスの ListChanged イベントを処理するメソッドを表します。
		/// </summary>
		public event System.ComponentModel.ListChangedEventHandler ListChanged;
		/// <summary>
		/// 検索するために使用されるインデックスから PropertyDescriptor を削除します。
		/// </summary>
		/// <param name="property">検索のために使用されるインデックスから削除する PropertyDescriptor。</param>
		public void RemoveIndex(System.ComponentModel.PropertyDescriptor property)
		{
		}
		/// <summary>
		/// ApplySort を使用して適用されるソートを削除します。
		/// </summary>
		public void RemoveSort()
		{
		}
		/// <summary>
		/// ソートの方向を取得します。
		/// </summary>
		public System.ComponentModel.ListSortDirection SortDirection {
			get {
				return new System.ComponentModel.ListSortDirection();
			}
		}
		/// <summary>
		/// ソートするために使用されている PropertyDescriptor を取得します。
		/// </summary>
		public System.ComponentModel.PropertyDescriptor SortProperty {
			get {
				return null;
			}
		}
		/// <summary>
		/// リストが変更するまたはリスト内の項目が変更する時に ListChanged イベント
		/// が発生するかどうかを取得します。
		/// </summary>
		public bool SupportsChangeNotification {
			get {
				return true;
			}
		}
		/// <summary>
		/// Find メソッドを使用して、リストが検索をサポートするかどうかを取得します。
		/// </summary>
		public bool SupportsSearching {
			get {
				return true;
			}
		}
		/// <summary>
		/// リストがソートをサポートするかどうかを取得します。
		/// </summary>
		public bool SupportsSorting {
			get {
				return true;
			}
		}
		/// <summary>
		/// 位置またはキーのいずれかによって Collection オブジェクトの特定のメンバを返します。
		/// </summary>
		public Widget this[int index] {
			get {
				return this.List[index] as Widget;
			}
			set {
				this.List[index] = value;
			}
		}
	}
}
