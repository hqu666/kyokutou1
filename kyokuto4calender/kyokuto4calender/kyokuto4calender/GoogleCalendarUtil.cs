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
		public IList<Google.Apis.Calendar.v3.Data.Event> GEventsListUp()
		{
			string TAG = "GEventsListUp";
			string dbMsg = "[GoogleCalendarUtil]";
			IList<Google.Apis.Calendar.v3.Data.Event> retList = new List<Google.Apis.Calendar.v3.Data.Event>();
			try {
				// Create Google Calendar API service.
				var service = new CalendarService(new BaseClientService.Initializer() {
					HttpClientInitializer = Constant.MyCredential,
					ApplicationName = Constant.ApplicationName,
				});
				// Define parameters of request.
				EventsResource.ListRequest request = service.Events.List("primary");
				request.TimeMin = DateTime.Now;
				request.ShowDeleted = false;
				request.SingleEvents = true;
				request.MaxResults = 10;
				request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
				Events events = request.Execute();				//取得実行
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
	//					Console.WriteLine("{0} ({1})", Summary, startDT);
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
