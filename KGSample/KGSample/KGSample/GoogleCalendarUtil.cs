using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
