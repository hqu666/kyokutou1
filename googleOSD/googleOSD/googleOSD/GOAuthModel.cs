using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace googleOSD {
	public class GOAuthModel {

		/// <summary>
		/// "912719822179-n9hvcs7tr9pqgn8mns7pdl5njo54gpe1.apps.googleusercontent.com",
		/// </summary>
		public String client_id { get; set; }
	
		/// <summary>
		/// "aGVZ_mfTKJq8WFf5spDOOiHi",		/// </summary>
		public String client_secret { get; set; }

		/// <summary>
		///  "kyokuto4",
		/// </summary>
		public String project_id { get; set; }

		/// <summary>
		///  "https://accounts.google.com/o/oauth2/auth",
		/// </summary>
		public String auth_uri { get; set; }

		/// <summary>
		/// "https://oauth2.googleapis.com/token",
		/// </summary>
		public String token_uri { get; set; }

		/// <summary>
		///  "https://www.googleapis.com/oauth2/v1/certs",
		/// </summary>
		public String auth_provider_x509_cert_url { get; set; }

		/// <summary>
		/// コンストクタ、初期データを読み込みます。
		/// </summary>
		public GOAuthModel(String client_id, String client_secret, String project_id,		
										String auth_uri, String token_uri, String auth_provider_x509_cert_url)
		{
			this.client_id = client_id;
			this.client_secret = client_secret;
			this.project_id = project_id;
			this.auth_uri = auth_uri;
			this.token_uri = token_uri;
			this.auth_provider_x509_cert_url = auth_provider_x509_cert_url;
		}


	}
}
