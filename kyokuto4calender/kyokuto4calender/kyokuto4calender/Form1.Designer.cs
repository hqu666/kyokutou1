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
			this.receiveData_lv = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// edit_bt
			// 
			this.edit_bt.Location = new System.Drawing.Point(713, 12);
			this.edit_bt.Name = "edit_bt";
			this.edit_bt.Size = new System.Drawing.Size(75, 23);
			this.edit_bt.TabIndex = 0;
			this.edit_bt.Text = "編集画面へ";
			this.edit_bt.UseVisualStyleBackColor = true;
			this.edit_bt.Click += new System.EventHandler(this.edit_bt_Click);
			// 
			// receiveData_lv
			// 
			this.receiveData_lv.AutoSize = true;
			this.receiveData_lv.Location = new System.Drawing.Point(59, 76);
			this.receiveData_lv.Name = "receiveData_lv";
			this.receiveData_lv.Size = new System.Drawing.Size(101, 12);
			this.receiveData_lv.TabIndex = 1;
			this.receiveData_lv.Text = "遷移先からの戻り値";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.receiveData_lv);
			this.Controls.Add(this.edit_bt);
			this.Name = "Form1";
			this.Text = "Home";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button edit_bt;
		private System.Windows.Forms.Label receiveData_lv;
	}
}

