#pragma checksum "..\..\..\Views\MySQLBase.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F0685576E5127904F9FD7BFE59FAD96944A0B210"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using GoogleOSD;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace TabCon {


	/// <summary>
	/// MySQLBase
	/// </summary>
	public partial class MySQLBase : System.Windows.Window, System.Windows.Markup.IComponentConnector {


#line 94 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.RowDefinition attach_row;

#line default
#line hidden


#line 98 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.TextBox server_lb;

#line default
#line hidden


#line 102 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.TextBox database_lb;

#line default
#line hidden


#line 104 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.TextBox port_lb;

#line default
#line hidden


#line 107 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.TextBox uid_lb;

#line default
#line hidden


#line 110 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.TextBox password_lb;

#line default
#line hidden


#line 114 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.Label connectionString_lb;

#line default
#line hidden


#line 117 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.ComboBox table_combo;

#line default
#line hidden


#line 133 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.DataGrid table_dg;

#line default
#line hidden


#line 141 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.Button cancel_bt;

#line default
#line hidden


#line 144 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.Button del_bt;

#line default
#line hidden


#line 147 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.Button save_bt;

#line default
#line hidden


#line 152 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.Button dis_conect_bt;

#line default
#line hidden


#line 155 "..\..\..\Views\MySQLBase.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.Button conect_bt;

#line default
#line hidden

		private bool _contentLoaded;

		/// <summary>
		/// InitializeComponent
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (_contentLoaded) {
				return;
			}
			_contentLoaded = true;
			System.Uri resourceLocater = new System.Uri("/TabCon;component/views/mysqlbase.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Views\MySQLBase.xaml"
			System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId) {
				case 1:
					this.attach_row = ((System.Windows.Controls.RowDefinition)(target));
					return;
				case 2:
					this.server_lb = ((System.Windows.Controls.TextBox)(target));
					return;
				case 3:
					this.database_lb = ((System.Windows.Controls.TextBox)(target));
					return;
				case 4:
					this.port_lb = ((System.Windows.Controls.TextBox)(target));
					return;
				case 5:
					this.uid_lb = ((System.Windows.Controls.TextBox)(target));
					return;
				case 6:
					this.password_lb = ((System.Windows.Controls.TextBox)(target));
					return;
				case 7:
					this.connectionString_lb = ((System.Windows.Controls.Label)(target));
					return;
				case 8:
					this.table_combo = ((System.Windows.Controls.ComboBox)(target));

#line 121 "..\..\..\Views\MySQLBase.xaml"
					this.table_combo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Table_combo_SelectionChanged);

#line default
#line hidden
					return;
				case 9:
					this.table_dg = ((System.Windows.Controls.DataGrid)(target));

#line 136 "..\..\..\Views\MySQLBase.xaml"
					this.table_dg.RowEditEnding += new System.EventHandler<System.Windows.Controls.DataGridRowEditEndingEventArgs>(this.Table_dg_RowEditEnding);

#line default
#line hidden

#line 136 "..\..\..\Views\MySQLBase.xaml"
					this.table_dg.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.Table_dg_SelectedCellsChanged);

#line default
#line hidden
					return;
				case 10:
					this.cancel_bt = ((System.Windows.Controls.Button)(target));
					return;
				case 11:
					this.del_bt = ((System.Windows.Controls.Button)(target));
					return;
				case 12:
					this.save_bt = ((System.Windows.Controls.Button)(target));

#line 147 "..\..\..\Views\MySQLBase.xaml"
					this.save_bt.Click += new System.Windows.RoutedEventHandler(this.Save_bt_Click);

#line default
#line hidden
					return;
				case 13:
					this.dis_conect_bt = ((System.Windows.Controls.Button)(target));

#line 152 "..\..\..\Views\MySQLBase.xaml"
					this.dis_conect_bt.Click += new System.Windows.RoutedEventHandler(this.Dis_conect_bt_Click);

#line default
#line hidden
					return;
				case 14:
					this.conect_bt = ((System.Windows.Controls.Button)(target));

#line 155 "..\..\..\Views\MySQLBase.xaml"
					this.conect_bt.Click += new System.Windows.RoutedEventHandler(this.Conect_bt_Click);

#line default
#line hidden
					return;
			}
			this._contentLoaded = true;
		}
	}
}

