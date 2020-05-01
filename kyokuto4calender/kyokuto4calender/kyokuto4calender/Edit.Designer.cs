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
			this.titol_tb = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// back_bt
			// 
			this.back_bt.Location = new System.Drawing.Point(658, 13);
			this.back_bt.Name = "back_bt";
			this.back_bt.Size = new System.Drawing.Size(114, 23);
			this.back_bt.TabIndex = 0;
			this.back_bt.Text = "起動画面に戻る";
			this.back_bt.UseVisualStyleBackColor = true;
			this.back_bt.Click += new System.EventHandler(this.back_bt_Click);
			// 
			// titol_tb
			// 
			this.titol_tb.Location = new System.Drawing.Point(34, 16);
			this.titol_tb.Name = "titol_tb";
			this.titol_tb.Size = new System.Drawing.Size(618, 19);
			this.titol_tb.TabIndex = 1;
			this.titol_tb.Text = "タイトルを入力して下さい";
			this.titol_tb.TextChanged += new System.EventHandler(this.titolbt_TextChanged);
			// 
			// Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.titol_tb);
			this.Controls.Add(this.back_bt);
			this.Name = "Edit";
			this.Text = "Edit";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Edit_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button back_bt;
		private System.Windows.Forms.TextBox titol_tb;
	}
}