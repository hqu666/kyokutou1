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
	public partial class Edit : Form {
		public Form1 mainForm;
		private string sendData = "";

		public Edit()
		{
			InitializeComponent();
		}

		private void back_bt_Click(object sender, EventArgs e)
		{
			if (mainForm != null) {
				mainForm.ReceiveData = "Duck";
			}

		}

		public string SendData {
			set {
				sendData = value;
				sendData_tb.Text = sendData;
			}
			get {
				return sendData;
			}
		}


	}
}
