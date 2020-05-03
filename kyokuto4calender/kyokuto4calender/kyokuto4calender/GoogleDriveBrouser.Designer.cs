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
			this.file_list_LV = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// pass_tv
			// 
			this.pass_tv.Location = new System.Drawing.Point(13, 13);
			this.pass_tv.Name = "pass_tv";
			this.pass_tv.Size = new System.Drawing.Size(239, 697);
			this.pass_tv.TabIndex = 0;
			// 
			// file_list_LV
			// 
			this.file_list_LV.HideSelection = false;
			this.file_list_LV.Location = new System.Drawing.Point(259, 13);
			this.file_list_LV.Name = "file_list_LV";
			this.file_list_LV.Size = new System.Drawing.Size(588, 697);
			this.file_list_LV.TabIndex = 1;
			this.file_list_LV.UseCompatibleStateImageBehavior = false;
			this.file_list_LV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.file_list_LV_MouseDoubleClick);
			// 
			// GoogleDriveBrouser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(859, 722);
			this.Controls.Add(this.file_list_LV);
			this.Controls.Add(this.pass_tv);
			this.Name = "GoogleDriveBrouser";
			this.Text = "GoogleDriveBrouser";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GoogleDriveBrouser_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView pass_tv;
		private System.Windows.Forms.ListView file_list_LV;
	}
}