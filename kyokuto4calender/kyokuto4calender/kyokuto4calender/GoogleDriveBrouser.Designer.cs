namespace kyokuto4calender {
	partial class GoogleDriveBrouser {
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
			this.components = new System.ComponentModel.Container();
			this.pass_tv = new System.Windows.Forms.TreeView();
			this.file_list_Lv = new System.Windows.Forms.ListView();
			this.openFDialog = new System.Windows.Forms.OpenFileDialog();
			this.pass_name_lb = new System.Windows.Forms.Label();
			this.file_open_bt = new System.Windows.Forms.Button();
			this.contextMStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.DelTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// pass_tv
			// 
			this.pass_tv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.pass_tv.Location = new System.Drawing.Point(13, 53);
			this.pass_tv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pass_tv.Name = "pass_tv";
			this.pass_tv.Size = new System.Drawing.Size(239, 294);
			this.pass_tv.TabIndex = 0;
			this.pass_tv.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.PassTvBeforeExpand);
			this.pass_tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.pass_tv_AfterSelect);
			// 
			// file_list_Lv
			// 
			this.file_list_Lv.AllowDrop = true;
			this.file_list_Lv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.file_list_Lv.ContextMenuStrip = this.contextMStrip;
			this.file_list_Lv.HideSelection = false;
			this.file_list_Lv.Location = new System.Drawing.Point(259, 53);
			this.file_list_Lv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.file_list_Lv.Name = "file_list_Lv";
			this.file_list_Lv.Size = new System.Drawing.Size(588, 294);
			this.file_list_Lv.TabIndex = 1;
			this.file_list_Lv.UseCompatibleStateImageBehavior = false;
			this.file_list_Lv.DragDrop += new System.Windows.Forms.DragEventHandler(this.file_list_Lv_DragDrop);
			this.file_list_Lv.DragEnter += new System.Windows.Forms.DragEventHandler(this.file_list_Lv_DragEnter);
			this.file_list_Lv.DoubleClick += new System.EventHandler(this.file_list_Lv_DoubleClick);
			// 
			// openFDialog
			// 
			this.openFDialog.FileName = "openFileDialog1";
			// 
			// pass_name_lb
			// 
			this.pass_name_lb.AutoSize = true;
			this.pass_name_lb.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.pass_name_lb.Location = new System.Drawing.Point(12, 9);
			this.pass_name_lb.Name = "pass_name_lb";
			this.pass_name_lb.Size = new System.Drawing.Size(213, 30);
			this.pass_name_lb.TabIndex = 2;
			this.pass_name_lb.Text = "閲覧中のフォルダ";
			this.pass_name_lb.Click += new System.EventHandler(this.pass_name_lb_Click);
			// 
			// file_open_bt
			// 
			this.file_open_bt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.file_open_bt.Location = new System.Drawing.Point(746, 25);
			this.file_open_bt.Name = "file_open_bt";
			this.file_open_bt.Size = new System.Drawing.Size(101, 23);
			this.file_open_bt.TabIndex = 3;
			this.file_open_bt.Text = "PCのファイル";
			this.file_open_bt.UseVisualStyleBackColor = true;
			this.file_open_bt.Click += new System.EventHandler(this.file_open_bt_Click);
			// 
			// contextMStrip
			// 
			this.contextMStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelTSMenuItem});
			this.contextMStrip.Name = "contextMStrip";
			this.contextMStrip.Size = new System.Drawing.Size(109, 28);
			// 
			// DelTSMenuItem
			// 
			this.DelTSMenuItem.Name = "DelTSMenuItem";
			this.DelTSMenuItem.Size = new System.Drawing.Size(210, 24);
			this.DelTSMenuItem.Text = "削除";
			this.DelTSMenuItem.Click += new System.EventHandler(this.DelTSMenuItem_Click);
			// 
			// GoogleDriveBrouser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(859, 361);
			this.Controls.Add(this.file_open_bt);
			this.Controls.Add(this.pass_name_lb);
			this.Controls.Add(this.file_list_Lv);
			this.Controls.Add(this.pass_tv);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "GoogleDriveBrouser";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "GoogleDriveBrouser";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GoogleDriveBrouser_FormClosing);
			this.contextMStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView pass_tv;
		private System.Windows.Forms.ListView file_list_Lv;
		private System.Windows.Forms.OpenFileDialog openFDialog;
		private System.Windows.Forms.Label pass_name_lb;
		private System.Windows.Forms.Button file_open_bt;
		private System.Windows.Forms.ContextMenuStrip contextMStrip;
		private System.Windows.Forms.ToolStripMenuItem DelTSMenuItem;
	}
}