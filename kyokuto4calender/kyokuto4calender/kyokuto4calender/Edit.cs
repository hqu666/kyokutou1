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
		private string titolStr = "";


		public Edit()
		{
			InitializeComponent();
		}

		private void back_bt_Click(object sender, EventArgs e)
		{
			if (mainForm != null) {
				mainForm.ReceiveData = titolStr;
				this.Close();
			}

		}

		public string TitolStr {
			set {
				titolStr = value;
				titol_tb.Text = titolStr;
			}
			get {
				return titolStr;
			}
		}


	}
}
