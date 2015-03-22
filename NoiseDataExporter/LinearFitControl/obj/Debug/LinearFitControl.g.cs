﻿#pragma checksum "..\..\LinearFitControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B0A61F5A5B403A96C6FE17497A28A521"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.Charts;
using Microsoft.Research.DynamicDataDisplay.Charts.Axes;
using Microsoft.Research.DynamicDataDisplay.Charts.Navigation;
using Microsoft.Research.DynamicDataDisplay.Charts.Shapes;
using Microsoft.Research.DynamicDataDisplay.Common.Palettes;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.Navigation;
using Microsoft.Research.DynamicDataDisplay.PointMarkers;
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


namespace LinearFitControl {
    
    
    /// <summary>
    /// LinearFitControl
    /// </summary>
    public partial class LinearFitControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\LinearFitControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Research.DynamicDataDisplay.ChartPlotter LinearFitPlotter;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\LinearFitControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Research.DynamicDataDisplay.LineGraph Curve;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\LinearFitControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Research.DynamicDataDisplay.LineGraph FitCurve;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\LinearFitControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Research.DynamicDataDisplay.Charts.VerticalLine LeftVerticalLine;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\LinearFitControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Research.DynamicDataDisplay.Charts.VerticalLine RightVerticalLine;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\LinearFitControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Research.DynamicDataDisplay.Charts.Shapes.DraggablePoint LeftDraggablePoint;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\LinearFitControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Research.DynamicDataDisplay.Charts.Shapes.DraggablePoint RightDraggablePoint;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\LinearFitControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DoneButton;
        
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
            System.Uri resourceLocater = new System.Uri("/LinearFitControl;component/linearfitcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LinearFitControl.xaml"
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
            this.LinearFitPlotter = ((Microsoft.Research.DynamicDataDisplay.ChartPlotter)(target));
            return;
            case 2:
            this.Curve = ((Microsoft.Research.DynamicDataDisplay.LineGraph)(target));
            return;
            case 3:
            this.FitCurve = ((Microsoft.Research.DynamicDataDisplay.LineGraph)(target));
            return;
            case 4:
            this.LeftVerticalLine = ((Microsoft.Research.DynamicDataDisplay.Charts.VerticalLine)(target));
            return;
            case 5:
            this.RightVerticalLine = ((Microsoft.Research.DynamicDataDisplay.Charts.VerticalLine)(target));
            return;
            case 6:
            this.LeftDraggablePoint = ((Microsoft.Research.DynamicDataDisplay.Charts.Shapes.DraggablePoint)(target));
            return;
            case 7:
            this.RightDraggablePoint = ((Microsoft.Research.DynamicDataDisplay.Charts.Shapes.DraggablePoint)(target));
            return;
            case 8:
            this.DoneButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\LinearFitControl.xaml"
            this.DoneButton.Click += new System.Windows.RoutedEventHandler(this.DoneButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

