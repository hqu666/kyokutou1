using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Windows.UI.Xaml.Media.Imaging;

namespace GoogleOSD {
	/// <summary>
	/// ProgressDialog.xaml の相互作用ロジック
	/// </summary>
	public partial class ProgressDialog : Window {
		private Bitmap _image = null;

		public ProgressDialog(string ProgressMsg = null)
		{
			string TAG = "ProgressDialog";
			string dbMsg = "[ProgressDialog]";
			try {
				InitializeComponent();
	//			ContentRendered += (s, e) => { MessageBox.Show("ContentRendered", "TEST"); };
				//dbMsg += " ,ProgressMsg= " + ProgressMsg;
				//Progress_msg_tb.Content = ProgressMsg;
				////		dbMsg += " ,[" + retFileID + "]" + targetFileName;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public void SetMsg(string ProgressMsg)
		{
			string TAG = "SetMsg";
			string dbMsg = "[ProgressDialog]";
			try {
				dbMsg += " ,ProgressMsg= " + ProgressMsg;
				Progress_msg_tb.Content = ProgressMsg;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// フォームを表示するときの処理

			// 画像ファイルをロードする
			_image = new Bitmap("Resources/DarsBar.gif", true);

			// pictureBox1の背景画像としてセット
			pictureBox1.BackgroundImage = _image;
			//サイズを合わせる
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			// 描画(Paint)イベントハンドラを追加
			pictureBox1.Paint += pictureBox1_Paint;
			// アニメーション開始
			ImageAnimator.Animate(_image, new EventHandler(Image_FrameChanged));

		}

		private void Image_FrameChanged(object o, EventArgs e)
		{
			// Paintイベントハンドラを呼び出す
			pictureBox1.Invalidate();
		}

		void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			// イベントハンドラ：ピクチャボックスの描画
			ImageAnimator.UpdateFrames(_image);
		}

		////////////////////////////////////////////////////
		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}
	}
}


//XMALでFormツールを使う	 https://gist.github.com/arosh/3213108
