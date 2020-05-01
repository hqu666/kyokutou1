using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyokuto4calender {
	public partial class Form1 : Form {
		Edit editForm;
		private string receiveData = "";

		public Form1()
		{
			InitializeComponent();
			editForm = new Edit();
			editForm.mainForm = this;
		}

		private void edit_bt_Click(object sender, EventArgs e)
		{
			editForm.Show();
		}
		public string ReceiveData {
			set {
				receiveData = value;
				receiveData_lv.Text = receiveData;
			}
			get {
				return receiveData;
			}
		}

	}
}
