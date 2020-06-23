using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleOSD {
	class OtherData {
		/// <summary>
		/// その他のファイルのPC保存位置
		/// </summary>
		public string OFilePCPass { set; get; }

		/// <summary>
		///その他のファイルのGoogleDriveID
		/// </summary>
		public string OFileGoogleFileID { set; get; }
		
		/// <summary>
		/// 添付などの選択
		/// </summary>
		public bool IsSerect { set; get; }
	}
}
