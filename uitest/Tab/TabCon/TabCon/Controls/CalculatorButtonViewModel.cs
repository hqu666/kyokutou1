using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Livet;
using Livet.Commands;

namespace TabCon.Controls {
	public class CalculatorButtonViewModel : ViewModel {
		public CalculatorButton MyView { get; set; }
		public Object RootViewModel { get; set; }

		/// <summary>
		/// 結果の書き出し先
		/// </summary>
		public TextBox TargetTextBox { get; set; }
		//public TextBox TargetTextBox {
		//	get { return (TextBox)GetValue(TargetTextBoxtProperty); }
		//	set { SetValue(TargetTextBoxtProperty, value); }
		//}

		//public static readonly DependencyProperty TargetTextBoxtProperty =
		//	DependencyProperty.Register("TargetTextBox", typeof(TextBox), typeof(CalculatorButton), new PropertyMetadata(default(TextBox)));

		/// <summary>
		/// 電卓クラス
		/// </summary>
		public CS_CalculatorControl calculatorControl;
		/// <summary>
		/// 電卓を表示しているウィンドウ
		/// </summary>
		public Window CalcWindow;
		/// <summary>
		/// フィールドに表示される値
		/// </summary>
		public string CalcText { get; set; }
		/// <summary>
		/// フィールドのフォントサイズ
		/// </summary>
		public string FieldFontSize { get; set; }
		/// <summary>
		/// フィールドの幅
		/// </summary>
		public string FieldWidth { get; set; }
		/// <summary>
		/// ダイアログタイトル
		/// </summary>
		public string ViewTitle { get; set; }


		public CalculatorButtonViewModel()
		{
			Initialize();
		}


		public void Initialize()
		{
			calculatorControl = new CS_CalculatorControl();
			calculatorControl.rootBT = MyView;
		}

		public ViewModelCommand CalcShow {
			get { return new Livet.Commands.ViewModelCommand(ShowCalc); }
		}
		public void ShowCalc()
		{
			CalcText = TargetTextBox.Text;
			calculatorControl.InputStr += (string)CalcText;
			calculatorControl.CalcProcess.Text = calculatorControl.InputStr;
			//Windowを生成して
			CalcWindow = new Window {
				Title = TargetTextBox.Name,
				Content = calculatorControl,
				ResizeMode = ResizeMode.NoResize
			};
			//書き込み先フィールドの左やや下に表示する
			Point pt = TargetTextBox.PointToScreen(new Point(0.0d, 0.0d));
			CalcWindow.Left = pt.X + 20;
			CalcWindow.Top = pt.Y + 30;
			CalcWindow.Topmost = true;
			CalcWindow.Width = 300;
			CalcWindow.Height = 400;
			if (ViewTitle !=null) {
				if (!ViewTitle.Equals("")) {
					CalcWindow.Title = ViewTitle;
				}
			}
			Nullable<bool> dialogResult = CalcWindow.ShowDialog();
		}

		/// <summary>
		/// ダイアログを終了させたい処から呼んで、外部からダイアログを閉じる
		/// </summary>
		public void CalcWindowCloss()
		{
			if (CalcWindow.IsLoaded) {
				string resurlStr = calculatorControl.ProcessVal.ToString();
				TargetTextBox.Text = resurlStr;
				CalcWindow.Close();
			}
		}


	}
}
