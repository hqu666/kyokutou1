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
			this.edit_bt = new System.Windows.Forms.Button();
			this.event_lv = new System.Windows.Forms.ListView();
			this.event_mc = new System.Windows.Forms.MonthCalendar();
			this.label1 = new System.Windows.Forms.Label();
			this.master_folder_url_lb = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.contlor_no_url_lb = new System.Windows.Forms.Label();
			this.master_folder_url_bt = new System.Windows.Forms.Button();
			this.attach_file_lv = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// edit_bt
			// 
			this.edit_bt.Location = new System.Drawing.Point(13, 495);
			this.edit_bt.Margin = new System.Windows.Forms.Padding(4);
			this.edit_bt.Name = "edit_bt";
			this.edit_bt.Size = new System.Drawing.Size(100, 29);
			this.edit_bt.TabIndex = 0;
			this.edit_bt.Text = "追加";
			this.edit_bt.UseVisualStyleBackColor = true;
			this.edit_bt.Click += new System.EventHandler(this.edit_bt_Click);
			// 
			// event_lv
			// 
			this.event_lv.HideSelection = false;
			this.event_lv.Location = new System.Drawing.Point(289, 13);
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 412);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 15);
			this.label1.TabIndex = 5;
			this.label1.Text = "現場マスタの添付ファイルパス";
			// 
			// master_folder_url_lb
			// 
			this.master_folder_url_lb.AutoSize = true;
			this.master_folder_url_lb.Location = new System.Drawing.Point(15, 378);
			this.master_folder_url_lb.Name = "master_folder_url_lb";
			this.master_folder_url_lb.Size = new System.Drawing.Size(43, 15);
			this.master_folder_url_lb.TabIndex = 6;
			this.master_folder_url_lb.Text = "label2";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 436);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(174, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "管理番号の添付ファイルパス";
			// 
			// contlor_no_url_lb
			// 
			this.contlor_no_url_lb.AutoSize = true;
			this.contlor_no_url_lb.Location = new System.Drawing.Point(15, 465);
			this.contlor_no_url_lb.Name = "contlor_no_url_lb";
			this.contlor_no_url_lb.Size = new System.Drawing.Size(43, 15);
			this.contlor_no_url_lb.TabIndex = 8;
			this.contlor_no_url_lb.Text = "label3";
			// 
			// master_folder_url_bt
			// 
			this.master_folder_url_bt.Location = new System.Drawing.Point(11, 233);
			this.master_folder_url_bt.Name = "master_folder_url_bt";
			this.master_folder_url_bt.Size = new System.Drawing.Size(255, 23);
			this.master_folder_url_bt.TabIndex = 9;
			this.master_folder_url_bt.Text = "添付ファイル選択";
			this.master_folder_url_bt.UseVisualStyleBackColor = true;
			this.master_folder_url_bt.Click += new System.EventHandler(this.master_folder_url_bt_Click);
			// 
			// attach_file_lv
			// 
			this.attach_file_lv.HideSelection = false;
			this.attach_file_lv.Location = new System.Drawing.Point(11, 273);
			this.attach_file_lv.Name = "attach_file_lv";
			this.attach_file_lv.Size = new System.Drawing.Size(255, 97);
			this.attach_file_lv.TabIndex = 10;
			this.attach_file_lv.UseCompatibleStateImageBehavior = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(949, 539);
			this.Controls.Add(this.attach_file_lv);
			this.Controls.Add(this.master_folder_url_bt);
			this.Controls.Add(this.contlor_no_url_lb);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.master_folder_url_lb);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.event_mc);
			this.Controls.Add(this.event_lv);
			this.Controls.Add(this.edit_bt);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Schedule";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button edit_bt;
		private System.Windows.Forms.ListView event_lv;
		private System.Windows.Forms.MonthCalendar event_mc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label master_folder_url_lb;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label contlor_no_url_lb;
		private System.Windows.Forms.Button master_folder_url_bt;
		private System.Windows.Forms.ListView attach_file_lv;
	}
}

