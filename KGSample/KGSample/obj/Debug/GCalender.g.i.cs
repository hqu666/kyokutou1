﻿#pragma checksum "..\..\GCalender.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BFFA0E1504CB41D89C1D5B434D15A2C10405F3BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using KGSample;
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


namespace KGSample {
    
    
    /// <summary>
    /// GCalender
    /// </summary>
    public partial class GCalender : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainContainer;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back_bt;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbYearMonth;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Next_bt;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button today_bt;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid CalendarContainer;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GDrive_bt;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbDate;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbSelectedDate;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Weekly_bt;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\GCalender.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Dayly_bt;
        
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
            System.Uri resourceLocater = new System.Uri("/KGSample;component/gcalender.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GCalender.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\GCalender.xaml"
            ((KGSample.GCalender)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.MetroWindow_SizeChanged);
            
            #line default
            #line hidden
            
            #line 11 "..\..\GCalender.xaml"
            ((KGSample.GCalender)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Back_bt = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\GCalender.xaml"
            this.Back_bt.Click += new System.Windows.RoutedEventHandler(this.Back_bt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbYearMonth = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\GCalender.xaml"
            this.cbYearMonth.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbYearMonth_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Next_bt = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\GCalender.xaml"
            this.Next_bt.Click += new System.Windows.RoutedEventHandler(this.Next_bt_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.today_bt = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\GCalender.xaml"
            this.today_bt.Click += new System.Windows.RoutedEventHandler(this.Today_bt_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CalendarContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.GDrive_bt = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\GCalender.xaml"
            this.GDrive_bt.Click += new System.Windows.RoutedEventHandler(this.GDrive_bt_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lbDate = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lbSelectedDate = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.Weekly_bt = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\GCalender.xaml"
            this.Weekly_bt.Click += new System.Windows.RoutedEventHandler(this.Weekly_bt_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Dayly_bt = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\GCalender.xaml"
            this.Dayly_bt.Click += new System.Windows.RoutedEventHandler(this.Dayly_bt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

