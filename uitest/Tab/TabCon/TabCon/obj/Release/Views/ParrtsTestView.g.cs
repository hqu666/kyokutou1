﻿#pragma checksum "..\..\..\Views\ParrtsTestView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B0848E925769E89C84BF43D3A4CB6730C7FC696B"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// ParrtsTestView
    /// </summary>
    public partial class ParrtsTestView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\Views\ParrtsTestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CalcTextFontSize;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\ParrtsTestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CalcTexWidth;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views\ParrtsTestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CalcTextDLogTitol;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\ParrtsTestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CalcResult;
        
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
            System.Uri resourceLocater = new System.Uri("/TabCon;component/views/parrtstestview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ParrtsTestView.xaml"
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
            this.CalcTextFontSize = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\Views\ParrtsTestView.xaml"
            this.CalcTextFontSize.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CalcTextFontSize_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CalcTexWidth = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\Views\ParrtsTestView.xaml"
            this.CalcTexWidth.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CalcTexWidth_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CalcTextDLogTitol = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CalcResult = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

