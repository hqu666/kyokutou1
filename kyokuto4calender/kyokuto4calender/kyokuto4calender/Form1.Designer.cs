namespace kyokuto4calender {
	partial class Form1 {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.event_lv = new System.Windows.Forms.ListView();
			this.event_mc = new System.Windows.Forms.MonthCalendar();
			this.master_folder_url_bt = new System.Windows.Forms.Button();
			this.attach_file_lv = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// event_lv
			// 
			this.event_lv.HideSelection = false;
			this.event_lv.Location = new System.Drawing.Point(330, 16);
			this.event_lv.Name = "event_lv";
			this.event_lv.Size = new System.Drawing.Size(648, 511);
			this.event_lv.TabIndex = 2;
			this.event_lv.UseCompatibleStateImageBehavior = false;
			this.event_lv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.event_lv_MouseDoubleClick);
			// 
			// event_mc
			// 
			this.event_mc.Location = new System.Drawing.Point(11, 13);
			this.event_mc.Name = "event_mc";
			this.event_mc.TabIndex = 4;
			this.event_mc.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.event_mc_DateChanged);
			// 
			// master_folder_url_bt
			// 
			this.master_folder_url_bt.Location = new System.Drawing.Point(11, 233);
			this.master_folder_url_bt.Name = "master_folder_url_bt";
			this.master_folder_url_bt.Size = new System.Drawing.Size(300, 30);
			this.master_folder_url_bt.TabIndex = 9;
			this.master_folder_url_bt.Text = "添付ファイル選択";
			this.master_folder_url_bt.UseVisualStyleBackColor = true;
			this.master_folder_url_bt.Click += new System.EventHandler(this.master_folder_url_bt_Click);
			// 
			// attach_file_lv
			// 
			this.attach_file_lv.HideSelection = false;
			this.attach_file_lv.Location = new System.Drawing.Point(11, 279);
			this.attach_file_lv.Name = "attach_file_lv";
			this.attach_file_lv.Size = new System.Drawing.Size(300, 245);
			this.attach_file_lv.TabIndex = 10;
			this.attach_file_lv.UseCompatibleStateImageBehavior = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(994, 539);
			this.Controls.Add(this.attach_file_lv);
			this.Controls.Add(this.master_folder_url_bt);
			this.Controls.Add(this.event_mc);
			this.Controls.Add(this.event_lv);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Schedule";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListView event_lv;
		private System.Windows.Forms.MonthCalendar event_mc;
		private System.Windows.Forms.Button master_folder_url_bt;
		private System.Windows.Forms.ListView attach_file_lv;
	}
}

