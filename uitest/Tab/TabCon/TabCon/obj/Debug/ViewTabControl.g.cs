﻿#pragma checksum "..\..\ViewTabControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9F59151C459FFC2A3AA0D0704EB0D2120105D9FC"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

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
using TabCon;


namespace TabCon {
    
    
    /// <summary>
    /// ViewTabControl
    /// </summary>
    public partial class ViewTabControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\ViewTabControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel SelfConpane;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ViewTabControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label InfoLavel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ViewTabControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeSerect;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ViewTabControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TabAdd;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\ViewTabControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TabDrel;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ViewTabControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox WindowSerect;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ViewTabControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddWindow;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\ViewTabControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Infragistics.Windows.Controls.XamTabControl MainTab;
        
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
            System.Uri resourceLocater = new System.Uri("/TabCon;component/viewtabcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ViewTabControl.xaml"
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
            this.SelfConpane = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.InfoLavel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.TypeSerect = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\ViewTabControl.xaml"
            this.TypeSerect.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TypeSerect_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TabAdd = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\ViewTabControl.xaml"
            this.TabAdd.Click += new System.Windows.RoutedEventHandler(this.TabAdd_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TabDrel = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\ViewTabControl.xaml"
            this.TabDrel.Click += new System.Windows.RoutedEventHandler(this.TabDrel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.WindowSerect = ((System.Windows.Controls.ComboBox)(target));
            
            #line 42 "..\..\ViewTabControl.xaml"
            this.WindowSerect.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.WindowSerect_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AddWindow = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\ViewTabControl.xaml"
            this.AddWindow.Click += new System.Windows.RoutedEventHandler(this.AddWindow_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MainTab = ((Infragistics.Windows.Controls.XamTabControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

