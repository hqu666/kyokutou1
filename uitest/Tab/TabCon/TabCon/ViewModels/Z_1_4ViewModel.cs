using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Windows.Shapes;
using Google.Apis.Drive.v3.Data;
using Infragistics.Controls.Schedules;
using Livet;
using Livet.Commands;
using Livet.Messaging.Windows;
using Livet.EventListeners;

using MySql.Data.MySqlClient;

using TabCon.Models;
using TabCon.Enums;
using Task = System.Threading.Tasks.Task;

namespace TabCon.ViewModels {
	public class Z_1_4ViewModel : ViewModel  {
		public string titolStr = "【Googleアカウント認証】";
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		//public GoogleAuth authWindow;
		//public GCalender mainView;
		//public GoogleDriveBrouser driveView;
		//public WebWindow webWindow;

		public t_project_bases tProject;
		//public IList<GAttachFile> sendFiles = new List<GAttachFile>();
		///// <summary>
		///// 添付ファイル　モデル
		///// </summary>
		//private AttachmentDataCollection attachmentDataCollection;


		/// <summary>
		/// このページで編集するEvent
		/// </summary>
		private Google.Apis.Calendar.v3.Data.Event taregetEvent { set; get; }
		/// <summary>
		/// 週別/日別区分
		/// </summary>
		public string weekDisplayMode { get; set; }

		public Views.X_2 MyView { get; set; }
		public ViewModels.MainViewModel RootViewModel { get; set; }
		/// <summary>
		/// 背景色
		/// </summary>
		public Dictionary<string, string> ColorComboSource { get; set; }
		public string souceEndValue = "選択...";
		#region ColorCombo選択変更
		private int _ColorComboSelectedIndex;
		public int ColorComboSelectedIndex {
			get {
				return _ColorComboSelectedIndex;
			}
			set {
				string TAG = "ColorComboSelectedIndex.set";
				string dbMsg = "";
				try {
					if (value == _ColorComboSelectedIndex)
						return;
					_ColorComboSelectedIndex = value;

					dbMsg += ",元の色 " + SelectedColorCord;
					dbMsg += "＞＞[ " + value + "]";
					//ColorCombo内で設定している色なら
					if (ColorComboSelectedIndex < ColorComboSource.Count - 1) {
						//対象イベントの背景色とXamColorPickerのSelectedColorに反映
						eventBgColor = (ColorComboSelectedIndex + 1).ToString();
						//	Z03Colorの列挙子を取得
						Z03Color headername = (Z03Color)Enum.Parse(typeof(Z03Color), ColorComboSelectedIndex.ToString());
						//	カラーコードは列挙子に使えないので置換えていた文字を＃戻す
						SelectedColorCord = headername.ToString().Replace("s", "#");
						RaisePropertyChanged("SelectedColorCord");
					}
					dbMsg += ">>変更色 " + SelectedColorCord;
					RaisePropertyChanged();
					MyLog(TAG, dbMsg);
				} catch (Exception er) {
					MyErrorLog(TAG, dbMsg, er);
				}
			}
		}
		#endregion

		#region XamColorPicker選択変更
		private string _SelectedColorCord;
		public string SelectedColorCord {
			get {
				return _SelectedColorCord;
			}
			set {
				string TAG = "SelectedColorCord.set";
				string dbMsg = "";
				try {
					if (value == _SelectedColorCord)
						return;
					_SelectedColorCord = value;
					eventBgColor = value;

					dbMsg += ",元のColorCombo選択[" + ColorComboSelectedIndex + "]";
					dbMsg += "＞＞選択色 " + value;
					int SourceEndIndex = ColorComboSource.Count - 1;
					//ColorCombo内で設定している色なら
					if (ColorComboSource.ContainsValue(value)) {
						//ColorCombono選択に反映
						int combIndex = 0;
						foreach (KeyValuePair<string, string> item in ColorComboSource) {
							if(item.Value== value) {
								break;
							}
							combIndex++;
							//読み出しが最後のアイテムに達したら
							if (item.Value.Equals(souceEndValue)) {
								combIndex = SourceEndIndex;
							}
						}
						ColorComboSelectedIndex = combIndex;
					}else{
						ColorComboSelectedIndex = SourceEndIndex;
					}
					dbMsg += ">>[" + ColorComboSelectedIndex +"/"+ SourceEndIndex + "]";
					RaisePropertyChanged();
					MyLog(TAG, dbMsg);
				} catch (Exception er) {
					MyErrorLog(TAG, dbMsg, er);
				}
			}
		}
		#endregion
		
		//表示対象年月
		public DateTime SelectedDateTime;
		/// <summary>
		/// 表示対象年月
		/// </summary>
		public string CurrentDate { get; set; }
		/// <summary>
		/// 個々の開催期間；終了-開始
		/// </summary>
		public TimeSpan EventTimeSpan;

		/// <summary>
		/// 予定配列
		/// </summary>
		//	public ObservableCollection<t_events> Events { get; set; }
		#region tEvents変更通知プロパティ
		public t_events _tEvents;
		/// <summary>
		/// 操作対象の予定
		/// </summary>
		public t_events tEvents {
			get { return _tEvents; }
			set {
				if (_tEvents == value)
					return;
				_tEvents = value;
				RaisePropertyChanged("tEvents");
			}
		}
		#endregion
		//viewへのBinding用
		///<summary>
		///イベント種別 :※固定値：イベント種別
		///</summary>
		public int eventType { get; set; }
		///<summary>
		///タイトル
		///</summary>
		public string eventTitle { get; set; }
		///<summary>
		///場所
		///</summary>
		public string eventPlace { get; set; }
		///<summary>
		///メモ
		///</summary>
		public string eventMemo { get; set; }
		///<summary>
		///ステータス :※固定値：イベントステータス
		///</summary>
		public int? eventStatus { get; set; }
		///<summary>
		///GoogleイベントID
		///</summary>
		public string googleId { get; set; }
		///<summary>
		///背景色 :※固定値：カラーもしくはARGB値（９桁）
		///</summary>
		public string eventBgColor { get; set; }
		///<summary>
		///文字色 :ARGB値（９桁：カラーピッカーによっては透明度が付与される）
		///</summary>
		public string eventFontColor { get; set; }
		public List<int> TSList { get; set; }

		public MySQL_Util MySQLUtil;

		/// <summary>
		/// ViewからのDataContext設定用
		/// </summary>
		public Z_1_4ViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			string TAG = "Initialize";
			string dbMsg = "";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		/// <summary>
		/// 開始日変更後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Start_date_dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "Start_date_dp_SelectedDateChanged";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += ",元の設定：" + tEvents.event_date_start;
				DatePicker dp = sender as DatePicker;
				DateTime selectedDate = dp.SelectedDate.Value.Date;     //時刻は00:00
				tEvents.event_date_start = selectedDate;
				dbMsg += ">>" + tEvents.event_date_start;
				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				TimeSpan startDTT = startDT.TimeOfDay;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				TimeSpan endDTT = endDT.TimeOfDay;
				dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
				TimeSpan duration = endDT - startDT;
				dbMsg += ",所要時間=" + duration;

				string selectedDateStr = String.Format("{0:yyyy-MM-dd}", selectedDate);
				dbMsg += ",selected=" + selectedDateStr;
				string startDTStr = String.Format("{0:yyyy-MM-dd}", startDT);
				if (!selectedDateStr.Equals(startDTStr)) {
					dbMsg += ">>変更";
					if (MyView.daylong_cb.IsChecked.Value) {
						dbMsg += ">>終日";
						taregetEvent.Start.Date = selectedDateStr;
					} else {
						selectedDate = selectedDate.Add(startDTT);
						dbMsg += ",登録＝" + selectedDate;
						taregetEvent.Start.DateTime = selectedDate;
						taregetEvent.Start.Date = null;                     //終日ではない事のフラグ
					}
				}
				if (taregetEvent.OriginalStartTime.DateTime == null) {
					taregetEvent.OriginalStartTime.DateTime = taregetEvent.Start.DateTime;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 開始時刻変更後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// 
		//private void Start_time_tp_SelectedTimeChanged(object sender, SelectionChangedEventArgs e)
		//{
		//	string TAG = "Start_time_tp_SelectedTimeChanged";
		//	string dbMsg = "[GEventEdit]";
		//	try {
		//		dbMsg += ",元の設定：" + tEvents.event_time_start;
		//		DatePicker dp = sender as DatePicker;
		//		MyView.TimePic tp = sender as TimePic;
		//		TimeSpan selectedTS = tp.selectedTS;
		//		int selectedHours = selectedTS.Hours;
		//		int selectedMinutes = selectedTS.Minutes;
		//		int selectedSeconds = selectedTS.Seconds;
		//		TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
		//		dbMsg += ",開始時刻=" + selectedTime;
		//		tEvents.event_time_start = (int)selectedHours;
		//		dbMsg += ">>" + tEvents.event_time_start;
		//		DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
		//		TimeSpan startDTT = startDT.TimeOfDay;
		//		DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
		//		TimeSpan endDTT = endDT.TimeOfDay;
		//		dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
		//		TimeSpan duration = endDT - startDT;
		//		dbMsg += ",所要時間=" + duration;

		//		//TimePic tp = sender as TimePic;
		//		//TimeSpan selectedTS = tp.selectedTS;
		//		//int selectedHours = selectedTS.Hours;
		//		//int selectedMinutes = selectedTS.Minutes;
		//		//int selectedSeconds = selectedTS.Seconds;
		//		//TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
		//		//dbMsg += ",開始時刻=" + selectedTime;
		//		//if (!selectedTime.Equals(startDTT)) {
		//		//	DateTime startDTDate = startDT.Date;
		//		//	dbMsg += ",startDTDate=" + startDTDate;
		//		//	startDT = startDTDate.Add(selectedTime);
		//		//	dbMsg += ">登録>" + startDT;
		//		taregetEvent.Start.DateTime = startDT;
		//		//	//終了側の変更
		//		//	//taregetEvent.End.DateTime = startDT.Add(duration);
		//		//	//dbMsg += ">end>" + taregetEvent.End.DateTime;
		//		//	//end_time_tp.SelectedTime = taregetEvent.End.DateTime.Value.TimeOfDay;
		//		//	//end_date_dp.SelectedDate = taregetEvent.End.DateTime.Value.Date;
		//		taregetEvent.Start.Date = null;                     //終日ではない事のフラグ
		//															//}
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		MyErrorLog(TAG, dbMsg, er);
		//	}
		//}

		/// <summary>
		/// 終了時刻変更後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//private void End_time_tp_SelectedTimeChanged(object sender, SelectionChangedEventArgs e)
		//{
		//	string TAG = "End_time_tp_SelectedTimeChanged";
		//	string dbMsg = "[GEventEdit]";
		//	try {
		//		dbMsg += ",元の設定：" + tEvents.event_time_end;
		//		DatePicker dp = sender as DatePicker;
		//		TimePic tp = sender as TimePic;
		//		TimeSpan selectedTS = tp.selectedTS;
		//		int selectedHours = selectedTS.Hours;
		//		int selectedMinutes = selectedTS.Minutes;
		//		int selectedSeconds = selectedTS.Seconds;
		//		TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
		//		dbMsg += ",開始時刻=" + selectedTime;
		//		tEvents.event_time_end = (int)selectedHours;
		//		dbMsg += ">>" + tEvents.event_time_end;
		//		DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
		//		TimeSpan startDTT = startDT.TimeOfDay;
		//		DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
		//		TimeSpan endDTT = endDT.TimeOfDay;
		//		dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
		//		TimeSpan duration = endDT - startDT;
		//		dbMsg += ",所要時間=" + duration;

		//		//TimePic tp = sender as TimePic;
		//		//TimeSpan selectedTS = tp.selectedTS;
		//		//int selectedHours = selectedTS.Hours;
		//		//int selectedMinutes = selectedTS.Minutes;
		//		//int selectedSeconds = selectedTS.Seconds;
		//		//TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
		//		dbMsg += ",終了時刻=" + selectedTime;
		//		if (!selectedTime.Equals(endDTT)) {
		//			DateTime endDTDate = endDT.Date;
		//			dbMsg += ",endDTDate=" + endDTDate;
		//			endDT = endDTDate.Add(selectedTime);
		//			dbMsg += ">登録>" + endDT;
		//			taregetEvent.End.DateTime = endDT;
		//			//終了側の変更
		//			//taregetEvent.End.DateTime = startDT.Add(duration);
		//			//dbMsg += ">end>" + taregetEvent.End.DateTime;
		//			//end_time_tp.SelectedTime = taregetEvent.End.DateTime.Value.TimeOfDay;
		//			//end_date_dp.SelectedDate = taregetEvent.End.DateTime.Value.Date;
		//			taregetEvent.End.Date = null;                     //終日ではない事のフラグ
		//		}
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		MyErrorLog(TAG, dbMsg, er);
		//	}
		//}

		private void RemoveAt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "RemoveAt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				//var selectedData = this.Attachments_dg.SelectedItem as AttachmentData;
				//if (selectedData == null) {
				//	dbMsg += "データ取得失敗";
				//} else {
				//	dbMsg += ",Title=" + selectedData.Title;
				//	string delFileId = selectedData.FileId;
				//	dbMsg += ",FileId= " + delFileId;
				//	dbMsg += ",FileUrl= " + selectedData.FileUrl;
				//	int delIndex = AttachmentRelease(delFileId, true);
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 添付ファイルの解除処理
		/// </summary>
		/// <param name="delFileId">解除対象</param>
		/// <param name="isDel">削除</param>
		private int AttachmentRelease(string delFileId, bool isDel)
		{
			string TAG = "AttachmentRelease";
			string dbMsg = "[GEventEdit]";
			int delIndex = -1;
			try {
				////string delFileId = delAttachment.FileId;
				////dbMsg += "  ,Del;Title=" + delAttachment.Title + "  ,Id=" + delAttachment.FileId;
				//dbMsg += "  ,Id=" + delFileId + ")";
				//IList<Google.Apis.Calendar.v3.Data.EventAttachment> attachments = this.taregetEvent.Attachments;
				//dbMsg += "Attachments" + attachments.Count + "件";
				//string title = "";
				//if (-1 < attachmentDataCollection.Count) {
				//	delIndex = 0;
				//	foreach (AttachmentData attachment in attachmentDataCollection) {
				//		title = attachment.Title;
				//		string fileId = attachment.FileId;
				//		dbMsg += "\r\n" + delIndex + ")" + title + ",fileId=" + fileId;
				//		if (fileId.Equals(delFileId)) {
				//			break;
				//		}
				//		delIndex++;
				//	}
				//	dbMsg += ",delIndex=" + delIndex;
				//	attachmentDataCollection.RemoveAt(delIndex);
				//	dbMsg += ">削除：添付>" + attachmentDataCollection.Count + "件";
				//}
				//this.Attachments_dg.Items.Refresh();
				//int cCount = attachmentDataCollection.Count;
				//if (isDel) {
				//	String titolStr = Constant.ApplicationName;
				//	String msgStr = title + "を削除しますか？：";
				//	MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
				//	dbMsg += ",result=" + result;
				//	if (result == MessageBoxResult.Yes) {

				//	}
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
				throw new NotImplementedException();
			}
			return delIndex;
		}

		/// <summary>
		/// GoogleDriveで選択したファイルを添付する
		/// ①PutItemEventFile
		/// ②GoogleDriveBrouser.File_list_lv_MouseDoubleClickでファイルだった場合
		/// </summary>
		/// <param name="fileItem"></param>
		public void AttachmentsFromDrive(Google.Apis.Drive.v3.Data.File fileItem)
		{
			string TAG = "AttachmentsFromDrive";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += ",[fileId=" + fileItem.Id + "]";
				foreach (Google.Apis.Calendar.v3.Data.EventAttachment cf in taregetEvent.Attachments) {
					if (cf.FileId.Equals(fileItem.Id)) {
						return;
					}
				}
				Google.Apis.Calendar.v3.Data.EventAttachment attachment = new Google.Apis.Calendar.v3.Data.EventAttachment();
				attachment.Title = fileItem.Name;
				dbMsg += "," + attachment.Title;
				attachment.FileId = fileItem.Id;
				dbMsg += ",fileUrl= " + attachment.FileUrl;
				if (fileItem.WebContentLink != null) {
					attachment.FileUrl = fileItem.WebContentLink;
				} else {
					//プレビューwebへ
					attachment.FileUrl = @"https://drive.google.com/file/d/" + fileItem.Id + "/view?usp=drive_web";
					dbMsg += ">>" + attachment.FileUrl;
				}
				attachment.ETag = fileItem.ETag;
				dbMsg += ",eTag= " + attachment.ETag;

				dbMsg += "  ,mimeType=" + fileItem.MimeType;
				if (fileItem.IconLink != null) {
					attachment.MimeType = fileItem.MimeType;
				} else {
					if (attachment.Title.Contains(".xls")) {
						attachment.MimeType = @"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
					} else if (attachment.Title.Contains(".doc")) {
						attachment.MimeType = @"application/vnd.openxmlformats-officedocument.wordprocessingml.document";
					} else if (attachment.Title.Contains(".ppt")) {
						attachment.MimeType = @"application/vnd.openxmlformats-officedocument.presentationml.presentation";
					} else if (attachment.Title.Contains(".pdf")) {
						attachment.MimeType = @"application/pdf";
					}
					dbMsg += ">>" + attachment.MimeType;
				}

				dbMsg += "  ,iconLink= " + fileItem.IconLink;
				if (fileItem.IconLink != null) {
					attachment.IconLink = fileItem.IconLink;
				} else {
					attachment.IconLink = @"https://ssl.gstatic.com/docs/doclist/images/icon_10_generic_list.png";
					if (attachment.Title.Contains(".xls")) {
						attachment.IconLink = @"https://drive-thirdparty.googleusercontent.com/16/type/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
					} else if (attachment.Title.Contains(".doc")) {
						attachment.IconLink = @"https://drive-thirdparty.googleusercontent.com/16/type/application/vnd.openxmlformats-officedocument.wordprocessingml.document";
					} else if (attachment.Title.Contains(".ppt")) {
						attachment.IconLink = @"https://drive-thirdparty.googleusercontent.com/16/type/application/vnd.openxmlformats-officedocument.presentationml.presentation";
					} else if (attachment.Title.Contains(".pdf")) {
						attachment.IconLink = @"https://drive-thirdparty.googleusercontent.com/16/type/application/pdf";
					}
					dbMsg += ">>" + attachment.IconLink;
				}
				dbMsg += "  ,attachments= " + this.taregetEvent.Attachments.Count + "件";
				taregetEvent.Attachments.Add(attachment);
				dbMsg += " >> " + taregetEvent.Attachments.Count + "件";
				MyLog(TAG, dbMsg);
				AddAttachmentst(attachment);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 添付ファイルのリストアイテム化	（ボタン化）
		/// </summary>
		/// <param name="attachment"></param>
		private void AddAttachmentst(Google.Apis.Calendar.v3.Data.EventAttachment attachment)
		{
			string TAG = "AddAttachmentst";
			string dbMsg = "[GEventEdit]";
			try {

				//string title = attachment.Title;
				//string fileId = attachment.FileId;
				//string fileUrl = attachment.FileUrl;
				//dbMsg += "," + title + ",fileId=" + fileId + ",fileUrl= " + fileUrl;
				//string mimeType = attachment.MimeType;
				//string eTag = attachment.ETag;
				//dbMsg += "  ,mimeType=" + mimeType + ",eTag= " + eTag;

				//if (attachmentDataCollection.Count < 1) {
				//	dbMsg += "  ,作成";
				//	attachmentDataCollection = new AttachmentDataCollection();
				//}
				//AttachmentData attachmentData = new AttachmentData();
				//attachmentData.Title = title;
				//attachmentData.FileId = fileId;
				//attachmentData.FileUrl = fileUrl;
				//attachmentData.MimeType = mimeType;
				//attachmentData.IconLink = attachment.IconLink;
				//attachmentData.ETag = attachment.ETag;

				////var queries = new List<string>() { $"id = '{ fileId }'" };           //	 , $"id = '{ fileId }'"
				////Task<File> rr = Task<File>.Run(() => {
				////		//SearchFilter filter = SearchFilter.NONE;
				////		//queries.Add(filter.ToQuery());
				////		return GoogleDriveUtil.FindFile(queries);
				////});
				////rr.Wait();
				////if (rr != null) {
				////		File fInfo = rr.Result;
				//File fInfo = GDriveUtil.FindById(fileId);
				//if (fInfo != null) {
				//	dbMsg += "  ,ModifiedTime=" + fInfo.ModifiedTime;
				//	attachmentData.Modifi = String.Format("{0:yyyy/MM/dd hh:mm}", fInfo.ModifiedTime);
				//	dbMsg += "  >>" + attachmentData.Modifi;
				//	long? fSIze = fInfo.Size;
				//	dbMsg += "  ,fSIze=" + fSIze;
				//	attachmentData.Size = fSIze + "KB";
				//	if (0 < fSIze) {
				//		attachmentData.Size = Math.Round(double.Parse(fSIze.ToString()) / 1000, 3) + "KB";
				//	} else if (999 < fSIze) {
				//		attachmentData.Size = Math.Round(double.Parse(fSIze.ToString()) / 1000, 0) + "KB";
				//	} else if (999999 < fSIze) {
				//		attachmentData.Size = Math.Round(double.Parse(fSIze.ToString()) / 1000000, 0) + "MB";
				//	}
				//}
				////	}
				//attachmentDataCollection.Add(attachmentData);

				//// データをそのままセットする
				//this.Attachments_dg.DataContext = attachmentDataCollection;
				////更新時はこれが必須
				//this.Attachments_dg.Items.Refresh();

				//int cCount = attachmentDataCollection.Count;
				//attachments_count_lb.Content = cCount.ToString();

				/*			
							//親になるパネルを作る
							StackPanel psp = new StackPanel();
							psp.Orientation = Orientation.Horizontal;
							psp.Margin = new Thickness(-5);

							//ボタンに見える部分
							Button bt = new Button();
							bt.Click += Attachment_bt_Click;
							bt.DataContext = fileUrl;
							bt.Style = FindResource("bt-attachment") as System.Windows.Style;
							//横並べ
							StackPanel sp = new StackPanel();
							sp.Orientation = Orientation.Horizontal;
							sp.Margin = new Thickness(-5);
							//アイコン
							string iconLink = attachment.IconLink;
							dbMsg += "  ,iconLink= " + iconLink;
							Image img = new Image();
							img.Source = new BitmapImage(new Uri("Resources/file.png", UriKind.Relative));
							if (iconLink == null) {
								if(mimeType.Equals(Constant.GoogleDriveMime_Folder)) {
									img.Source = new BitmapImage(new Uri("Resources/folder.png", UriKind.Relative));
								}
							} else{
								img.Source = new BitmapImage(new Uri(iconLink));
							}
							img.Height = 10;
							img.Width = 10;
							sp.Children.Add(img);
							//ファイルの表示名
							Label lb = new Label();
							lb.Content = title;
							lb.Margin = new Thickness(-5);
							//格納
							sp.Children.Add(lb);
							bt.Content = sp;
							psp.Children.Add(bt);
							//削除ボタン
							Button dbt = new Button();
							dbt.Click += Del_Attachment_bt_Click;
							dbt.DataContext = attachment;
							dbt.Style = FindResource("bt-dell") as System.Windows.Style;
							psp.Children.Add(dbt);
							//XAMLへ格納;
						attachments_sp.Children.Add(psp);
						*/
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 添付ファイルボタンの解除ボタンのクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Del_Attachment_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Del_Attachment_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				Button bt = sender as Button;
				Google.Apis.Calendar.v3.Data.EventAttachment delAttachment = bt.DataContext as Google.Apis.Calendar.v3.Data.EventAttachment;
				string delFileId = delAttachment.FileId;
				dbMsg += "  ,Del;Title=" + delAttachment.Title + "  ,Id=" + delAttachment.FileId;
				int delIndex = AttachmentRelease(delFileId, false);
				if (0 < delIndex) {
					////	//添付表示も削除
					//attachments_sp.Children.RemoveAt(delIndex);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// 添付ファイルの取得処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Attachment_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Attachment_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				Button bt = sender as Button;
				string taregetUrl = bt.DataContext as string;
				dbMsg += "  ,taregetUrl=" + taregetUrl;
				//デフォルトのブラウザで開く
				System.Diagnostics.Process.Start(taregetUrl);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
				throw new NotImplementedException();
			}
		}
		/// <summary>
		/// 書込み・更新結果をwebで見せる
		/// 現在未使用
		/// </summary>
		/// <param name="targetUrl"></param>
		private void QuitToWeb(string targetUrl)
		{
			string TAG = "QuitToWeb";
			string dbMsg = "[GoogleAuth]";
			try {
				dbMsg += ",targetUrl= " + targetUrl;

				string UserId = Constant.MyCalendarCredential.UserId;
				dbMsg += " ,UserId=" + UserId;
				MyLog(TAG, dbMsg);
				Constant.WebStratUrl = Constant.CalenderOtherView + "month?pli=1";
				//特定日の指定は　/month/2020/9/1?pli=1
				//		dbMsg += ",CalenderURL=" + Constant.WebStratUrl;
				//if (webWindow == null) {
				//	dbMsg += "一日リストを生成";
				//	webWindow = new WebWindow();
				//	webWindow.authWindow = null;
				//	webWindow.mainView = mainView;
				//	webWindow.Show();
				//	webWindow.SetMyURL(new Uri(targetUrl));
				//}
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 書込み・更新結果をダイアログで見せてから元のVieへ
		/// </summary>
		/// <param name="targetUrl"></param>
		private void ExecuteRes(string retLink)
		{
			string TAG = "ExecuteRes";
			string dbMsg = "[GEventEdit]";
			try {
				if (retLink != null) {
					//				if (retLink.Contains("https://www.google.com/calendar/event")) {
					String titolStr = Constant.ApplicationName;
					DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
					DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
					String msgStr = startDT + "～" + endDT;
					msgStr += "	\r\n" + taregetEvent.Summary;
					msgStr += "	を登録しました";
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dbMsg += ",result=" + result;
					string ym = String.Format("{0:yyyyMM}", startDT);
					msgStr += "	,ym=" + ym;
					//MonthInfo monthInfo = new MonthInfo(ym);
					//mainView.CreateCalendar(monthInfo);
					dbMsg += msgStr;
					QuitMe();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// イベント削除ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Del_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Del_bt_Click";
			string dbMsg = "[GEventEdit]";
			string retLink = taregetEvent.HtmlLink;
			try {
				String titolStr = Constant.ApplicationName;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				String msgStr = startDT + "～" + endDT;
				msgStr += "	\r\n" + taregetEvent.Summary;
				msgStr += "	を削除しました";

				GCalendarUtil.DeleteGEvents(taregetEvent);

				MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				dbMsg += ",result=" + result;
				string ym = String.Format("{0:yyyyMM}", startDT);
				msgStr += "	,ym=" + ym;
				//MonthInfo monthInfo = new MonthInfo(ym);
				//mainView.CreateCalendar(monthInfo);
				dbMsg += msgStr;
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// キャンセルボタンのクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Cancel_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Cancel_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Back_bt_Click(object sender, EventArgs e)
		{
			string TAG = "back_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// WPFでクローズボックスなど、ウインドウを閉じる時に発生するイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string TAG = "Window_Closing";
			string dbMsg = "[GEventEdit]";
			try {
				//				e.Cancel = true;                //このオブジェクトを破棄させない(1)
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// このフォームを閉じる
		/// ※this.Close();だと再表示でクラッシュするのでthis.Visible = false;でこのオブジェクトを破棄させない
		/// </summary>
		private void QuitMe()
		{
			string TAG = "QuitMe";
			string dbMsg = "[GEventEdit]";
			try {
				//if (mainView != null) {
				//	mainView.editView = null;
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			MyView.Close();
		}

		//戻し/////////////////////////////////////////////////////////////////////////
		public ViewModelCommand BackDate {
			get { return new Livet.Commands.ViewModelCommand(DateBack); }
		}
		/// <summary>
		/// 戻る
		/// </summary>
		public void DateBack()
		{
			string TAG = "DateBack";
			string dbMsg = "";
			try {
				if (weekDisplayMode.Equals("Week")) {
					SelectedDateTime = SelectedDateTime.AddDays(-7);
				} else {
					SelectedDateTime = SelectedDateTime.AddDays(-1);
				}
				dbMsg += SelectedDateTime + "に戻す";
				CurrentDate = String.Format("{0:yyyy年MM月dd日}", SelectedDateTime);
				dbMsg += ">>" + CurrentDate;
				RaisePropertyChanged("CurrentDate");
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		//////////////////////////////////////////////////登録//
		#region CancelCommand　　接続
		private ViewModelCommand _ConnectCommand;

		public ViewModelCommand ConnectCommand {
			get {
				if (_ConnectCommand == null) {
					_ConnectCommand = new ViewModelCommand(Connect);
				}
				return _ConnectCommand;
			}
		}

		public void Connect()
		{
			string TAG = "Connect";
			string dbMsg = "";
			try {

				MyLog(TAG, dbMsg);
				Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		#endregion

		#region CancelCommand　　解除
		private ViewModelCommand _CancelCommand;

		public ViewModelCommand CancelCommand {
			get {
				if (_CancelCommand == null) {
					_CancelCommand = new ViewModelCommand(Cancel);
				}
				return _CancelCommand;
			}
		}

		public void Cancel()
		{
			string TAG = "Connect";
			string dbMsg = "";
			try {

				MyLog(TAG, dbMsg);
				Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}

		}
		#endregion

		//Livet Messenger用///////////////////////
		new public void Dispose()
		{
			// 基本クラスのDispose()でCompositeDisposableに登録されたイベントを解放する。
			base.Dispose();
			Dispose(true);
		}
		///////////////////////Livet Messenger用//
		public static void MyLog(string TAG, string dbMsg)
		{
			dbMsg = "[" + MethodBase.GetCurrentMethod().Module.Name+ "]" + dbMsg;
			//dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}

		public MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
																		MessageBoxButton buttns,
																		MessageBoxImage icon
																		)
		{
			CS_Util Util = new CS_Util();
			return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
		}

	}
}