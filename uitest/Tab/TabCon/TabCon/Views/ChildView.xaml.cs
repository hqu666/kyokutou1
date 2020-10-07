﻿using System.Windows;
using TabCon.ViewModels;

namespace TabCon.Views {
	/// <summary>
	/// ChildView.xaml の相互作用ロジック
	/// </summary>
	public partial class ChildView : Window {

		public ChildView()
		{
			InitializeComponent();
			this.DataContext = new ViewModels.ChildViewModel();

		}

		public ViewTabControl MW { get; internal set; }
	}
}