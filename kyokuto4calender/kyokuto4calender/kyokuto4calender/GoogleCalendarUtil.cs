using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace kyokuto4calender {
	class GoogleCalendarUtil {
		public Google.Apis.Calendar.v3.Data.Event  listItems = null;

		/// <summary>
		/// GoogleDriveの登録状況表示
		/// </summary>
		/// <returns></returns>
		public IList<Event> GEventsListUp()
		{
			string TAG = "GEventsListUp";
			string dbMsg = "[GoogleCalendarUtil]";
			IList<Google.Apis.Calendar.v3.Data.Event> retList = new List<Google.Apis.Calendar.v3.Data.Event>();
			try {
				// Create Google Calendar API service.
				var service = new CalendarService(new BaseClientService.Initializer() {
					HttpClientInitializer = Constant.MyCalendarCredential,
					ApplicationName = Constant.ApplicationName,
				});
				dbMsg += ",HttpClient=" + service.HttpClient.ToString();

				// Define parameters of request.
				EventsResource.ListRequest request = service.Events.List("primary");
				request.TimeMin = DateTime.Now;
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
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retList;
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
			string retLink=null;
			try {
				// 予定を追加登録
				String eventId = Constant.eventItem.Id;
				Event body = Constant.eventItem;
				dbMsg = "[" + eventId ;
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
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retLink;
		}

////////////////////////////////////////////////////////////////////////////////////////////////////////////
		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg);
		}
	}
}

/*
 追加		http://sloppy-content.blog.jp/archives/16488560.html
 イベントを作成する		https://developers.google.com/calendar/create-events#java	
 */
