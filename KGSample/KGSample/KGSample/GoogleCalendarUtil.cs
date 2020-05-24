using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace KGSample {
	class GoogleCalendarUtil {
		public Google.Apis.Calendar.v3.Data.Event listItems = null;
		CS_Util Util = new CS_Util();

		/// <summary>
		/// GoogleCalender・Eventの登録状況表示
		/// </summary>
		/// <param name="timeMin">開始日</param>
		/// <param name="timeMax">終了日</param>
		/// <returns></returns>
		public IList<Event> GEventsListUp(DateTime timeMin,DateTime timeMax)
		{
			string TAG = "GEventsListUp";
			string dbMsg = "[GoogleCalendarUtil]";
			IList<Google.Apis.Calendar.v3.Data.Event> retList = new List<Google.Apis.Calendar.v3.Data.Event>();
			try {
				dbMsg += ",対象期間=" + timeMin + "～" + timeMax;
				// Create Google Calendar API service.
				var service = new CalendarService(new BaseClientService.Initializer() {
					HttpClientInitializer = Constant.MyCalendarCredential,
					ApplicationName = Constant.ApplicationName,
				});
				dbMsg += ",HttpClient=" + service.HttpClient.ToString();

				// Define parameters of request.
				// ※終日・複数日のStartはDateTimeが無いのでStart.DateでソートしたいがOrderByEnumに該当カラムが無い
				EventsResource.ListRequest request = service.Events.List("primary");
				request.TimeMin = timeMin;                     //DateTime.Now;
				request.TimeMax = timeMax;
				request.ShowDeleted = false;
				request.SingleEvents = true;
				request.MaxResults = 1000;
				request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
				Task<Events> evRequest = Task.Run(() => {
					return request.ExecuteAsync();              //取得実行
				});
				evRequest.Wait();
				Events events = evRequest.Result;                           //作成結果が格納され戻される
																			//				Events events = request.Execute();              //取得実行
				Constant.CalenderSummary = events.Summary;
				if (events.Items != null && events.Items.Count > 0) {
					dbMsg += ",events=" + events.Items.Count() + "件";
					foreach (var eventItem in events.Items) {
						string startDT = eventItem.Start.DateTime.ToString();
						dbMsg += "\r\n" + startDT;
						string endDT = eventItem.End.DateTime.ToString();
						dbMsg += "～" + endDT;
						if (String.IsNullOrEmpty(startDT)) {
							startDT = eventItem.Start.Date;
						}
						string Summary = eventItem.Summary;
						dbMsg += "," + Summary;
						retList.Add(eventItem);
					}
					dbMsg += "," + retList.Count() + "件";
				} else {
					dbMsg += "まだ予定が登録されていません";
				}
				Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
			return retList;
		}

		/// <summary>
		/// EventDateTimeを20211231などの数値で返す
		/// </summary>
		/// <param name="TEventDateTime">EventのStartやEnd</param>
		/// <returns>20211231などのint</returns>
		public int EventDateTime2Int(EventDateTime TEventDateTime)
		{
			string TAG = "EventDateTime2Str";
			string dbMsg = "[GoogleCalendarUtil]";
			int retInt = 0;
			try {
				retInt = int.Parse(EventDateTime2Str(TEventDateTime));
				dbMsg += ">>" + retInt;
		//		Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
			return retInt;
		}

		/// <summary>
		///  EventDateTimeをyyyyMMddの文字列で返す
		/// </summary>
		/// <param name="TEventDateTime">EventのStartやEnd</param>
		/// <returns>yyyyMMddのstring</returns>
		public string EventDateTime2Str(EventDateTime TEventDateTime)
		{
			string TAG = "EventDateTime2Str";
			string dbMsg = "[GoogleCalendarUtil]";
			string retStr = null;
			try {
				DateTime tDateTime = EventDateTime2DT( TEventDateTime);
				if(tDateTime ==null) {
					tDateTime = DateTime.Now;
				}
				//if (TEventDateTime.DateTime == null) {
				//	dbMsg += "Date=" + TEventDateTime.Date;
				//	string todayItemStartDate = TEventDateTime.Date;
				//	string[] sStr = todayItemStartDate.Split('-');
				//	tDateTime = new DateTime(int.Parse(sStr[0]), int.Parse(sStr[1]), int.Parse(sStr[2]));
				//}
				//if (TEventDateTime.Date == null) {
				//	dbMsg += "Date=" + TEventDateTime.DateTime;
				//	int sYear = TEventDateTime.DateTime.Value.Year;
				//	int sMonth = TEventDateTime.DateTime.Value.Month;
				//	int sDay = TEventDateTime.DateTime.Value.Day;
				//	tDateTime = new DateTime(sYear, sMonth, sDay);
				//}
				retStr = String.Format("{0:yyyyMMdd}", tDateTime);
				dbMsg += ">>" + retStr;
	//			Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
			return retStr;
		}

		/// <summary>
		/// Google.EventのStart・Endでデータが入っているところからDateTimeを返す
		/// 何も使えるものが無ければ現在日時が返る
		/// </summary>
		/// <param name="TEventDateTime"></param>
		/// <returns></returns>
		public DateTime EventDateTime2DT(EventDateTime TEventDateTime)
		{
			string TAG = "EventDateTime2DT";
			string dbMsg = "[GoogleCalendarUtil]";
			DateTime tDateTime = DateTime.Now;
			try {
				if (TEventDateTime.DateTime != null) {
					dbMsg += "Date=" + TEventDateTime.DateTime;
					int sYear = TEventDateTime.DateTime.Value.Year;
					int sMonth = TEventDateTime.DateTime.Value.Month;
					int sDay = TEventDateTime.DateTime.Value.Day;
					int sHour = TEventDateTime.DateTime.Value.Hour;
					int sMinute = TEventDateTime.DateTime.Value.Minute;
					int sSecond = TEventDateTime.DateTime.Value.Second;
					tDateTime = new DateTime(sYear, sMonth, sDay, sHour, sMinute, sSecond);
				}else if (TEventDateTime.Date != null) {
					dbMsg += "Date=" + TEventDateTime.Date;
					string todayItemStartDate = TEventDateTime.Date;
					string[] sStr = todayItemStartDate.Split('-');
					tDateTime = new DateTime(int.Parse(sStr[0]), int.Parse(sStr[1]), int.Parse(sStr[2]));
				}
				dbMsg += ">>" + tDateTime;
				//			Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
			return tDateTime;
		}


		public Color ColorId2RGB(string colorId)
		{
			string TAG = "ColorId2RGB";
			string dbMsg = "[GoogleCalendarUtil]";
			Color reColor = Color.FromRgb( 0x00, 0xFF, 0x00);
			try {
				dbMsg += "colorId=" + colorId;
				switch(colorId){
					case "1":
						dbMsg += ":ラベンダー";
						reColor = Color.FromRgb( 121, 134, 203);
						break;
					case "2":
						dbMsg += ":セージ";
						reColor = Color.FromRgb( 51, 182, 121);
						break;
					case "3":
						dbMsg += ":ブドウ";
						reColor = Color.FromRgb( 142, 36, 170);
						break;
					case "4":
						dbMsg += ":フラミンゴ";
						reColor = Color.FromRgb( 230, 124, 115);
						break;
					case "5":
						dbMsg += ":バナナ";
						reColor = Color.FromRgb(246, 192, 40);
						break;
					case "6":
						dbMsg += ":ミカン";
						reColor = Color.FromRgb( 244, 81, 30);
						break;
					case "7":
						dbMsg += ":不明";
						break;
					case "8":
						dbMsg += ":ブルーベリー";
						reColor = Color.FromRgb( 63, 81, 181);
						break;
					case "9":
						dbMsg += ":グラファイト";
						reColor = Color.FromRgb( 97, 97, 97);
						break;
					case "10":
						dbMsg += ":バジル";
						reColor = Color.FromRgb( 11, 128, 67);
						break;
					case "11":
						dbMsg += ":トマト";
						reColor = Color.FromRgb( 213, 0, 0);
						break;
					default:
						dbMsg += ":無指定：ピーコック";
						reColor = Color.FromRgb( 121, 134, 203);
						break;
				}
				dbMsg += ">>" + reColor;
				Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
			return reColor;
		}


		/// <summary>
		/// Eventの更新
		/// 成功したらUrlを返す
		/// </summary>
		/// <returns>Url</returns>
		public string UpDateGEvents()
		{
			string TAG = "UpDateGEvents";
			string dbMsg = "[GoogleCalendarUtil]";
			string retLink = null;
			try {
				// 予定を追加登録
				String eventId = Constant.eventItem.Id;
				Event body = Constant.eventItem;
				dbMsg = "[" + eventId;
				dbMsg = "}" + Constant.eventItem.Start.ToString();
				dbMsg = "," + Constant.eventItem.Summary;
				dbMsg = "\r\n" + Constant.eventItem.Description;
				CalendarService service = new CalendarService(new BaseClientService.Initializer() {
					HttpClientInitializer = Constant.MyCalendarCredential,
					ApplicationName = Constant.ApplicationName,
				});
				string calendarId = "primary";
				EventsResource.UpdateRequest request = service.Events.Update(body, calendarId, eventId);

				//	EventsResource.InsertRequest request = Constant.MyCalendarService.Events.Insert(Constant.eventItem, calendarId);
				//Google.Apis.Requests.RequestError .The requested identifier already exists. [409]
				//すでに存在するオブジェクトを作成しようとしました。
				Event createdEvent = request.Execute();
				retLink = createdEvent.HtmlLink;
				dbMsg = ">>" + retLink;
				Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
			return retLink;
		}

	}
}

/*
 追加		http://sloppy-content.blog.jp/archives/16488560.html
 イベントを作成する		https://developers.google.com/calendar/create-events#java	
 */
