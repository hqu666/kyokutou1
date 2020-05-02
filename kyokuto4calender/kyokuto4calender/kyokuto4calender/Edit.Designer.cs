namespace kyokuto4calender {
	partial class Edit {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.back_bt = new System.Windows.Forms.Button();
			this.summary_tb = new System.Windows.Forms.TextBox();
			this.start_dtp = new System.Windows.Forms.DateTimePicker();
			this.end_dtp = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.description_tb = new System.Windows.Forms.TextBox();
			this.ColorId_tb = new System.Windows.Forms.TextBox();
			this.location_tb = new System.Windows.Forms.TextBox();
			this.status_tb = new System.Windows.Forms.TextBox();
			this.recurringEventId_lb = new System.Windows.Forms.Label();
			this.Id_lb = new System.Windows.Forms.Label();
			this.attendees_lv = new System.Windows.Forms.ListView();
			this.conferenceData_vb = new System.Windows.Forms.TextBox();
			this.icaluid_lb = new System.Windows.Forms.Label();
			this.organizer_dtp = new System.Windows.Forms.DateTimePicker();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.ColorId_cb = new System.Windows.Forms.ComboBox();
			this.owner_adress_lb = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// back_bt
			// 
			this.back_bt.Location = new System.Drawing.Point(877, 16);
			this.back_bt.Margin = new System.Windows.Forms.Padding(4);
			this.back_bt.Name = "back_bt";
			this.back_bt.Size = new System.Drawing.Size(152, 29);
			this.back_bt.TabIndex = 0;
			this.back_bt.Text = "起動画面に戻る";
			this.back_bt.UseVisualStyleBackColor = true;
			this.back_bt.Click += new System.EventHandler(this.back_bt_Click);
			// 
			// summary_tb
			// 
			this.summary_tb.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.summary_tb.Location = new System.Drawing.Point(13, 14);
			this.summary_tb.Margin = new System.Windows.Forms.Padding(4);
			this.summary_tb.Name = "summary_tb";
			this.summary_tb.Size = new System.Drawing.Size(855, 37);
			this.summary_tb.TabIndex = 1;
			this.summary_tb.Text = "タイトルを入力して下さい";
			// 
			// start_dtp
			// 
			this.start_dtp.Location = new System.Drawing.Point(14, 73);
			this.start_dtp.Name = "start_dtp";
			this.start_dtp.Size = new System.Drawing.Size(200, 22);
			this.start_dtp.TabIndex = 2;
			// 
			// end_dtp
			// 
			this.end_dtp.Location = new System.Drawing.Point(242, 73);
			this.end_dtp.Name = "end_dtp";
			this.end_dtp.Size = new System.Drawing.Size(200, 22);
			this.end_dtp.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(217, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "～";
			// 
			// description_tb
			// 
			this.description_tb.Location = new System.Drawing.Point(12, 296);
			this.description_tb.Multiline = true;
			this.description_tb.Name = "description_tb";
			this.description_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.description_tb.Size = new System.Drawing.Size(853, 318);
			this.description_tb.TabIndex = 5;
			// 
			// ColorId_tb
			// 
			this.ColorId_tb.Location = new System.Drawing.Point(874, 378);
			this.ColorId_tb.Name = "ColorId_tb";
			this.ColorId_tb.Size = new System.Drawing.Size(100, 22);
			this.ColorId_tb.TabIndex = 6;
			// 
			// location_tb
			// 
			this.location_tb.Location = new System.Drawing.Point(13, 118);
			this.location_tb.Name = "location_tb";
			this.location_tb.Size = new System.Drawing.Size(855, 22);
			this.location_tb.TabIndex = 7;
			// 
			// status_tb
			// 
			this.status_tb.Location = new System.Drawing.Point(874, 419);
			this.status_tb.Name = "status_tb";
			this.status_tb.Size = new System.Drawing.Size(100, 22);
			this.status_tb.TabIndex = 8;
			// 
			// recurringEventId_lb
			// 
			this.recurringEventId_lb.AutoSize = true;
			this.recurringEventId_lb.Location = new System.Drawing.Point(16, 144);
			this.recurringEventId_lb.Name = "recurringEventId_lb";
			this.recurringEventId_lb.Size = new System.Drawing.Size(43, 15);
			this.recurringEventId_lb.TabIndex = 9;
			this.recurringEventId_lb.Text = "label2";
			// 
			// Id_lb
			// 
			this.Id_lb.AutoSize = true;
			this.Id_lb.Location = new System.Drawing.Point(17, 55);
			this.Id_lb.Name = "Id_lb";
			this.Id_lb.Size = new System.Drawing.Size(43, 15);
			this.Id_lb.TabIndex = 10;
			this.Id_lb.Text = "label2";
			// 
			// attendees_lv
			// 
			this.attendees_lv.HideSelection = false;
			this.attendees_lv.Location = new System.Drawing.Point(877, 60);
			this.attendees_lv.Name = "attendees_lv";
			this.attendees_lv.Size = new System.Drawing.Size(178, 123);
			this.attendees_lv.TabIndex = 11;
			this.attendees_lv.UseCompatibleStateImageBehavior = false;
			// 
			// conferenceData_vb
			// 
			this.conferenceData_vb.Location = new System.Drawing.Point(874, 461);
			this.conferenceData_vb.Name = "conferenceData_vb";
			this.conferenceData_vb.Size = new System.Drawing.Size(100, 22);
			this.conferenceData_vb.TabIndex = 12;
			// 
			// icaluid_lb
			// 
			this.icaluid_lb.AutoSize = true;
			this.icaluid_lb.Location = new System.Drawing.Point(16, 98);
			this.icaluid_lb.Name = "icaluid_lb";
			this.icaluid_lb.Size = new System.Drawing.Size(43, 15);
			this.icaluid_lb.TabIndex = 13;
			this.icaluid_lb.Text = "label2";
			// 
			// organizer_dtp
			// 
			this.organizer_dtp.Location = new System.Drawing.Point(668, 75);
			this.organizer_dtp.Name = "organizer_dtp";
			this.organizer_dtp.Size = new System.Drawing.Size(200, 22);
			this.organizer_dtp.TabIndex = 14;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "通知",
            "メール"});
			this.comboBox1.Location = new System.Drawing.Point(13, 163);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 23);
			this.comboBox1.TabIndex = 15;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(446, 75);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(59, 19);
			this.checkBox1.TabIndex = 16;
			this.checkBox1.Text = "終日";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "繰り返さない",
            "毎週",
            "毎月",
            "毎年",
            "毎週平日（月～金）",
            "カスタム..."});
			this.comboBox2.Location = new System.Drawing.Point(512, 74);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 23);
			this.comboBox2.TabIndex = 17;
			// 
			// ColorId_cb
			// 
			this.ColorId_cb.FormattingEnabled = true;
			this.ColorId_cb.Items.AddRange(new object[] {
            "トマト",
            "フラミンゴ",
            "ミカン",
            "バナナ",
            "セージ",
            "バジル",
            "ピーコック",
            "ブルーベリー",
            "ラベンダー",
            "ブドウ",
            "グラファイト"});
			this.ColorId_cb.Location = new System.Drawing.Point(284, 215);
			this.ColorId_cb.Name = "ColorId_cb";
			this.ColorId_cb.Size = new System.Drawing.Size(121, 23);
			this.ColorId_cb.TabIndex = 18;
			// 
			// owner_adress_lb
			// 
			this.owner_adress_lb.AutoSize = true;
			this.owner_adress_lb.Location = new System.Drawing.Point(19, 218);
			this.owner_adress_lb.Name = "owner_adress_lb";
			this.owner_adress_lb.Size = new System.Drawing.Size(178, 15);
			this.owner_adress_lb.TabIndex = 19;
			this.owner_adress_lb.Text = "abcbdffghaiklnm@gmail.com";
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "予定あり",
            "予定なし"});
			this.comboBox3.Location = new System.Drawing.Point(12, 255);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(121, 23);
			this.comboBox3.TabIndex = 20;
			// 
			// comboBox4
			// 
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Items.AddRange(new object[] {
            "デフォルトの公開設定",
            "公開",
            "非公開"});
			this.comboBox4.Location = new System.Drawing.Point(154, 255);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(121, 23);
			this.comboBox4.TabIndex = 21;
			// 
			// Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1067, 648);
			this.Controls.Add(this.comboBox4);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.owner_adress_lb);
			this.Controls.Add(this.ColorId_cb);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.organizer_dtp);
			this.Controls.Add(this.icaluid_lb);
			this.Controls.Add(this.conferenceData_vb);
			this.Controls.Add(this.attendees_lv);
			this.Controls.Add(this.Id_lb);
			this.Controls.Add(this.recurringEventId_lb);
			this.Controls.Add(this.status_tb);
			this.Controls.Add(this.location_tb);
			this.Controls.Add(this.ColorId_tb);
			this.Controls.Add(this.description_tb);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.end_dtp);
			this.Controls.Add(this.start_dtp);
			this.Controls.Add(this.summary_tb);
			this.Controls.Add(this.back_bt);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Edit";
			this.Text = "Edit";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Edit_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button back_bt;
		private System.Windows.Forms.TextBox summary_tb;
		private System.Windows.Forms.DateTimePicker start_dtp;
		private System.Windows.Forms.DateTimePicker end_dtp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox description_tb;
		private System.Windows.Forms.TextBox ColorId_tb;
		private System.Windows.Forms.TextBox location_tb;
		private System.Windows.Forms.TextBox status_tb;
		private System.Windows.Forms.Label recurringEventId_lb;
		private System.Windows.Forms.Label Id_lb;
		private System.Windows.Forms.ListView attendees_lv;
		private System.Windows.Forms.TextBox conferenceData_vb;
		private System.Windows.Forms.Label icaluid_lb;
		private System.Windows.Forms.DateTimePicker organizer_dtp;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox ColorId_cb;
		private System.Windows.Forms.Label owner_adress_lb;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.ComboBox comboBox4;
	}
}