﻿#pragma checksum "..\..\WebWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47441A9843BAA8285A96B1434C5EBD91531CA106"
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
using Microsoft.Toolkit.Wpf.UI.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace GoogleOSD {
    
    
    /// <summary>
    /// WebWindow
    /// </summary>
    public partial class WebWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\WebWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel control_sp;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\WebWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button go_back_bt;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\WebWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button fowerd_bt;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\WebWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refresh_bt;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\WebWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox url_tb;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\WebWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Toolkit.Wpf.UI.Controls.WebView web_wb;
        
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
            System.Uri resourceLocater = new System.Uri("/googleOSD;component/webwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WebWindow.xaml"
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
            
            #line 13 "..\..\WebWindow.xaml"
            ((GoogleOSD.WebWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.control_sp = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.go_back_bt = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\WebWindow.xaml"
            this.go_back_bt.Click += new System.Windows.RoutedEventHandler(this.Go_back_bt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.fowerd_bt = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\WebWindow.xaml"
            this.fowerd_bt.Click += new System.Windows.RoutedEventHandler(this.Fowerd_bt_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.refresh_bt = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\WebWindow.xaml"
            this.refresh_bt.Click += new System.Windows.RoutedEventHandler(this.Refresh_bt_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.url_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\WebWindow.xaml"
            this.url_tb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Url_tb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.web_wb = ((Microsoft.Toolkit.Wpf.UI.Controls.WebView)(target));
            
            #line 79 "..\..\WebWindow.xaml"
            this.web_wb.NavigationCompleted += new System.EventHandler<Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationCompletedEventArgs>(this.Web_wb_NavigationCompleted);
            
            #line default
            #line hidden
            
            #line 79 "..\..\WebWindow.xaml"
            this.web_wb.NavigationStarting += new System.EventHandler<Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationStartingEventArgs>(this.Web_wb_NavigationStarting);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

