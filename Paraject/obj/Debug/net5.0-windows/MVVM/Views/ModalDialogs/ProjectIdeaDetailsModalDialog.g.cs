﻿#pragma checksum "..\..\..\..\..\..\MVVM\Views\ModalDialogs\ProjectIdeaDetailsModalDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0134A0CFED6DF22472C3ECE87D3D1717D87D12E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Paraject.Core.Commands;
using Paraject.MVVM.ViewModels.ModalDialogs;
using Paraject.MVVM.Views.ModalDialogs;
using SharpVectors.Converters;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Paraject.MVVM.Views.ModalDialogs {
    
    
    /// <summary>
    /// ProjectIdeaDetailsModalDialog
    /// </summary>
    public partial class ProjectIdeaDetailsModalDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 92 "..\..\..\..\..\..\MVVM\Views\ModalDialogs\ProjectIdeaDetailsModalDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProjectNameTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Paraject;component/mvvm/views/modaldialogs/projectideadetailsmodaldialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\MVVM\Views\ModalDialogs\ProjectIdeaDetailsModalDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 20 "..\..\..\..\..\..\MVVM\Views\ModalDialogs\ProjectIdeaDetailsModalDialog.xaml"
            ((Paraject.MVVM.Views.ModalDialogs.ProjectIdeaDetailsModalDialog)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ProjectIdeaDetailsModalDialogMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ProjectNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

