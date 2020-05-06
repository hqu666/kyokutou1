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
			this.pass_tv.Location = new System.Drawing.Point(13, 13);
			this.pass_tv.Name = "pass_tv";
			this.pass_tv.Size = new System.Drawing.Size(239, 697);
			this.pass_tv.TabIndex = 0;
			// 
			// file_list_Lv
			// 
			this.file_list_Lv.HideSelection = false;
			this.file_list_Lv.Location = new System.Drawing.Point(259, 13);
			this.file_list_Lv.Name = "file_list_Lv";
			this.file_list_Lv.Size = new System.Drawing.Size(588, 697);
			this.file_list_Lv.TabIndex = 1;
			this.file_list_Lv.UseCompatibleStateImageBehavior = false;
			this.file_list_Lv.MouseUp += new System.Windows.Forms.MouseEventHandler(this.file_list_Lv_MouseUp);
			// 
			// GoogleDriveBrouser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(859, 722);
			this.Controls.Add(this.file_list_Lv);
			this.Controls.Add(this.pass_tv);
			this.Name = "GoogleDriveBrouser";
			this.Text = "GoogleDriveBrouser";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GoogleDriveBrouser_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView pass_tv;
		private System.Windows.Forms.ListView file_list_Lv;
	}
}