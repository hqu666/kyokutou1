﻿#pragma checksum "..\..\GoogleAuth.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9C0B8F8E5ADE47640809F0CFA3877F5DEF337FFD"
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
    /// GoogleAuth
    /// </summary>
    public partial class GoogleAuth : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 77 "..\..\GoogleAuth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox company_id_tb;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\GoogleAuth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox user_name_tb;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\GoogleAuth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Json_read_bt;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\GoogleAuth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Log_in_bt;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\GoogleAuth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Log_out_bt;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\GoogleAuth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Google_Acount_tb;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\GoogleAuth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Google_Password_tb;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\GoogleAuth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Setting_dg;
        
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
            System.Uri resourceLocater = new System.Uri("/googleOSD;component/googleauth.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GoogleAuth.xaml"
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
            this.company_id_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.user_name_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Json_read_bt = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\GoogleAuth.xaml"
            this.Json_read_bt.Click += new System.Windows.RoutedEventHandler(this.Json_read_bt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Log_in_bt = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\GoogleAuth.xaml"
            this.Log_in_bt.Click += new System.Windows.RoutedEventHandler(this.Log_in_bt_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Log_out_bt = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\GoogleAuth.xaml"
            this.Log_out_bt.Click += new System.Windows.RoutedEventHandler(this.Log_out_bt_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Google_Acount_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Google_Password_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Setting_dg = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

