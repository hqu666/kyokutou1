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
			this.select_bt = new System.Windows.Forms.Button();
			this.send_bt = new System.Windows.Forms.Button();
			this.info_lb = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.pass_lv = new System.Windows.Forms.Label();
			this.conect_bt = new System.Windows.Forms.Button();
			this.files_tb = new System.Windows.Forms.TextBox();
			this.update_bt = new System.Windows.Forms.Button();
			this.google_drive_tree = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// select_bt
			// 
			this.select_bt.Location = new System.Drawing.Point(807, 347);
			this.select_bt.Margin = new System.Windows.Forms.Padding(4);
			this.select_bt.Name = "select_bt";
			this.select_bt.Size = new System.Drawing.Size(100, 29);
			this.select_bt.TabIndex = 0;
			this.select_bt.Text = "選択";
			this.select_bt.UseVisualStyleBackColor = true;
			this.select_bt.Click += new System.EventHandler(this.Serect_bt_Click);
			// 
			// send_bt
			// 
			this.send_bt.Location = new System.Drawing.Point(828, 13);
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
			this.info_lb.Click += new System.EventHandler(this.info_lb_Click);
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
			this.pass_lv.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pass_lv.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.pass_lv.Location = new System.Drawing.Point(24, 361);
			this.pass_lv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.pass_lv.Name = "pass_lv";
			this.pass_lv.Size = new System.Drawing.Size(448, 19);
			this.pass_lv.TabIndex = 7;
			this.pass_lv.Text = "ファイルを選択するとそのフォルダの全ファイルを読み込みます";
			this.pass_lv.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// conect_bt
			// 
			this.conect_bt.Location = new System.Drawing.Point(693, 13);
			this.conect_bt.Margin = new System.Windows.Forms.Padding(4);
			this.conect_bt.Name = "conect_bt";
			this.conect_bt.Size = new System.Drawing.Size(100, 29);
			this.conect_bt.TabIndex = 10;
			this.conect_bt.Text = "接続";
			this.conect_bt.UseVisualStyleBackColor = true;
			this.conect_bt.Click += new System.EventHandler(this.Conect_bt_Click);
			// 
			// files_tb
			// 
			this.files_tb.Location = new System.Drawing.Point(19, 384);
			this.files_tb.Margin = new System.Windows.Forms.Padding(4);
			this.files_tb.Multiline = true;
			this.files_tb.Name = "files_tb";
			this.files_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.files_tb.Size = new System.Drawing.Size(909, 163);
			this.files_tb.TabIndex = 12;
			this.files_tb.Text = "送信ファイルのリスト";
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
			// 
			// google_drive_tree
			// 
			this.google_drive_tree.Location = new System.Drawing.Point(19, 57);
			this.google_drive_tree.Name = "google_drive_tree";
			this.google_drive_tree.Size = new System.Drawing.Size(909, 289);
			this.google_drive_tree.TabIndex = 14;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(945, 562);
			this.Controls.Add(this.google_drive_tree);
			this.Controls.Add(this.update_bt);
			this.Controls.Add(this.files_tb);
			this.Controls.Add(this.conect_bt);
			this.Controls.Add(this.pass_lv);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.info_lb);
			this.Controls.Add(this.send_bt);
			this.Controls.Add(this.select_bt);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Googleドライブとの連携";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button select_bt;
		private System.Windows.Forms.Button send_bt;
		private System.Windows.Forms.Label info_lb;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label pass_lv;
		private System.Windows.Forms.Button conect_bt;
		private System.Windows.Forms.TextBox files_tb;
		private System.Windows.Forms.Button update_bt;
		private System.Windows.Forms.TreeView google_drive_tree;
	}
}

