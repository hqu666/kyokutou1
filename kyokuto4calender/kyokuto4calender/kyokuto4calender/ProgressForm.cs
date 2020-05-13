using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace kyokuto4calender {

	/// <summary>
	/// ProgressForm の概要の説明です。
	/// </summary>
	public class ProgressForm : System.Windows.Forms.Form {
		internal System.Windows.Forms.TextBox Label1;
		internal System.Windows.Forms.ProgressBar ProgressBar1;
		internal System.Windows.Forms.Button Button1;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProgressForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.Label1 = new System.Windows.Forms.TextBox();
			this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
			this.Button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();

			int ClientWidth= 400;
			int ClientPanding = 8;

			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(ClientPanding, ClientPanding);
			this.Label1.Name = "Label1";
			this.Label1.Multiline = true;
			this.Label1.Size = new System.Drawing.Size(ClientWidth - (ClientPanding * 2), 80);
			this.Label1.ScrollBars = ScrollBars.Vertical;
			this.Label1.ReadOnly = true;
			this.Label1.TabIndex = 0;
			// 
			// ProgressBar1
			// 
			this.ProgressBar1.Location = new System.Drawing.Point(ClientPanding, this.Label1.Bottom+ ClientPanding);
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(ClientWidth-(8*2), 23);			//216
			this.ProgressBar1.TabIndex = 1;
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(ClientWidth-88, this.ProgressBar1.Bottom+ ClientPanding);			//232
			this.Button1.Name = "Button1";
			this.Button1.TabIndex = 2;
			this.Button1.Text = "キャンセル";
			// 
			// ProgressForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(ClientWidth, this.Button1.Bottom+ ClientPanding);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.ProgressBar1);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgressForm";
			this.ShowInTaskbar = false;
			this.Text = "ProgressForm";
			this.ResumeLayout(false);

		}
		#endregion
	}

	/// <summary>
	/// 進行状況ダイアログを表示するためのクラス
	/// </summary>
	public class ProgressDialog : IDisposable {
		//キャンセルボタンがクリックされたか
		private volatile bool _canceled = false;
		//ダイアログフォーム
		private volatile ProgressForm form;
		//フォームが表示されるまで待機するための待機ハンドル
		private System.Threading.ManualResetEvent startEvent;
		//フォームが一度表示されたか
		private bool showed = false;
		//フォームをコードで閉じているか
		private volatile bool closing = false;
		//オーナーフォーム
		private Form ownerForm;

		//別処理をするためのスレッド
		private System.Threading.Thread thread;

		//フォームのタイトル
		private volatile string _title = "進行状況";
		//ProgressBarの最小、最大、現在の値
		private volatile int _minimum = 0;
		private volatile int _maximum = 100;
		private volatile int _value = 0;
		//表示するメッセージ
		private volatile string _message = "";

		/// <summary>
		/// ダイアログのタイトルバーに表示する文字列
		/// </summary>
		public string Title {
			set {
				_title = value;
				if (form != null)
					form.Invoke(new MethodInvoker(SetTitle));
			}
			get {
				return _title;
			}
		}

		/// <summary>
		/// プログレスバーの最小値
		/// </summary>
		public int Minimum {
			set {
				_minimum = value;
				if (form != null)
					form.Invoke(new MethodInvoker(SetProgressMinimum));
			}
			get {
				return _minimum;
			}
		}

		/// <summary>
		/// プログレスバーの最大値
		/// </summary>
		public int Maximum {
			set {
				_maximum = value;
				if (form != null)
					form.Invoke(new MethodInvoker(SetProgressMaximun));
			}
			get {
				return _maximum;
			}
		}

		/// <summary>
		/// プログレスバーの値
		/// </summary>
		public int Value {
			set {
				_value = value;
				if (form != null)
					form.Invoke(new MethodInvoker(SetProgressValue));
			}
			get {
				return _value;
			}
		}

		/// <summary>
		/// ダイアログに表示するメッセージ
		/// </summary>
		public string Message {
			set {
				_message = value;
				if (form != null)
					form.Invoke(new MethodInvoker(SetMessage));
			}
			get {
				return _message;
			}
		}

		/// <summary>
		/// キャンセルされたか
		/// </summary>
		public bool Canceled {
			get { return _canceled; }
		}

		/// <summary>
		/// ダイアログを表示する
		/// </summary>
		/// <param name="owner">
		/// ownerの中央にダイアログが表示される
		/// </param>
		/// <remarks>
		/// このメソッドは一回しか呼び出せません。
		/// </remarks>
		public void Show(Form owner)
		{
			if (showed)
				throw new Exception("ダイアログは一度表示されています。");
			showed = true;

			_canceled = false;
			startEvent = new System.Threading.ManualResetEvent(false);
			ownerForm = owner;

			//スレッドを作成
			thread = new System.Threading.Thread(
				new System.Threading.ThreadStart(Run));
			thread.IsBackground = true;
			this.thread.ApartmentState =
				System.Threading.ApartmentState.STA;
			thread.Start();

			//フォームが表示されるまで待機する
			startEvent.WaitOne();
		}
		public void Show()
		{
			Show(null);
		}

		//別スレッドで処理するメソッド
		private void Run()
		{
			//フォームの設定
			form = new ProgressForm();
			form.Text = _title;
			form.Button1.Click += new EventHandler(Button1_Click);
			form.Closing += new CancelEventHandler(form_Closing);
			form.Activated += new EventHandler(form_Activated);
			form.ProgressBar1.Minimum = _minimum;
			form.ProgressBar1.Maximum = _maximum;
			form.ProgressBar1.Value = _value;
			//フォームの表示位置をオーナーの中央へ
			if (ownerForm != null) {
				form.StartPosition = FormStartPosition.Manual;
				form.Left =
					ownerForm.Left + (ownerForm.Width - form.Width) / 2;
				form.Top =
					ownerForm.Top + (ownerForm.Height - form.Height) / 2;
			}
			//フォームの表示
			form.ShowDialog();

			form.Dispose();
		}

		/// <summary>
		/// ダイアログを閉じる
		/// </summary>
		public void Close()
		{
			closing = true;
			form.Invoke(new MethodInvoker(form.Close));
		}

		public void Dispose()
		{
			form.Invoke(new MethodInvoker(form.Dispose));
		}

		private void SetProgressValue()
		{
			if (form != null && !form.IsDisposed)
				form.ProgressBar1.Value = _value;
		}

		private void SetMessage()
		{
			if (form != null && !form.IsDisposed)
				form.Label1.Text = _message;
			//カレット位置を末尾に移動
			form.Label1.SelectionStart = form.Label1.Text.Length;
			//テキストボックスにフォーカスを移動
			form.Label1.Focus();
			//カレット位置までスクロール
			form.Label1.ScrollToCaret();
		}

		private void SetTitle()
		{
			if (form != null && !form.IsDisposed)
				form.Text = _title;
		}

		private void SetProgressMaximun()
		{
			if (form != null && !form.IsDisposed)
				form.ProgressBar1.Maximum = _maximum;
		}

		private void SetProgressMinimum()
		{
			if (form != null && !form.IsDisposed)
				form.ProgressBar1.Minimum = _minimum;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			_canceled = true;
		}

		private void form_Closing(object sender, CancelEventArgs e)
		{
			if (!closing) {
				e.Cancel = true;
				_canceled = true;
			}
		}

		private void form_Activated(object sender, EventArgs e)
		{
			form.Activated -= new EventHandler(form_Activated);
			startEvent.Set();
		}
	}

}

/*
 https://dobon.net/vb/dotnet/programing/progressdialogbw.html
 
 */
