﻿namespace kyokuto4calender {
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
			this.SuspendLayout();
			// 
			// edit_bt
			// 
			this.edit_bt.Location = new System.Drawing.Point(11, 233);
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
			this.event_lv.Size = new System.Drawing.Size(648, 483);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(949, 508);
			this.Controls.Add(this.event_mc);
			this.Controls.Add(this.event_lv);
			this.Controls.Add(this.edit_bt);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Home";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button edit_bt;
		private System.Windows.Forms.ListView event_lv;
		private System.Windows.Forms.MonthCalendar event_mc;
	}
}
