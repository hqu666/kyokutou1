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
			this.pass_tv = new System.Windows.Forms.TreeView();
			this.file_list_Lv = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// pass_tv
			// 
			this.pass_tv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.pass_tv.Location = new System.Drawing.Point(10, 10);
			this.pass_tv.Margin = new System.Windows.Forms.Padding(2);
			this.pass_tv.Name = "pass_tv";
			this.pass_tv.Size = new System.Drawing.Size(180, 269);
			this.pass_tv.TabIndex = 0;
			this.pass_tv.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.PassTvBeforeExpand);
			this.pass_tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.PassTvNodeMouseClick);
			// 
			// file_list_Lv
			// 
			this.file_list_Lv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.file_list_Lv.HideSelection = false;
			this.file_list_Lv.Location = new System.Drawing.Point(194, 10);
			this.file_list_Lv.Margin = new System.Windows.Forms.Padding(2);
			this.file_list_Lv.Name = "file_list_Lv";
			this.file_list_Lv.Size = new System.Drawing.Size(442, 269);
			this.file_list_Lv.TabIndex = 1;
			this.file_list_Lv.UseCompatibleStateImageBehavior = false;
			this.file_list_Lv.MouseUp += new System.Windows.Forms.MouseEventHandler(this.file_list_Lv_MouseUp);
			// 
			// GoogleDriveBrouser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 289);
			this.Controls.Add(this.file_list_Lv);
			this.Controls.Add(this.pass_tv);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "GoogleDriveBrouser";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "GoogleDriveBrouser";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GoogleDriveBrouser_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView pass_tv;
		private System.Windows.Forms.ListView file_list_Lv;
	}
}