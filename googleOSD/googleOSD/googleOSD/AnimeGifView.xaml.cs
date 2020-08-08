using System.Windows.Controls;
using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Windows.UI.Xaml.Media.Imaging;
using UserControl = System.Windows.Controls.UserControl;

namespace GoogleOSD {
    /// <summary>
	/// GIFアニメを再生できるView
    /// </summary>
    public partial class AnimeGifView : UserControl
    {
		private Bitmap _image = null;


		public AnimeGifView()
        {
            InitializeComponent();
        }


		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// フォームを表示するときの処理

			// 画像ファイルをロードする
			_image = new Bitmap("Resources/DarsBar.gif", true);

			// pictureBox1の背景画像としてセット
			pictureBox1.BackgroundImage = _image;
			//サイズを合わせる　※はみ出すと動かない
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
//C#でアニメーションGIF画像を動かす	https://cammy.co.jp/technical/2016/09/10/c%E3%81%A7%E3%82%A2%E3%83%8B%E3%83%A1%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3gif%E7%94%BB%E5%83%8F%E3%82%92%E5%8B%95%E3%81%8B%E3%81%99/
