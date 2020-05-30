using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KGSample {
	/// <summary>
	/// XAMLにTimePickerが無いので作成した時刻選択
	/// </summary>
	public partial class TimePic : UserControl {

		/// <summary>
		/// 選択値が変わった時に発生するイベント
		/// </summary>
		public event SelectionChangedEventHandler TimeSelectionChanged;

		public static RoutedEvent selectedTimeEvent = EventManager.RegisterRoutedEvent(
									 "selectedTimeChanged", // イベント名
									RoutingStrategy.Tunnel, // イベントタイプ
									typeof(RoutedEventHandler), // イベントハンドラの型
									typeof(TimePic)); // イベントのオーナー

		/// <summary>
		/// コンボボックスの選択値が変更されたら発生するイベント
		/// </summary>
		public event RoutedEventHandler SelectedTimeChanged {
			add { this.AddHandler(selectedTimeEvent, value); }
			remove { this.RemoveHandler(selectedTimeEvent, value); }
		}

		private void RaiseSampleEvent(object sender, RoutedEventArgs e)
		{
			e.Handled = true;
			RaiseEvent(new RoutedEventArgs(TimePic.selectedTimeEvent));
		}

		public TimeSpan selectedTS;

		/// <summary>
		/// 設定されたTimeSpan
		/// </summary>
		[Browsable(true)]
		[Description("XAMLにTimePickerが無いので作成")]
		public TimeSpan selectedTimeSpan {
			get {
				return selectedTS;
			}
			set {
				selectedTS = value;
		//		SetMyTimeSpan(selectedTS);
			}
		}

		/// <summary>
		/// 読み込まれた時点でリストを構成する
		/// </summary>
		public TimePic()
		{
			string TAG = "TimePic";
			string dbMsg = "[TimePic]";
			try {
				InitializeComponent();
				AddHours();
				AddMinutes();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		
		/// <summary>
		/// 外部から表示時刻を設定する
		/// </summary>
		/// <param name="targetDT"></param>
		public void SetMyTimeSpan(TimeSpan setTS)
		{
			string TAG = "SetMyTimeSpan";
			string dbMsg = "[TimePic]" + setTS;
			try {
				//初期化して入れ物を作る
				selectedTS = DateTime.Now.TimeOfDay;
				dbMsg += ",selectedTS=" + selectedTS;
				//指定値が有ればそちらに入れ替える
				if (setTS != null) {
					selectedTS = setTS;
					dbMsg += ">>" + selectedTS;
				}
				dbMsg += ",Hours=" + selectedTS.Hours;
				dbMsg += "(" + Hours_cb.Items.Count+")";
				Hours_cb.SelectedIndex = selectedTS.Hours;
				dbMsg += ",Minutes=" + selectedTS.Minutes;
				dbMsg += "(" + Minutes_cb.Items.Count + ")";
				Minutes_cb.SelectedIndex = selectedTS.Minutes;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 時間のリスト構成
		/// </summary>
		public void AddHours()
		{
			string TAG = "AddHours";
			string dbMsg = "[TimePic]";
			try {
				for (int i = 0;i<23;i++){
					//ファイルの表示名color情報をラベルに格納して
					Label lb = new Label();
					lb.Content = i.ToString();
					lb.DataContext = i;
					Hours_cb.Items.Add(lb);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 分のリスト構成
		/// </summary>
		public void AddMinutes()
		{
			string TAG = "AddMinutes";
			string dbMsg = "[TimePic]";
			try {
				for (int i = 0; i < 59; i++) {
					Label lb = new Label();
					lb.Content = i.ToString();
					lb.DataContext = i;
					Minutes_cb.Items.Add(i);
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// Parentでchildrenのイベントをまとめて取得
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StackPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "StackPanel_SelectionChanged";
			string dbMsg = "[TimePic]";
			try {
				//ComboBox cb = sender as ComboBox;
				//int serectIndex = cb.SelectedIndex;
				//dbMsg += ",serectIndex=" + serectIndex;
				//childrenのデータが全て生成できていたら　※読込み直後はnullの可能性有り
				if (-1<Hours_cb.SelectedIndex && -1<Minutes_cb.SelectedIndex ) {
					SetSelctedDateTime(Hours_cb.SelectedIndex, Minutes_cb.SelectedIndex, e);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// 分の選択
		/// </summary>
		/// <param name="setHours"></param>
		/// <param name="setMinutes"></param>
		public void SetSelctedDateTime(int setHours,int setMinutes,  SelectionChangedEventArgs e)
		{
			string TAG = "SetSelctedDateTime";
			string dbMsg = "[TimePic]" + setHours + " : " + setMinutes;
			try {
				selectedTS = new TimeSpan(setHours, setMinutes,0);
				dbMsg = ",selectedDT=" + selectedTS;
				//if (this.SelectedTimeChanged != null) {
				//	TimeSelectionChanged(this, e);
				//}
				if (this.TimeSelectionChanged != null) {
					TimeSelectionChanged(this, e);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		private void OnComboBoxSelectionChanged(SelectionChangedEventArgs e)
		{
			if (TimeSelectionChanged != null)
				TimeSelectionChanged(this, e);
		}

		////////////////////////////////////////////////////
		public void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}

	}
}
