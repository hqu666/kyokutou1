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
			this.serected_clear_bt = new System.Windows.Forms.Button();
			this.file_count_lv = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// event_lv
			// 
			this.event_lv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.event_lv.HideSelection = false;
			this.event_lv.Location = new System.Drawing.Point(248, 13);
			this.event_lv.Margin = new System.Windows.Forms.Padding(2);
			this.event_lv.Name = "event_lv";
			this.event_lv.Size = new System.Drawing.Size(487, 323);
			this.event_lv.TabIndex = 2;
			this.event_lv.UseCompatibleStateImageBehavior = false;
			this.event_lv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.event_lv_MouseDoubleClick);
			// 
			// event_mc
			// 
			this.event_mc.Location = new System.Drawing.Point(8, 10);
			this.event_mc.Margin = new System.Windows.Forms.Padding(7);
			this.event_mc.Name = "event_mc";
			this.event_mc.TabIndex = 4;
			this.event_mc.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.event_mc_DateChanged);
			// 
			// master_folder_url_bt
			// 
			this.master_folder_url_bt.Location = new System.Drawing.Point(8, 186);
			this.master_folder_url_bt.Margin = new System.Windows.Forms.Padding(2);
			this.master_folder_url_bt.Name = "master_folder_url_bt";
			this.master_folder_url_bt.Size = new System.Drawing.Size(152, 24);
			this.master_folder_url_bt.TabIndex = 9;
			this.master_folder_url_bt.Text = "添付ファイル選択";
			this.master_folder_url_bt.UseVisualStyleBackColor = true;
			this.master_folder_url_bt.Click += new System.EventHandler(this.master_folder_url_bt_Click);
			// 
			// attach_file_lv
			// 
			this.attach_file_lv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.attach_file_lv.HideSelection = false;
			this.attach_file_lv.Location = new System.Drawing.Point(8, 223);
			this.attach_file_lv.Margin = new System.Windows.Forms.Padding(2);
			this.attach_file_lv.Name = "attach_file_lv";
			this.attach_file_lv.Size = new System.Drawing.Size(226, 103);
			this.attach_file_lv.TabIndex = 10;
			this.attach_file_lv.UseCompatibleStateImageBehavior = false;
			// 
			// serected_clear_bt
			// 
			this.serected_clear_bt.Location = new System.Drawing.Point(166, 186);
			this.serected_clear_bt.Name = "serected_clear_bt";
			this.serected_clear_bt.Size = new System.Drawing.Size(68, 23);
			this.serected_clear_bt.TabIndex = 11;
			this.serected_clear_bt.Text = "クリア";
			this.serected_clear_bt.UseVisualStyleBackColor = true;
			this.serected_clear_bt.Click += new System.EventHandler(this.serected_clear_bt_Click);
			// 
			// file_count_lv
			// 
			this.file_count_lv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.file_count_lv.AutoSize = true;
			this.file_count_lv.Location = new System.Drawing.Point(200, 328);
			this.file_count_lv.Name = "file_count_lv";
			this.file_count_lv.Size = new System.Drawing.Size(11, 12);
			this.file_count_lv.TabIndex = 12;
			this.file_count_lv.Text = "0";
			this.file_count_lv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(217, 328);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(17, 12);
			this.label1.TabIndex = 13;
			this.label1.Text = "件";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(746, 347);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.file_count_lv);
			this.Controls.Add(this.serected_clear_bt);
			this.Controls.Add(this.attach_file_lv);
			this.Controls.Add(this.master_folder_url_bt);
			this.Controls.Add(this.event_mc);
			this.Controls.Add(this.event_lv);
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Schedule";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListView event_lv;
		private System.Windows.Forms.MonthCalendar event_mc;
		private System.Windows.Forms.Button master_folder_url_bt;
		private System.Windows.Forms.ListView attach_file_lv;
		private System.Windows.Forms.Button serected_clear_bt;
		private System.Windows.Forms.Label file_count_lv;
		private System.Windows.Forms.Label label1;
	}
}

