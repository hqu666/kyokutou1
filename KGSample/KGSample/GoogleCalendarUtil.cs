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
		public int EventDate2Int(EventDateTime TEventDateTime)
		{
			string TAG = "EventDate2Str";
			string dbMsg = "[GoogleCalendarUtil]";
			int retInt = 0;
			try {
				DateTime tDateTime = EventDateTime2DT(TEventDateTime);
				string retStr = String.Format("{0:yyyyMMdd}", tDateTime);
				retInt = int.Parse(retStr);
				dbMsg += ">>" + retInt;
		//		Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
			return retInt;
		}

		public long EventDateTime2Long(EventDateTime TEventDateTime)
		{
			string TAG = "EventDateTime2Long";
			string dbMsg = "[GoogleCalendarUtil]";
			long retLong  = 0;
			try {
				DateTime tDateTime = EventDateTime2DT(TEventDateTime);
				string retStr = String.Format("{0:yyyyMMddHHmm}", tDateTime);
				 retLong = long.Parse(retStr);
				dbMsg += ">>" + retLong;
				Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
			return retLong;
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
				if (TEventDateTime.Date != null) {
					dbMsg += "Date=" + TEventDateTime.Date;
					string todayItemStartDate = TEventDateTime.Date;
					string[] sStr = todayItemStartDate.Split('-');
					tDateTime = new DateTime(int.Parse(sStr[0]), int.Parse(sStr[1]), int.Parse(sStr[2]));
				}else if (TEventDateTime.DateTime != null) {
					dbMsg += "Date=" + TEventDateTime.DateTime;
					int sYear = TEventDateTime.DateTime.Value.Year;
					int sMonth = TEventDateTime.DateTime.Value.Month;
					int sDay = TEventDateTime.DateTime.Value.Day;
					int sHour = TEventDateTime.DateTime.Value.Hour;
					int sMinute = TEventDateTime.DateTime.Value.Minute;
					int sSecond = TEventDateTime.DateTime.Value.Second;
					tDateTime = new DateTime(sYear, sMonth, sDay, sHour, sMinute, sSecond);
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
/*
				Google.Apis.Calendar.v3.Data.Colors colors = Constant.MyCalendarService.Colors.Get().Fetch();

				// Print available calendarListEntry colors.
				foreach (KeyValuePair<String, ColorDefinition> color in colors.Calendar) {
					System.out.println("ColorId : " + color.Key);
					System.out.println("  Background: " + color.Value.Background);
					System.out.println("  Foreground: " + color.Value.Foreground);
				}
				// Print available event colors.
				foreach (KeyValuePair<String, ColorDefinition> color in colors.Event) {
					System.out.println("ColorId : " + color.Key);
					System.out.println("  Background: " + color.Value.Background);
					System.out.println("  Foreground: " + color.Value.Foreground);
				}
*/

				switch (colorId){
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
		//https://developers.google.com/calendar/v3/reference/colors/get#.net

		/// <summary>
		/// GoogleのIDで定義されたEventColor	を設定する	
		/// </summary>
		public void setGoogleEventColor()
		{
			string TAG = "setGoogleEventColor";
			string dbMsg = "[GCalender]";
			try {
				Constant.googleEventColor = new List<Constant.GoogleEventColor>();
				dbMsg += ":googleEventColor=" + Constant.googleEventColor.Count + "件";
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("1", "ラベンダー", Color.FromRgb(121, 134, 203)));       //,#FF7986CB
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("2", "セージ", Color.FromRgb(1, 182, 121)));                   //#FF01B679
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("3", "ブドウ", Color.FromRgb(142, 36, 170)));                  //#FF8E24AA
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("4", "フラミンゴ", Color.FromRgb(230, 124, 115)));       //#FFE67C73
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("5", "バナナ", Color.FromRgb(246, 192, 40)));               //#FFF6C028
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("6", "ミカン", Color.FromRgb(244, 81, 30)));                   //#FFF4511E
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("7", "ピーコック", Color.FromRgb(121, 134, 203)));			//
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("8", "ブルーベリー", Color.FromRgb(63, 81, 181)));            //#FF3F51B5
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("9", "グラファイト", Color.FromRgb(97, 97, 97)));         //#FF616161
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("10", "バジル", Color.FromRgb(11, 128, 67)));                //#FF0B8043
				Constant.googleEventColor.Add(new Constant.GoogleEventColor("11", "トマト", Color.FromRgb(213, 0, 0)));                        //#FFD50000				Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// Eventの更新
		/// 成功したらUrlを返す
		/// </summary>
		/// <returns>Url</returns>
		public string UpDateGEvents(Google.Apis.Calendar.v3.Data.Event eventItem)
		{
			string TAG = "UpDateGEvents";
			string dbMsg = "[GoogleCalendarUtil]";
			string retLink = null;
			try {
				// 予定を追加登録
				String eventId =eventItem.Id;
				Event body = eventItem;
				dbMsg = "[" + eventId;
				dbMsg = "}" + eventItem.Start.ToString();
				dbMsg = "," +eventItem.Summary;
				dbMsg = "\r\n" + eventItem.Description;
				CalendarService service = new CalendarService(new BaseClientService.Initializer() {
					HttpClientInitializer = Constant.MyCalendarCredential,
					ApplicationName = Constant.ApplicationName,
				});
				string calendarId = "primary";
				EventsResource.UpdateRequest request = service.Events.Update(body, calendarId, eventId);
				Event createdEvent = request.Execute();
				retLink = createdEvent.HtmlLink;
				dbMsg = ">>" + retLink;
				Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
			return retLink;
		}

		/// <summary>
		/// 予定を新規登録
		/// </summary>
		/// <returns></returns>
		public string InsertGEvents(Google.Apis.Calendar.v3.Data.Event eventItem)
		{
			string TAG = "InsertGEvents";
			string dbMsg = "[GoogleCalendarUtil]";
			string retLink = null;
			try {
				String eventId = eventItem.Id;
				Event body = eventItem;
				//dbMsg = "[" + eventId;
				dbMsg =  eventItem.Start.ToString();
				dbMsg = "," + eventItem.Summary;
				dbMsg = "\r\n" + eventItem.Description;
				CalendarService service = new CalendarService(new BaseClientService.Initializer() {
					HttpClientInitializer = Constant.MyCalendarCredential,
					ApplicationName = Constant.ApplicationName,
				});
				string calendarId = "primary";
				EventsResource.InsertRequest request = service.Events.Insert(body, calendarId);
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
 * https://developers.google.com/calendar/v3/reference/events
 追加		http://sloppy-content.blog.jp/archives/16488560.html
 イベントを作成する		https://developers.google.com/calendar/create-events#java	
 */
