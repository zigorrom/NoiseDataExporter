﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Research.DynamicDataDisplay.Charts.Shapes;
using Microsoft.Research.DynamicDataDisplay.Charts;

namespace LinearFit
{
    /// <summary>
    /// Interaction logic for IVAnalysisControl.xaml
    /// </summary>
    public partial class LineatFitControl : UserControl
    {
        private LinearFitViewModel m_viewModel;
        public LineatFitControl()
        {
            InitializeComponent();
            m_viewModel = new LinearFitViewModel();
            var lp = new Point(0, 0);
            var rp = new Point(1, 0);
            var LeftDraggablePoint = new DraggablePoint(lp);
            var RightDraggablePoint = new DraggablePoint(rp);
            LeftDraggablePoint.PositionChanged += leftDraggablePoint_PositionChanged;
            RightDraggablePoint.PositionChanged += rightDraggablePoint_PositionChanged;
            
            m_viewModel.LeftMarkerPosition = lp.X;
            m_viewModel.RightMarkerPosition = rp.X;
            
            
            IVPlotter.Children.Add(LeftDraggablePoint);
            IVPlotter.Children.Add(RightDraggablePoint);
           
            var LeftVerticalLineBinding = new Binding("LeftMarkerPosition");
            LeftVerticalLineBinding.Source = m_viewModel;
            LeftVerticalLine.SetBinding(VerticalLine.ValueProperty, LeftVerticalLineBinding);

            var RigthVerticalLineBinding = new Binding("RightMarkerPosition");
            RigthVerticalLineBinding.Source = m_viewModel;
            RightVerticalLine.SetBinding(VerticalLine.ValueProperty, RigthVerticalLineBinding);
        }

        void rightDraggablePoint_PositionChanged(object sender,PositionChangedEventArgs e)
        {
            m_viewModel.RightMarkerPosition = e.Position.X;
        }

        void leftDraggablePoint_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            m_viewModel.LeftMarkerPosition = e.Position.X;
        }

        private void DoneButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }

     //   private List
    }
}
