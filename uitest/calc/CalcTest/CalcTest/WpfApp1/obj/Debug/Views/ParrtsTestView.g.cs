﻿#pragma checksum "..\..\..\Views\ParrtsTestView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6682705BED60F11A25FE09681F66B2053B9F9FA1"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using CS_Calculator;
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


namespace WpfApp1.Views {
    
    
    /// <summary>
    /// ParrtsTestView
    /// </summary>
    public partial class ParrtsTestView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\Views\ParrtsTestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CalcTextFontSize;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\ParrtsTestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CalcTexWidth;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\ParrtsTestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CalcTextDLogTitol;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Views\ParrtsTestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Bt2Tbox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Views\ParrtsTestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CS_Calculator.CalculatorButton CalcCallBt;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/views/parrtstestview.xaml", System.UriKind.Relative);
            
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
            
            #line 37 "..\..\..\Views\ParrtsTestView.xaml"
            this.CalcTextFontSize.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CalcTextFontSize_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CalcTexWidth = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\Views\ParrtsTestView.xaml"
            this.CalcTexWidth.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CalcTexWidth_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CalcTextDLogTitol = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\Views\ParrtsTestView.xaml"
            this.CalcTextDLogTitol.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CalcTextDLogTitol_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Bt2Tbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CalcCallBt = ((CS_Calculator.CalculatorButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
