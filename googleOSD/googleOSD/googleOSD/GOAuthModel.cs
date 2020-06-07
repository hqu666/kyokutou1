using System;
using System.Collections.Generic;

namespace GoogleOSD {
	/// <summary>
	/// GoogleのOAuthから取得したJSON
	/// </summary>
	public class GOAuthModel {
		/// <summary>
		/// "912719822179-n9hvcs7tr9pqgn8mns7pdl5njo54gpe1.apps.googleusercontent.com",
		/// </summary>
		public String client_id;

		/// <summary>
		/// "aGVZ_mfTKJq8WFf5spDOOiHi",		/// </summary>
		public String client_secret;

		/// <summary>
		///  "kyokuto4",
		/// </summary>
		public String project_id;

		/// <summary>
		///  "https://accounts.google.com/o/oauth2/auth",
		/// </summary>
		public String auth_uri;

		/// <summary>
		/// "https://oauth2.googleapis.com/token",
		/// </summary>
		public String token_uri;

		/// <summary>
		///  "https://www.googleapis.com/oauth2/v1/certs",
		/// </summary>
		public String auth_provider_x509_cert_url;


	//	private List< Menbers> ivalue1;
	//	private IDictionary<string, Menbers> ivalue1;
		private IDictionary<string, object> ivalue1;
		//	public List< Menbers> installed {
		//	public IDictionary<string, Menbers> installed {
		public IDictionary<string, object> installed {
			get {
			//	return null;
				return ivalue1;
				/*
				 IDictionary<string, Menbers>の場合
				  Error converting value "912719822179-n9hvcs7tr9pqgn8mns7pdl5njo54gpe1.apps.googleusercontent.com" to type 'GoogleOSD.Menbers'. Path 'installed.client_id', line 3, position 91.			
				  * 
				 List< Menbers>の場合
				 Cannot deserialize the current JSON object (e.g. {"name":"value"}) into type 'System.Collections.Generic.List`1[GoogleOSD.Menbers]' because the type requires a JSON array (e.g. [1,2,3]) to deserialize correctly.
To fix this error either change the JSON to a JSON array (e.g. [1,2,3]) or change the deserialized type so that it is a normal .NET type (e.g. not a primitive type like integer, not a collection type like an array or List<T>) that can be deserialized from a JSON object. JsonObjectAttribute can also be added to the type to force it to deserialize from a JSON object.
Path 'installed.client_id', line 3, position 16.
				 */
			}
			set {
				ivalue1 = value;
				foreach (var item in value) {
						switch (item.Key){
							case "client_id":
								client_id = item.Value.ToString();
								break;
							case "client_secret":
								client_secret = item.Value.ToString();
								break;
							case "project_id":
								project_id = item.Value.ToString();
								break;
							case "auth_uri":
								auth_uri = item.Value.ToString();
								break;
							case "token_uri":
								token_uri = item.Value.ToString();
								break;
							case "auth_provider_x509_cert_url":
								auth_provider_x509_cert_url = item.Value.ToString();
								break;
					}
				}
				}
		}
	}
	//	public Dictionary<string, Menbers> installed { get; set; }	
	
	public class Menbers {
		//	Dictionary<string, string> installed = new Dictionary<string, string>();
		public String clientId="";
		/// <summary>
		/// "912719822179-n9hvcs7tr9pqgn8mns7pdl5njo54gpe1.apps.googleusercontent.com",
		/// </summary>
		public String client_id {
			get {
				return @clientId;
				//Error converting value .... to type 'GoogleOSD.Menbers'. Path 'installed.client_id', line 3, position 91.
			}
			set {
				clientId = @value.ToString();
			}
		}

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
			//public GOAuthModel(String client_id, String client_secret, String project_id,
			//								String auth_uri, String token_uri, String auth_provider_x509_cert_url)
			//{
			//	this.client_id = client_id;
			//	this.client_secret = client_secret;
			//	this.project_id = project_id;
			//	this.auth_uri = auth_uri;
			//	this.token_uri = token_uri;
			//	this.auth_provider_x509_cert_url = auth_provider_x509_cert_url;
			//}

		}
	}


