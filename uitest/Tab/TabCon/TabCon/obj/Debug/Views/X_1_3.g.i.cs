﻿#pragma checksum "..\..\..\Views\X_1_3.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1DA01A73DE098801A50C8C65D1814A561064D939"
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
using Infragistics.Controls.Layouts;
using Infragistics.Controls.Menus;
using Infragistics.Controls.Schedules;
using Infragistics.DragDrop;
using Infragistics.Shared;
using Infragistics.Windows;
using Infragistics.Windows.Controls;
using Infragistics.Windows.Controls.Markup;
using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.DataPresenter.Calculations;
using Infragistics.Windows.Editors;
using Infragistics.Windows.Reporting;
using Infragistics.Windows.Themes;
using Infragistics.Windows.Tiles;
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
using TabCon.Controls;
using TabCon.Views;


namespace TabCon.Views {
    
    
    /// <summary>
    /// X_1_3
    /// </summary>
    public partial class X_1_3 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Views\X_1_3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TabCon.Controls.X_1_Control ControlPanel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Views\X_1_3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Infragistics.Controls.Schedules.XamMonthView MyCalendar;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\X_1_3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Infragistics.Controls.Schedules.XamScheduleDataManager dataManager;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\X_1_3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Infragistics.Controls.Schedules.ListScheduleDataConnector dataConnector;
        
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
            System.Uri resourceLocater = new System.Uri("/TabCon;component/views/x_1_3.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\X_1_3.xaml"
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
            this.ControlPanel = ((TabCon.Controls.X_1_Control)(target));
            return;
            case 2:
            this.MyCalendar = ((Infragistics.Controls.Schedules.XamMonthView)(target));
            return;
            case 3:
            this.dataManager = ((Infragistics.Controls.Schedules.XamScheduleDataManager)(target));
            return;
            case 4:
            this.dataConnector = ((Infragistics.Controls.Schedules.ListScheduleDataConnector)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

