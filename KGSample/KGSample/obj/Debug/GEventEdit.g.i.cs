﻿#pragma checksum "..\..\GEventEdit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6F9DBD0D64E95BAD2FC696489F684ED73864CFF2"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using Infragistics;
using Infragistics.Controls;
using Infragistics.Controls.Editors;
using KGSample;
using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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


namespace KGSample {
    
    
    /// <summary>
    /// GEventEdit
    /// </summary>
    public partial class GEventEdit : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 63 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainContainer;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition top_col;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition titol_row;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition attach_row;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox htmlLink_lb;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button del_bt;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titol_tv;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save_bt;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker start_date_dp;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal KGSample.TimePic start_time_tp;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.TimePicker end_time_tp;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker end_date_dp;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label time_zone_lb;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button time_zone_attach_bt;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label rep;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox daylong_cb;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox kurikaesi_cb;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox location_tb;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel overrides_sp;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel attendees_sp;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label email_lb;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox color_cb;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox yotei_cb;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox koukai_cb;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox order_tb;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox management_number_tb;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customer_tb;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox momo_tb;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser description_wb;
        
        #line default
        #line hidden
        
        
        #line 253 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button attach_bt;
        
        #line default
        #line hidden
        
        
        #line 275 "..\..\GEventEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel attachments_sp;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KGSample;component/geventedit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GEventEdit.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\GEventEdit.xaml"
            ((KGSample.GEventEdit)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.MetroWindow_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.top_col = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 4:
            this.titol_row = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 5:
            this.attach_row = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 6:
            this.htmlLink_lb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.del_bt = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.titol_tv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.save_bt = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\GEventEdit.xaml"
            this.save_bt.Click += new System.Windows.RoutedEventHandler(this.Save_bt_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.start_date_dp = ((System.Windows.Controls.DatePicker)(target));
            
            #line 123 "..\..\GEventEdit.xaml"
            this.start_date_dp.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Start_date_dp_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.start_time_tp = ((KGSample.TimePic)(target));
            return;
            case 12:
            this.end_time_tp = ((MahApps.Metro.Controls.TimePicker)(target));
            
            #line 130 "..\..\GEventEdit.xaml"
            this.end_time_tp.SelectedTimeChanged += new System.EventHandler<MahApps.Metro.Controls.TimePickerBaseSelectionChangedEventArgs<System.Nullable<System.TimeSpan>>>(this.End_time_tp_SelectedTimeChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.end_date_dp = ((System.Windows.Controls.DatePicker)(target));
            
            #line 132 "..\..\GEventEdit.xaml"
            this.end_date_dp.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.End_date_dp_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.time_zone_lb = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.time_zone_attach_bt = ((System.Windows.Controls.Button)(target));
            return;
            case 16:
            this.rep = ((System.Windows.Controls.Label)(target));
            return;
            case 17:
            this.daylong_cb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 147 "..\..\GEventEdit.xaml"
            this.daylong_cb.Click += new System.Windows.RoutedEventHandler(this.Daylong_cb_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.kurikaesi_cb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 19:
            this.location_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 20:
            this.overrides_sp = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 21:
            this.attendees_sp = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 22:
            this.email_lb = ((System.Windows.Controls.Label)(target));
            return;
            case 23:
            this.color_cb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 214 "..\..\GEventEdit.xaml"
            this.color_cb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Color_cb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 24:
            this.yotei_cb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 25:
            this.koukai_cb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 26:
            this.order_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 27:
            this.management_number_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 28:
            this.customer_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 29:
            this.momo_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 248 "..\..\GEventEdit.xaml"
            this.momo_tb.LostFocus += new System.Windows.RoutedEventHandler(this.Momo_tb_LostFocus);
            
            #line default
            #line hidden
            return;
            case 30:
            this.description_wb = ((System.Windows.Controls.WebBrowser)(target));
            return;
            case 31:
            this.attach_bt = ((System.Windows.Controls.Button)(target));
            
            #line 254 "..\..\GEventEdit.xaml"
            this.attach_bt.Click += new System.Windows.RoutedEventHandler(this.Attach_bt_Click);
            
            #line default
            #line hidden
            return;
            case 32:
            this.attachments_sp = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

