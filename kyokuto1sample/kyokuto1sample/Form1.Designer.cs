namespace kyokuto1sample
{
	partial class Form1
	{
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
			if (disposing && ( components != null )) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.send_bt = new System.Windows.Forms.Button();
			this.info_lb = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.pass_lv = new System.Windows.Forms.Label();
			this.update_bt = new System.Windows.Forms.Button();
			this.google_drive_tree = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// send_bt
			// 
			this.send_bt.Location = new System.Drawing.Point(561, 13);
			this.send_bt.Margin = new System.Windows.Forms.Padding(4);
			this.send_bt.Name = "send_bt";
			this.send_bt.Size = new System.Drawing.Size(100, 29);
			this.send_bt.TabIndex = 1;
			this.send_bt.Text = "送信";
			this.send_bt.UseVisualStyleBackColor = true;
			this.send_bt.Click += new System.EventHandler(this.Send_bt_Click);
			// 
			// info_lb
			// 
			this.info_lb.AutoSize = true;
			this.info_lb.Location = new System.Drawing.Point(168, 20);
			this.info_lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.info_lb.Name = "info_lb";
			this.info_lb.Size = new System.Drawing.Size(216, 15);
			this.info_lb.TabIndex = 5;
			this.info_lb.Text = "まずは接続ボタンをクリックして下さい";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(80, 20);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label1.Size = new System.Drawing.Size(80, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "接続先　：　";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// pass_lv
			// 
			this.pass_lv.AutoSize = true;
			this.pass_lv.BackColor = System.Drawing.SystemColors.Control;
			this.pass_lv.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.pass_lv.Location = new System.Drawing.Point(167, 371);
			this.pass_lv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.pass_lv.Name = "pass_lv";
			this.pass_lv.Size = new System.Drawing.Size(275, 19);
			this.pass_lv.TabIndex = 7;
			this.pass_lv.Text = "送信するファイルをドロップして下さい";
			this.pass_lv.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// update_bt
			// 
			this.update_bt.Location = new System.Drawing.Point(19, 13);
			this.update_bt.Margin = new System.Windows.Forms.Padding(4);
			this.update_bt.Name = "update_bt";
			this.update_bt.Size = new System.Drawing.Size(53, 29);
			this.update_bt.TabIndex = 13;
			this.update_bt.Text = "更新";
			this.update_bt.UseVisualStyleBackColor = true;
			this.update_bt.Click += new System.EventHandler(this.Update_bt_Click);
			// 
			// google_drive_tree
			// 
			this.google_drive_tree.AllowDrop = true;
			this.google_drive_tree.Location = new System.Drawing.Point(19, 57);
			this.google_drive_tree.Name = "google_drive_tree";
			this.google_drive_tree.Size = new System.Drawing.Size(642, 289);
			this.google_drive_tree.TabIndex = 14;
			this.google_drive_tree.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
			this.google_drive_tree.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(682, 399);
			this.Controls.Add(this.google_drive_tree);
			this.Controls.Add(this.update_bt);
			this.Controls.Add(this.pass_lv);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.info_lb);
			this.Controls.Add(this.send_bt);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Googleドライブとの連携";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button send_bt;
		private System.Windows.Forms.Label info_lb;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label pass_lv;
		private System.Windows.Forms.Button update_bt;
		private System.Windows.Forms.TreeView google_drive_tree;
	}
}

